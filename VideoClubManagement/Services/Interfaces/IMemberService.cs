using System.Collections.Generic;
using VideoClubManagement.Database.Models;

namespace VideoClubManagement.Services.Interfaces
{
    public interface IMemberService
    {
        List<Member> GetAllMembers();
    }
}