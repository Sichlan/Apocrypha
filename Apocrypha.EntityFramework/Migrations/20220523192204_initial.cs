using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTimeIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTimeIndicator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    System = table.Column<string>(type: "text", nullable: true),
                    Core = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true),
                    AbbreviationFallback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellRangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true)
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "text", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionTimeIndicatorTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActionTimeIndicatorId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTimeIndicatorTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTimeIndicatorTranslation_ActionTimeIndicator_ActionTim~",
                        column: x => x.ActionTimeIndicatorId,
                        principalTable: "ActionTimeIndicator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllignmentTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AllignmentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllignmentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllignmentTranslations_Allignments_AllignmentId",
                        column: x => x.AllignmentId,
                        principalTable: "Allignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuleBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleBooks_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
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
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    TrueAllignmentId = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DisableNonPlaytimeEditing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CharacterName = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Allignments_TrueAllignmentId",
                        column: x => x.TrueAllignmentId,
                        principalTable: "Allignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
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
                    CastingTimeIndicatorId = table.Column<int>(type: "int", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "text", nullable: true),
                    SpellRangeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellVariants_ActionTimeIndicator_CastingTimeIndicatorId",
                        column: x => x.CastingTimeIndicatorId,
                        principalTable: "ActionTimeIndicator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "CharacterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AquiredAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterItems_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
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
                name: "SpellDescriptorSpellVariant",
                columns: table => new
                {
                    SpellDescriptorsId = table.Column<int>(type: "int", nullable: false),
                    SpellVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptorSpellVariant", x => new { x.SpellDescriptorsId, x.SpellVariantsId });
                    table.ForeignKey(
                        name: "FK_SpellDescriptorSpellVariant_SpellDescriptors_SpellDescriptor~",
                        column: x => x.SpellDescriptorsId,
                        principalTable: "SpellDescriptors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellDescriptorSpellVariant_SpellVariants_SpellVariantsId",
                        column: x => x.SpellVariantsId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ActionTimeIndicatorTranslation_ActionTimeIndicatorId",
                table: "ActionTimeIndicatorTranslation",
                column: "ActionTimeIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllignmentTranslations_AllignmentId",
                table: "AllignmentTranslations",
                column: "AllignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItems_ItemId",
                table: "CharacterItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItems_OwnerId",
                table: "CharacterItems",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CreatorUserId",
                table: "Characters",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TrueAllignmentId",
                table: "Characters",
                column: "TrueAllignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleBooks_EditionId",
                table: "RuleBooks",
                column: "EditionId");

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
                name: "IX_SpellDescriptorSpellVariant_SpellVariantsId",
                table: "SpellDescriptorSpellVariant",
                column: "SpellVariantsId");

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
                name: "IX_SpellVariants_CastingTimeIndicatorId",
                table: "SpellVariants",
                column: "CastingTimeIndicatorId");

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
                name: "ActionTimeIndicatorTranslation");

            migrationBuilder.DropTable(
                name: "AllignmentTranslations");

            migrationBuilder.DropTable(
                name: "CharacterItems");

            migrationBuilder.DropTable(
                name: "SpellComponents");

            migrationBuilder.DropTable(
                name: "SpellComponentTypeTranslations");

            migrationBuilder.DropTable(
                name: "SpellDescriptorSpellVariant");

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
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Items");

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
                name: "Allignments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ActionTimeIndicator");

            migrationBuilder.DropTable(
                name: "RuleBooks");

            migrationBuilder.DropTable(
                name: "SpellRangeTypes");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Editions");
        }
    }
}
