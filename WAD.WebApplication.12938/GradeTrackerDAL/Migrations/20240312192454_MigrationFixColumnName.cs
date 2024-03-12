using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerDAL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFixColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudent_Modules_EnrolledModulesModuleId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "EnrolledModulesModuleId",
                table: "ModuleStudents",
                newName: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Modules_ModuleId",
                table: "ModuleStudents",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudent_Modules_EnrolledModulesModuleId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "ModuleStudents",
                newName: "EntrolledModulesModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_EntrolledModulesModuleId",
                table: "ModuleStudents",
                column: "EntrolledModulesModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
