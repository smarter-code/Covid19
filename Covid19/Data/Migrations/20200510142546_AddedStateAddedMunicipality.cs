using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class AddedStateAddedMunicipality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MunicipalityId",
                table: "Patients",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StateId",
                table: "Patients",
                column: "StateId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Municipality_MunicipalityId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_State_StateId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MunicipalityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_StateId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Patients");
        }
    }
}
