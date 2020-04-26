using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubManagement.ViewModel
{
    public class NewRentalViewModel
    {
        public MemberViewModel Member { get; set; }
        public List<MovieForRentalViewModel> Movies { get; set; }
    }
}
