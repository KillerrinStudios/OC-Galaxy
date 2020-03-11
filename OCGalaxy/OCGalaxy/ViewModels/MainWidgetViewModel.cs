using System;
using System.Collections.Generic;
using System.Text;

namespace OCGalaxy.ViewModels
{
    public class MainWidgetViewModel : OCViewModelBase
    {
        public BusArrivalViewModel BusArrivalVM { get; protected set; } = new BusArrivalViewModel();
        public SettingsViewModel SettingsVM { get; protected set; } = new SettingsViewModel();

        bool _settingEnabled;
        public bool SettingEnabled
        {
            get => _settingEnabled;
            set
            {
                _settingEnabled = value;
                RaisePropertyChanged(nameof(SettingEnabled));
            }
        }

        bool _mapEnabled;
        public bool MapEnabled
        {
            get => _mapEnabled;
            set
            {
                _mapEnabled = value;
                RaisePropertyChanged(nameof(MapEnabled));
            }
        }

        public MainWidgetViewModel()
        {

        }

        public override void Rotate(bool isClockwise)
        {
            base.Rotate(isClockwise);
        }

        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            MapEnabled = false;
            SettingEnabled = false;
        }
    }
}
