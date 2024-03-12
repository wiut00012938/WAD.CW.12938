using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerDAL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFixedStudentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudent_Students_StudentsId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ModuleStudents",
                newName: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Students_StudentId",
                table: "ModuleStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudents_Students_StudentId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ModuleStudents",
                newName: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Students_StudentsId",
                table: "ModuleStudents",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
