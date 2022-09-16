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
    [Migration("20220916080413_playerhero-ent-bugfix")]
    partial class playerheroentbugfix
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

            modelBuilder.Entity("PlayerBaseApi.Entities.BuildingUpdateTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("UpdateDuration")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.ToTable("BuildingUpdateTime");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildingTypeId = 1,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            BuildingTypeId = 2,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            BuildingTypeId = 3,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            BuildingTypeId = 4,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            BuildingTypeId = 5,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            BuildingTypeId = 6,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            BuildingTypeId = 7,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            BuildingTypeId = 8,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            BuildingTypeId = 9,
                            Level = 2,
                            UpdateDuration = new TimeSpan(0, 0, 2, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            BuildingTypeId = 1,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            BuildingTypeId = 2,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 12,
                            BuildingTypeId = 3,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 13,
                            BuildingTypeId = 4,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 14,
                            BuildingTypeId = 5,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 15,
                            BuildingTypeId = 6,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 16,
                            BuildingTypeId = 7,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 17,
                            BuildingTypeId = 8,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 18,
                            BuildingTypeId = 9,
                            Level = 3,
                            UpdateDuration = new TimeSpan(0, 0, 5, 0, 0)
                        },
                        new
                        {
                            Id = 19,
                            BuildingTypeId = 1,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 20,
                            BuildingTypeId = 2,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 21,
                            BuildingTypeId = 3,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 22,
                            BuildingTypeId = 4,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 23,
                            BuildingTypeId = 5,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 24,
                            BuildingTypeId = 6,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 25,
                            BuildingTypeId = 7,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 26,
                            BuildingTypeId = 8,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 27,
                            BuildingTypeId = 9,
                            Level = 4,
                            UpdateDuration = new TimeSpan(0, 0, 10, 0, 0)
                        },
                        new
                        {
                            Id = 28,
                            BuildingTypeId = 1,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 29,
                            BuildingTypeId = 2,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 30,
                            BuildingTypeId = 3,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 31,
                            BuildingTypeId = 4,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 32,
                            BuildingTypeId = 5,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 33,
                            BuildingTypeId = 6,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 34,
                            BuildingTypeId = 7,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 35,
                            BuildingTypeId = 8,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 36,
                            BuildingTypeId = 9,
                            Level = 5,
                            UpdateDuration = new TimeSpan(0, 0, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundPictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsApe")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThemeColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "dummydescription",
                            IsActive = true,
                            IsApe = false,
                            MaxLevel = 30,
                            Name = "Zeus",
                            Story = "Dummyherostory",
                            ThemeColor = "#993333",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 2,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Hadesdescription",
                            IsActive = true,
                            IsApe = false,
                            MaxLevel = 30,
                            Name = "Hades",
                            Story = "Hadesherostory",
                            ThemeColor = "#2F4F4F",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-2-100x100.png"
                        },
                        new
                        {
                            Id = 3,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Poseidondescription",
                            IsActive = true,
                            IsApe = false,
                            MaxLevel = 30,
                            Name = "Poseidon",
                            Story = "Poseidonherostory",
                            ThemeColor = "#00FFFF",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-3-100x100.png"
                        },
                        new
                        {
                            Id = 4,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Odindescription",
                            IsActive = true,
                            IsApe = false,
                            MaxLevel = 30,
                            Name = "Odin",
                            Story = "Odinherostory",
                            ThemeColor = "#993333",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 5,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Thordescription",
                            IsActive = true,
                            IsApe = false,
                            MaxLevel = 30,
                            Name = "Thor",
                            Story = "Thorherostory",
                            ThemeColor = "#993333",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 6,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Smasher",
                            IsActive = true,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Hulk",
                            Story = "Hulkherostory",
                            ThemeColor = "#006400",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 7,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Abominationdescription",
                            IsActive = true,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Abomination",
                            Story = "Abominationherostory",
                            ThemeColor = "#7CFC00",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 8,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "octopusdescription",
                            IsActive = true,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Dr. Octopus",
                            Story = "Octopusherostory",
                            ThemeColor = "#778899",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 9,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Just Joker",
                            IsActive = true,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Joker",
                            Story = "Dramatic Hero Story",
                            ThemeColor = "#FF8C00",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 10,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Black Noir description",
                            IsActive = true,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Black Noir",
                            Story = "Black Noir herostory",
                            ThemeColor = "#000000",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        },
                        new
                        {
                            Id = 11,
                            BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                            Description = "Invinsible Gauntlet Lover",
                            IsActive = false,
                            IsApe = true,
                            MaxLevel = 30,
                            Name = "Thanos",
                            Story = "Long Story",
                            ThemeColor = "#8A2BE2",
                            ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"
                        });
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerBaseInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseLevel")
                        .HasColumnType("integer");

                    b.Property<int>("BluePrints")
                        .HasColumnType("integer");

                    b.Property<int>("Gems")
                        .HasColumnType("integer");

                    b.Property<int>("HeroCards")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("LastBaseCollect")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Scraps")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PlayerBaseInfo");
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

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentLevel")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillPoint")
                        .HasColumnType("integer");

                    b.Property<int>("TalentPoint")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("PlayerHero");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerTalentTreeNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("TalentTreeNodeId")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TalentTreeNodeId");

                    b.ToTable("PlayerTalentTreeNode");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.TalentTree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThemeColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TalentTree");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.TalentTreeNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuffId")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TalentTreeId")
                        .HasColumnType("integer");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("TalentTreeId");

                    b.ToTable("TalentTreeNode");
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

            modelBuilder.Entity("PlayerBaseApi.Entities.BuildingUpdateTime", b =>
                {
                    b.HasOne("PlayerBaseApi.Entities.BuildingType", "BuildingType")
                        .WithMany()
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingType");
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

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerHero", b =>
                {
                    b.HasOne("PlayerBaseApi.Entities.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.PlayerTalentTreeNode", b =>
                {
                    b.HasOne("PlayerBaseApi.Entities.TalentTreeNode", "TalentTreeNode")
                        .WithMany()
                        .HasForeignKey("TalentTreeNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TalentTreeNode");
                });

            modelBuilder.Entity("PlayerBaseApi.Entities.TalentTreeNode", b =>
                {
                    b.HasOne("PlayerBaseApi.Entities.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayerBaseApi.Entities.TalentTree", "TalentTree")
                        .WithMany()
                        .HasForeignKey("TalentTreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("TalentTree");
                });
#pragma warning restore 612, 618
        }
    }
}
