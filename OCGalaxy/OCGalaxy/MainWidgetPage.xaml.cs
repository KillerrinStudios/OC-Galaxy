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
    public partial class MainWidgetPage : CirclePage, IRotaryEventReceiver
    {
        MainWidgetViewModel _viewModel;
        public MainWidgetPage()
        {
            InitializeComponent();
            _viewModel = this.BindingContext as MainWidgetViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.OnBackButtonPressed();
            return false;
        }

        public void Rotate(RotaryEventArgs args)
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.Rotate(args.IsClockwise);
        }

        private void SettingsIconButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.SettingEnabled = true;
        }

        private void BusArrivalControl_GPSClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.MapEnabled = true;
        }

        private void StartApiIconButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.BusArrivalVM.StartApiCall();
        }

        private void StopApiIconButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as MainWidgetViewModel;
            viewModel.BusArrivalVM.StopApiCall();
        }
    }
}