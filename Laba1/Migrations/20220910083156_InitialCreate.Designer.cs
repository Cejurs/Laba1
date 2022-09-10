﻿// <auto-generated />
using Laba1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laba1.Migrations
{
    [DbContext(typeof(ProfessionContex))]
    [Migration("20220910083156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Laba1.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("Laba1.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ProfessionQuestion", b =>
                {
                    b.Property<int>("ProfessionsId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.HasKey("ProfessionsId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("ProfessionQuestion");
                });

            modelBuilder.Entity("ProfessionQuestion", b =>
                {
                    b.HasOne("Laba1.Profession", null)
                        .WithMany()
                        .HasForeignKey("ProfessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laba1.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
