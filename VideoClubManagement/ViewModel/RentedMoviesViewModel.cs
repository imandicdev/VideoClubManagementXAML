using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace VideoClubManagement.ViewModel
{
    public class RentedMoviesViewModel
    {
        public DateTime Rented { get; set; }
        public DateTime? Returned { get; set; }
        public MemberViewModel Member { get; set; }
        public MovieViewModel Movie { get; set; }
    }
}
