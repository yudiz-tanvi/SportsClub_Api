using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_SportsClub.repository.Migrations
{
    public partial class AddAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterGames",
                table: "MasterGames");

            migrationBuilder.RenameTable(
                name: "MasterGames",
                newName: "MasterGameEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterGameEntity",
                table: "MasterGameEntity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterGameEntity",
                table: "MasterGameEntity");

            migrationBuilder.RenameTable(
                name: "MasterGameEntity",
                newName: "MasterGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterGames",
                table: "MasterGames",
                column: "Id");
        }
    }
}
