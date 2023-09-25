using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class PoisonPhaseDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhases_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId",
                principalTable: "PoisonDurations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases");

            migrationBuilder.DropIndex(
                name: "IX_PoisonPhases_PoisonPhaseDurationId",
                table: "PoisonPhases");

            migrationBuilder.DropColumn(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases");
        }
    }
}
