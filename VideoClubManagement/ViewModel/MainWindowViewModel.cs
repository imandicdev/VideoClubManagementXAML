using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using VideoClubManagement.Annotations;
using VideoClubManagement.Services;
using VideoClubManagement.Services.Interfaces;

namespace VideoClubManagement.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRentingService _rentingService;
        private readonly IMovieService _movieService;
        private readonly IMemberService _memberService;
        private readonly IMessageService _messageService;
        private List<RentedMoviesViewModel> _rentedMovies;
        private List<MemberViewModel> _members;
        private MemberViewModel _selectedMember;
        private DateTime? _selectedReturnedDate;
        private DateTime? _selectedRentedDate;
        private bool _isAddingNewRental;
        private List<MovieViewModel> _movies;
        private NewRentalViewModel _newRental;

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel(IRentingService rentingService, IMovieService movieService, IMemberService memberService, IMessageService messageService)
        {
            
            _rentingService = rentingService;
            _movieService = movieService;
            _memberService = memberService;
            _messageService = messageService;

            Initialize();
        }

        private void Initialize()
        {
            ClearFilterCommand = new RelayCommand(ClearFilter, HasFilter);
            ApplyFilterCommand = new RelayCommand(ApplyFilter);

            NewRentalCommand = new RelayCommand(OpenNewRental);
            CancelNewRentalCommand = new RelayCommand(CancelNewRental);
            SaveNewRentalCommand = new RelayCommand(SaveNewRental, CanSaveNewRental);

            LoadRentedMovies();
            LoadMembers();
        }

        private bool CanSaveNewRental()
        {
            return NewRental != null && 
                   NewRental.Member != null && 
                   NewRental.Movies != null && 
                   NewRental.Movies.Any(movie => movie.Selected);
        }

        private void SaveNewRental()
        {
            try
            {
                var movies = NewRental.Movies.Where(movie => movie.Selected).Select(model => model.Movie.Code).ToList();
                _rentingService.SaveNewRental(NewRental.Member.Code, movies);
                LoadRentedMovies();
                IsAddingNewRental = false;
                _messageService.ShowInfo("Success", "Rental saved successfuly");
            }
            catch (Exception e)
            {
                _messageService.ShowError("Error saving rental", e.Message);
            }
        }

        private void CancelNewRental()
        {
            IsAddingNewRental = false;
        }

        private void OpenNewRental()
        {
            // Reload members
            LoadMembers();
            
            // Load movies
            NewRental = new NewRentalViewModel
            {
                Movies = _movieService.GetAllMovies()
                            .Where(movie => movie.Copies > 0)
                            .Select(movie => new MovieForRentalViewModel(new MovieViewModel(movie)))
                            .ToList()
            };

            IsAddingNewRental = true;
        }

        private void ApplyFilter()
        {
            LoadRentedMovies();
        }

        private bool HasFilter()
        {
            return SelectedMember != null || SelectedRentedDate != null || SelectedReturnedDate != null;
        }

        private void ClearFilter()
        {
            SelectedMember = null;
            SelectedRentedDate = null;
            SelectedReturnedDate = null;
            LoadRentedMovies();
        }

        private void LoadMembers()
        {
            Members = _memberService.GetAllMembers().Select(member => new MemberViewModel(member)).ToList();
        }

        private void LoadRentedMovies()
        {
            FilterModel filter = null;
            if (HasFilter())
            {
                filter = new FilterModel()
                {
                    MemberCode = SelectedMember?.Code,
                    RentedDate = SelectedRentedDate,
                    ReturnedDate = SelectedReturnedDate
                };
            }

            var rentals = _rentingService.GetRentedMovies(filter);

            var rentedMovies = new List<RentedMoviesViewModel>();

            foreach (var movieRental in rentals)
            {
                rentedMovies.Add(item: new RentedMoviesViewModel()
                {
                    Movie = new MovieViewModel(movieRental.Movie),
                    Member = new MemberViewModel(movieRental.Member),
                    Rented = movieRental.Rented,
                    Returned = movieRental.Returned,
                    
                });
            }
            RentedMovies = rentedMovies;
        }

        public ICommand ClearFilterCommand { get; set; }
        public ICommand ApplyFilterCommand { get; set; }
        public ICommand NewRentalCommand { get; set; }
        public ICommand CancelNewRentalCommand { get; set; }
        public ICommand SaveNewRentalCommand { get; set; }

        public List<RentedMoviesViewModel> RentedMovies
        {
            get { return _rentedMovies; }
            set
            {
                if (Equals(value, _rentedMovies)) return;
                _rentedMovies = value;
                OnPropertyChanged();
            }
        }

        public List<MemberViewModel> Members
        {
            get { return _members; }
            set
            {
                if (Equals(value, _members)) return;
                _members = value;
                OnPropertyChanged();
            }
        }


        public List<MovieViewModel> Movies
        {
            get { return _movies; }
            set
            {
                if (Equals(value, _movies)) return;
                _movies = value;
                OnPropertyChanged();
            }
        }

        public NewRentalViewModel NewRental
        {
            get { return _newRental; }
            set
            {
                if (Equals(value, _newRental)) return;
                _newRental = value;
                OnPropertyChanged();
            }
        }

        public MemberViewModel SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                if (Equals(value, _selectedMember)) return;
                _selectedMember = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public DateTime? SelectedReturnedDate
        {
            get { return _selectedReturnedDate; }
            set
            {
                if (value.Equals(_selectedReturnedDate)) return;
                _selectedReturnedDate = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public DateTime? SelectedRentedDate
        {
            get { return _selectedRentedDate; }
            set
            {
                if (value.Equals(_selectedRentedDate)) return;
                _selectedRentedDate = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public bool IsAddingNewRental
        {
            get { return _isAddingNewRental; }
            set
            {
                if (value == _isAddingNewRental) return;
                _isAddingNewRental = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}