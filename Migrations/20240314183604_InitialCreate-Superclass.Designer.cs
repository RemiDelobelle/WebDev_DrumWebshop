﻿// <auto-generated />
using DrumWebshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrumWebshop.Migrations
{
    [DbContext(typeof(DrumContext))]
    [Migration("20240314183604_InitialCreate-Superclass")]
    partial class InitialCreateSuperclass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrumWebshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("DrumWebshop.Models.Cymbal", b =>
                {
                    b.HasBaseType("DrumWebshop.Models.Product");

                    b.Property<string>("Finish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Sound")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cymbal");
                });

            modelBuilder.Entity("DrumWebshop.Models.Hardware", b =>
                {
                    b.HasBaseType("DrumWebshop.Models.Product");

                    b.HasDiscriminator().HasValue("Hardware");
                });

            modelBuilder.Entity("DrumWebshop.Models.Shell", b =>
                {
                    b.HasBaseType("DrumWebshop.Models.Product");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shell_Material");

                    b.Property<int>("Pieces")
                        .HasColumnType("int");

                    b.Property<int>("PlyCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Shell");
                });

            modelBuilder.Entity("DrumWebshop.Models.Snare", b =>
                {
                    b.HasBaseType("DrumWebshop.Models.Product");

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<string>("Finish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Snare_Finish");

                    b.Property<int>("LugCount")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Snare_Material");

                    b.Property<int>("PlyCount")
                        .HasColumnType("int")
                        .HasColumnName("Snare_PlyCount");

                    b.HasDiscriminator().HasValue("Snare");
                });

            modelBuilder.Entity("DrumWebshop.Models.Hardware", b =>
                {
                    b.OwnsMany("DrumWebshop.Models.HwComponent", "HwComponents", b1 =>
                        {
                            b1.Property<int>("HardwareId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ProductCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HardwareId", "Id");

                            b1.ToTable("HwComponents");

                            b1.WithOwner()
                                .HasForeignKey("HardwareId");
                        });

                    b.Navigation("HwComponents");
                });
#pragma warning restore 612, 618
        }
    }
}