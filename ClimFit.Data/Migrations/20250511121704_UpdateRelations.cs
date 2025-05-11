using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimFit.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OutfitSuggestion_WeatherLogId",
                table: "OutfitSuggestion",
                column: "WeatherLogId");

            migrationBuilder.CreateIndex(
                name: "IX_OutfitItem_ClothingItemId",
                table: "OutfitItem",
                column: "ClothingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutfitItem_OutfitSuggestionId",
                table: "OutfitItem",
                column: "OutfitSuggestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutfitItem_ClothingItem_ClothingItemId",
                table: "OutfitItem",
                column: "ClothingItemId",
                principalTable: "ClothingItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutfitItem_OutfitSuggestion_OutfitSuggestionId",
                table: "OutfitItem",
                column: "OutfitSuggestionId",
                principalTable: "OutfitSuggestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutfitSuggestion_WeatherLog_WeatherLogId",
                table: "OutfitSuggestion",
                column: "WeatherLogId",
                principalTable: "WeatherLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutfitItem_ClothingItem_ClothingItemId",
                table: "OutfitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OutfitItem_OutfitSuggestion_OutfitSuggestionId",
                table: "OutfitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OutfitSuggestion_WeatherLog_WeatherLogId",
                table: "OutfitSuggestion");

            migrationBuilder.DropIndex(
                name: "IX_OutfitSuggestion_WeatherLogId",
                table: "OutfitSuggestion");

            migrationBuilder.DropIndex(
                name: "IX_OutfitItem_ClothingItemId",
                table: "OutfitItem");

            migrationBuilder.DropIndex(
                name: "IX_OutfitItem_OutfitSuggestionId",
                table: "OutfitItem");
        }
    }
}
