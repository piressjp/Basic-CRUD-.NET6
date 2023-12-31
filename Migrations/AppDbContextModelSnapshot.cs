﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Data;

#nullable disable

namespace Todo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Todo.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DT_Criacao")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DT_Criacao");

                    b.Property<DateTime>("DT_Nascimento")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DT_Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Telefone");

                    b.HasKey("ID");

                    b.ToTable("User", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
