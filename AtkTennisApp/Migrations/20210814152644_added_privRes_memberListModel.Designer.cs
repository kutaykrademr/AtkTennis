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
    [Migration("20210814152644_added_privRes_memberListModel")]
    partial class added_privRes_memberListModel
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

                    b.Property<int>("CourtConditions")
                        .HasColumnType("int");

                    b.Property<string>("CourtFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtTimePeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtWebConditions")
                        .HasColumnType("int");

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

            modelBuilder.Entity("AtkTennisApp.Models.CourtRecipeType", b =>
                {
                    b.Property<int>("CourtRecipeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourtRecipeTypes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtRecipeTypeId");

                    b.ToTable("courtRecipeTypes");
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

            modelBuilder.Entity("AtkTennisApp.Models.MemberList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailExp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2Exp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneExp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("PrivRes")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebReservation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("memberLists");
                });

            modelBuilder.Entity("AtkTennisApp.Models.PerformanceLevel", b =>
                {
                    b.Property<int>("PerLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PerLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerQuotaInf")
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

            modelBuilder.Entity("AtkTennisApp.Models.PrivateLesson", b =>
                {
                    b.Property<int>("PrivateLessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PrivateLessonPrice")
                        .HasColumnType("int");

                    b.Property<string>("PrivateLessonType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TariffeInf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherPrice")
                        .HasColumnType("int");

                    b.HasKey("PrivateLessonId");

                    b.ToTable("privateLessons");
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

                    b.Property<int>("ResTimes30")
                        .HasColumnType("int");

                    b.Property<int>("Restimes60")
                        .HasColumnType("int");

                    b.HasKey("ResTimeId");

                    b.ToTable("resTimes");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Reservation", b =>
                {
                    b.Property<int>("ResId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CancelRes")
                        .HasColumnType("bit");

                    b.Property<string>("CancelResUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourtId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PriceIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PriceInf")
                        .HasColumnType("bit");

                    b.Property<bool>("Procedure")
                        .HasColumnType("bit");

                    b.Property<string>("ResDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResNowDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doResUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResId");

                    b.HasIndex("CourtId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("AtkTennisApp.Models.ReservationCancel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CancelReasons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CancelRes")
                        .HasColumnType("bit");

                    b.Property<string>("CancelResUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PriceIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PriceInf")
                        .HasColumnType("bit");

                    b.Property<bool>("Procedure")
                        .HasColumnType("bit");

                    b.Property<string>("ResDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResFinishTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResId")
                        .HasColumnType("int");

                    b.Property<string>("ResNowDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("reservationCancels");
                });

            modelBuilder.Entity("AtkTennisApp.Models.ReservationSettings", b =>
                {
                    b.Property<int?>("ReservationSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReservationSettingsInf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationSettingsId");

                    b.ToTable("reservationSettings");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolLevel", b =>
                {
                    b.Property<int>("SchoolLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Levels")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolLevelId");

                    b.ToTable("schoolLevels");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SchoolLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("SchoolTypesId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int?>("schoolPriceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolLevelId");

                    b.HasIndex("SchoolTypesId");

                    b.HasIndex("schoolPriceTypeId");

                    b.ToTable("schoolPrices");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolPriceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PriceTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("schoolPriceTypes");
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

            modelBuilder.Entity("AtkTennisApp.Models.ToDoList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToDo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ListId");

                    b.ToTable("toDoLists");
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

                    b.Property<bool>("Dashboard")
                        .HasColumnType("bit");

                    b.Property<bool>("DebtandPayment")
                        .HasColumnType("bit");

                    b.Property<bool>("Reservations")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SystemSettings")
                        .HasColumnType("bit");

                    b.HasKey("UserSettingsId");

                    b.ToTable("userSettings");
                });

            modelBuilder.Entity("AtkTennisApp.Models.Reservation", b =>
                {
                    b.HasOne("AtkTennisApp.Models.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId");

                    b.Navigation("Court");
                });

            modelBuilder.Entity("AtkTennisApp.Models.SchoolPrice", b =>
                {
                    b.HasOne("AtkTennisApp.Models.SchoolLevel", "schoolLevel")
                        .WithMany()
                        .HasForeignKey("SchoolLevelId");

                    b.HasOne("AtkTennisApp.Models.SchoolType", "schoolType")
                        .WithMany()
                        .HasForeignKey("SchoolTypesId");

                    b.HasOne("AtkTennisApp.Models.SchoolPriceType", "schoolPriceType")
                        .WithMany()
                        .HasForeignKey("schoolPriceTypeId");

                    b.Navigation("schoolLevel");

                    b.Navigation("schoolPriceType");

                    b.Navigation("schoolType");
                });
#pragma warning restore 612, 618
        }
    }
}