using GalaSoft.MvvmLight;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.ViewModel
{
    public class MovieViewModel
    {
        public MovieViewModel(Movie movie)
        {
            if(movie == null)
                return;

            Code = movie.Code;
            Name = movie.Name;
            Stock = movie.Copies;
        }

        public int Stock { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}