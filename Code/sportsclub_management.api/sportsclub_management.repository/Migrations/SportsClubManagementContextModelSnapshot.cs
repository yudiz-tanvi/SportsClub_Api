﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sportsclub_management.repository;

namespace sportsclub_management.repository.Migrations
{
    [DbContext(typeof(SportsClubManagementContext))]
    partial class SportsClubManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sportsclub_management.models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<Guid>("MasterRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("MasterRoleId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("sportsclub_management.models.CoachAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MasterCoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MasterCoachId");

                    b.ToTable("CoachAddress");
                });

            modelBuilder.Entity("sportsclub_management.models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Add_Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MaasterPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MasterGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MasterPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaasterPlayerId");

                    b.HasIndex("MasterGameId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("sportsclub_management.models.GameEquipmentMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MasterEquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MasterGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasMaxLength(100);

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("MasterEquipmentId");

                    b.HasIndex("MasterGameId");

                    b.ToTable("GameEquipmentMap");
                });

            modelBuilder.Entity("sportsclub_management.models.MasterCoach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AadharNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MasterGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MasterGameId");

                    b.ToTable("MasterCoach");
                });

            modelBuilder.Entity("sportsclub_management.models.MasterEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MasterEquipment");
                });

            modelBuilder.Entity("sportsclub_management.models.MasterGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MasterGame");
                });

            modelBuilder.Entity("sportsclub_management.models.MasterPlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AadharNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<decimal>("Fees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MasterPlayer");
                });

            modelBuilder.Entity("sportsclub_management.models.MasterRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Display_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MasterRole");
                });

            modelBuilder.Entity("sportsclub_management.models.PlayerGameMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MasterGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MasterPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MasterGameId");

                    b.HasIndex("MasterPlayerId");

                    b.ToTable("PlayerGameMap");
                });

            modelBuilder.Entity("sportsclub_management.models.Admin", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterRole", "MasterRole")
                        .WithMany()
                        .HasForeignKey("MasterRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sportsclub_management.models.CoachAddress", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterCoach", "MasterCoach")
                        .WithMany()
                        .HasForeignKey("MasterCoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sportsclub_management.models.Feedback", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterPlayer", "MasterPlayer")
                        .WithMany()
                        .HasForeignKey("MaasterPlayerId");

                    b.HasOne("sportsclub_management.models.MasterGame", "MasterGame")
                        .WithMany()
                        .HasForeignKey("MasterGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sportsclub_management.models.GameEquipmentMap", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterEquipment", "MasterEquipment")
                        .WithMany()
                        .HasForeignKey("MasterEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sportsclub_management.models.MasterGame", "MasterGame")
                        .WithMany()
                        .HasForeignKey("MasterGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sportsclub_management.models.MasterCoach", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterGame", "MasterGame")
                        .WithMany()
                        .HasForeignKey("MasterGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sportsclub_management.models.PlayerGameMap", b =>
                {
                    b.HasOne("sportsclub_management.models.MasterGame", "MasterGame")
                        .WithMany()
                        .HasForeignKey("MasterGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sportsclub_management.models.MasterPlayer", "MasterPlayer")
                        .WithMany()
                        .HasForeignKey("MasterPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
