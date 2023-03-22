using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class AddedHospitalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipalityId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MaxBedsCount = table.Column<int>(nullable: false),
                    AvailableBedsCount = table.Column<int>(nullable: false),
                    MaxVentilatorCount = table.Column<int>(nullable: false),
                    AvailableVentilatorCount = table.Column<int>(nullable: false),
                    MaxICUBedsCount = table.Column<int>(nullable: false),
                    AvailableICUBedsCount = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_UserId",
                table: "Hospitals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipalityId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Municipalities_MunicipalityId",
                table: "Patients",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
