using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Szkola.Data;
using Szkola.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileAndroidHelper))]
namespace Szkola.Droid.Services
{
    public class FileAndroidHelper : IFileHelper
    {
        public string GetFilePath(string name)
        {
            string path = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, name);
        }
    }
}