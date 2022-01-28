using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_SportsClub.repository.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MasterGameId",
                table: "PlayerGameMap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterPlayerId",
                table: "PlayerGameMap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterEquipmentId",
                table: "GameEquipmentMap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterGameId",
                table: "GameEquipmentMap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterGameId",
                table: "Feedback",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterPlayerId",
                table: "Feedback",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterCoachId",
                table: "CoachAddress",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MasterRoleId",
                table: "Admin",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameMap_MasterGameId",
                table: "PlayerGameMap",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameMap_MasterPlayerId",
                table: "PlayerGameMap",
                column: "MasterPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEquipmentMap_MasterEquipmentId",
                table: "GameEquipmentMap",
                column: "MasterEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEquipmentMap_MasterGameId",
                table: "GameEquipmentMap",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MasterGameId",
                table: "Feedback",
                column: "MasterGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MasterPlayerId",
                table: "Feedback",
                column: "MasterPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachAddress_MasterCoachId",
                table: "CoachAddress",
                column: "MasterCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_MasterRoleId",
                table: "Admin",
                column: "MasterRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_MasterRole_MasterRoleId",
                table: "Admin",
                column: "MasterRoleId",
                principalTable: "MasterRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachAddress_MasterCoach_MasterCoachId",
                table: "CoachAddress",
                column: "MasterCoachId",
                principalTable: "MasterCoach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_MasterGames_MasterGameId",
                table: "Feedback",
                column: "MasterGameId",
                principalTable: "MasterGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_MasterPlayer_MasterPlayerId",
                table: "Feedback",
                column: "MasterPlayerId",
                principalTable: "MasterPlayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEquipmentMap_MasterEquipment_MasterEquipmentId",
                table: "GameEquipmentMap",
                column: "MasterEquipmentId",
                principalTable: "MasterEquipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEquipmentMap_MasterGames_MasterGameId",
                table: "GameEquipmentMap",
                column: "MasterGameId",
                principalTable: "MasterGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGameMap_MasterGames_MasterGameId",
                table: "PlayerGameMap",
                column: "MasterGameId",
                principalTable: "MasterGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGameMap_MasterPlayer_MasterPlayerId",
                table: "PlayerGameMap",
                column: "MasterPlayerId",
                principalTable: "MasterPlayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_MasterRole_MasterRoleId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachAddress_MasterCoach_MasterCoachId",
                table: "CoachAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_MasterGames_MasterGameId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_MasterPlayer_MasterPlayerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEquipmentMap_MasterEquipment_MasterEquipmentId",
                table: "GameEquipmentMap");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEquipmentMap_MasterGames_MasterGameId",
                table: "GameEquipmentMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGameMap_MasterGames_MasterGameId",
                table: "PlayerGameMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGameMap_MasterPlayer_MasterPlayerId",
                table: "PlayerGameMap");

            migrationBuilder.DropIndex(
                name: "IX_PlayerGameMap_MasterGameId",
                table: "PlayerGameMap");

            migrationBuilder.DropIndex(
                name: "IX_PlayerGameMap_MasterPlayerId",
                table: "PlayerGameMap");

            migrationBuilder.DropIndex(
                name: "IX_GameEquipmentMap_MasterEquipmentId",
                table: "GameEquipmentMap");

            migrationBuilder.DropIndex(
                name: "IX_GameEquipmentMap_MasterGameId",
                table: "GameEquipmentMap");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_MasterGameId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_MasterPlayerId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_CoachAddress_MasterCoachId",
                table: "CoachAddress");

            migrationBuilder.DropIndex(
                name: "IX_Admin_MasterRoleId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "MasterGameId",
                table: "PlayerGameMap");

            migrationBuilder.DropColumn(
                name: "MasterPlayerId",
                table: "PlayerGameMap");

            migrationBuilder.DropColumn(
                name: "MasterEquipmentId",
                table: "GameEquipmentMap");

            migrationBuilder.DropColumn(
                name: "MasterGameId",
                table: "GameEquipmentMap");

            migrationBuilder.DropColumn(
                name: "MasterGameId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "MasterPlayerId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "MasterCoachId",
                table: "CoachAddress");

            migrationBuilder.DropColumn(
                name: "MasterRoleId",
                table: "Admin");
        }
    }
}
