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
    public partial class GradingPage : ContentPage
    {
        public ObservableCollection<GradeUI> Items { get; set; }

        private Student _student;

        public GradingPage(Student student)
        {
            _student = student;
            InitializeComponent();
            Items = new ObservableCollection<GradeUI>();
			MyListView.ItemsSource = Items;
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Zapisz",
                Command = new Command(async () => await Save())
            });
        }

        private async Task Save()
        {
            foreach (var i in Items)
            {
                var r = await App.LocalDB.SaveItem(i.Grade);
                if (r == 0)
                {
                    await DisplayAlert("Błąd", $"Nie zapisano {i.Subject}", "OK");
                }
            }
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

            var subjects = await App.LocalDB.GetItems<Subject>();
            var grades = await App.LocalDB.Database.Table<Grade>().Where(x => x.StudentID == _student.ID).ToListAsync();

            Items.Clear();
            foreach (var s in subjects)
            {
                Items.Add(new GradeUI()
                {
                    Subject = s,
                    Grade = new Grade()
                    {
                        ID = grades.Where(x => x.SubjectID == s.ID).Select(x => x.ID).FirstOrDefault(),
                        SubjectID = s.ID,
                        StudentID = _student.ID,
                        Value = grades.Where(x => x.SubjectID == s.ID).Select(x => x.Value).FirstOrDefault()
                    }
                });
            }
        }

        public class GradeUI
        {
            public Subject Subject { get; set; }
            public Grade Grade { get; set; }
        }
    }

}
