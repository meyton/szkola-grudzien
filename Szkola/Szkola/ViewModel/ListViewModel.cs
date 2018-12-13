using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Szkola.ViewModel
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public ListViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            await Task.Delay(2000);
            Device.BeginInvokeOnMainThread(() =>
            {
                Items.Add("Kolejny");
                Items.Add("Następnie kolejny");
                Items.Add("I kolejny");
            });
            await Task.Delay(1000);
            Device.BeginInvokeOnMainThread(() =>
            {
                Items.RemoveAt(3);
                Items.RemoveAt(2);
            });
        }
    }
}
