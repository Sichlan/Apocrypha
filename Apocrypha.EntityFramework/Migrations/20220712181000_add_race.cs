using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations
{
    public partial class add_race : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleBookTranslation_RuleBooks_RuleBookId",
                table: "RuleBookTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RuleBookTranslation",
                table: "RuleBookTranslation");

            migrationBuilder.RenameTable(
                name: "RuleBookTranslation",
                newName: "RuleBookTranslations");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RuleBooks",
                newName: "FallbackDescription");

            migrationBuilder.RenameIndex(
                name: "IX_RuleBookTranslation_RuleBookId",
                table: "RuleBookTranslations",
                newName: "IX_RuleBookTranslations_RuleBookId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RuleBookTranslations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RuleBookTranslations",
                table: "RuleBookTranslations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Alphabets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
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
                name: "AlphabetTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlphabetId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlphabetTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlphabetTranslations_Alphabets_AlphabetId",
                        column: x => x.AlphabetId,
                        principalTable: "Alphabets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSizeCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureSizeCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSizeCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSizeCategoryTranslations_CreatureSizeCategories_Crea~",
                        column: x => x.CreatureSizeCategoryId,
                        principalTable: "CreatureSizeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureSubTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureSubTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSubTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSubTypeTranslations_CreatureSubTypes_CreatureSubType~",
                        column: x => x.CreatureSubTypeId,
                        principalTable: "CreatureSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreatureTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatureTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureTypeTranslations_CreatureTypes_CreatureTypeId",
                        column: x => x.CreatureTypeId,
                        principalTable: "CreatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RuleBookId = table.Column<int>(type: "int", nullable: true),
                    Page = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    SubTypeId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Races_CreatureSizeCategories_SizeId",
                        column: x => x.SizeId,
                        principalTable: "CreatureSizeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_CreatureSubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "CreatureSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_CreatureTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CreatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_RuleBooks_RuleBookId",
                        column: x => x.RuleBookId,
                        principalTable: "RuleBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementManeuverabilityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementManeuverabilityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementManeuverabilityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementManeuverabilityTranslations_MovementManeuverabilitie~",
                        column: x => x.MovementManeuverabilityId,
                        principalTable: "MovementManeuverabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementModeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementModeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementModeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementModeTranslations_MovementModes_MovementModeId",
                        column: x => x.MovementModeId,
                        principalTable: "MovementModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SenseTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenseId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenseTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SenseTranslations_Senses_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Senses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguageTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeatOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdList = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatOptions_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceAdditionalLanguages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceBonusLanguages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceMovementModes_MovementModes_MovementModeId",
                        column: x => x.MovementModeId,
                        principalTable: "MovementModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceMovementModes_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceSenses_Senses_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Senses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceTranslations_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceSpecialAbilityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceSpecialAbilityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CultureName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSpecialAbilityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceSpecialAbilityTranslations_RaceSpecialAbilities_RaceSpec~",
                        column: x => x.RaceSpecialAbilityId,
                        principalTable: "RaceSpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlphabetTranslations_AlphabetId",
                table: "AlphabetTranslations",
                column: "AlphabetId");

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
                name: "IX_Races_RuleBookId",
                table: "Races",
                column: "RuleBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_SizeId",
                table: "Races",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_SubTypeId",
                table: "Races",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_TypeId",
                table: "Races",
                column: "TypeId");

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
                name: "IX_SenseTranslations_SenseId",
                table: "SenseTranslations",
                column: "SenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleBookTranslations_RuleBooks_RuleBookId",
                table: "RuleBookTranslations",
                column: "RuleBookId",
                principalTable: "RuleBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleBookTranslations_RuleBooks_RuleBookId",
                table: "RuleBookTranslations");

            migrationBuilder.DropTable(
                name: "AlphabetTranslations");

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
                name: "SenseTranslations");

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
                name: "Alphabets");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "CreatureSizeCategories");

            migrationBuilder.DropTable(
                name: "CreatureSubTypes");

            migrationBuilder.DropTable(
                name: "CreatureTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RuleBookTranslations",
                table: "RuleBookTranslations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RuleBookTranslations");

            migrationBuilder.RenameTable(
                name: "RuleBookTranslations",
                newName: "RuleBookTranslation");

            migrationBuilder.RenameColumn(
                name: "FallbackDescription",
                table: "RuleBooks",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_RuleBookTranslations_RuleBookId",
                table: "RuleBookTranslation",
                newName: "IX_RuleBookTranslation_RuleBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RuleBookTranslation",
                table: "RuleBookTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleBookTranslation_RuleBooks_RuleBookId",
                table: "RuleBookTranslation",
                column: "RuleBookId",
                principalTable: "RuleBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
