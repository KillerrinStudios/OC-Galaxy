using System;
using System.Collections.Generic;
using System.Text;

namespace OCGalaxy.ViewModels
{
    public class MainViewModel : OCViewModelBase
    {
        public MainViewModel()
        {
        }

        public override void Rotate(bool isClockwise)
        {
            base.Rotate(isClockwise);
        }

        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
        }
    }
}
