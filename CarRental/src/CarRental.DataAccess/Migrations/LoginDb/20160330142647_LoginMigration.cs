using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CarRental.Web.Migrations.LoginDb
{
    public partial class LoginMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "User",
                nullable: true,
                defaultValue: "Regular");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "User",
                nullable: true,
                defaultValue: "regular");
        }
    }
}
