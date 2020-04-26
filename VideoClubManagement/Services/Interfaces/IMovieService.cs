using System.Collections.Generic;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
    }
}