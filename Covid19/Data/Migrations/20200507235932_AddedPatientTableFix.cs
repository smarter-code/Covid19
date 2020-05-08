using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class AddedPatientTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList");

            migrationBuilder.RenameTable(
                name: "ToDoList",
                newName: "Patients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "ToDoList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList",
                column: "Id");
        }
    }
}
