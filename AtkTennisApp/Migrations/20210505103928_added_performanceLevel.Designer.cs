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
    [Migration("20210505103928_added_performanceLevel")]
    partial class added_performanceLevel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtkTennisApp.Models.ApplicationLog", b =>
                {
                    b.Property<int>("ApplicationLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdField")
                        .HasColumnType("int");

                    b.Property<string>("IdFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationLogId");

                    b.ToTable("applicationLogs");
                });

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

            modelBuilder.Entity("AtkTennisApp.Models.ErrorLog", b =>
                {
                    b.Property<int>("ErrorLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdField")
                        .HasColumnType("int");

                    b.Property<string>("IdFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ErrorLogId");

                    b.ToTable("errorLogs");
                });

            modelBuilder.Entity("AtkTennisApp.Models.PerformanceLevel", b =>
                {
                    b.Property<int>("PerLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PerLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerQuotaInf")
                        .HasColumnType("int");

                    b.HasKey("PerLevelId");

                    b.ToTable("performanceLevels");
                });

            modelBuilder.Entity("AtkTennisApp.Models.PerformanceType", b =>
                {
                    b.Property<int>("PerformanceTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PerformanceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerformanceTypes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerformanceTypesId");

                    b.ToTable("performanceTypes");
                });

            modelBuilder.Entity("AtkTennisApp.Models.QueryLog", b =>
                {
                    b.Property<int>("QueryLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ElapsedMilisecond")
                        .HasColumnType("int");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QueryLogId");

                    b.ToTable("queryLogs");
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

                    b.Property<int?>("CourtsCourtId")
                        .HasColumnType("int");

                    b.Property<string>("ResDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResId");

                    b.HasIndex("CourtsCourtId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolLevel", b =>
                {
                    b.Property<int>("SchoolLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuotaInf")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolLevelId");

                    b.ToTable("schoolLevels");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolType", b =>
                {
                    b.Property<int>("SchoolTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Types")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolTypesId");

                    b.ToTable("schoolTypes");
                });

            modelBuilder.Entity("AtkTennisApp.Models.UserLog", b =>
                {
                    b.Property<int>("UserLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Port")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserLogId");

                    b.ToTable("userLogs");
                });

            modelBuilder.Entity("AtkTennisApp.Models.UserSettings", b =>
                {
                    b.Property<int>("UserSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Advisory")
                        .HasColumnType("bit");

                    b.Property<bool>("DebtandPayment")
                        .HasColumnType("bit");

                    b.Property<bool>("Reservations")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("System")
                        .HasColumnType("bit");

                    b.HasKey("UserSettingsId");

                    b.ToTable("userSettings");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Reservation", b =>
                {
                    b.HasOne("AtkTennisApp.Models.Court", "CourtsCourt")
                        .WithMany("Reservations")
                        .HasForeignKey("CourtsCourtId");

                    b.Navigation("CourtsCourt");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Court", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
