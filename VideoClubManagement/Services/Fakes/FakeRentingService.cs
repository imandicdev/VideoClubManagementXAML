using System;
using System.Collections.Generic;
using System.Linq;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services.Fakes
{
    public class FakeRentingService : IRentingService
    {
        #region InMemoryData
        
        private List<MovieRental> _rentals;

        public FakeRentingService(IMovieService movieService, IMemberService memberService)
        {
            var movies = movieService.GetAllMovies();
            var members = memberService.GetAllMembers();
            
            _rentals = new List<MovieRental>();
            var rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
                var movie = movies[rnd.Next(movies.Count)];
                var member = members[rnd.Next(members.Count)];
                var date = new DateTime(2017, rnd.Next(1,12), 1).AddDays(rnd.Next(30));
                
                _rentals.Add(new MovieRental()
                {
                    Member = member,
                    MemberCode = member.Code,
                    Movie = movie,
                    MovieCode = movie.Code,
                    Rented = date,
                    Returned = i%2 == 0 ? (DateTime?) null : date.AddDays(rnd.Next(4)) ,
                    Deadline = date.AddDays(rnd.Next(6))
                });
            }
        }

        #endregion

        public int GetMovieStock(int movieCode)
        {
            throw new NotImplementedException();
        }

        public List<MovieRental> GetRentedMovies(FilterModel filter = null)
        {
            return _rentals;
        }

        public void SaveNewRental(int memberCode, List<int> movieCodes)
        {
            throw new NotImplementedException();
        }
    }
}
