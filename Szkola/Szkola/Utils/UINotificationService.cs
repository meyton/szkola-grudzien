using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Szkola.Utils
{
    public class UINotificationService
    {
        public static async Task DisplayAlert(string message)
        {
            // zaloguj message
            await App.Current.MainPage.DisplayAlert("Wiadomość", message, "OK");
        }

        public static async Task<bool> DisplayQuestion(string question)
        {
            return await App.Current.MainPage.DisplayAlert("Pytanie", question, "TAK", "NIE");
        }
    }
}
