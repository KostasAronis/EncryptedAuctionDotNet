using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionStore.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context)
        {
            //try
            //{
            //    await _next(context);
            //}
            //finally
            //{
            //    _logger.LogInformation(
            //        "Request {method} {url} => {statusCode}",
            //        context.Request?.Method,
            //        context.Request?.Path.Value,
            //        context.Response?.StatusCode);
            //}
            await LogRequest(context);
            await LogResponse(context);
            
        }
        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            //_logger.LogInformation($"Http Request Information:{Environment.NewLine}" +
            //                       $"Schema:{context.Request.Scheme} " +
            //                       $"Host: {context.Request.Host} " +
            //                       $"Path: {context.Request.Path} " +
            //                       $"QueryString: {context.Request.QueryString} " +
            //                       $"Request Body: {ReadStreamInChunks(requestStream)}");
            var reqBody = ReadStreamInChunks(requestStream);
            _logger.LogInformation(
                $"Http Request Information:{Environment.NewLine}" +
                $"{context.Request.Method}: {context.Request.Scheme}://" +
                $"{context.Request.Host}" +
                $"{context.Request.Path}" +
                $"{context.Request.QueryString}" +
                (String.IsNullOrEmpty(reqBody) ? "" : $"{Environment.NewLine}Request Body: {reqBody}")
            );
            context.Request.Body.Position = 0;
        }
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            //_logger.LogInformation($"Http Response Information:{Environment.NewLine}" +
            //                       $"Schema:{context.Request.Scheme} " +
            //                       $"Host: {context.Request.Host} " +
            //                       $"Path: {context.Request.Path} " +
            //                       $"QueryString: {context.Request.QueryString} " +
            //                       $"Response Body: {text}");
            _logger.LogInformation(
                $"Http Response Information:{Environment.NewLine}" +
                $"{context.Request.Method} [{context.Response.StatusCode}]: {context.Request.Scheme}://" +
                $"{context.Request.Host}" +
                $"{context.Request.Path}" +
                $"{context.Request.QueryString}" +
                (String.IsNullOrEmpty(text) ? "" : $"{Environment.NewLine}Request Body: {text}")
            );
            if (!String.IsNullOrEmpty(text))
            {
                try
                {
                    var parsedJson = JsonConvert.DeserializeObject(text);
                    var jsonStr = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                    _logger.LogDebug(String.IsNullOrEmpty(jsonStr) ? "" : $"{Environment.NewLine}Request Body: {jsonStr}");
                }
                catch
                {
                    _logger.LogDebug(String.IsNullOrEmpty(text) ? "" : $"{Environment.NewLine}Request Body: {text}");
                }
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
