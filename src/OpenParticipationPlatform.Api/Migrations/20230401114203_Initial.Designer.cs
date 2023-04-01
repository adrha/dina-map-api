﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenParticipationPlatform.Api.Context;

#nullable disable

namespace OpenParticipationPlatform.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230401114203_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.CategoryDbo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("CanUserAddObject")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("MapGeometry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.FaqDbo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("MapObjectId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Published")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MapObjectId");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.MapObjectDbo", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ActiveFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ActiveTo")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GeometryData")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MapObjects");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.UrlDbo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MapObjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MapObjectId");

                    b.ToTable("Urls");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.FaqDbo", b =>
                {
                    b.HasOne("OpenParticipationPlatform.Api.Dbo.MapObjectDbo", "MapObject")
                        .WithMany("Faqs")
                        .HasForeignKey("MapObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapObject");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.MapObjectDbo", b =>
                {
                    b.HasOne("OpenParticipationPlatform.Api.Dbo.CategoryDbo", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.UrlDbo", b =>
                {
                    b.HasOne("OpenParticipationPlatform.Api.Dbo.MapObjectDbo", "MapObject")
                        .WithMany("Urls")
                        .HasForeignKey("MapObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapObject");
                });

            modelBuilder.Entity("OpenParticipationPlatform.Api.Dbo.MapObjectDbo", b =>
                {
                    b.Navigation("Faqs");

                    b.Navigation("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}
