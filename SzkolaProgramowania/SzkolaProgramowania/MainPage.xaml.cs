using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SzkolaProgramowania
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            lblMain.Text = "To jest text zmieniony po inicjalizacji";
            lblMain.TextColor = Color.Blue;
            lblMain.FontSize = 20;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.BackgroundColor = Color.Red;
            lblMain.IsVisible = !lblMain.IsVisible;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        private void colorButton(object sender, EventArgs e)
        {
            var color = entryColor.Text;

            if (string.IsNullOrWhiteSpace(color))
            {
                return;
            }

            var colorHex = Color.FromHex(color);
            btnColor.BackgroundColor = colorHex;
        }
    }
}
