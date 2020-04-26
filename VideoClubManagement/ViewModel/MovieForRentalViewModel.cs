using System.ComponentModel;
using System.Runtime.CompilerServices;
using VideoClubManagement.Annotations;

namespace VideoClubManagement.ViewModel
{
    public class MovieForRentalViewModel
    {
        public MovieForRentalViewModel(MovieViewModel movie)
        {
            Movie = movie;
        }
        public MovieViewModel Movie { get; set; }
        public bool Selected { get; set; }
        
    }
}