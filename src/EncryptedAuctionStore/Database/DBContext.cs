using EncryptedAuctionStore.Database.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionStore.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions)
            : base(dbContextOptions)
        { }
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(new List<Product>()
        //    {
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "S2719DGF",
        //        Price = 327.89,
        //        Description = "Dell S2719DGF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C24F390FHU",
        //        Price = 109.54,
        //        Description = "Samsung C24F390FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24G2U",
        //        Price = 183.89,
        //        Description = "AOC 24G2U",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "CJG50",
        //        Price = 276.48,
        //        Description = "Samsung CJG50",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "C24G1",
        //        Price = 179.98,
        //        Description = "AOC C24G1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24GL600F-B",
        //        Price = 176.75,
        //        Description = "LG 24GL600F-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2719HR",
        //        Price = 153.9,
        //        Description = "Dell SE2719HR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2219H",
        //        Price = 133.79,
        //        Description = "Dell P2219H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2590VXQ",
        //        Price = 135.5,
        //        Description = "AOC G2590VXQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27UL500-W",
        //        Price = 276.4,
        //        Description = "LG 27UL500-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24TL510S-PZ",
        //        Price = 128.0,
        //        Description = "LG 24TL510S-PZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27RG50",
        //        Price = 287.75,
        //        Description = "Samsung C27RG50",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "C27G1",
        //        Price = 234.99,
        //        Description = "AOC C27G1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "29WL500-B",
        //        Price = 187.65,
        //        Description = "LG 29WL500-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24MK600M-B",
        //        Price = 119.6,
        //        Description = "LG 24MK600M-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "TUF Gaming VG27VQ",
        //        Price = 273.0,
        //        Description = "Asus TUF Gaming VG27VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2790PX",
        //        Price = 263.7,
        //        Description = "AOC G2790PX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "CQ32G1",
        //        Price = 318.99,
        //        Description = "AOC CQ32G1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "C32G1",
        //        Price = 243.98,
        //        Description = "AOC C32G1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "32UK550-B",
        //        Price = 357.85,
        //        Description = "LG 32UK550-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "CQ27G2U",
        //        Price = 287.9,
        //        Description = "AOC CQ27G2U",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24MK400H-B",
        //        Price = 93.5,
        //        Description = "LG 24MK400H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "S3220DGF",
        //        Price = 369.9,
        //        Description = "Dell S3220DGF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "UJ590",
        //        Price = 305.38,
        //        Description = "Samsung UJ590",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX2458-C-mhd",
        //        Price = 170.54,
        //        Description = "Viewsonic VX2458-C-mhd",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27F390FHU",
        //        Price = 141.99,
        //        Description = "Samsung C27F390FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "Q3279VWFD8",
        //        Price = 202.9,
        //        Description = "AOC Q3279VWFD8",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "27V2Q",
        //        Price = 155.99,
        //        Description = "AOC 27V2Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VP249QGR",
        //        Price = 205.0,
        //        Description = "Asus VP249QGR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24V2Q",
        //        Price = 121.61,
        //        Description = "AOC 24V2Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2719DC Black",
        //        Price = 411.79,
        //        Description = "Dell UltraSharp U2719DC Black",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "LS24D330HSX",
        //        Price = 109.04,
        //        Description = "Samsung LS24D330HSX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C24RG50",
        //        Price = 177.3,
        //        Description = "Samsung C24RG50",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24TL510V-PZ",
        //        Price = 97.54,
        //        Description = "LG 24TL510V-PZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2419HR",
        //        Price = 127.9,
        //        Description = "Dell SE2419HR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "22MK600M-B",
        //        Price = 102.7,
        //        Description = "LG 22MK600M-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "28TL510S-PZ",
        //        Price = 148.9,
        //        Description = "LG 28TL510S-PZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2719D",
        //        Price = 353.81,
        //        Description = "Dell UltraSharp U2719D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "EliteDisplay E273q Gray",
        //        Price = 308.25,
        //        Description = "HP EliteDisplay E273q Gray",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "246E9QJAB",
        //        Price = 119.33,
        //        Description = "Philips 246E9QJAB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2319H",
        //        Price = 139.89,
        //        Description = "Dell P2319H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "20MK400H-B",
        //        Price = 68.3,
        //        Description = "LG 20MK400H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27F396FHU",
        //        Price = 154.2,
        //        Description = "Samsung C27F396FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2418HT",
        //        Price = 270.21,
        //        Description = "Dell P2418HT",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2719H",
        //        Price = 207.85,
        //        Description = "Dell P2719H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27MK600M-B",
        //        Price = 143.99,
        //        Description = "LG 27MK600M-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "TUF Gaming VG27WQ",
        //        Price = 388.95,
        //        Description = "Asus TUF Gaming VG27WQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "248E9QHSB",
        //        Price = 119.69,
        //        Description = "Philips 248E9QHSB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27UL650-W",
        //        Price = 368.0,
        //        Description = "LG 27UL650-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S27F350FHU",
        //        Price = 140.8,
        //        Description = "Samsung S27F350FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "28TL510V-PZ",
        //        Price = 120.59,
        //        Description = "LG 28TL510V-PZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24G2U5",
        //        Price = 153.47,
        //        Description = "AOC 24G2U5",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "AG241QX",
        //        Price = 296.59,
        //        Description = "AOC AG241QX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix G27CQ4",
        //        Price = 340.1,
        //        Description = "MSI Optix G27CQ4",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2460VQ6",
        //        Price = 126.83,
        //        Description = "AOC G2460VQ6",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24MP59G-P",
        //        Price = 118.1,
        //        Description = "LG 24MP59G-P",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2590PX",
        //        Price = 230.45,
        //        Description = "AOC G2590PX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "29UM69G-B",
        //        Price = 243.99,
        //        Description = "LG 29UM69G-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2590FX",
        //        Price = 207.55,
        //        Description = "AOC G2590FX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S27H850QFU",
        //        Price = 288.89,
        //        Description = "Samsung S27H850QFU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2219H",
        //        Price = 106.84,
        //        Description = "Dell SE2219H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "LS24R350FHUXEN",
        //        Price = 117.7,
        //        Description = "Samsung LS24R350FHUXEN",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix MAG271CQR",
        //        Price = 599.0,
        //        Description = "MSI Optix MAG271CQR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2419H",
        //        Price = 148.35,
        //        Description = "Dell P2419H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27GL850-B",
        //        Price = 488.99,
        //        Description = "LG 27GL850-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix MAG241C",
        //        Price = 259.0,
        //        Description = "MSI Optix MAG241C",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C24F396FHU",
        //        Price = 124.63,
        //        Description = "Samsung C24F396FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S27E330HZX",
        //        Price = 137.0,
        //        Description = "Samsung S27E330HZX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2412M Black",
        //        Price = 143.14,
        //        Description = "Dell UltraSharp U2412M Black",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "U2419H",
        //        Price = 173.27,
        //        Description = "Dell U2419H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "LC32JG50QQU",
        //        Price = 303.0,
        //        Description = "Samsung LC32JG50QQU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Zowie",
        //        Model = "XL2411P",
        //        Price = 209.81,
        //        Description = "Zowie XL2411P",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27MK400H-B",
        //        Price = 128.8,
        //        Description = "LG 27MK400H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "Rog Strix XG32VQ",
        //        Price = 497.24,
        //        Description = "Asus Rog Strix XG32VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Ultrasharp U2520D",
        //        Price = 343.25,
        //        Description = "Dell Ultrasharp U2520D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX2758-PC-MH",
        //        Price = 219.0,
        //        Description = "Viewsonic VX2758-PC-MH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "32MP58HQ",
        //        Price = 169.58,
        //        Description = "LG 32MP58HQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW2518HF",
        //        Price = 449.5,
        //        Description = "Dell Alienware AW2518HF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "223V7QHAB",
        //        Price = 94.89,
        //        Description = "Philips 223V7QHAB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "U32R590",
        //        Price = 368.05,
        //        Description = "Samsung U32R590",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "TUF Gaming VG32VQ",
        //        Price = 484.0,
        //        Description = "Asus TUF Gaming VG32VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "27G2U/BK",
        //        Price = 220.0,
        //        Description = "AOC 27G2U/BK",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27MK430H-B",
        //        Price = 130.1,
        //        Description = "LG 27MK430H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2778VQ",
        //        Price = 148.5,
        //        Description = "AOC G2778VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "Elite XG2405",
        //        Price = 229.9,
        //        Description = "Viewsonic Elite XG2405",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "34GL750-B",
        //        Price = 438.95,
        //        Description = "LG 34GL750-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S22F350FHU",
        //        Price = 88.04,
        //        Description = "Samsung S22F350FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "U2879VF",
        //        Price = 241.55,
        //        Description = "AOC U2879VF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2415",
        //        Price = 209.85,
        //        Description = "Dell UltraSharp U2415",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix G27C4",
        //        Price = 242.4,
        //        Description = "MSI Optix G27C4",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S24F356FHU",
        //        Price = 118.75,
        //        Description = "Samsung S24F356FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "22MK400H-B",
        //        Price = 82.18,
        //        Description = "LG 22MK400H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U3419W",
        //        Price = 772.51,
        //        Description = "Dell UltraSharp U3419W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "29WK600-W",
        //        Price = 249.0,
        //        Description = "LG 29WK600-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2518D",
        //        Price = 298.0,
        //        Description = "Dell UltraSharp U2518D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "G2260VWQ6",
        //        Price = 88.25,
        //        Description = "AOC G2260VWQ6",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C32HG70",
        //        Price = 437.89,
        //        Description = "Samsung C32HG70",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S27R750Q",
        //        Price = 278.99,
        //        Description = "Samsung S27R750Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG278QR",
        //        Price = 312.0,
        //        Description = "Asus VG278QR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2418D",
        //        Price = 251.51,
        //        Description = "Dell P2418D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "22MK430H-B",
        //        Price = 92.07,
        //        Description = "LG 22MK430H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG248QG",
        //        Price = 237.0,
        //        Description = "Asus VG248QG",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VZ249HE Black",
        //        Price = 119.0,
        //        Description = "Asus VZ249HE Black",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C43J890",
        //        Price = 778.97,
        //        Description = "Samsung C43J890",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2416H",
        //        Price = 114.0,
        //        Description = "Dell SE2416H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Zowie",
        //        Model = "XL2546",
        //        Price = 497.95,
        //        Description = "Zowie XL2546",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2717H",
        //        Price = 162.0,
        //        Description = "Dell SE2717H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW3420DW",
        //        Price = 1092.0,
        //        Description = "Dell Alienware AW3420DW",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "MG248QR",
        //        Price = 245.0,
        //        Description = "Asus MG248QR",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW2518H",
        //        Price = 407.06,
        //        Description = "Dell Alienware AW2518H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX2758-2KP-mhd",
        //        Price = 370.0,
        //        Description = "Viewsonic VX2758-2KP-mhd",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "29WK500-P",
        //        Price = 272.0,
        //        Description = "LG 29WK500-P",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "E2420H",
        //        Price = 105.65,
        //        Description = "Dell E2420H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "Designo Curve MX34VQ",
        //        Price = 688.9,
        //        Description = "Asus Designo Curve MX34VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "UR55",
        //        Price = 321.65,
        //        Description = "Samsung UR55",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "24f",
        //        Price = 129.15,
        //        Description = "HP 24f",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2421D",
        //        Price = 240.5,
        //        Description = "Dell P2421D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P4317Q",
        //        Price = 652.63,
        //        Description = "Dell P4317Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24GL650-B",
        //        Price = 187.43,
        //        Description = "LG 24GL650-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S22R350FHU",
        //        Price = 99.0,
        //        Description = "Samsung S22R350FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "34WK650-W",
        //        Price = 316.5,
        //        Description = "LG 34WK650-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24MK430H-B",
        //        Price = 107.8,
        //        Description = "LG 24MK430H-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "25x",
        //        Price = 239.0,
        //        Description = "HP 25x",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "P24h G4",
        //        Price = 118.0,
        //        Description = "HP P24h G4",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Ultrasharp U2720Q",
        //        Price = 577.9,
        //        Description = "Dell Ultrasharp U2720Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Acer",
        //        Model = "Nitro VG270UP",
        //        Price = 444.68,
        //        Description = "Acer Nitro VG270UP",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "25UM58-P",
        //        Price = 148.98,
        //        Description = "LG 25UM58-P",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "32ML600M-B",
        //        Price = 187.48,
        //        Description = "LG 32ML600M-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW3418DW",
        //        Price = 749.0,
        //        Description = "Dell Alienware AW3418DW",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Zowie",
        //        Model = "Rl2455",
        //        Price = 205.0,
        //        Description = "Zowie Rl2455",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "Q27G2U",
        //        Price = 280.9,
        //        Description = "AOC Q27G2U",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "XG2402",
        //        Price = 278.0,
        //        Description = "Viewsonic XG2402",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "243V7QDAB",
        //        Price = 106.19,
        //        Description = "Philips 243V7QDAB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "e970Swn",
        //        Price = 61.4,
        //        Description = "AOC e970Swn",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "U32H850",
        //        Price = 377.85,
        //        Description = "Samsung U32H850",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Gigabyte",
        //        Model = "Aorus FI27Q",
        //        Price = 601.54,
        //        Description = "Gigabyte Aorus FI27Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "C27G2ZU/BK",
        //        Price = 294.9,
        //        Description = "AOC C27G2ZU/BK",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "Rog Swift PG348Q",
        //        Price = 741.77,
        //        Description = "Asus Rog Swift PG348Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "27CHG70",
        //        Price = 421.94,
        //        Description = "Samsung 27CHG70",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2419HC",
        //        Price = 189.0,
        //        Description = "Dell P2419HC",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "276E9QDSB",
        //        Price = 148.49,
        //        Description = "Philips 276E9QDSB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "34UC79G-B",
        //        Price = 519.0,
        //        Description = "LG 34UC79G-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "29UC88",
        //        Price = 399.0,
        //        Description = "LG 29UC88",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C34H890",
        //        Price = 567.81,
        //        Description = "Samsung C34H890",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24TL510V-WZ",
        //        Price = 106.1,
        //        Description = "LG 24TL510V-WZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Gigabyte",
        //        Model = "Aorus CV27Q",
        //        Price = 503.14,
        //        Description = "Gigabyte Aorus CV27Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27F591FDU",
        //        Price = 210.0,
        //        Description = "Samsung C27F591FDU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27FG73",
        //        Price = 305.0,
        //        Description = "Samsung C27FG73",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S27R350FHU",
        //        Price = 136.27,
        //        Description = "Samsung S27R350FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2720D",
        //        Price = 293.65,
        //        Description = "Dell P2720D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "27fw",
        //        Price = 183.25,
        //        Description = "HP 27fw",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2720DC",
        //        Price = 308.7,
        //        Description = "Dell P2720DC",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "I2481FXH",
        //        Price = 132.94,
        //        Description = "AOC I2481FXH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27MP59G-P",
        //        Price = 157.95,
        //        Description = "LG 27MP59G-P",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "Rog Strix XG27VQ",
        //        Price = 378.69,
        //        Description = "Asus Rog Strix XG27VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "LS24E65UPL",
        //        Price = 133.28,
        //        Description = "Samsung LS24E65UPL",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VA2419-SH",
        //        Price = 108.9,
        //        Description = "Viewsonic VA2419-SH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "CU34G2X",
        //        Price = 529.22,
        //        Description = "AOC CU34G2X",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix MAG241CV",
        //        Price = 235.0,
        //        Description = "MSI Optix MAG241CV",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "24w",
        //        Price = 100.11,
        //        Description = "HP 24w",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "E2470SWH",
        //        Price = 102.66,
        //        Description = "AOC E2470SWH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Eizo",
        //        Model = "EV2450 Black",
        //        Price = 278.9,
        //        Description = "Eizo EV2450 Black",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "243V7QDSB",
        //        Price = 104.5,
        //        Description = "Philips 243V7QDSB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "AG241QG",
        //        Price = 435.49,
        //        Description = "AOC AG241QG",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "EliteDisplay E243",
        //        Price = 148.99,
        //        Description = "HP EliteDisplay E243",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S24F350FHU",
        //        Price = 106.29,
        //        Description = "Samsung S24F350FHU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2417H",
        //        Price = 243.98,
        //        Description = "Dell P2417H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "ROG Swift PG27VQ",
        //        Price = 799.0,
        //        Description = "Asus ROG Swift PG27VQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "S2719H",
        //        Price = 206.95,
        //        Description = "Dell S2719H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27UL600-W",
        //        Price = 336.39,
        //        Description = "LG 27UL600-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2421DC",
        //        Price = 279.65,
        //        Description = "Dell P2421DC",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "27G2U5",
        //        Price = 179.98,
        //        Description = "AOC 27G2U5",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "34UM69G-B",
        //        Price = 318.98,
        //        Description = "LG 34UM69G-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp UP3216Q",
        //        Price = 1084.68,
        //        Description = "Dell UltraSharp UP3216Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "Q3279VWF",
        //        Price = 177.29,
        //        Description = "AOC Q3279VWF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "P2719HC",
        //        Price = 231.16,
        //        Description = "Dell P2719HC",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "28TL510V-WZ",
        //        Price = 109.0,
        //        Description = "LG 28TL510V-WZ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27UD58",
        //        Price = 470.0,
        //        Description = "LG 27UD58",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VA2719-SH",
        //        Price = 148.79,
        //        Description = "Viewsonic VA2719-SH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U3219Q",
        //        Price = 795.0,
        //        Description = "Dell UltraSharp U3219Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW2521HF",
        //        Price = 391.0,
        //        Description = "Dell Alienware AW2521HF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Acer",
        //        Model = "Nitro VG240Y",
        //        Price = 143.4,
        //        Description = "Acer Nitro VG240Y",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG245HE",
        //        Price = 168.99,
        //        Description = "Asus VG245HE",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "BenQ",
        //        Model = "GW2280",
        //        Price = 92.35,
        //        Description = "BenQ GW2280",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C24FG70",
        //        Price = 399.0,
        //        Description = "Samsung C24FG70",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Acer",
        //        Model = "Nitro VG270",
        //        Price = 174.61,
        //        Description = "Acer Nitro VG270",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "LS34J550WQU",
        //        Price = 399.67,
        //        Description = "Samsung LS34J550WQU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "E2418HN",
        //        Price = 129.9,
        //        Description = "Dell E2418HN",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "EliteDisplay E273",
        //        Price = 169.0,
        //        Description = "HP EliteDisplay E273",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Turbo-X",
        //        Model = "Nemesis NC27QGH",
        //        Price = 319.0,
        //        Description = "Turbo-X Nemesis NC27QGH",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "CR50",
        //        Price = 158.75,
        //        Description = "Samsung CR50",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "E Line 276E9QJAB",
        //        Price = 153.99,
        //        Description = "Philips E Line 276E9QJAB",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "AGON AG272FCX6",
        //        Price = 301.06,
        //        Description = "AOC AGON AG272FCX6",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "Alienware AW2720HF",
        //        Price = 393.9,
        //        Description = "Dell Alienware AW2720HF",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "SE2417HG",
        //        Price = 134.9,
        //        Description = "Dell SE2417HG",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24E1Q",
        //        Price = 109.09,
        //        Description = "AOC 24E1Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "24MT49S",
        //        Price = 179.0,
        //        Description = "LG 24MT49S",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG278Q",
        //        Price = 288.28,
        //        Description = "Asus VG278Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix MAG271CV",
        //        Price = 302.61,
        //        Description = "MSI Optix MAG271CV",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "276C8",
        //        Price = 304.7,
        //        Description = "Philips 276C8",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix G241VC",
        //        Price = 163.99,
        //        Description = "MSI Optix G241VC",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "TUF Gaming VG27AQ",
        //        Price = 499.0,
        //        Description = "Asus TUF Gaming VG27AQ",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "BenQ",
        //        Model = "GC2870H",
        //        Price = 185.9,
        //        Description = "BenQ GC2870H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG245Q",
        //        Price = 182.0,
        //        Description = "Asus VG245Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "HP",
        //        Model = "Omen X 27",
        //        Price = 860.0,
        //        Description = "HP Omen X 27",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "27GL63T-B",
        //        Price = 252.8,
        //        Description = "LG 27GL63T-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C49RG90SSU",
        //        Price = 1140.75,
        //        Description = "Samsung C49RG90SSU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "S24H850",
        //        Price = 253.75,
        //        Description = "Samsung S24H850",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "Rog Swift PG258Q",
        //        Price = 558.0,
        //        Description = "Asus Rog Swift PG258Q",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Philips",
        //        Model = "322E1C/00",
        //        Price = 193.54,
        //        Description = "Philips 322E1C/00",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "S2419H",
        //        Price = 160.95,
        //        Description = "Dell S2419H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24P1",
        //        Price = 151.8,
        //        Description = "AOC 24P1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Acer",
        //        Model = "B277",
        //        Price = 228.9,
        //        Description = "Acer B277",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VP28UQG",
        //        Price = 276.02,
        //        Description = "Asus VP28UQG",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "U28H750UQU",
        //        Price = 308.9,
        //        Description = "Samsung U28H750UQU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C24FG73",
        //        Price = 290.0,
        //        Description = "Samsung C24FG73",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "BenQ",
        //        Model = "EX3203R",
        //        Price = 479.4,
        //        Description = "BenQ EX3203R",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U3415W",
        //        Price = 670.35,
        //        Description = "Dell UltraSharp U3415W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "U2717D",
        //        Price = 398.3,
        //        Description = "Dell U2717D",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "38WK95C-W",
        //        Price = 968.28,
        //        Description = "LG 38WK95C-W",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Dell",
        //        Model = "UltraSharp U2417H",
        //        Price = 346.34,
        //        Description = "Dell UltraSharp U2417H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX4380-4K",
        //        Price = 601.0,
        //        Description = "Viewsonic VX4380-4K",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C27H711",
        //        Price = 328.94,
        //        Description = "Samsung C27H711",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Acer",
        //        Model = "BE270UA",
        //        Price = 369.71,
        //        Description = "Acer BE270UA",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "C32F391FWU",
        //        Price = 203.5,
        //        Description = "Samsung C32F391FWU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX3258-2KPC-MHD",
        //        Price = 337.19,
        //        Description = "Viewsonic VX3258-2KPC-MHD",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Iiyama",
        //        Model = "G-Master G2530HSU-B1",
        //        Price = 136.96,
        //        Description = "Iiyama G-Master G2530HSU-B1",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Prestige PS341WU",
        //        Price = 1976.9,
        //        Description = "MSI Prestige PS341WU",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "MSI",
        //        Model = "Optix G24C4",
        //        Price = 222.6,
        //        Description = "MSI Optix G24C4",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Zowie",
        //        Model = "XL2740",
        //        Price = 577.95,
        //        Description = "Zowie XL2740",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "XG2705",
        //        Price = 289.77,
        //        Description = "Viewsonic XG2705",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "LG",
        //        Model = "32GK850G-B",
        //        Price = 740.9,
        //        Description = "LG 32GK850G-B",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "CHG90",
        //        Price = 769.45,
        //        Description = "Samsung CHG90",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Viewsonic",
        //        Model = "VX3276-2K-MHD",
        //        Price = 259.9,
        //        Description = "Viewsonic VX3276-2K-MHD",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VG248QE",
        //        Price = 199.9,
        //        Description = "Asus VG248QE",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Lenovo",
        //        Model = "ThinkVision S22e-19",
        //        Price = 96.8,
        //        Description = "Lenovo ThinkVision S22e-19",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "24B1H",
        //        Price = 95.45,
        //        Description = "AOC 24B1H",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "AOC",
        //        Model = "AG352QCX",
        //        Price = 513.45,
        //        Description = "AOC AG352QCX",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Asus",
        //        Model = "VA249HE",
        //        Price = 94.0,
        //        Description = "Asus VA249HE",
        //        Category = "Monitor"
        //        },
        //        new Product()
        //        {
        //        Id = Guid.NewGuid(),
        //        Brand = "Samsung",
        //        Model = "U28E590D",
        //        Price = 228.97,
        //        Description = "Samsung U28E590D",
        //        Category = "Monitor"
        //        }
        //        });
        //}
    }
}
