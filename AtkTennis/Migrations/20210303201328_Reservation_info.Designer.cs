﻿// <auto-generated />
using AtkTennis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtkTennis.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210303201328_Reservation_info")]
    partial class Reservation_info
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtkTennis.Models.Reservation", b =>
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

                    b.HasKey("ResId");

                    b.ToTable("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
