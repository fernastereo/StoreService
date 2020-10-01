﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceStore.Api.Shop.Persistence;

namespace ServiceStore.Api.Shop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20201001230255_MySQLInitialMigration")]
    partial class MySQLInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServiceStore.Api.Shop.Model.ShopSession", b =>
                {
                    b.Property<int>("ShopSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("ShopSessionId");

                    b.ToTable("ShopSession");
                });

            modelBuilder.Entity("ServiceStore.Api.Shop.Model.ShopSessionDetail", b =>
                {
                    b.Property<int>("ShopSessionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("SelectedProduct")
                        .HasColumnType("text");

                    b.Property<int>("ShopSessionId")
                        .HasColumnType("int");

                    b.HasKey("ShopSessionDetailId");

                    b.HasIndex("ShopSessionId");

                    b.ToTable("ShopSessionDetail");
                });

            modelBuilder.Entity("ServiceStore.Api.Shop.Model.ShopSessionDetail", b =>
                {
                    b.HasOne("ServiceStore.Api.Shop.Model.ShopSession", "ShopSession")
                        .WithMany("DetailList")
                        .HasForeignKey("ShopSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
