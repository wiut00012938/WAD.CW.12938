using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeTrackerDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrationFixedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ModuleStudent",   
                newName: "ModuleStudents"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ModuleStudents",
                newName: "ModuleStudent"  
            );
        }
    }
}
