using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class Spells1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpellComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellRangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRangeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellSubSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellComponentTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellComponentTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponentTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellComponentTypeTranslations_SpellComponentTypes_SpellComp~",
                        column: x => x.SpellComponentTypeId,
                        principalTable: "SpellComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellRangeTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellRangeTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRangeTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellRangeTypeTranslations_SpellRangeTypes_SpellRangeTypeId",
                        column: x => x.SpellRangeTypeId,
                        principalTable: "SpellRangeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellTranslations_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    RuleBookId = table.Column<int>(type: "int", nullable: true),
                    RuleBookPage = table.Column<int>(type: "int", nullable: true),
                    CastingTimeValue = table.Column<int>(type: "int", nullable: false),
                    SpellRangeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellVariants_RuleBooks_RuleBookId",
                        column: x => x.RuleBookId,
                        principalTable: "RuleBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellVariants_SpellRangeTypes_SpellRangeTypeId",
                        column: x => x.SpellRangeTypeId,
                        principalTable: "SpellRangeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellVariants_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellSchoolTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellSchoolId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSchoolTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellSchoolTranslations_SpellSchools_SpellSchoolId",
                        column: x => x.SpellSchoolId,
                        principalTable: "SpellSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellSubSchoolTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellSubSchoolId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchoolTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellSubSchoolTranslations_SpellSubSchools_SpellSubSchoolId",
                        column: x => x.SpellSubSchoolId,
                        principalTable: "SpellSubSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellComponentTypeId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    MinimalItemGoldValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    CountIndicator = table.Column<string>(type: "text", nullable: true),
                    OtherComponentText = table.Column<string>(type: "text", nullable: true),
                    OtherComponentName = table.Column<string>(type: "text", nullable: true),
                    SpellVariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellComponents_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellComponents_SpellComponentTypes_SpellComponentTypeId",
                        column: x => x.SpellComponentTypeId,
                        principalTable: "SpellComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellComponents_SpellVariants_SpellVariantId",
                        column: x => x.SpellVariantId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellVariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellDescriptors_SpellVariants_SpellVariantId",
                        column: x => x.SpellVariantId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellSchoolSpellVariant",
                columns: table => new
                {
                    SpellSchoolsId = table.Column<int>(type: "int", nullable: false),
                    SpellVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSchoolSpellVariant", x => new { x.SpellSchoolsId, x.SpellVariantsId });
                    table.ForeignKey(
                        name: "FK_SpellSchoolSpellVariant_SpellSchools_SpellSchoolsId",
                        column: x => x.SpellSchoolsId,
                        principalTable: "SpellSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellSchoolSpellVariant_SpellVariants_SpellVariantsId",
                        column: x => x.SpellVariantsId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellSubSchoolSpellVariant",
                columns: table => new
                {
                    SpellSubSchoolsId = table.Column<int>(type: "int", nullable: false),
                    SpellVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchoolSpellVariant", x => new { x.SpellSubSchoolsId, x.SpellVariantsId });
                    table.ForeignKey(
                        name: "FK_SpellSubSchoolSpellVariant_SpellSubSchools_SpellSubSchoolsId",
                        column: x => x.SpellSubSchoolsId,
                        principalTable: "SpellSubSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellSubSchoolSpellVariant_SpellVariants_SpellVariantsId",
                        column: x => x.SpellVariantsId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellVariantTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellVariantId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellVariantTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellVariantTranslations_SpellVariants_SpellVariantId",
                        column: x => x.SpellVariantId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellDescriptorTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpellDescriptorId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptorTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellDescriptorTranslations_SpellDescriptors_SpellDescriptor~",
                        column: x => x.SpellDescriptorId,
                        principalTable: "SpellDescriptors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponents_ItemId",
                table: "SpellComponents",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponents_SpellComponentTypeId",
                table: "SpellComponents",
                column: "SpellComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponents_SpellVariantId",
                table: "SpellComponents",
                column: "SpellVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellComponentTypeTranslations_SpellComponentTypeId",
                table: "SpellComponentTypeTranslations",
                column: "SpellComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellDescriptors_SpellVariantId",
                table: "SpellDescriptors",
                column: "SpellVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellDescriptorTranslations_SpellDescriptorId",
                table: "SpellDescriptorTranslations",
                column: "SpellDescriptorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellRangeTypeTranslations_SpellRangeTypeId",
                table: "SpellRangeTypeTranslations",
                column: "SpellRangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSchoolSpellVariant_SpellVariantsId",
                table: "SpellSchoolSpellVariant",
                column: "SpellVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSchoolTranslations_SpellSchoolId",
                table: "SpellSchoolTranslations",
                column: "SpellSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSubSchoolSpellVariant_SpellVariantsId",
                table: "SpellSubSchoolSpellVariant",
                column: "SpellVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSubSchoolTranslations_SpellSubSchoolId",
                table: "SpellSubSchoolTranslations",
                column: "SpellSubSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellTranslations_SpellId",
                table: "SpellTranslations",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellVariants_RuleBookId",
                table: "SpellVariants",
                column: "RuleBookId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellVariants_SpellId",
                table: "SpellVariants",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellVariants_SpellRangeTypeId",
                table: "SpellVariants",
                column: "SpellRangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellVariantTranslations_SpellVariantId",
                table: "SpellVariantTranslations",
                column: "SpellVariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellComponents");

            migrationBuilder.DropTable(
                name: "SpellComponentTypeTranslations");

            migrationBuilder.DropTable(
                name: "SpellDescriptorTranslations");

            migrationBuilder.DropTable(
                name: "SpellRangeTypeTranslations");

            migrationBuilder.DropTable(
                name: "SpellSchoolSpellVariant");

            migrationBuilder.DropTable(
                name: "SpellSchoolTranslations");

            migrationBuilder.DropTable(
                name: "SpellSubSchoolSpellVariant");

            migrationBuilder.DropTable(
                name: "SpellSubSchoolTranslations");

            migrationBuilder.DropTable(
                name: "SpellTranslations");

            migrationBuilder.DropTable(
                name: "SpellVariantTranslations");

            migrationBuilder.DropTable(
                name: "SpellComponentTypes");

            migrationBuilder.DropTable(
                name: "SpellDescriptors");

            migrationBuilder.DropTable(
                name: "SpellSchools");

            migrationBuilder.DropTable(
                name: "SpellSubSchools");

            migrationBuilder.DropTable(
                name: "SpellVariants");

            migrationBuilder.DropTable(
                name: "SpellRangeTypes");

            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
