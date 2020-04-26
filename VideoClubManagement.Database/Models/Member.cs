using System.Collections.Generic;

namespace VideoClubManagement.Database.Models
{
    public class Member
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public virtual List<MovieRental> MovieRentals { get; set; } 
    }
}