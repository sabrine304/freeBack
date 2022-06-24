using Microsoft.EntityFrameworkCore.Migrations;

namespace crudProjectWebApi.Migrations
{
    public partial class addcommentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentStatus",
                table: "RegisterTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCode",
                table: "RegisterTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidationStatus",
                table: "RegisterTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentStatus",
                table: "RegisterInspectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCode",
                table: "RegisterInspectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidationStatus",
                table: "RegisterInspectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentStatus",
                table: "RegisterDirectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCode",
                table: "RegisterDirectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidationStatus",
                table: "RegisterDirectors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "IdentificationCode",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "ValidationStatus",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "IdentificationCode",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "ValidationStatus",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "RegisterDirectors");

            migrationBuilder.DropColumn(
                name: "IdentificationCode",
                table: "RegisterDirectors");

            migrationBuilder.DropColumn(
                name: "ValidationStatus",
                table: "RegisterDirectors");
        }
    }
}
