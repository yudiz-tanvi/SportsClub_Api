using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sportsclub_management.repository.Migrations
{
    public partial class AddSportsClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterGame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterPlayer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Mobile = table.Column<long>(maxLength: 10, nullable: false),
                    AadharNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPlayer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Display_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameEquipmentMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<long>(maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(maxLength: 250, nullable: false),
                    MasterGameId = table.Column<Guid>(nullable: false),
                    MasterEquipmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEquipmentMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEquipmentMap_MasterEquipment_MasterEquipmentId",
                        column: x => x.MasterEquipmentId,
                        principalTable: "MasterEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEquipmentMap_MasterGame_MasterGameId",
                        column: x => x.MasterGameId,
                        principalTable: "MasterGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterCoach",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Mobile = table.Column<long>(maxLength: 10, nullable: false),
                    AadharNumber = table.Column<string>(maxLength: 12, nullable: false),
                    MasterGameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCoach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterCoach_MasterGame_MasterGameId",
                        column: x => x.MasterGameId,
                        principalTable: "MasterGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Add_Feedback = table.Column<string>(maxLength: 500, nullable: false),
                    MasterPlayerId = table.Column<Guid>(nullable: false),
                    MaasterPlayerId = table.Column<Guid>(nullable: true),
                    MasterGameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_MasterPlayer_MaasterPlayerId",
                        column: x => x.MaasterPlayerId,
                        principalTable: "MasterPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_MasterGame_MasterGameId",
                        column: x => x.MasterGameId,
                        principalTable: "MasterGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    MasterPlayerId = table.Column<Guid>(nullable: false),
                    MasterGameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameMap_MasterGame_MasterGameId",
                        column: x => x.MasterGameId,
                        principalTable: "MasterGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameMap_MasterPlayer_MasterPlayerId",
                        column: x => x.MasterPlayerId,
                        principalTable: "MasterPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    Mobile = table.Column<long>(maxLength: 10, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    MasterRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_MasterRole_MasterRoleId",
                        column: x => x.MasterRoleId,
                        principalTable: "MasterRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    MasterCoachId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoachAddress_MasterCoach_MasterCoachId",
                        column: x => x.MasterCoachId,
                        principalTable: "MasterCoach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_MasterRoleId",
                table: "Admin",
                column: "MasterRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachAddress_MasterCoachId",
                table: "CoachAddress",
                column: "MasterCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MaasterPlayerId",
                table: "Feedback",
                column: "MaasterPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MasterGameId",
                table: "Feedback",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEquipmentMap_MasterEquipmentId",
                table: "GameEquipmentMap",
                column: "MasterEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEquipmentMap_MasterGameId",
                table: "GameEquipmentMap",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterCoach_MasterGameId",
                table: "MasterCoach",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameMap_MasterGameId",
                table: "PlayerGameMap",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameMap_MasterPlayerId",
                table: "PlayerGameMap",
                column: "MasterPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CoachAddress");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "GameEquipmentMap");

            migrationBuilder.DropTable(
                name: "PlayerGameMap");

            migrationBuilder.DropTable(
                name: "MasterRole");

            migrationBuilder.DropTable(
                name: "MasterCoach");

            migrationBuilder.DropTable(
                name: "MasterEquipment");

            migrationBuilder.DropTable(
                name: "MasterPlayer");

            migrationBuilder.DropTable(
                name: "MasterGame");
        }
    }
}
