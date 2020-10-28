using LoginXF.App.Data;
using LoginXF.App.Entities;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Windows.Input;

namespace LoginXF.App.ViewModels
{
    public class CreateUserPageViewModel : ViewModelBase
    {
        #region Private Members

        private IUserRepository _userRepository;
        private IPageDialogService _dialogService;

        private string _name;
        private string _email;
        private string _telephone;
        private string _password;
        private string _passwordConfirmation;
        private DateTime _birthDate;

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string PasswordConfirmation
        {
            get => _passwordConfirmation;
            set => SetProperty(ref _passwordConfirmation, value);
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        #endregion

        #region Commands

        public ICommand CreateUserCommand { get; set; }

        #endregion

        #region Constructors

        public CreateUserPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IUserRepository userRepository)
            : base(navigationService)
        {
            Title = "Create User";

            _userRepository = userRepository;
            _dialogService = dialogService;

            InitializeCommands();
        }

        #endregion

        #region Private Methods Implementations

        private void InitializeCommands()
        {
            CreateUserCommand = new DelegateCommand(CreateUserCommandImplementationAsync);
        }

        #endregion

        #region Commands Methods Implementations

        private async void CreateUserCommandImplementationAsync()
        {
            // TODO: Separate this validation into a method.
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Telephone) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(PasswordConfirmation) ||
                BirthDate == null)
            {
                //await _dialogService.DisplayAlertAsync("Alert", "None of the fields can be empty", "OK"); Not working on UWP
                await _dialogService.DisplayActionSheetAsync("None of the fields can be empty.", "OK", null);
                return;
            }

            // TODO: Separate this validation into a method.
            if (Name.Length < 4)
            {
                await _dialogService.DisplayActionSheetAsync("The name must contain more than 4 characters.", "OK", null);
                return;
            }

            // TODO: Separate this validation into a method.
            if (Name.Length > 50)
            {
                await _dialogService.DisplayActionSheetAsync("The name must contain less than 50 characters.", "OK", null);
                return;
            }

            // TODO: Separate this validation into a method.
            if (Name.Length > 50)
            {
                await _dialogService.DisplayActionSheetAsync("The name must contain less than 50 characters.", "OK", null);
                return;
            }

            // TODO: Separate this validation into a method.
            if (!Password.Equals(PasswordConfirmation))
            {
                await _dialogService.DisplayActionSheetAsync("Passwords not math.", "OK", null);
                return;
            }

            // TODO: Separate this validation into a method.
            if (DateTime.Now.Year - BirthDate.Year < 18)
            {
                await _dialogService.DisplayActionSheetAsync("You must be of legal age.", "OK", null);
                return;
            }

            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Telephone = Telephone,
                BirthDate = BirthDate
            };

            _userRepository.Persist(user);

            await NavigationService.GoBackAsync();
        }

        #endregion

    }
}
