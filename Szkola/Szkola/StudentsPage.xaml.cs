using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Szkola.Data.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        public ObservableCollection<Student> Students { get; set; }

        public StudentsPage()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            MyListView.ItemsSource = Students;
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Dodaj nowego",
                Command = new Command(async () => await NavigateToNewStudent())
            });
        }

        private async Task NavigateToNewStudent()
        {
            await Navigation.PushAsync(new AddNewStudentPage());
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            var student = e.Item as Student;
            
            await DisplayAlert("Item Tapped", 
                $"{student.FirstName} {student.LastName} was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var students = await App.LocalDB.GetItems<Student>();

            Students.Clear();
            foreach (var s in students)
            {
                Students.Add(s);
            }
        }
    }
}
