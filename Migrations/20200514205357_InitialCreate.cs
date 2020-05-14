using Microsoft.EntityFrameworkCore.Migrations;

namespace NPWeatherService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    ParkCode = table.Column<string>(maxLength: 5, nullable: false),
                    State = table.Column<string>(maxLength: 25, nullable: false),
                    ParkName = table.Column<string>(maxLength: 35, nullable: false),
                    Acreage = table.Column<int>(nullable: false),
                    ElevationInFeet = table.Column<int>(nullable: false),
                    MilesOfTrail = table.Column<decimal>(type: "decimal(5, 1)", nullable: false),
                    NumberOfCampsites = table.Column<int>(nullable: false),
                    Climate = table.Column<string>(maxLength: 10, nullable: false),
                    YearFounded = table.Column<int>(nullable: false),
                    AnnualVisitorCount = table.Column<int>(nullable: false),
                    EntryFee = table.Column<decimal>(type: "Money", nullable: false),
                    NumberOfAnimalSpecies = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    InspirationalQuote = table.Column<string>(nullable: false),
                    InspirationalQuoteSource = table.Column<string>(maxLength: 25, nullable: false),
                    ParkDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.ParkCode);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkCode = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<int>(maxLength: 2, nullable: false),
                    ActivityLevel = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Park_ParkCode",
                        column: x => x.ParkCode,
                        principalTable: "Park",
                        principalColumn: "ParkCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Survey_ParkCode",
                table: "Survey",
                column: "ParkCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
