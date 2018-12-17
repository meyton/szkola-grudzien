using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private LoginViewModel _viewModel;
		public LoginPage ()
		{
            _viewModel = new LoginViewModel();
			InitializeComponent ();
            BindingContext = _viewModel;
		}
	}
}