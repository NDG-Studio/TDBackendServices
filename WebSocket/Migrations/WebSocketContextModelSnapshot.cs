﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebSocket;

#nullable disable

namespace WebSocket.Migrations
{
    [DbContext(typeof(WebSocketContext))]
    partial class WebSocketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("WebSocket.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatRoomMemberId")
                        .HasColumnType("uuid");

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExtentionTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("SendedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomMemberId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("WebSocket.Entities.ChatRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ChatRoomTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastChangeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("WebSocket.Entities.ChatRoomMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatRoomId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("JoinedRoomDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastSeen")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomId");

                    b.ToTable("ChatRoomMember");
                });

            modelBuilder.Entity("WebSocket.Entities.Gang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvatarId")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GangEntryTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("MemberCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<int>("RaidCapacity")
                        .HasColumnType("integer");

                    b.Property<long>("ScrapPool")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gang");
                });

            modelBuilder.Entity("WebSocket.Entities.GangApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Coordinate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GangId")
                        .HasColumnType("uuid");

                    b.Property<string>("Rank1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rank2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rank3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rank4")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserAvatarId")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GangId");

                    b.ToTable("GangApplication");
                });

            modelBuilder.Entity("WebSocket.Entities.GangMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MemberTypeId")
                        .HasColumnType("uuid");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberTypeId");

                    b.ToTable("GangMember");
                });

            modelBuilder.Entity("WebSocket.Entities.MemberType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanAcceptMember")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDestroyGang")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDistributeMoney")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanEditGang")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanKick")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanMemberChangeType")
                        .HasColumnType("boolean");

                    b.Property<Guid>("GangId")
                        .HasColumnType("uuid");

                    b.Property<bool>("GateManager")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PoolScore")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GangId");

                    b.ToTable("MemberType");
                });

            modelBuilder.Entity("WebSocket.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ACoord")
                        .HasColumnType("text");

                    b.Property<int?>("ADead")
                        .HasColumnType("integer");

                    b.Property<int>("AGangAvatarId")
                        .HasColumnType("integer");

                    b.Property<string>("AGangId")
                        .HasColumnType("text");

                    b.Property<string>("AGangName")
                        .HasColumnType("text");

                    b.Property<int?>("APrisoner")
                        .HasColumnType("integer");

                    b.Property<int?>("ATroop")
                        .HasColumnType("integer");

                    b.Property<long?>("AUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("AUsername")
                        .HasColumnType("text");

                    b.Property<int?>("AWounded")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<string>("GainedResources")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsCollected")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ProcessDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Seen")
                        .HasColumnType("boolean");

                    b.Property<string>("TCoord")
                        .HasColumnType("text");

                    b.Property<int?>("TDead")
                        .HasColumnType("integer");

                    b.Property<int>("TGangAvatarId")
                        .HasColumnType("integer");

                    b.Property<string>("TGangId")
                        .HasColumnType("text");

                    b.Property<string>("TGangName")
                        .HasColumnType("text");

                    b.Property<int?>("TPrisoner")
                        .HasColumnType("integer");

                    b.Property<int?>("TScrap")
                        .HasColumnType("integer");

                    b.Property<int?>("TTroop")
                        .HasColumnType("integer");

                    b.Property<long?>("TUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("TUsername")
                        .HasColumnType("text");

                    b.Property<int?>("TWall")
                        .HasColumnType("integer");

                    b.Property<int?>("TWounded")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<byte?>("VictorySide")
                        .HasColumnType("smallint");

                    b.Property<int?>("WarLoot")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("WebSocket.Entities.UserActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsConnectedNow")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastConnection")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastNewsCheck")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserActivity");
                });

            modelBuilder.Entity("WebSocket.Entities.ChatMessage", b =>
                {
                    b.HasOne("WebSocket.Entities.ChatRoomMember", "ChatRoomMember")
                        .WithMany()
                        .HasForeignKey("ChatRoomMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoomMember");
                });

            modelBuilder.Entity("WebSocket.Entities.ChatRoomMember", b =>
                {
                    b.HasOne("WebSocket.Entities.ChatRoom", "ChatRoom")
                        .WithMany()
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");
                });

            modelBuilder.Entity("WebSocket.Entities.GangApplication", b =>
                {
                    b.HasOne("WebSocket.Entities.Gang", "Gang")
                        .WithMany()
                        .HasForeignKey("GangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gang");
                });

            modelBuilder.Entity("WebSocket.Entities.GangMember", b =>
                {
                    b.HasOne("WebSocket.Entities.MemberType", "MemberType")
                        .WithMany()
                        .HasForeignKey("MemberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberType");
                });

            modelBuilder.Entity("WebSocket.Entities.MemberType", b =>
                {
                    b.HasOne("WebSocket.Entities.Gang", "Gang")
                        .WithMany()
                        .HasForeignKey("GangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gang");
                });
#pragma warning restore 612, 618
        }
    }
}
