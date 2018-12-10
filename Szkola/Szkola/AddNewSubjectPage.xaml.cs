using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewSubjectPage : ContentPage
	{
		public AddNewSubjectPage()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var name = entryName.Text;

            var subject = new Subject()
            {
                Name = name
            };

            var result = await App.LocalDB.SaveItem(subject);

            if (result > 0)
            {
                await DisplayAlert("SUKCES", "Przedmiot dodany do bazy", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("BŁĄD", "Nie dodano przedmiotu", "OK");
            }

        }
    }
}