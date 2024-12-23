﻿// <auto-generated />
using System;
using FWF.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace fwf.dal.Migrations
{
    [DbContext(typeof(FwfDbContext))]
    [Migration("20241208224023_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FWF.Dal.Models.Route", b =>
                {
                    b.Property<string>("Airline")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("airline");

                    b.Property<string>("SourceAirport")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sourceAirport");

                    b.Property<string>("DestinationAirport")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("destinationAirport");

                    b.Property<string>("CodeShare")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("codeShare");

                    b.Property<int>("Stops")
                        .HasColumnType("int")
                        .HasColumnName("stops");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Equipment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("equipment");

                    b.Property<string>("SourceName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sourceName");

                    b.HasKey("Airline", "SourceAirport", "DestinationAirport", "CodeShare", "Stops");

                    b.ToTable("route");
                });

            modelBuilder.Entity("FWF.Dal.Models.RouteStaging", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Airline")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("airline");

                    b.Property<string>("CodeShare")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("codeShare");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("DestinationAirport")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("destinationAirport");

                    b.Property<string>("Equipment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("equipment");

                    b.Property<Guid?>("PipelineRunId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("pipelineRunId");

                    b.Property<string>("Provider")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("provider");

                    b.Property<string>("SourceAirport")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sourceAirport");

                    b.Property<int?>("Stops")
                        .HasColumnType("int")
                        .HasColumnName("stops");

                    b.HasKey("Id");

                    b.ToTable("route_staging");
                });
#pragma warning restore 612, 618
        }
    }
}
