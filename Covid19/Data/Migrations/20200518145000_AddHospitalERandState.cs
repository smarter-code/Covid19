using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class AddHospitalERandState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hospitals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsERActive",
                table: "Hospitals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_StateId",
                table: "Hospitals",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_States_StateId",
                table: "Hospitals",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_States_StateId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_StateId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "IsERActive",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Hospitals");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
