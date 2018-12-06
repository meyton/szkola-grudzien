using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HttpClientPage : ContentPage
	{
        private string _url;
        private string _content;

		public HttpClientPage(string url)
		{
            _url = url;
			InitializeComponent();
        }

        private async Task Navigate()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);
                _content = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Zwrotka", $"Strona zwróciła {response.StatusCode}", "OK");
            }
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Navigate();
        }
    }
}