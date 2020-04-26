using System.Collections.Generic;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services.Fakes
{
    public class FakeMovieService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>()
        {
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
        };

        public List<Movie> GetAllMovies()
        {
            return _movies;
        }
    }
}