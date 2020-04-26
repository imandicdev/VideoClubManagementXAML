using System.Windows;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.Services
{
    public class MessageBoxService : IMessageService
    {
        public void ShowInfo(string title, string info)
        {
            MessageBox.Show(info, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowError(string title, string info)
        {
            MessageBox.Show(info, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}