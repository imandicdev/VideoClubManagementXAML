using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.ViewModel
{
    public class MemberViewModel
    {
        
        public MemberViewModel(Member member)
        {
            Code = member.Code;
            Name = member.Name;
            Surname = member.Surname;
            Cellphone = member.Cellphone;
            Email = member.Email;
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}
