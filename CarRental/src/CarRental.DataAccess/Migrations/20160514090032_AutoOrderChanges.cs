using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CarRental.Web.Migrations
{
    public partial class AutoOrderChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Commentd", table: "Order");
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Order",
                nullable: true);
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Order",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Order",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Order",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Order",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Order",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Auto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Comments", table: "Order");
            migrationBuilder.DropColumn(name: "Confirmed", table: "Order");
            migrationBuilder.DropColumn(name: "Email", table: "Order");
            migrationBuilder.DropColumn(name: "Name", table: "Order");
            migrationBuilder.DropColumn(name: "Phone", table: "Order");
            migrationBuilder.DropColumn(name: "Surname", table: "Order");
            migrationBuilder.DropColumn(name: "Model", table: "Auto");
            migrationBuilder.AddColumn<string>(
                name: "Commentd",
                table: "Order",
                nullable: true);
        }
    }
}
