using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VideoClubManagement.Database;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services
{
    public class RentingService : IRentingService
    {

        public int GetMovieStock(int movieCode)
        {
            return 0;
        }

        public List<MovieRental> GetRentedMovies(FilterModel filter = null)
        {
            using (var db = new VideoClubDbContext())
            {
                var rentedMovies = db.MovieRentals.AsQueryable();

                if (filter != null)
                {
                    if (filter.MemberCode != null)
                        rentedMovies = rentedMovies.Where(rental => rental.MemberCode == filter.MemberCode);

                    if (filter.RentedDate != null)
                    {
                        var minDate = filter.RentedDate.Value.Date;
                        var maxDate = filter.RentedDate.Value.Date.AddDays(1);
                        rentedMovies = rentedMovies.Where(rental => rental.Rented >= minDate && rental.Rented < maxDate);
                    }

                    if (filter.ReturnedDate != null)
                    {
                        var minDate = filter.ReturnedDate.Value.Date;
                        var maxDate = filter.ReturnedDate.Value.Date.AddDays(1);
                        rentedMovies = rentedMovies.Where(rental => rental.Returned >= minDate && rental.Returned < maxDate);
                    }
                }

                return rentedMovies
                    .Include(rental => rental.Movie)
                    .Include(rental => rental.Member)
                    .OrderByDescending(rental => rental.Rented)
                    .ToList();
            }

        }

        public void SaveNewRental(int memberCode, List<int> movieCodes)
        {
            // Validate max number of movies:
            if(movieCodes.Count > 4)
                throw new Exception("User can't rent more than 4 movies");

            using (var db = new VideoClubDbContext())
            {
                // Validate if user has movies to be returned
                if(db.MovieRentals.Any(rental => rental.MemberCode == memberCode && rental.Returned == null))
                    throw new Exception("User can't rent more movies because has movies to be returned");

                // Check if user has already rented any of the movies
                var userPreviousRentals = 
                    db.MovieRentals
                    .Where(rental => rental.MemberCode == memberCode && movieCodes.Contains(rental.MovieCode))
                    .Select(rental => rental.Movie);

                if (userPreviousRentals.Any())
                {
                    var friendlyMessage = "User already rent the following movies in the past and can't rent them again:";
                    foreach (var movie in userPreviousRentals)
                    {
                        friendlyMessage += Environment.NewLine + movie.Name;
                    }
                    throw new Exception(friendlyMessage);
                }
                
                // Check stock
                var movies = db.Movies.Where(movie => movieCodes.Contains(movie.Code)).ToList();

                if (movies.Any(movie => movie.Copies <= 0))
                {
                    var friendlyMessage = "The following movies can't be rented because they have no stock:";
                    foreach (var movie in movies)
                    {
                        friendlyMessage += Environment.NewLine + movie.Name;
                    }
                    throw new Exception(friendlyMessage);
                }

                // Calculate deadline date
                var daysToReturn = 2; // Default for 1 movie;
                if (movieCodes.Count > 3)
                    daysToReturn = 6;
                else if (movieCodes.Count > 1)
                    daysToReturn = 4;

                // Rent the movies
                foreach (var movie in movies)
                {
                    var newRental = new MovieRental();
                    newRental.MemberCode = memberCode;
                    newRental.MovieCode = movie.Code;
                    newRental.Rented = DateTime.Now;
                    newRental.Deadline = DateTime.Now.AddDays(daysToReturn);
                    db.MovieRentals.Add(newRental);

                    // Fix movie stock
                    movie.Copies--;
                }

                // Save all changes both on rentals and movies
                db.SaveChanges();
            }
        }
    }
}