using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_SportsClub.repository.Migrations
{
    public partial class Tanvi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MasterGameId",
                table: "MasterCoach",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MasterCoach_MasterGameId",
                table: "MasterCoach",
                column: "MasterGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterCoach_MasterGames_MasterGameId",
                table: "MasterCoach",
                column: "MasterGameId",
                principalTable: "MasterGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterCoach_MasterGames_MasterGameId",
                table: "MasterCoach");

            migrationBuilder.DropIndex(
                name: "IX_MasterCoach_MasterGameId",
                table: "MasterCoach");

            migrationBuilder.DropColumn(
                name: "MasterGameId",
                table: "MasterCoach");
        }
    }
}
