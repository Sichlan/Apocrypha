using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ProperForeignAnnotationPoison5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId",
                principalTable: "PoisonDurations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId",
                principalTable: "PoisonDurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
