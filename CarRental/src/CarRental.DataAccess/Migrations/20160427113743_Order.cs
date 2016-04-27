using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CarRental.Web.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    AutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<bool>(nullable: false),
                    AudioCode = table.Column<string>(nullable: true),
                    CascoInsurenceEnd = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true),
                    EngineCapicity = table.Column<float>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    Gearbox = table.Column<string>(nullable: true),
                    InsurenceEnd = table.Column<DateTime>(nullable: false),
                    MainBelt = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Milleage = table.Column<int>(nullable: false),
                    OilChange = table.Column<int>(nullable: false),
                    PlateNumber = table.Column<string>(nullable: true),
                    TAEnd = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.AutoId);
                });
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoId = table.Column<int>(nullable: false),
                    Commentd = table.Column<string>(nullable: true),
                    DayPrice = table.Column<decimal>(nullable: false),
                    DeliveryPrice = table.Column<string>(nullable: true),
                    OrderEnd = table.Column<DateTime>(nullable: false),
                    OrderStart = table.Column<DateTime>(nullable: false),
                    RentPlace = table.Column<string>(nullable: true),
                    RentReturn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Auto");
            migrationBuilder.DropTable("Order");
        }
    }
}
