using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Szkola.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DuckiesPage : ContentPage
	{
        private DuckiesViewModel _viewModel;
        private List<Button> _ducks;
        private double _maxX = 0;
        private double _maxY = 0;

		public DuckiesPage ()
		{
			InitializeComponent ();
            _viewModel = new DuckiesViewModel();
            BindingContext = _viewModel;
            _viewModel.Score = 0;
            _maxX = this.Width;
            _maxY = this.Height;
            
		}

        private void InitGame(int number)
        {
            _ducks = new List<Button>();

            for (int i = 0; i < number; i++)
            {
                var duck = new Button()
                {
                    Text = $"Kaczka {i}",
                    TextColor = Color.Black,
                    BackgroundColor = Color.Yellow
                };
                duck.Clicked += Duck_Clicked;
                _ducks.Add(duck);
                playground.Children.Add(duck, new Point(i * 20, i * 30));
            }
        }

        private void Duck_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _viewModel.Score += 1;
            btn.IsVisible = false;
        }

        private async void Fly(uint delay)
        {
            var a = new Random();
            while (_ducks.Any(x => x.IsVisible))
            {
                foreach (var b in _ducks)
                {
                    var nextX = a.Next((int)_maxX) - b.X;
                    var nextY = a.Next((int)_maxY) - b.Y;
                    var t = b.TranslateTo(nextX, nextY, delay);
                }

                await Task.Delay((int)delay);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _maxX = this.Width;
            _maxY = this.Height;
            ProcessGame();
        }

        private void ProcessGame()
        {
            InitGame(3);
            Fly(2000);
        }
    }
}