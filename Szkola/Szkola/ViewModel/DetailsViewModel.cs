using System;
using System.Collections.Generic;
using System.Text;
using Szkola.Data.Web;

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

        public DetailsViewModel(UserDetails user)
        {
            User = user;
        }
    }
}
