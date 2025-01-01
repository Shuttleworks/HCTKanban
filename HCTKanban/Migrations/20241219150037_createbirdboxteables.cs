using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCTKanban.Migrations
{
    /// <inheritdoc />
    public partial class createbirdboxteables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirdBox",
                columns: table => new
                {
                    BirdBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BirdBoxTypeId = table.Column<int>(type: "int", nullable: false),
                    BirdBoxStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdBox", x => x.BirdBoxId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BirdBoxType",
                columns: table => new
                {
                    BirdBoxTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BirdBoxName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdBoxType", x => x.BirdBoxTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.InsertData(
				table: "BirdBoxType",
				columns: new[] { "BirdBoxTypeId", "BirdBoxName" },
				values: new object[,]
				{
					{ 1, "Barn Owl" },
					{ 2, "Tawny" },
					{ 3, "Kestrel" }
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirdBox");

            migrationBuilder.DropTable(
                name: "BirdBoxType");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
