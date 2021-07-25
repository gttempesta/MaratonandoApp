﻿// <auto-generated />
using System;
using MaratonandoApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaratonandoApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEstreia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diretor")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Pais")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Poster")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FilmId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmComment", b =>
                {
                    b.Property<int>("FilmCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("FilmCommentId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmComment");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmLibrary", b =>
                {
                    b.Property<int>("FilmLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FilmLibraryId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("FilmLibraries");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmsOnLibrary", b =>
                {
                    b.Property<int>("FilmLibraryId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAssistido")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FlAssistido")
                        .HasColumnType("bit");

                    b.Property<bool>("FlFavorito")
                        .HasColumnType("bit");

                    b.Property<int>("NotaFilme")
                        .HasColumnType("int");

                    b.HasKey("FilmLibraryId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmsOnLibraries");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("nroEpisode")
                        .HasColumnType("int");

                    b.Property<int>("nroTemporada")
                        .HasColumnType("int");

                    b.Property<string>("sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.HasIndex("SerieId");

                    b.ToTable("Episode");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeComment", b =>
                {
                    b.Property<int>("EpisodeCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeCommentId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeComment");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeLibrary", b =>
                {
                    b.Property<int>("EpisodeLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SerieOnLibraryId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeLibraryId");

                    b.HasIndex("SerieOnLibraryId")
                        .IsUnique();

                    b.ToTable("EpisodeLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeOnLibrary", b =>
                {
                    b.Property<int>("EpisodeLibraryId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAssistido")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FlAssistido")
                        .HasColumnType("bit");

                    b.Property<int>("NotaEpisodio")
                        .HasColumnType("int");

                    b.HasKey("EpisodeLibraryId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.Serie", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEstreia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Pais")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Poster")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("QtdTemporadas")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SerieId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieLibrary", b =>
                {
                    b.Property<int>("SerieLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SerieLibraryId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("SerieLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieOnLibrary", b =>
                {
                    b.Property<int>("SerieOnLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("SerieLibraryId")
                        .HasColumnType("int");

                    b.Property<int>("SeriesStatus")
                        .HasColumnType("int");

                    b.HasKey("SerieOnLibraryId");

                    b.HasIndex("SerieId");

                    b.HasIndex("SerieLibraryId");

                    b.ToTable("SerieOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.User.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmComment", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", "ApplicationUser")
                        .WithMany("filmComments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("MaratonandoApp.Shared.Models.Film.Film", "Film")
                        .WithMany("filmComments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", "ApplicationUser")
                        .WithOne("FilmLibrary")
                        .HasForeignKey("MaratonandoApp.Shared.Models.Film.FilmLibrary", "UserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmsOnLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.Film.Film", "Film")
                        .WithMany("FilmOnLibraries")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaratonandoApp.Shared.Models.Film.FilmLibrary", "FilmLibrary")
                        .WithMany("filmsOnLibraries")
                        .HasForeignKey("FilmLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("FilmLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.Episode", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.Series.Serie", null)
                        .WithMany("episodes")
                        .HasForeignKey("SerieId");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeComment", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("MaratonandoApp.Shared.Models.Series.Episode", "Episode")
                        .WithMany("episodeComments")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.Series.SerieOnLibrary", "SerieOnLibrary")
                        .WithOne("episodeLibrary")
                        .HasForeignKey("MaratonandoApp.Shared.Models.Series.EpisodeLibrary", "SerieOnLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SerieOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeOnLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.Series.Episode", "Episode")
                        .WithMany("EpisodeOnLibrary")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaratonandoApp.Shared.Models.Series.EpisodeLibrary", "episodeLibrary")
                        .WithMany("EpisodeOnLibrary")
                        .HasForeignKey("EpisodeLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("episodeLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", "ApplicationUser")
                        .WithOne("SerieLibrary")
                        .HasForeignKey("MaratonandoApp.Shared.Models.Series.SerieLibrary", "UserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieOnLibrary", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.Series.Serie", "Serie")
                        .WithMany("SerieOnLibrary")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaratonandoApp.Shared.Models.Series.SerieLibrary", "SerieLibrary")
                        .WithMany("serieOnLibrary")
                        .HasForeignKey("SerieLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("SerieLibrary");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MaratonandoApp.Shared.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.Film", b =>
                {
                    b.Navigation("filmComments");

                    b.Navigation("FilmOnLibraries");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Film.FilmLibrary", b =>
                {
                    b.Navigation("filmsOnLibraries");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.Episode", b =>
                {
                    b.Navigation("episodeComments");

                    b.Navigation("EpisodeOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.EpisodeLibrary", b =>
                {
                    b.Navigation("EpisodeOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.Serie", b =>
                {
                    b.Navigation("episodes");

                    b.Navigation("SerieOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieLibrary", b =>
                {
                    b.Navigation("serieOnLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.Series.SerieOnLibrary", b =>
                {
                    b.Navigation("episodeLibrary");
                });

            modelBuilder.Entity("MaratonandoApp.Shared.Models.User.ApplicationUser", b =>
                {
                    b.Navigation("filmComments");

                    b.Navigation("FilmLibrary");

                    b.Navigation("SerieLibrary");
                });
#pragma warning restore 612, 618
        }
    }
}
