using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActionTimeIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTimeIndicator", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Allignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allignments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alphabets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alphabets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSizeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AttackAndArmorClassModifier = table.Column<int>(type: "int", nullable: false),
                    SpecialAttackModifier = table.Column<int>(type: "int", nullable: false),
                    HideModifier = table.Column<int>(type: "int", nullable: false),
                    HeightOrLengthMin = table.Column<double>(type: "double", nullable: true),
                    HeightOrLengthMax = table.Column<double>(type: "double", nullable: true),
                    WeightMin = table.Column<double>(type: "double", nullable: true),
                    WeightMax = table.Column<double>(type: "double", nullable: true),
                    Space = table.Column<double>(type: "double", nullable: false),
                    NaturalReachTall = table.Column<int>(type: "int", nullable: false),
                    NaturalReachLong = table.Column<int>(type: "int", nullable: false),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSizeCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSubTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Core = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementManeuverabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementManeuverabilities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementModes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Senses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AbbreviationFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponentTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellRangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRangeTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSchools", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellSubSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchools", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateJoined = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActionTimeIndicatorTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActionTimeIndicatorId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTimeIndicatorTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTimeIndicatorTranslation_ActionTimeIndicator_ActionTim~",
                        column: x => x.ActionTimeIndicatorId,
                        principalTable: "ActionTimeIndicator",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AllignmentTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AllignmentId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllignmentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllignmentTranslations_Allignments_AllignmentId",
                        column: x => x.AllignmentId,
                        principalTable: "Allignments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlphabetTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlphabetId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlphabetTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlphabetTranslations_Alphabets_AlphabetId",
                        column: x => x.AlphabetId,
                        principalTable: "Alphabets",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlphabetId = table.Column<int>(type: "int", nullable: true),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Alphabets_AlphabetId",
                        column: x => x.AlphabetId,
                        principalTable: "Alphabets",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSizeCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureSizeCategoryId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSizeCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSizeCategoryTranslations_CreatureSizeCategories_Crea~",
                        column: x => x.CreatureSizeCategoryId,
                        principalTable: "CreatureSizeCategories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSubTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureSubTypeId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSubTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSubTypeTranslations_CreatureSubTypes_CreatureSubType~",
                        column: x => x.CreatureSubTypeId,
                        principalTable: "CreatureSubTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureTypeId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureTypeTranslations_CreatureTypes_CreatureTypeId",
                        column: x => x.CreatureTypeId,
                        principalTable: "CreatureTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RuleBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementManeuverabilityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementManeuverabilityId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementManeuverabilityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementManeuverabilityTranslations_MovementManeuverabilitie~",
                        column: x => x.MovementManeuverabilityId,
                        principalTable: "MovementManeuverabilities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementModeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementModeId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementModeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementModeTranslations_MovementModes_MovementModeId",
                        column: x => x.MovementModeId,
                        principalTable: "MovementModes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SenseTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenseId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenseTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SenseTranslations_Senses_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Senses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellComponentTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellComponentTypeId = table.Column<int>(type: "int", nullable: true),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponentTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellComponentTypeTranslations_SpellComponentTypes_SpellComp~",
                        column: x => x.SpellComponentTypeId,
                        principalTable: "SpellComponentTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellDescriptorTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellDescriptorId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptorTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellDescriptorTranslations_SpellDescriptors_SpellDescriptor~",
                        column: x => x.SpellDescriptorId,
                        principalTable: "SpellDescriptors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellRangeTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellRangeTypeId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRangeTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellRangeTypeTranslations_SpellRangeTypes_SpellRangeTypeId",
                        column: x => x.SpellRangeTypeId,
                        principalTable: "SpellRangeTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellTranslations_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellSchoolTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellSchoolId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSchoolTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellSchoolTranslations_SpellSchools_SpellSchoolId",
                        column: x => x.SpellSchoolId,
                        principalTable: "SpellSchools",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellSubSchoolTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellSubSchoolId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSubSchoolTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellSubSchoolTranslations_SpellSubSchools_SpellSubSchoolId",
                        column: x => x.SpellSubSchoolId,
                        principalTable: "SpellSubSchools",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    TrueAllignmentId = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DisableNonPlaytimeEditing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CharacterName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Allignments_TrueAllignmentId",
                        column: x => x.TrueAllignmentId,
                        principalTable: "Allignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguageTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RuleBookId = table.Column<int>(type: "int", nullable: true),
                    RuleBookPage = table.Column<int>(type: "int", nullable: true),
                    CreatureTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatureSubTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatureSizeCategoryId = table.Column<int>(type: "int", nullable: true),
                    StrengthBonus = table.Column<int>(type: "int", nullable: false),
                    DexterityBonus = table.Column<int>(type: "int", nullable: false),
                    ConstitutionBonus = table.Column<int>(type: "int", nullable: false),
                    IntelligenceBonus = table.Column<int>(type: "int", nullable: false),
                    WisdomBonus = table.Column<int>(type: "int", nullable: false),
                    CharismaBonus = table.Column<int>(type: "int", nullable: false),
                    AdditionalSkillPoints = table.Column<int>(type: "int", nullable: false),
                    LevelAdjustment = table.Column<int>(type: "int", nullable: true),
                    ChallengeRating = table.Column<int>(type: "int", nullable: false),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_CreatureSizeCategories_CreatureSizeCategoryId",
                        column: x => x.CreatureSizeCategoryId,
                        principalTable: "CreatureSizeCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Races_CreatureSubTypes_CreatureSubTypeId",
                        column: x => x.CreatureSubTypeId,
                        principalTable: "CreatureSubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Races_CreatureTypes_CreatureTypeId",
                        column: x => x.CreatureTypeId,
                        principalTable: "CreatureTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Races_RuleBooks_RuleBookId",
                        column: x => x.RuleBookId,
                        principalTable: "RuleBooks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RuleBookTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RuleBookId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleBookTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleBookTranslations_RuleBooks_RuleBookId",
                        column: x => x.RuleBookId,
                        principalTable: "RuleBooks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    RuleBookId = table.Column<int>(type: "int", nullable: true),
                    RuleBookPage = table.Column<int>(type: "int", nullable: true),
                    CastingTimeValue = table.Column<int>(type: "int", nullable: false),
                    CastingTimeIndicatorId = table.Column<int>(type: "int", nullable: true),
                    DescriptionFallback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpellRangeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellVariants_ActionTimeIndicator_CastingTimeIndicatorId",
                        column: x => x.CastingTimeIndicatorId,
                        principalTable: "ActionTimeIndicator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellVariants_RuleBooks_RuleBookId",
                        column: x => x.RuleBookId,
                        principalTable: "RuleBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellVariants_SpellRangeTypes_SpellRangeTypeId",
                        column: x => x.SpellRangeTypeId,
                        principalTable: "SpellRangeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellVariants_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AquiredAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterItems_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharacterItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeatOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    IdList = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatOptions_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceAdditionalLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAdditionalLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceAdditionalLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceAdditionalLanguages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceBonusLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBonusLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceBonusLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceBonusLanguages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceMovementModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    MovementModeId = table.Column<int>(type: "int", nullable: true),
                    MovementManeuverabilityId = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceMovementModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceMovementModes_MovementManeuverabilities_MovementManeuver~",
                        column: x => x.MovementManeuverabilityId,
                        principalTable: "MovementManeuverabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceMovementModes_MovementModes_MovementModeId",
                        column: x => x.MovementModeId,
                        principalTable: "MovementModes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceMovementModes_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceSenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    SenseId = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceSenses_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceSenses_Senses_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Senses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceSpecialAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    FallbackName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallbackDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSpecialAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceSpecialAbilities_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceTranslations_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellComponentTypeId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    MinimalItemGoldValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    CountIndicator = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtherComponentText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtherComponentName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpellVariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellComponents_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellComponents_SpellComponentTypes_SpellComponentTypeId",
                        column: x => x.SpellComponentTypeId,
                        principalTable: "SpellComponentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellComponents_SpellVariants_SpellVariantId",
                        column: x => x.SpellVariantId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellVariantTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpellVariantId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellVariantTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellVariantTranslations_SpellVariants_SpellVariantId",
                        column: x => x.SpellVariantId,
                        principalTable: "SpellVariants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceSpecialAbilityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceSpecialAbilityId = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSpecialAbilityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceSpecialAbilityTranslations_RaceSpecialAbilities_RaceSpec~",
                        column: x => x.RaceSpecialAbilityId,
                        principalTable: "RaceSpecialAbilities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTimeIndicatorTranslation_ActionTimeIndicatorId",
                table: "ActionTimeIndicatorTranslation",
                column: "ActionTimeIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllignmentTranslations_AllignmentId",
                table: "AllignmentTranslations",
                column: "AllignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AlphabetTranslations_AlphabetId",
                table: "AlphabetTranslations",
                column: "AlphabetId");

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
                name: "IX_CreatureSizeCategoryTranslations_CreatureSizeCategoryId",
                table: "CreatureSizeCategoryTranslations",
                column: "CreatureSizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSubTypeTranslations_CreatureSubTypeId",
                table: "CreatureSubTypeTranslations",
                column: "CreatureSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTypeTranslations_CreatureTypeId",
                table: "CreatureTypeTranslations",
                column: "CreatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatOptions_RaceId",
                table: "FeatOptions",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_AlphabetId",
                table: "Languages",
                column: "AlphabetId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTranslations_LanguageId",
                table: "LanguageTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementManeuverabilityTranslations_MovementManeuverabilityId",
                table: "MovementManeuverabilityTranslations",
                column: "MovementManeuverabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementModeTranslations_MovementModeId",
                table: "MovementModeTranslations",
                column: "MovementModeId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAdditionalLanguages_LanguageId",
                table: "RaceAdditionalLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAdditionalLanguages_RaceId",
                table: "RaceAdditionalLanguages",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBonusLanguages_LanguageId",
                table: "RaceBonusLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBonusLanguages_RaceId",
                table: "RaceBonusLanguages",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceMovementModes_MovementManeuverabilityId",
                table: "RaceMovementModes",
                column: "MovementManeuverabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceMovementModes_MovementModeId",
                table: "RaceMovementModes",
                column: "MovementModeId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceMovementModes_RaceId",
                table: "RaceMovementModes",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_CreatureSizeCategoryId",
                table: "Races",
                column: "CreatureSizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_CreatureSubTypeId",
                table: "Races",
                column: "CreatureSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_CreatureTypeId",
                table: "Races",
                column: "CreatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_RuleBookId",
                table: "Races",
                column: "RuleBookId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSenses_RaceId",
                table: "RaceSenses",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSenses_SenseId",
                table: "RaceSenses",
                column: "SenseId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSpecialAbilities_RaceId",
                table: "RaceSpecialAbilities",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSpecialAbilityTranslations_RaceSpecialAbilityId",
                table: "RaceSpecialAbilityTranslations",
                column: "RaceSpecialAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTranslations_RaceId",
                table: "RaceTranslations",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleBooks_EditionId",
                table: "RuleBooks",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleBookTranslations_RuleBookId",
                table: "RuleBookTranslations",
                column: "RuleBookId");

            migrationBuilder.CreateIndex(
                name: "IX_SenseTranslations_SenseId",
                table: "SenseTranslations",
                column: "SenseId");

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
                name: "AlphabetTranslations");

            migrationBuilder.DropTable(
                name: "CharacterItems");

            migrationBuilder.DropTable(
                name: "CreatureSizeCategoryTranslations");

            migrationBuilder.DropTable(
                name: "CreatureSubTypeTranslations");

            migrationBuilder.DropTable(
                name: "CreatureTypeTranslations");

            migrationBuilder.DropTable(
                name: "FeatOptions");

            migrationBuilder.DropTable(
                name: "LanguageTranslations");

            migrationBuilder.DropTable(
                name: "MovementManeuverabilityTranslations");

            migrationBuilder.DropTable(
                name: "MovementModeTranslations");

            migrationBuilder.DropTable(
                name: "RaceAdditionalLanguages");

            migrationBuilder.DropTable(
                name: "RaceBonusLanguages");

            migrationBuilder.DropTable(
                name: "RaceMovementModes");

            migrationBuilder.DropTable(
                name: "RaceSenses");

            migrationBuilder.DropTable(
                name: "RaceSpecialAbilityTranslations");

            migrationBuilder.DropTable(
                name: "RaceTranslations");

            migrationBuilder.DropTable(
                name: "RuleBookTranslations");

            migrationBuilder.DropTable(
                name: "SenseTranslations");

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
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MovementManeuverabilities");

            migrationBuilder.DropTable(
                name: "MovementModes");

            migrationBuilder.DropTable(
                name: "RaceSpecialAbilities");

            migrationBuilder.DropTable(
                name: "Senses");

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
                name: "Alphabets");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "ActionTimeIndicator");

            migrationBuilder.DropTable(
                name: "SpellRangeTypes");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "CreatureSizeCategories");

            migrationBuilder.DropTable(
                name: "CreatureSubTypes");

            migrationBuilder.DropTable(
                name: "CreatureTypes");

            migrationBuilder.DropTable(
                name: "RuleBooks");

            migrationBuilder.DropTable(
                name: "Editions");
        }
    }
}
