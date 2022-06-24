using Microsoft.EntityFrameworkCore.Migrations;

namespace crudProjectWebApi.Migrations
{
    public partial class fixed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterTeachers_User_userRefIdId",
                table: "RegisterTeachers");

            migrationBuilder.DropIndex(
                name: "IX_RegisterTeachers_userRefIdId",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "userRefIdId",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "RegisterInspectors");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "RegisterDirectors");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "RegisterInspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterTeachers_UserId",
                table: "RegisterTeachers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterTeachers_User_UserId",
                table: "RegisterTeachers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterTeachers_User_UserId",
                table: "RegisterTeachers");

            migrationBuilder.DropIndex(
                name: "IX_RegisterTeachers_UserId",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "RegisterInspectors");

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "RegisterTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userRefIdId",
                table: "RegisterTeachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "RegisterInspectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "RegisterDirectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterTeachers_userRefIdId",
                table: "RegisterTeachers",
                column: "userRefIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterTeachers_User_userRefIdId",
                table: "RegisterTeachers",
                column: "userRefIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
