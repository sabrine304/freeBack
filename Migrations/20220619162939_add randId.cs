using Microsoft.EntityFrameworkCore.Migrations;

namespace crudProjectWebApi.Migrations
{
    public partial class addrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentRank",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "CurrentRank",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "CurrentRank",
                table: "RegisterDirectors");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "RegisterTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "RegisterInspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "RegisterDirectors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RankId",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "RegisterDirectors");

            migrationBuilder.AddColumn<string>(
                name: "CurrentRank",
                table: "RegisterTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentRank",
                table: "RegisterInspectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentRank",
                table: "RegisterDirectors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
