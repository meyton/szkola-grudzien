using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Szkola.Utils;

namespace Szkola.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        {
            Message = "Czekam na połączenie z serwerem";
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            await Task.Delay(1000);
            Message = "Serwer dostępny. Pobieram użytkownika.";
            await Task.Delay(1000);
            Message = "Użytkownik OK. Wysyłam pomiary.";
            await Task.Delay(1000);
            for (int i = 1; i < 100; i++)
            {
                await Task.Delay(50);
                Message = $"Wysyłam pomiar {i} / 100";
            }
            Message = "Wysłano pomiary. Dziękuję";
            await Task.Delay(1000);
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(nameof(Message));
                }
            }
        }
    }
}
