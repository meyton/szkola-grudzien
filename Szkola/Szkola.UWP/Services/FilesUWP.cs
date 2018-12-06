using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data;
using Szkola.UWP.Services;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilesUWP))]
namespace Szkola.UWP.Services
{
    public class FilesUWP : IFileHelper
    {
        public string GetFilePath(string name)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, name);
        }
    }
}
