using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class PoisonDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinDurationDiceSize",
                table: "PoisonDurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinDurationDiceCount",
                table: "PoisonDurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxDurationDiceSize",
                table: "PoisonDurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxDurationDiceCount",
                table: "PoisonDurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaxDurationIndicatorId",
                table: "PoisonDurations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinDurationIndicatorId",
                table: "PoisonDurations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDurations_MaxDurationIndicatorId",
                table: "PoisonDurations",
                column: "MaxDurationIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDurations_MinDurationIndicatorId",
                table: "PoisonDurations",
                column: "MinDurationIndicatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDurations_ActionTimeIndicator_MaxDurationIndicatorId",
                table: "PoisonDurations",
                column: "MaxDurationIndicatorId",
                principalTable: "ActionTimeIndicator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDurations_ActionTimeIndicator_MinDurationIndicatorId",
                table: "PoisonDurations",
                column: "MinDurationIndicatorId",
                principalTable: "ActionTimeIndicator",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDurations_ActionTimeIndicator_MaxDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDurations_ActionTimeIndicator_MinDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.DropIndex(
                name: "IX_PoisonDurations_MaxDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.DropIndex(
                name: "IX_PoisonDurations_MinDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.DropColumn(
                name: "MaxDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.DropColumn(
                name: "MinDurationIndicatorId",
                table: "PoisonDurations");

            migrationBuilder.AlterColumn<int>(
                name: "MinDurationDiceSize",
                table: "PoisonDurations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinDurationDiceCount",
                table: "PoisonDurations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxDurationDiceSize",
                table: "PoisonDurations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxDurationDiceCount",
                table: "PoisonDurations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
