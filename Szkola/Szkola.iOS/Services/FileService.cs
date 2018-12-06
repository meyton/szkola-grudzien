using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Szkola.Data;
using Szkola.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace Szkola.iOS.Services
{
    public class FileService : IFileHelper
    {
        public string GetFilePath(string name)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal); string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, name);
        }
    }
}