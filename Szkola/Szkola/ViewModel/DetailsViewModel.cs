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
        private Employee _user;

        public Employee User
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

        public DetailsViewModel(Employee user)
        {
            _httpService = new HttpService();
            User = user;
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            var userResponse = await _httpService.UpdateEmployee((int)User.Id, "Marcin", "marcin@gmail.com");
            if (userResponse.IsSuccess)
            {
                var response = await _httpService.Logout();
                if (response.IsSuccess)
                {
                    App.AccessToken = string.Empty;
                    await Utils.NavigationService.Pop();
                }
            }
        }

        private IHttpService _httpService;
    }
}
