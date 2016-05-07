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

                    b.Property<bool>("Activity");

                    b.Property<string>("AudioCode");

                    b.Property<DateTime>("CascoInsurenceEnd");

                    b.Property<string>("Color");

                    b.Property<string>("Comments");

                    b.Property<string>("DocumentNumber");

                    b.Property<float>("EngineCapicity");

                    b.Property<string>("FuelType");

                    b.Property<string>("Gearbox");

                    b.Property<DateTime>("InsurenceEnd");

                    b.Property<int>("MainBelt");

                    b.Property<string>("Make");

                    b.Property<int>("Milleage");

                    b.Property<int>("OilChange");

                    b.Property<string>("PlateNumber");

                    b.Property<DateTime>("TAEnd");

                    b.Property<int>("Year");

                    b.HasKey("AutoId");
                });

            modelBuilder.Entity("CarRental.DataAccess.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutoId");

                    b.Property<string>("Commentd");

                    b.Property<decimal>("DayPrice");

                    b.Property<string>("DeliveryPrice");

                    b.Property<DateTime>("OrderEnd");

                    b.Property<DateTime>("OrderStart");

                    b.Property<string>("RentPlace");

                    b.Property<string>("RentReturn");

                    b.HasKey("OrderId");
                });

            modelBuilder.Entity("CarRental.DataAccess.Entities.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutoId");

                    b.Property<decimal>("Value");

                    b.Property<int>("dayEnd");

                    b.Property<int>("dayFrom");

                    b.HasKey("PriceId");
                });
        }
    }
}
