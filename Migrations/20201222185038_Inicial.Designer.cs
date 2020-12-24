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
    [Migration("20201222185038_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("AdministracionEmpleados.NETCore.Models.Entities.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NombreEmpleado");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
