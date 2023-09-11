using Conlang.Application.Services;
using Conlang.UI.Services;
using System.ComponentModel;

public class LoginPageViewModel : INotifyPropertyChanged
{
    readonly IAuthenticationService _authenticationService;
    readonly INavigationService _navigationService;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    string _username;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    string _password;

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public LoginPageViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
    {
        _authenticationService = authenticationService;
        _navigationService = navigationService;
    }
    
    void OnLogin()
    {
        if (_authenticationService.Authenticate(Username, Password))
        {
            _navigationService.NavigateTo("Dashboard");
        }
        else
        {
            // Show error message to user
        }
    }

    // This method is used to determine if the login button should be enabled
    bool CanLogin()
    {
        return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrEmpty(Password);
    }

    // This method is used to determine if the register button should be enabled
    void OnRegister()
    {
        _authenticationService.Register(Username, Password);
    }
}