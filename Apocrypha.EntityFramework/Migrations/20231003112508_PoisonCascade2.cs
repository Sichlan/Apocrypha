using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PoisonCascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDamageTargetTranslations_PoisonDamageTargets_PoisonDam~",
                table: "PoisonDamageTargetTranslations");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_PoisonDeliveryMethods_Poiso~",
                table: "PoisonDeliveryMethodTranslations");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_FK_PoisonPhaseElements_Pois~",
                table: "PoisonPhaseElements");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_Poisons_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Poisons_PoisonDeliveryMethods_DeliveryMethodId",
                table: "Poisons");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonSpecialEffectTranslations_PoisonSpecialEffects_PoisonS~",
                table: "PoisonSpecialEffectTranslations");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonTranslations_Poisons_FK_PoisonTranslations_Poisons_Poi~",
                table: "PoisonTranslations");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
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
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonId",
                table: "PoisonTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonSpecialEffectId",
                table: "PoisonSpecialEffectTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonId",
                table: "PoisonPhases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseId",
                table: "PoisonPhaseElements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonDeliveryMethodId",
                table: "PoisonDeliveryMethodTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<int>(
                name: "PoisonDamageTargetId",
                table: "PoisonDamageTargetTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            
            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDamageTargetTranslations_PoisonDamageTargets_PoisonDam~",
                table: "PoisonDamageTargetTranslations",
                column: "PoisonDamageTargetId",
                principalTable: "PoisonDamageTargets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            
            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_PoisonDeliveryMethods_Poiso~",
                table: "PoisonDeliveryMethodTranslations",
                column: "PoisonDeliveryMethodId",
                principalTable: "PoisonDeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements",
                column: "PoisonPhaseId",
                principalTable: "PoisonPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId",
                principalTable: "PoisonDurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                column: "PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poisons_PoisonDeliveryMethods_DeliveryMethodId",
                table: "Poisons",
                column: "DeliveryMethodId",
                principalTable: "PoisonDeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonSpecialEffectTranslations_PoisonSpecialEffects_PoisonS~",
                table: "PoisonSpecialEffectTranslations",
                column: "PoisonSpecialEffectId",
                principalTable: "PoisonSpecialEffects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations",
                column: "PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDamageTargetTranslations_PoisonDamageTargets_PoisonDam~",
                table: "PoisonDamageTargetTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_PoisonDeliveryMethods_Poiso~",
                table: "PoisonDeliveryMethodTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_Poisons_PoisonDeliveryMethods_DeliveryMethodId",
                table: "Poisons");

            migrationBuilder.DropForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonSpecialEffectTranslations_PoisonSpecialEffects_PoisonS~",
                table: "PoisonSpecialEffectTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonId",
                table: "PoisonTranslations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoisonSpecialEffectId",
                table: "PoisonSpecialEffectTranslations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseDurationId",
                table: "PoisonPhases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonId",
                table: "PoisonPhases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoisonPhaseId",
                table: "PoisonPhaseElements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoisonDeliveryMethodId",
                table: "PoisonDeliveryMethodTranslations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PoisonDamageTargetId",
                table: "PoisonDamageTargetTranslations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_PoisonDamageTargetTranslations_PoisonDamageTargets_PoisonDam~",
                table: "PoisonDamageTargetTranslations",
                column: "PoisonDamageTargetId",
                principalTable: "PoisonDamageTargets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonDeliveryMethodTranslations_PoisonDeliveryMethods_Poiso~",
                table: "PoisonDeliveryMethodTranslations",
                column: "PoisonDeliveryMethodId",
                principalTable: "PoisonDeliveryMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_FK_PoisonPhaseElements_Pois~",
                table: "PoisonPhaseElements",
                column: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                principalTable: "PoisonPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                table: "PoisonPhaseElements",
                column: "PoisonPhaseId",
                principalTable: "PoisonPhases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_PoisonDurations_PoisonPhaseDurationId",
                table: "PoisonPhases",
                column: "PoisonPhaseDurationId",
                principalTable: "PoisonDurations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_Poisons_FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                column: "FK_PoisonPhases_Poisons_PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonPhases_Poisons_PoisonId",
                table: "PoisonPhases",
                column: "PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Poisons_PoisonDeliveryMethods_DeliveryMethodId",
                table: "Poisons",
                column: "DeliveryMethodId",
                principalTable: "PoisonDeliveryMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Poisons_Users_CreatorId",
                table: "Poisons",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonSpecialEffectTranslations_PoisonSpecialEffects_PoisonS~",
                table: "PoisonSpecialEffectTranslations",
                column: "PoisonSpecialEffectId",
                principalTable: "PoisonSpecialEffects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonTranslations_Poisons_FK_PoisonTranslations_Poisons_Poi~",
                table: "PoisonTranslations",
                column: "FK_PoisonTranslations_Poisons_PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonTranslations_Poisons_PoisonId",
                table: "PoisonTranslations",
                column: "PoisonId",
                principalTable: "Poisons",
                principalColumn: "Id");
        }
    }
}
