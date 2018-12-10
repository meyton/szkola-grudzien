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
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var students = await App.LocalDB.GetItems<Student>();

            foreach (var s in students)
            {
                Students.Add(s);
            }
        }
    }
}
