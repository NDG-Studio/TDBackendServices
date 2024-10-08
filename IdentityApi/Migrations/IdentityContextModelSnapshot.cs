﻿// <auto-generated />
using System;
using IdentityApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityApi.Migrations
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IdentityApi.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AppleId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FacebookId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("FirstLogInDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GooglePlayId")
                        .HasColumnType("text");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsAndroid")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsApe")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTutorialDone")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastSeen")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MobileUserId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "ugurcan.bagriyanik@ndgstudio.com.tr",
                            FirstLogInDate = new DateTimeOffset(new DateTime(2022, 11, 18, 12, 19, 7, 708, DateTimeKind.Unspecified).AddTicks(1513), new TimeSpan(0, 3, 0, 0, 0)),
                            IsActive = true,
                            IsAndroid = true,
                            IsApe = true,
                            IsTutorialDone = false,
                            LastSeen = new DateTimeOffset(new DateTime(2022, 11, 18, 12, 19, 7, 708, DateTimeKind.Unspecified).AddTicks(1567), new TimeSpan(0, 3, 0, 0, 0)),
                            MobileUserId = "dummyMobileUserId1",
                            PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Username = "Ugur"
                        });
                });

            modelBuilder.Entity("IdentityApi.Entities.UserToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
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

            modelBuilder.Entity("IdentityApi.Entities.UserToken", b =>
                {
                    b.HasOne("IdentityApi.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
