using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCTKanban.Migrations
{
    /// <inheritdoc />
    public partial class jsidentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JSidentifier",
                table: "BirdBox",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.InsertData(
				table: "Status",
				columns: new[] { "StatusId", "Name" },
				values: new object[,]
				{
					{ 1, "To do" },
					{ 2, "In Progress" },
					{ 3, "Complete (in workshop)" },
					{ 4, "In Storeroom" }
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JSidentifier",
                table: "BirdBox");
        }
    }
}
