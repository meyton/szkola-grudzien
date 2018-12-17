using System;
using Szkola.Data;
using Szkola.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Szkola
{
    public partial class App : Application
    {
        private static LocalDatabase localDB;
        public static LocalDatabase LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    string path = string.Empty;
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    path = fileHelper.GetFilePath("app.db3");
                    localDB = new LocalDatabase(path);
                }
                return localDB;
            }
        }
        
        public static string AccessToken { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
