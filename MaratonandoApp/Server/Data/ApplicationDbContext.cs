using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaratonandoApp.Shared.Models.Film;
using MaratonandoApp.Shared.Models.User;

namespace MaratonandoApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<FilmLibrary> FilmLibraries { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmsOnLibrary> FilmsOnLibraries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.FilmLibrary)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<FilmLibrary>(b => b.UserId);

            modelBuilder.Entity<FilmsOnLibrary>().HasKey(fol => new { fol.FilmLibraryId, fol.FilmId });

            modelBuilder.Entity<FilmsOnLibrary>()
                .HasOne<Film>(fol => fol.Film)
                .WithMany(f => f.FilmOnLibraries)
                .HasForeignKey(fol => fol.FilmId);

            modelBuilder.Entity<FilmsOnLibrary>()
                .HasOne<FilmLibrary>(fol => fol.FilmLibrary)
                .WithMany(f => f.filmsOnLibraries)
                .HasForeignKey(fol => fol.FilmLibraryId);
        }


        public DbSet<MaratonandoApp.Shared.Models.Film.FilmComment> FilmComment { get; set; }
    }
}
