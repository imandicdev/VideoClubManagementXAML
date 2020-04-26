using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubManagement.Services
{
    public class FilterModel
    {
        public int? MemberCode { get; set; }
        public DateTime? RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
