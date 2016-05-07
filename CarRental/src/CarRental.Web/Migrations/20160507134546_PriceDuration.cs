using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CarRental.Web.Migrations
{
    public partial class PriceDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "day", table: "Price");
            migrationBuilder.AddColumn<int>(
                name: "dayEnd",
                table: "Price",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "dayFrom",
                table: "Price",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "dayEnd", table: "Price");
            migrationBuilder.DropColumn(name: "dayFrom", table: "Price");
            migrationBuilder.AddColumn<int>(
                name: "day",
                table: "Price",
                nullable: false,
                defaultValue: 0);
        }
    }
}
