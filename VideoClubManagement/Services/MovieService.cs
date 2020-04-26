using System;
using System.Collections.Generic;
using System.Linq;
using VideoClubManagement.Database;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services
{
    public class MovieService : IMovieService
    {
        public List<Movie> GetAllMovies()
        {
            using (var db = new VideoClubDbContext())
            {
                return db.Movies.OrderBy(movie => movie.Name).ToList();
            }
        }
    }
}