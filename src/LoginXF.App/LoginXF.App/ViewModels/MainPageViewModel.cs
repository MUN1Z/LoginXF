using LoginXF.App.Data;
using LoginXF.App.Entities;
using LoginXF.App.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LoginXF.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Private Members

        IUserRepository _userRepository;

        private ObservableCollection<User> _users;

        #endregion

        #region Properties

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        #endregion

        #region Commands

        public ICommand CreateUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }

        #endregion

        #region Constructors

        public MainPageViewModel(INavigationService navigationService, IUserRepository userRepository)
           : base(navigationService)
        {
            Title = "Main";

            _userRepository = userRepository;

            InitializeCommands();
        }

        #endregion

        #region Override Methods

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            RefreshUsers();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            CreateUserCommand = new DelegateCommand(CreateUserCommandImplementation);
            DeleteUserCommand = new DelegateCommand<string>(DeleteUserCommandImplementation);
        }

        private void RefreshUsers()
        {
            Users = new ObservableCollection<User>(_userRepository.GetAll());
        }

        #endregion

        #region Commands Implementations

        private void CreateUserCommandImplementation()
        {
            NavigationService.NavigateAsync(nameof(CreateUserPage));
        }

        private void DeleteUserCommandImplementation(string Id)
        {
            _userRepository.Delete(Id);
            RefreshUsers();
        }

        #endregion
    }
}
