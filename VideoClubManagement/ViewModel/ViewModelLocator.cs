/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:VideoClubManagement"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using VideoClubManagement.Services;
using VideoClubManagement.Services.Fakes;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IMovieService, FakeMovieService>();
                SimpleIoc.Default.Register<IMemberService, FakeMemberService>();
                SimpleIoc.Default.Register<IRentingService, FakeRentingService>();
                
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IMovieService, MovieService>();
                SimpleIoc.Default.Register<IMemberService, MemberService>();
                SimpleIoc.Default.Register<IRentingService, RentingService>();
            }

            SimpleIoc.Default.Register<IMessageService, MessageBoxService>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
            
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            
        }
    }
}