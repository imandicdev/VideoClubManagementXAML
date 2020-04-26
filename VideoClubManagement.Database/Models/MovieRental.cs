using System;

namespace VideoClubManagement.Database.Models
{
    public class MovieRental
    {
        public int Id { get; set; }

        public int MovieCode { get; set; }
        public Movie Movie { get; set; }

        public int MemberCode { get; set; }
        public Member Member { get; set; }

        public DateTime Rented { get; set; }
        public DateTime? Returned { get; set; }
        public DateTime Deadline { get; set; }
    }
}