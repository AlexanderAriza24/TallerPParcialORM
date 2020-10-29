﻿// <auto-generated />
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(PersonaContext))]
    [Migration("20201027032004_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("PersonaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ValorApoyo")
                        .HasColumnType("int");

                    b.HasKey("AyudaId");

                    b.HasIndex("PersonaId")
                        .IsUnique()
                        .HasFilter("[PersonaId] IS NOT NULL");

                    b.ToTable("Ayuda");
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
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

            modelBuilder.Entity("Entity.Ayuda", b =>
                {
                    b.HasOne("Entity.Persona", null)
                        .WithOne("Ayuda")
                        .HasForeignKey("Entity.Ayuda", "PersonaId");
                });
#pragma warning restore 612, 618
        }
    }
}