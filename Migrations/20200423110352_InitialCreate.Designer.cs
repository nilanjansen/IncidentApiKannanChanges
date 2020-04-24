﻿// <auto-generated />
using System;
using DeltaEndpoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeltaEndpoint.Migrations
{
    [DbContext(typeof(deltastoreContext))]
    [Migration("20200423110352_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeltaEndpoint.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId");

                    b.Property<string>("CreatorContact")
                        .IsRequired();
                      

                    b.Property<string>("IssueType")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<byte[]>("Media")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<string>("Status");

                    b.HasKey("IncidentId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("DeltaEndpoint.Models.IssueType", b =>
                {
                    b.Property<int>("IssueTypeId");

                    b.Property<string>("IssueTypeName")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("IssueTypeId");

                    b.ToTable("IssueType");
                });

            modelBuilder.Entity("DeltaEndpoint.Models.Location", b =>
                {
                    b.Property<int>("LocationId");

                    b.Property<string>("LocationName")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
