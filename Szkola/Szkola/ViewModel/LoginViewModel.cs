using System;
using System.Threading.Tasks;
using Szkola.Data.Web;
using Szkola.Services;
using Szkola.Services.Interfaces;
using Xamarin.Forms;

namespace Szkola.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IHttpService _httpService;
        public Command LoginCommand { get; private set; }

        public LoginViewModel()
        {
            _httpService = new HttpService();
            LoginCommand = new Command(async () => await TryToLogin());
        }

        private async Task TryToLogin()
        {
            var response = await _httpService.Authorize("developer", "developer");
            if (response.IsSuccess)
            {
                var atResponse = await _httpService.AccessToken(((LoginResponse)response.Response).Data.AuthorizationCode);
                if (atResponse.IsSuccess)
                {
                    var accessToken = ((AccessTokenResponse)atResponse.Response).Data.AccessToken;
                    App.AccessToken = accessToken;
                    await Utils.UINotificationService.DisplayAlert($"Zalogowano poprawnie. Twój access token to: {accessToken}.");
                }
            }
        }
    }
}