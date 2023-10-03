using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class PoisonDeliveryMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_Allignments_AllignmentId",
                table: "PoisonDeliveryMethodTranslations");

            migrationBuilder.DropIndex(
                name: "IX_PoisonDeliveryMethodTranslations_AllignmentId",
                table: "PoisonDeliveryMethodTranslations");

            migrationBuilder.DropColumn(
                name: "AllignmentId",
                table: "PoisonDeliveryMethodTranslations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllignmentId",
                table: "PoisonDeliveryMethodTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDeliveryMethodTranslations_AllignmentId",
                table: "PoisonDeliveryMethodTranslations",
                column: "AllignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_Allignments_AllignmentId",
                table: "PoisonDeliveryMethodTranslations",
                column: "AllignmentId",
                principalTable: "Allignments",
                principalColumn: "Id");
        }
    }
}
