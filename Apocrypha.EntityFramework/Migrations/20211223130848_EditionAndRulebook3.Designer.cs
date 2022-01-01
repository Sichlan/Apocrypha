﻿// <auto-generated />
using System;
using Apocrypha.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apocrypha.EntityFramework.Migrations
{
    [DbContext(typeof(ApocryphaDbContext))]
    [Migration("20211223130848_EditionAndRulebook3")]
    partial class EditionAndRulebook3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<bool>("DisableNonPlaytimeEditing")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.CharacterItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AquiredAt")
                        .HasColumnType("datetime");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OwnerId");

                    b.ToTable("CharacterItems");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Core")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("System")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.RuleBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EditionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("RuleBooks");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Character", b =>
                {
                    b.HasOne("Apocrypha.CommonObject.Models.User", "CreatorUser")
                        .WithMany("Characters")
                        .HasForeignKey("CreatorUserId");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.CharacterItem", b =>
                {
                    b.HasOne("Apocrypha.CommonObject.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Apocrypha.CommonObject.Models.Character", "Owner")
                        .WithMany("InventoryItems")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Item");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.RuleBook", b =>
                {
                    b.HasOne("Apocrypha.CommonObject.Models.Edition", "Edition")
                        .WithMany("RuleBooks")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edition");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Character", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.Edition", b =>
                {
                    b.Navigation("RuleBooks");
                });

            modelBuilder.Entity("Apocrypha.CommonObject.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
