using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClubManagement.Services.Interfaces
{
    public interface IMessageService
    {
        void ShowInfo(string title, string info);
        void ShowError(string title, string info);
    }
}
