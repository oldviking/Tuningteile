﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tuningteile.Data;

namespace Tuningteile.Migrations
{
    [DbContext(typeof(TuningteileContext))]
    [Migration("20211019091143_change872")]
    partial class change872
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelTuningPart", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("TuningPartId")
                        .HasColumnType("int");

                    b.HasKey("ModelId", "TuningPartId");

                    b.HasIndex("TuningPartId");

                    b.ToTable("ModelTuningPart");
                });

            modelBuilder.Entity("Tuningteile.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Tuningteile.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Begin_Year_construction")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("End_Year_construction")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("compatibiliyModelId")
                        .HasColumnType("int");

                    b.Property<int?>("compatibiliyTuningPartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("compatibiliyModelId", "compatibiliyTuningPartId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Tuningteile.Models.TuningPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<int?>("compatibiliyModelId")
                        .HasColumnType("int");

                    b.Property<int?>("compatibiliyTuningPartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("compatibiliyModelId", "compatibiliyTuningPartId");

                    b.ToTable("TuningPart");
                });

            modelBuilder.Entity("Tuningteile.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tuningteile.Models.compatibiliy", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("TuningPartId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ModelId", "TuningPartId");

                    b.ToTable("compatibiliy");
                });

            modelBuilder.Entity("Tuningteile.Models.manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("manufacturer");
                });

            modelBuilder.Entity("ModelTuningPart", b =>
                {
                    b.HasOne("Tuningteile.Models.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuningteile.Models.TuningPart", null)
                        .WithMany()
                        .HasForeignKey("TuningPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuningteile.Models.Model", b =>
                {
                    b.HasOne("Tuningteile.Models.manufacturer", "Manufacturer")
                        .WithMany("Model")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuningteile.Models.compatibiliy", null)
                        .WithMany("Model")
                        .HasForeignKey("compatibiliyModelId", "compatibiliyTuningPartId");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Tuningteile.Models.TuningPart", b =>
                {
                    b.HasOne("Tuningteile.Models.Category", "category")
                        .WithMany("TuningPart")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuningteile.Models.compatibiliy", null)
                        .WithMany("TuningPart")
                        .HasForeignKey("compatibiliyModelId", "compatibiliyTuningPartId");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Tuningteile.Models.Category", b =>
                {
                    b.Navigation("TuningPart");
                });

            modelBuilder.Entity("Tuningteile.Models.compatibiliy", b =>
                {
                    b.Navigation("Model");

                    b.Navigation("TuningPart");
                });

            modelBuilder.Entity("Tuningteile.Models.manufacturer", b =>
                {
                    b.Navigation("Model");
                });
#pragma warning restore 612, 618
        }
    }
}
