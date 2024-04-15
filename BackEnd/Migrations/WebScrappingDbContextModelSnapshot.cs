﻿// <auto-generated />
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(WebScrappingDbContext))]
    partial class WebScrappingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Models.IAliment", b =>
                {
                    b.Property<string>("AlimentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scientificName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlimentId");

                    b.ToTable("Aliments");
                });

            modelBuilder.Entity("BackEnd.Models.IComponents", b =>
                {
                    b.Property<string>("ComponentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AlimentId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponentsId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("BackEnd.Models.ISingleComponent", b =>
                {
                    b.Property<string>("SingleComponentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AlimentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Componente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentsId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesvioPadrão")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IComponentsComponentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NúmeroDeDadosUtilizado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referências")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeDados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unidades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorMáximo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorMínimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorPor100g")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SingleComponentId");

                    b.HasIndex("IComponentsComponentsId");

                    b.ToTable("SingleComponent");
                });

            modelBuilder.Entity("BackEnd.Models.ISingleComponent", b =>
                {
                    b.HasOne("BackEnd.Models.IComponents", null)
                        .WithMany("SingleComponent")
                        .HasForeignKey("IComponentsComponentsId");
                });

            modelBuilder.Entity("BackEnd.Models.IComponents", b =>
                {
                    b.Navigation("SingleComponent");
                });
#pragma warning restore 612, 618
        }
    }
}
