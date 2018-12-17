using System;
using System.Threading.Tasks;
using Szkola.Data.Web;
using Szkola.Services;
using Szkola.Services.Interfaces;
using Szkola.View;
using Xamarin.Forms;

namespace Szkola.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        private IHttpService _httpService;
        public Command LoginCommand { get; private set; }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged(nameof(Password));
                }
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged(nameof(Username));
                }
            }
        }

        public LoginViewModel()
        {
            _httpService = new HttpService();
            LoginCommand = new Command(async () => await TryToLogin());
        }

        private async Task TryToLogin()
        {
            var response = await _httpService.Authorize(Username, Password);
            if (response.IsSuccess)
            {
                var atResponse = await _httpService.AccessToken(((LoginResponse)response.Response).Data.AuthorizationCode);
                if (atResponse.IsSuccess)
                {
                    var accessToken = ((AccessTokenResponse)atResponse.Response).Data.AccessToken;
                    App.AccessToken = accessToken;
                    await Utils.UINotificationService.DisplayAlert($"Zalogowano poprawnie. Twój access token to: {accessToken}.");
                    var userResponse = await _httpService.GetPersonalData();
                    if (userResponse.IsSuccess)
                    {
                        var vm = new DetailsViewModel(((MeResponse)userResponse.Response).Data);
                        await Utils.NavigationService.PushAsync(new DetailsPage(vm));
                    }

                }
            }
            else
            {
                await Utils.UINotificationService.DisplayAlert("Logowanie nieudane.");
            }
        }
    }
}