using Microsoft.EntityFrameworkCore.Migrations;

namespace crudProjectWebApi.Migrations
{
    public partial class fixedrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userRefIdId",
                table: "RegisterTeachers",
                type: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterTeachers_User_userRefIdId",
                table: "RegisterTeachers");

            migrationBuilder.DropIndex(
                name: "IX_RegisterTeachers_userRefIdId",
                table: "RegisterTeachers");

            migrationBuilder.DropColumn(
                name: "userRefIdId",
                table: "RegisterTeachers");
        }
    }
}
