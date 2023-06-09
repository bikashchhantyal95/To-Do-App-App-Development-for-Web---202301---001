﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo_App_WEB_1001.Data;

#nullable disable

namespace Todo_App_WEB_1001.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20230413032357_Inital Migration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("Todo_App_WEB_1001.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = false,
                            Description = "Test1"
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            Description = "Test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
