using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class PoisonCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoisonTranslations_FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations",
                column: "FK_PoisonTranslations_Poisons_PoisonId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhases_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                column: "FK_PoisonPhases_Poisons_PoisonId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_FK_PoisonPhaseElements_PoisonPhases_Pois~",
                table: "PoisonPhaseElements",
                column: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_FK_PoisonPhaseElements_Pois~",
                table: "PoisonPhaseElements",
                column: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                principalTable: "PoisonPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_Poisons_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                column: "FK_PoisonPhases_Poisons_PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonTranslations_Poisons_FK_PoisonTranslations_Poisons_Poi~",
                table: "PoisonTranslations",
                column: "FK_PoisonTranslations_Poisons_PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_FK_PoisonPhaseElements_Pois~",
                table: "PoisonPhaseElements");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_Poisons_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonTranslations_Poisons_FK_PoisonTranslations_Poisons_Poi~",
                table: "PoisonTranslations");

            migrationBuilder.DropIndex(
                name: "IX_PoisonTranslations_FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations");

            migrationBuilder.DropIndex(
                name: "IX_PoisonPhases_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");

            migrationBuilder.DropIndex(
                name: "IX_PoisonPhaseElements_FK_PoisonPhaseElements_PoisonPhases_Pois~",
                table: "PoisonPhaseElements");

            migrationBuilder.DropColumn(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations");

            migrationBuilder.DropColumn(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");

            migrationBuilder.DropColumn(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements");
        }
    }
}
