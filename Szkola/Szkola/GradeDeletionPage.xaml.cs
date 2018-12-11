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
    public partial class GradeDeletionPage : ContentPage
    {
        public ObservableCollection<StudentWithGrade> Items { get; set; }

        public GradeDeletionPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<StudentWithGrade>();

            MyListView.ItemsSource = Items;

            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Usuń zaznaczone",
                Command = new Command(async () => await Delete())
            });
        }

        private async Task Delete()
        {
            foreach (var i in Items.Where(x => x.IsGoingToBeDeleted))
            {
                await App.LocalDB.DeleteItem(i.Grade);
            }

            await Navigation.PopToRootAsync();
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
            var grades = await App.LocalDB.GetItems<Grade>();
            foreach (var g in grades)
            {
                Items.Add(new StudentWithGrade()
                {
                    Student = await App.LocalDB.GetItemByID<Student>(g.StudentID),
                    Grade = g,
                    Subject = await App.LocalDB.GetItemByID<Subject>(g.SubjectID)
                });
            }
        }

        public class StudentWithGrade
        {
            public Subject Subject { get; set; }
            public Student Student { get; set; }
            public Grade Grade { get; set; }
            public bool IsGoingToBeDeleted { get; set; }
            public string ShortDescription { get => $"{Grade.Value} - {Student.FullName} - {Subject.Name}"; }
        }
    }
}
