﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlayerBaseApi;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    [DbContext(typeof(PlayerBaseContext))]
    [Migration("20220912091124_buildurl-added")]
    partial class buildurladded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PlayerBaseApi.Entities.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BuildingType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-5.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Base"
                        },
                        new
                        {
                            Id = 2,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Gang Tower"
                        },
                        new
                        {
                            Id = 3,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Wall"
                        },
                        new
                        {
                            Id = 4,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Hospital"
                        },
                        new
                        {
                            Id = 5,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Prison"
                        },
                        new
                        {
                            Id = 6,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Market"
                        },
                        new
                        {
                            Id = 7,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Altar"
                        },
                        new
                        {
                            Id = 8,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Watch Tower"
                        },
                        new
                        {
                            Id = 9,
                            BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                            IsActive = true,
                            MaxLevel = 1000,
                            Name = "Research Laboratory"
                        });
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerBasePlacement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BuildingLevel")
                        .HasColumnType("integer");

                    b.Property<int>("BuildingTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("CoordX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordY")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdateEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.ToTable("PlayerBasePlacement");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BuildingLevel = 1,
                            BuildingTypeId = 1,
                            CoordX = 1,
                            CoordY = 1,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("SharedLibrary.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<string>("AppVersion")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceModel")
                        .HasColumnType("text");

                    b.Property<string>("DeviceType")
                        .HasColumnType("text");

                    b.Property<double?>("Duration")
                        .HasColumnType("double precision");

                    b.Property<string>("EventId")
                        .HasColumnType("text");

                    b.Property<string>("EventName")
                        .HasColumnType("text");

                    b.Property<string>("Exception")
                        .HasColumnType("text");

                    b.Property<string>("InnerException")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OsVersion")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("SharedLibrary.Entities.LogAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<string>("AppVersion")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceModel")
                        .HasColumnType("text");

                    b.Property<string>("DeviceType")
                        .HasColumnType("text");

                    b.Property<double?>("Duration")
                        .HasColumnType("double precision");

                    b.Property<string>("EventId")
                        .HasColumnType("text");

                    b.Property<string>("EventName")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OsVersion")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("LogAction");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerBasePlacement", b =>
                {
                    b.HasOne("PlayerBaseApi.Entities.BuildingType", "BuildingType")
                        .WithMany()
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingType");
                });
#pragma warning restore 612, 618
        }
    }
}
