using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubManagement.Database.Models
{
    public class Movie
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Copies { get; set; }
        public virtual List<MovieRental> MovieRentals { get; set; }
    }
}
