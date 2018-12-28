﻿// <auto-generated />
using GraphQLWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLWeb.GraphQlCollection.Item", b =>
                {
                    b.Property<string>("BarCode")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("SellingPrice");

                    b.Property<string>("Title");

                    b.HasKey("BarCode");

                    b.ToTable("Items");

                    b.HasData(
                        new { BarCode = "123", SellingPrice = 50m, Title = "Headphone" },
                        new { BarCode = "456", SellingPrice = 40m, Title = "Keyboard" },
                        new { BarCode = "789", SellingPrice = 100m, Title = "Monitor" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
