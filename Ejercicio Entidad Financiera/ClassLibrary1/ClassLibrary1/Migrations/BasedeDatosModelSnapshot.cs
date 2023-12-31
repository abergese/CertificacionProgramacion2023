﻿// <auto-generated />
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(BasedeDatos))]
    partial class BasedeDatosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Backend.CuentaBancaria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("clienteid")
                        .HasColumnType("int");

                    b.Property<string>("numeroCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.Property<string>("tipoCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("CuentaBancaria");
                });

            modelBuilder.Entity("Backend.TarjetaCredito", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("limiteCredito")
                        .HasColumnType("float");

                    b.Property<double>("montoDeuda")
                        .HasColumnType("float");

                    b.Property<string>("numeroTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldoDisponible")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("TarjetaCredito");
                });

            modelBuilder.Entity("Backend.CuentaBancaria", b =>
                {
                    b.HasOne("Backend.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
