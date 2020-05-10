using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class UnknownChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Municipality_MunicipalityId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_State_StateId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_States_StateId",
                table: "Patients",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_States_StateId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Municipality_MunicipalityId",
                table: "Patients",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_State_StateId",
                table: "Patients",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
