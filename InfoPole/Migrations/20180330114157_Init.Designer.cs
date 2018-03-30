﻿// <auto-generated />
using InfoPole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InfoPole.Migrations
{
    [DbContext(typeof(InfoPoleDbContext))]
    [Migration("20180330114157_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InfoPole.Core.Entities.DataBase.KeyTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("KeyId");

                    b.Property<long>("MarkupTagId");

                    b.HasKey("Id");

                    b.ToTable("KeyTags");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.DataBase.UrlKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("KeyId");

                    b.Property<long>("UrlId");

                    b.HasKey("Id");

                    b.ToTable("UrlKeys");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.DataFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long>("SearchEngineId");

                    b.Property<DateTime>("Uploaded");

                    b.HasKey("Id");

                    b.ToTable("DataFiles");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.MarkupTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MarkupTags");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.SearchEngine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SearchEngines");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.SearchKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.HasKey("Id");

                    b.ToTable("SearchKeys");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.SearchKeyFrequency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Frequency");

                    b.Property<long>("SearchEngineId");

                    b.Property<long>("SearchKeyId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("SearchKeyFrequencies");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("MarkupTagId");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("InfoPole.Core.Entities.UrlItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Domain");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("UrlItems");
                });
#pragma warning restore 612, 618
        }
    }
}
