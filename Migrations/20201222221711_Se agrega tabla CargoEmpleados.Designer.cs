﻿// <auto-generated />
using AdministracionEmpleados.NETCore.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdministracionEmpleados.NETCore.Migrations
{
    [DbContext(typeof(DBContextPrueba))]
    [Migration("20201222221711_Se agrega tabla CargoEmpleados")]
    partial class SeagregatablaCargoEmpleados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdministracionEmpleados.NETCore.Models.Entities.CargoEmpleado", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnName("Cargo")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCargo");

                    b.ToTable("CargoEmpleados");
                });

            modelBuilder.Entity("AdministracionEmpleados.NETCore.Models.Entities.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NombreEmpleado")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
