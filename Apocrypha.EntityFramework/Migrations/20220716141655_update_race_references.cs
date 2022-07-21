using Microsoft.EntityFrameworkCore.Migrations;

namespace Apocrypha.EntityFramework.Migrations;

public partial class update_race_references : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureSizeCategories_SizeId",
            table: "Races");

        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureSubTypes_SubTypeId",
            table: "Races");

        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureTypes_TypeId",
            table: "Races");

        migrationBuilder.RenameColumn(
            name: "TypeId",
            table: "Races",
            newName: "CreatureTypeId");

        migrationBuilder.RenameColumn(
            name: "SubTypeId",
            table: "Races",
            newName: "CreatureSubTypeId");

        migrationBuilder.RenameColumn(
            name: "SizeId",
            table: "Races",
            newName: "CreatureSizeCategoryId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_TypeId",
            table: "Races",
            newName: "IX_Races_CreatureTypeId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_SubTypeId",
            table: "Races",
            newName: "IX_Races_CreatureSubTypeId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_SizeId",
            table: "Races",
            newName: "IX_Races_CreatureSizeCategoryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureSizeCategories_CreatureSizeCategoryId",
            table: "Races",
            column: "CreatureSizeCategoryId",
            principalTable: "CreatureSizeCategories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureSubTypes_CreatureSubTypeId",
            table: "Races",
            column: "CreatureSubTypeId",
            principalTable: "CreatureSubTypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureTypes_CreatureTypeId",
            table: "Races",
            column: "CreatureTypeId",
            principalTable: "CreatureTypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureSizeCategories_CreatureSizeCategoryId",
            table: "Races");

        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureSubTypes_CreatureSubTypeId",
            table: "Races");

        migrationBuilder.DropForeignKey(
            name: "FK_Races_CreatureTypes_CreatureTypeId",
            table: "Races");

        migrationBuilder.RenameColumn(
            name: "CreatureTypeId",
            table: "Races",
            newName: "TypeId");

        migrationBuilder.RenameColumn(
            name: "CreatureSubTypeId",
            table: "Races",
            newName: "SubTypeId");

        migrationBuilder.RenameColumn(
            name: "CreatureSizeCategoryId",
            table: "Races",
            newName: "SizeId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_CreatureTypeId",
            table: "Races",
            newName: "IX_Races_TypeId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_CreatureSubTypeId",
            table: "Races",
            newName: "IX_Races_SubTypeId");

        migrationBuilder.RenameIndex(
            name: "IX_Races_CreatureSizeCategoryId",
            table: "Races",
            newName: "IX_Races_SizeId");

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureSizeCategories_SizeId",
            table: "Races",
            column: "SizeId",
            principalTable: "CreatureSizeCategories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureSubTypes_SubTypeId",
            table: "Races",
            column: "SubTypeId",
            principalTable: "CreatureSubTypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Races_CreatureTypes_TypeId",
            table: "Races",
            column: "TypeId",
            principalTable: "CreatureTypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}
