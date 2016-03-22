using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CarRental.DataAccess;

namespace CarRental.Web.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    partial class CarRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRental.DataAccess.Entities.Auto", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make");

                    b.Property<int>("Year");

                    b.HasKey("AutoId");
                });
        }
    }
}
