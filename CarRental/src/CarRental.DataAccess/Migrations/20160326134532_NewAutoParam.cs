using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CarRental.Web.Migrations
{
    public partial class NewAutoParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activity",
                table: "Auto",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "AudioCode",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "CascoInsurenceEnd",
                table: "Auto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<float>(
                name: "EngineCapicity",
                table: "Auto",
                nullable: false,
                defaultValue: 0f);
            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Gearbox",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "InsurenceEnd",
                table: "Auto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "MainBelt",
                table: "Auto",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Milleage",
                table: "Auto",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "OilChange",
                table: "Auto",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Auto",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "TAEnd",
                table: "Auto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Activity", table: "Auto");
            migrationBuilder.DropColumn(name: "AudioCode", table: "Auto");
            migrationBuilder.DropColumn(name: "CascoInsurenceEnd", table: "Auto");
            migrationBuilder.DropColumn(name: "Color", table: "Auto");
            migrationBuilder.DropColumn(name: "Comments", table: "Auto");
            migrationBuilder.DropColumn(name: "DocumentNumber", table: "Auto");
            migrationBuilder.DropColumn(name: "EngineCapicity", table: "Auto");
            migrationBuilder.DropColumn(name: "FuelType", table: "Auto");
            migrationBuilder.DropColumn(name: "Gearbox", table: "Auto");
            migrationBuilder.DropColumn(name: "InsurenceEnd", table: "Auto");
            migrationBuilder.DropColumn(name: "MainBelt", table: "Auto");
            migrationBuilder.DropColumn(name: "Milleage", table: "Auto");
            migrationBuilder.DropColumn(name: "OilChange", table: "Auto");
            migrationBuilder.DropColumn(name: "PlateNumber", table: "Auto");
            migrationBuilder.DropColumn(name: "TAEnd", table: "Auto");
        }
    }
}
