using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class Poisons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PoisonCraftModifier = table.Column<int>(type: "int", nullable: true),
                    WithoutDuration = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonDamageTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CraftModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonDamageTargets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonDeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CraftDifficultyClassModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonDeliveryMethods", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonDurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinDurationDiceCount = table.Column<int>(type: "int", nullable: false),
                    MinDurationDiceSize = table.Column<int>(type: "int", nullable: false),
                    MaxDurationDiceCount = table.Column<int>(type: "int", nullable: false),
                    MaxDurationDiceSize = table.Column<int>(type: "int", nullable: false),
                    CraftModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonDurations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonSpecialEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CraftModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonSpecialEffects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConditionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionTranslations_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonDamageTargetTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PoisonDamageTargetId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonDamageTargetTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonDamageTargetTranslations_PoisonDamageTargets_PoisonDam~",
                        column: x => x.PoisonDamageTargetId,
                        principalTable: "PoisonDamageTargets",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonDeliveryMethodTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AllignmentId = table.Column<int>(type: "int", nullable: true),
                    PoisonDeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonDeliveryMethodTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonDeliveryMethodTranslations_Allignments_AllignmentId",
                        column: x => x.AllignmentId,
                        principalTable: "Allignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoisonDeliveryMethodTranslations_PoisonDeliveryMethods_Poiso~",
                        column: x => x.PoisonDeliveryMethodId,
                        principalTable: "PoisonDeliveryMethods",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Poisons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    Toxicity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poisons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poisons_PoisonDeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "PoisonDeliveryMethods",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonSpecialEffectTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PoisonSpecialEffectId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonSpecialEffectTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonSpecialEffectTranslations_PoisonSpecialEffects_PoisonS~",
                        column: x => x.PoisonSpecialEffectId,
                        principalTable: "PoisonSpecialEffects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonPhases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PoisonId = table.Column<int>(type: "int", nullable: true),
                    PhaseNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonPhases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonPhases_Poisons_PoisonId",
                        column: x => x.PoisonId,
                        principalTable: "Poisons",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PoisonId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonTranslations_Poisons_PoisonId",
                        column: x => x.PoisonId,
                        principalTable: "Poisons",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PoisonPhaseElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PoisonPhaseId = table.Column<int>(type: "int", nullable: true),
                    DamageDiceCount = table.Column<int>(type: "int", nullable: true),
                    DamageDiceSize = table.Column<int>(type: "int", nullable: true),
                    PoisonDamageTargetId = table.Column<int>(type: "int", nullable: true),
                    PoisonDurationId = table.Column<int>(type: "int", nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    PoisonSpecialEffectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonPhaseElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonPhaseElements_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoisonPhaseElements_PoisonDamageTargets_PoisonDamageTargetId",
                        column: x => x.PoisonDamageTargetId,
                        principalTable: "PoisonDamageTargets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoisonPhaseElements_PoisonDurations_PoisonDurationId",
                        column: x => x.PoisonDurationId,
                        principalTable: "PoisonDurations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoisonPhaseElements_PoisonPhases_PoisonPhaseId",
                        column: x => x.PoisonPhaseId,
                        principalTable: "PoisonPhases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoisonPhaseElements_PoisonSpecialEffects_PoisonSpecialEffect~",
                        column: x => x.PoisonSpecialEffectId,
                        principalTable: "PoisonSpecialEffects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionTranslations_ConditionId",
                table: "ConditionTranslations",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDamageTargetTranslations_PoisonDamageTargetId",
                table: "PoisonDamageTargetTranslations",
                column: "PoisonDamageTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDeliveryMethodTranslations_AllignmentId",
                table: "PoisonDeliveryMethodTranslations",
                column: "AllignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonDeliveryMethodTranslations_PoisonDeliveryMethodId",
                table: "PoisonDeliveryMethodTranslations",
                column: "PoisonDeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_ConditionId",
                table: "PoisonPhaseElements",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_PoisonDamageTargetId",
                table: "PoisonPhaseElements",
                column: "PoisonDamageTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_PoisonDurationId",
                table: "PoisonPhaseElements",
                column: "PoisonDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_PoisonPhaseId",
                table: "PoisonPhaseElements",
                column: "PoisonPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhaseElements_PoisonSpecialEffectId",
                table: "PoisonPhaseElements",
                column: "PoisonSpecialEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonPhases_PoisonId",
                table: "PoisonPhases",
                column: "PoisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Poisons_DeliveryMethodId",
                table: "Poisons",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonSpecialEffectTranslations_PoisonSpecialEffectId",
                table: "PoisonSpecialEffectTranslations",
                column: "PoisonSpecialEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonTranslations_PoisonId",
                table: "PoisonTranslations",
                column: "PoisonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionTranslations");

            migrationBuilder.DropTable(
                name: "PoisonDamageTargetTranslations");

            migrationBuilder.DropTable(
                name: "PoisonDeliveryMethodTranslations");

            migrationBuilder.DropTable(
                name: "PoisonPhaseElements");

            migrationBuilder.DropTable(
                name: "PoisonSpecialEffectTranslations");

            migrationBuilder.DropTable(
                name: "PoisonTranslations");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "PoisonDamageTargets");

            migrationBuilder.DropTable(
                name: "PoisonDurations");

            migrationBuilder.DropTable(
                name: "PoisonPhases");

            migrationBuilder.DropTable(
                name: "PoisonSpecialEffects");

            migrationBuilder.DropTable(
                name: "Poisons");

            migrationBuilder.DropTable(
                name: "PoisonDeliveryMethods");
        }
    }
}
