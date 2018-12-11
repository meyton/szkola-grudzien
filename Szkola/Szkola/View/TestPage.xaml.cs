using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.Utils;
using Szkola.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage (BaseViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel;
         
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await NavigationService.Pop();
        }
    }
}