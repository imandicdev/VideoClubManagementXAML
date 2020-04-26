using System;
using System.Collections.Generic;
using System.Linq;
using VideoClubManagement.Database;
using VideoClubManagement.Database.Models;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services
{
    public class MemberService : IMemberService
    {
        public List<Member> GetAllMembers()
        {
            using (var db = new VideoClubDbContext())
            {
                return db.Members.OrderBy(member => member.Name).ToList();
            }
        }
    }
}