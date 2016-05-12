using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CarRental.Web.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Auto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Photo", table: "Auto");
        }
    }
}
