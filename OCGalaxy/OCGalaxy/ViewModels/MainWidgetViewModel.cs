using OCGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OCGalaxy.ViewModels
{
    public class MainWidgetViewModel : OCViewModelBase
    {
        public BusArrivalViewModel BusArrivalVM { get; protected set; } = new BusArrivalViewModel();
        public SettingsViewModel SettingsVM { get; protected set; } = new SettingsViewModel();

        private MenuItemModel _settingsMenuItem = null;
        public MenuItemModel SettingsMenuItem
        {
            get => _settingsMenuItem;
            protected set
            {
                _settingsMenuItem = value;
                RaisePropertyChanged(nameof(SettingsMenuItem));
            }
        }

        private ToggleMenuItemModel _searchApiMenuItem;
        public ToggleMenuItemModel SearchApiMenuItem
        {
            get => _searchApiMenuItem;
            set
            {
                _searchApiMenuItem = value;
                RaisePropertyChanged(nameof(SearchApiMenuItem));
            }
        }

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
            SettingsMenuItem = new MenuItemModel("Settings", "", "icons/appbar.settings.png", new Command(() => { SettingEnabled = true; }));
            SearchApiMenuItem = new ToggleMenuItemModel(false,
                new MenuItemModel("Start Searching", "Starts searching for Trips", "icons/appbar.control.play.png", new Command(() => { BusArrivalVM.StartApiCall(); })),
                new MenuItemModel("Stop Searching", "Stops searching for Trips", "icons/appbar.control.stop.png", new Command(() => { BusArrivalVM.StopApiCall(); }))
            );
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
