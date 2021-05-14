﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(AdventureWorks2019Context))]
    [Migration("20210106230154_mig5")]
    partial class mig5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            

            modelBuilder.Entity("WebApplication5.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasComment("Primary key for File records.")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("File Name");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Root Path to File");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            
#pragma warning restore 612, 618
        }
    }
}