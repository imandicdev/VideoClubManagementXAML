using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.Database
{
    public class VideoClubDbContext : DbContext
    {
        public VideoClubDbContext() : base ("VideoClubConnection")
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<VideoClubDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(member => member.Code);
            modelBuilder.Entity<Movie>().HasKey(movie => movie.Code);

            modelBuilder.Entity<MovieRental>()
                .HasRequired(rental => rental.Member)
                .WithMany(member => member.MovieRentals)
                .HasForeignKey(rental => rental.MemberCode);

            modelBuilder.Entity<Member>().ToTable("SuperMembers");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }
    }
}
