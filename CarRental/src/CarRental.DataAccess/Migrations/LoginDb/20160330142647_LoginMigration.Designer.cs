using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CarRental.DataAccess;

namespace CarRental.Web.Migrations.LoginDb
{
    [DbContext(typeof(LoginDbContext))]
    [Migration("20160330142647_LoginMigration")]
    partial class LoginMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRental.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Status")
                        .HasAnnotation("Relational:DefaultValue", "Regular")
                        .HasAnnotation("Relational:DefaultValueType", "System.String");

                    b.Property<string>("Username");

                    b.HasKey("Id");
                });
        }
    }
}
