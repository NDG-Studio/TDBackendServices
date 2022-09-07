﻿// <auto-generated />
using System;
using MapApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MapApi.Migrations
{
    [DbContext(typeof(MapContext))]
    [Migration("20220907141245_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MapApi.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("XMax")
                        .HasColumnType("integer");

                    b.Property<int>("XMin")
                        .HasColumnType("integer");

                    b.Property<int>("YMax")
                        .HasColumnType("integer");

                    b.Property<int>("YMin")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("MapApi.Entities.MapItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("integer");

                    b.Property<int>("CoordX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordY")
                        .HasColumnType("integer");

                    b.Property<int>("MapItemTypeId")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("MapItemTypeId");

                    b.ToTable("MapItem");
                });

            modelBuilder.Entity("MapApi.Entities.MapItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MapItemType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Player"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Gate"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "UnAssignedCenter"
                        });
                });

            modelBuilder.Entity("MapApi.Entities.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("XMax")
                        .HasColumnType("integer");

                    b.Property<int>("XMin")
                        .HasColumnType("integer");

                    b.Property<int>("YMax")
                        .HasColumnType("integer");

                    b.Property<int>("YMin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Zone");
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

            modelBuilder.Entity("MapApi.Entities.Area", b =>
                {
                    b.HasOne("MapApi.Entities.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("MapApi.Entities.MapItem", b =>
                {
                    b.HasOne("MapApi.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MapApi.Entities.MapItemType", "MapItemType")
                        .WithMany()
                        .HasForeignKey("MapItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("MapItemType");
                });
#pragma warning restore 612, 618
        }
    }
}
