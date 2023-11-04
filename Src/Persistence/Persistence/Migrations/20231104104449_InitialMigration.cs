using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    airportname = table.Column<string>(name: "airport_name", type: "varchar(200)", maxLength: 200, nullable: true),
                    iatacode = table.Column<string>(name: "iata_code", type: "longtext", nullable: true),
                    icaocode = table.Column<string>(name: "icao_code", type: "longtext", nullable: true),
                    latitude = table.Column<string>(type: "longtext", nullable: true),
                    longitude = table.Column<string>(type: "longtext", nullable: true),
                    geonameid = table.Column<string>(name: "geoname_id", type: "longtext", nullable: true),
                    timezone = table.Column<string>(type: "longtext", nullable: true),
                    gmt = table.Column<string>(type: "longtext", nullable: true),
                    phonenumber = table.Column<string>(name: "phone_number", type: "longtext", nullable: true),
                    countryname = table.Column<string>(name: "country_name", type: "longtext", nullable: true),
                    countryiso2 = table.Column<string>(name: "country_iso2", type: "longtext", nullable: true),
                    cityiatacode = table.Column<string>(name: "city_iata_code", type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    flightdate = table.Column<DateOnly>(name: "flight_date", type: "date", nullable: false),
                    flightstatus = table.Column<string>(name: "flight_status", type: "longtext", nullable: true),
                    airportname = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
