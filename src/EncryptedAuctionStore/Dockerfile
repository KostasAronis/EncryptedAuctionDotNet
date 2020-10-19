#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/EncryptedAuctionStore/EncryptedAuctionStore.csproj", "src/EncryptedAuctionStore/"]
COPY ["src/EncryptedAuctionDatatypes/EncryptedAuctionDatatypes.csproj", "src/EncryptedAuctionDatatypes/"]
RUN dotnet restore "src/EncryptedAuctionStore/EncryptedAuctionStore.csproj"
COPY . .
WORKDIR "/src/src/EncryptedAuctionStore"
RUN dotnet build "EncryptedAuctionStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EncryptedAuctionStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EncryptedAuctionStore.dll"]