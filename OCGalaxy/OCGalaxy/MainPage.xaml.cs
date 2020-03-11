using OCGalaxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OCGalaxy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage, IRotaryEventReceiver
    {
        MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = this.BindingContext as MainViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MainViewModel;
            viewModel.OnBackButtonPressed();

            return base.OnBackButtonPressed();
        }

        public void Rotate(RotaryEventArgs args)
        {
            var viewModel = BindingContext as MainViewModel;
            viewModel.Rotate(args.IsClockwise);
        }
    }
}