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
            migrationBuilder.DropTable("Order");
        }
    }
}
