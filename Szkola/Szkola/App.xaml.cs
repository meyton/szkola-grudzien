using System;
using Szkola.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Szkola
{
    public partial class App : Application
    {
        public LocalDatabase LocalDB { get; set; }

        public string DBPath { get; set; }

        public App()
        {
            InitializeComponent();
            string path = string.Empty;
            var fileHelper = DependencyService.Get<IFileHelper>();
            path = fileHelper.GetFilePath("app.db3");
            LocalDB = new LocalDatabase(path);
            DBPath = path;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
