﻿// <auto-generated />
using System;
using AtkTennis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtkTennisApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210403133809_first_adding")]
    partial class first_adding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtkTennisApp.Models.Court", b =>
                {
                    b.Property<int>("CourtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourtConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtWebConditions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtId");

                    b.ToTable("courts");
                });

            modelBuilder.Entity("AtkTennisApp.Models.CourtPriceList", b =>
                {
                    b.Property<int>("CourtPriceListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtPriceListId");

                    b.ToTable("courtPriceLists");
                });

            modelBuilder.Entity("AtkTennisApp.Models.ResTime", b =>
                {
                    b.Property<int>("ResTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResTimes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResTimeId");

                    b.ToTable("resTimes");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Reservation", b =>
                {
                    b.Property<int>("ResId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("courtsCourtId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResId");

                    b.HasIndex("courtsCourtId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Reservation", b =>
                {
                    b.HasOne("AtkTennisApp.Models.Court", "courts")
                        .WithMany("reservations")
                        .HasForeignKey("courtsCourtId");

                    b.Navigation("courts");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Court", b =>
                {
                    b.Navigation("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
