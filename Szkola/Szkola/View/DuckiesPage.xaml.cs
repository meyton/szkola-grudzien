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
	public partial class DuckiesPage : ContentPage
	{
        private DuckiesViewModel _viewModel;

		public DuckiesPage ()
		{
			InitializeComponent ();
            _viewModel = new DuckiesViewModel();
            BindingContext = _viewModel;
            _viewModel.Score = 0;
            Task.Run(async () => await Fly());
		}

        private async Task Fly()
        {
            await btnKaczka.TranslateTo(-200, -100, 2000);
            await btnKaczka.TranslateTo(200, 100, 2000);
            await btnKaczka.TranslateTo(1, 1, 2000);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _viewModel.Score += 1;
            btn.IsVisible = false;
        }
    }
}