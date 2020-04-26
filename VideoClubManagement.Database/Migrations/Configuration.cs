using VideoClubManagement.Database.Models;

namespace VideoClubManagement.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoClubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        protected override void Seed(VideoClubDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Members.AddOrUpdate(member => member.Name,
                new Member { Name = "Rita", Surname = "Kucera", Cellphone = "(125) 546-4478", Street = "Pilgrim Avenue", StreetNumber = "71", City = "Orlando", Email = "rita.kucera@email.com"},
                new Member { Name = "Lucas", Surname = "Bertoni", Cellphone = "(226) 906-2721", Street = "S. Magnolia St.", StreetNumber = "514", City = "Seattle", Email = "lucas.bertoni@email.com"},
                new Member { Name = "Jessica", Surname = "Alba", Cellphone = "(671) 925-1352", Street = "Bowman St.", StreetNumber = "70", City = "Jersey City", Email = "jessica.alba@email.com"},
                new Member { Name = "Owen", Surname = "Wilson", Cellphone = "(949) 569-4371", Street = "Shirley Ave.", StreetNumber = "44", City = "Columbus", Email = "owen.wilson@email.com"},
                new Member { Name = "Keanu", Surname = "Reaves", Cellphone = "(630) 446-8851", Street = "Goldfield Rd.", StreetNumber = "4", City = "Honolulu", Email = "keanu.reaves@email.com"}
                );

            context.Movies.AddOrUpdate(movie => movie.Name,
                new Movie {Name = "Doctor Strange", Copies = 3},
                new Movie {Name = "Pulp Fiction", Copies = 2},
                new Movie {Name = "The Amazing Spider-Man", Copies = 1},
                new Movie {Name = "Star Wars: The Force Awakens", Copies = 2},
                new Movie {Name = "Wreck-It Ralph", Copies = 1},
                new Movie {Name = "Forrest Gump", Copies = 4},
                new Movie {Name = "The Revenant", Copies = 2},
                new Movie {Name = "The Fifth Element", Copies = 3},
                new Movie {Name = "The Hobbit: An Unexpected Journey", Copies = 2},
                new Movie {Name = "Thor: Ragnarok", Copies = 1}
                );
        }
    }
}
