using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerAPI.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }
    }
}
