using System.Collections.Generic;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services.Fakes
{
    public class FakeMemberService : IMemberService
    {

        private List<Member> _members = new List<Member>()
        {
            new Member
            {
                Name = "Rita",
                Surname = "Kucera",
                Cellphone = "(125) 546-4478",
                Street = "Pilgrim Avenue",
                StreetNumber = "71",
                City = "Orlando",
                Email = "rita.kucera@email.com"
            },
            new Member
            {
                Name = "Lucas",
                Surname = "Bertoni",
                Cellphone = "(226) 906-2721",
                Street = "S. Magnolia St.",
                StreetNumber = "514",
                City = "Seattle",
                Email = "lucas.bertoni@email.com"
            },
            new Member
            {
                Name = "Jessica",
                Surname = "Alba",
                Cellphone = "(671) 925-1352",
                Street = "Bowman St.",
                StreetNumber = "70",
                City = "Jersey City",
                Email = "jessica.alba@email.com"
            },
            new Member
            {
                Name = "Owen",
                Surname = "Wilson",
                Cellphone = "(949) 569-4371",
                Street = "Shirley Ave.",
                StreetNumber = "44",
                City = "Columbus",
                Email = "owen.wilson@email.com"
            },
            new Member
            {
                Name = "Keanu",
                Surname = "Reaves",
                Cellphone = "(630) 446-8851",
                Street = "Goldfield Rd.",
                StreetNumber = "4",
                City = "Honolulu",
                Email = "keanu.reaves@email.com"
            }
        };


        public List<Member> GetAllMembers()
        {
            return _members;
        }
    }
}