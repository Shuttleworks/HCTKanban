using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCTKanban.Migrations
{
    /// <inheritdoc />
    public partial class birdboxtype_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BirdBox_BirdBoxTypeId",
                table: "BirdBox",
                column: "BirdBoxTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdBox_BirdBoxType_BirdBoxTypeId",
                table: "BirdBox",
                column: "BirdBoxTypeId",
                principalTable: "BirdBoxType",
                principalColumn: "BirdBoxTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdBox_BirdBoxType_BirdBoxTypeId",
                table: "BirdBox");

            migrationBuilder.DropIndex(
                name: "IX_BirdBox_BirdBoxTypeId",
                table: "BirdBox");
        }
    }
}
