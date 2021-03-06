﻿// <auto-generated />
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(PersonaContext))]
    partial class PersonaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Ayuda", b =>
                {
                    b.Property<string>("AyudaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValorAyuda")
                        .HasColumnType("int");

                    b.HasKey("AyudaId");

                    b.ToTable("Ayudas");
                });

            modelBuilder.Entity("Entity.PersonaBd", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoAyuda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
