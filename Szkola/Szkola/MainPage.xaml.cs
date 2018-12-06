using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Szkola
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
            await Navigation.PushAsync(new TicTacToePage());
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

        private void EntryColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var isHex = Regex.IsMatch(e.NewTextValue, "^#(?:[0-9a-fA-F]{3}){1,2}$");
            entryColor.BackgroundColor = isHex ?
                Color.LightGreen :
                Color.DarkRed;
        }

        private async void WebpageEntry_Completed(object sender, EventArgs e)
        {
            await Navigate();
        }

        private async Task Navigate()
        {
            var url = webpageEntry.Text;
            App.LocalDB.GetUsers();
            if (string.IsNullOrEmpty(url))
            {
                await DisplayAlert("UWAGA", "Nie wpisałeś adresu WWW", "OK");
                return;
            }

            var response = await DisplayAlert("PYTANIE", "Czy masz skończone 18 lat, żeby wejść na stronę?", "TAK", "NIE");

            if (response)
            {
                Data.Properties.AppProperties["webUrl"] = url;
                await Data.Properties.Save();
                await Navigation.PushAsync(new HttpClientPage(url));
            }
            else
            {
                await DisplayAlert("OK", "Wróć jak dorośniesz", "OK");
            }
        }

        private async void DisplayMessage(string message)
        {
            await DisplayAlert("Wiadomość", message, "OK");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await DisplayAlert("DB Path", (Application.Current as App).DBPath, "OK");
            if (Data.Properties.AppProperties.ContainsKey("webUrl"))
                lblUrl.Text = Data.Properties.AppProperties["webUrl"].ToString();

        }
    }
}
