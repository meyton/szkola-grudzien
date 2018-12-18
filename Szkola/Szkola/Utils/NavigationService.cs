using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Szkola.Utils
{
    public class NavigationService
    {
        public static async Task PushAsync(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
            page.BackgroundColor = Color.LightGreen;
        }

        public static async Task Pop()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
