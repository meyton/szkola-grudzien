using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data.Web;
using Szkola.Services;
using Szkola.Services.Interfaces;
using Xamarin.Forms;

namespace Szkola.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private UserDetails _user;

        public UserDetails User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    RaisePropertyChanged(nameof(User));
                }
            }
        }

        public Command LogoutCommand { get; private set; }

        public DetailsViewModel(UserDetails user)
        {
            _httpService = new HttpService();
            User = user;
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        { 
            var response = await _httpService.Logout();
            if (response.IsSuccess)
            {
                App.AccessToken = string.Empty;
                await Utils.NavigationService.Pop();
            }
        }

        private IHttpService _httpService;
    }
}
