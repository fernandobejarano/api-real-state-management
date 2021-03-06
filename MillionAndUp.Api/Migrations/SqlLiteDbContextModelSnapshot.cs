// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MillionAndUp.Persistence;

namespace MillionAndUp.Api.Migrations
{
    [DbContext(typeof(SqlLiteDbContext))]
    partial class SqlLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.HasKey("OwnerId");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("CodeInternal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("PropertyId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.PropertyImage", b =>
                {
                    b.Property<int>("PropertyImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdProperty")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PropertyImageId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImage");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.PropertyTrace", b =>
                {
                    b.Property<int>("PropertyTraceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Tax")
                        .HasColumnType("REAL");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("PropertyTraceId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyTrace");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.Property", b =>
                {
                    b.HasOne("MillionAndUp.Models.Models.Entity.Owner", "Owner")
                        .WithMany("Propertys")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.PropertyImage", b =>
                {
                    b.HasOne("MillionAndUp.Models.Models.Entity.Property", "Property")
                        .WithMany("PropertyImages")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.PropertyTrace", b =>
                {
                    b.HasOne("MillionAndUp.Models.Models.Entity.Property", "Property")
                        .WithMany("PropertyTraces")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.Owner", b =>
                {
                    b.Navigation("Propertys");
                });

            modelBuilder.Entity("MillionAndUp.Models.Models.Entity.Property", b =>
                {
                    b.Navigation("PropertyImages");

                    b.Navigation("PropertyTraces");
                });
#pragma warning restore 612, 618
        }
    }
}
