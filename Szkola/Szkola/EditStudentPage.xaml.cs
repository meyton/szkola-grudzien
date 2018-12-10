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
	public partial class EditStudentPage : ContentPage
	{
        private Student _student;
		public EditStudentPage (Student student)
		{
            _student = student;
			InitializeComponent ();
            entryFirstName.Text = student.FirstName;
            entryLastName.Text = student.LastName;
            entryClassName.Text = student.ClassNumber.ToString();
            dpBirthday.Date = student.Birthday;
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Usuń",
                Command = new Command(async () => await Delete())
            });
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Oceny",
                Command = new Command(async () => await Navigation.PushAsync(new GradingPage(_student)))
            });
        }

        private async Task Delete()
        {
            if (await DisplayAlert("Czy na pewno?", "Czy na pewno usunąć tego studenta?", "TAK", "NIE"))
            {
                await App.LocalDB.DeleteItem(_student);
                await Navigation.PopAsync();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            var lastName = entryLastName.Text;
            int className = int.Parse(entryClassName.Text);
            DateTime birthday = dpBirthday.Date;
            
            var student = new Student()
            {
                ID = _student.ID,
                FirstName = firstName,
                LastName = lastName,
                ClassNumber = className,
                Birthday = birthday
            };

            var result = await App.LocalDB.SaveItem(student);

            if (result > 0)
            {
                await DisplayAlert("SUKCES", "Student zmieniony w bazie", "OK");
            }
            else
            {
                await DisplayAlert("BŁĄD", "Nie dodano studenta", "OK");
            }
        }
    }
}