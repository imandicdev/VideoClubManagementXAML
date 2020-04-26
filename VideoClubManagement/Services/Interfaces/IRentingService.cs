using System;
using System.Collections.Generic;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.Services.Interfaces
{
    public interface IRentingService
    {
        List<MovieRental> GetRentedMovies(FilterModel filter = null);
        void SaveNewRental(int memberCode, List<int> movieCodes);
    }
}