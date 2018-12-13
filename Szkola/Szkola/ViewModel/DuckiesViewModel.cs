using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.ViewModel
{
    public class DuckiesViewModel : BaseViewModel
    {
        private int _score;

        public int Score {
            get => _score;
            set {
                if (_score != value)
                {
                    _score = value;
                    RaisePropertyChanged(nameof(Score));
                }
            }
        }
    }
}
