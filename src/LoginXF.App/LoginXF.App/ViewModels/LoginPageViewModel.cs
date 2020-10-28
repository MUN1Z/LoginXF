using LoginXF.App.Data;
using LoginXF.App.Entities;
using LoginXF.App.Services;
using LoginXF.App.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Windows.Input;

namespace LoginXF.App.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Private Members

        private IUserRepository _userRepository;
        private IUserTokenService _userTokenService;
        private IPageDialogService _dialogService;

        private string _email;
        private string _password;

        private bool _isLoading;

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Properties

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        #endregion

        #region Constructors

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IUserRepository userRepository, IUserTokenService userTokenService)
           : base(navigationService)
        {
            Title = "Login";

            _userRepository = userRepository;
            _dialogService = dialogService;
            _userTokenService = userTokenService;

            //Add default Admin User
            if (!_userRepository.Login("admin@email.com", "admin"))
                _userRepository.Persist(new User 
                { 
                    Name = "Admin", 
                    Email = "admin@email.com",
                    Password = "admin",
                    Telephone = "83 9999-8888",
                    BirthDate = DateTime.Now
                });

            InitializeCommands();
        }

        #endregion

        #region Initializers

        private void InitializeCommands()
        {
            LoginCommand = new DelegateCommand(LoginCommandImplementation);
        }

        #endregion

        #region Commmands Implementations

        private async void LoginCommandImplementation()
        {
            if (_userRepository.Login(Email, Password))
            {
                IsLoading = true;

                var userToken = await ServiceGenerator.GetMockyService().GetToken();

                _userTokenService.SaveUserToken(userToken);

                IsLoading = false;
                await NavigationService.NavigateAsync(nameof(MainPage));
            }
            else
                await _dialogService.DisplayActionSheetAsync("Invalid email or password.", "OK", null);
        }

        #endregion
    }
}
