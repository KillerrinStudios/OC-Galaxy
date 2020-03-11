using OCGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OCGalaxy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusArrivalControl : ContentView
    {
        public static readonly BindableProperty RouteNumberProperty = BindableProperty.Create(
            propertyName: nameof(RouteNumber),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: RouteNumberPropertyChanged);
        public string RouteNumber
        {
            get { return (string)GetValue(RouteNumberProperty); }
            set { SetValue(RouteNumberProperty, value); }
        }

        public static readonly BindableProperty RouteNameProperty = BindableProperty.Create(
            propertyName: nameof(RouteName),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: RouteNamePropertyChanged);
        public string RouteName
        {
            get { return (string)GetValue(RouteNameProperty); }
            set { SetValue(RouteNameProperty, value); }
        }

        public static readonly BindableProperty ArrivalTimeProperty = BindableProperty.Create(
            propertyName: nameof(ArrivalTime),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: ArrivalTimePropertyChanged);
        public string ArrivalTime
        {
            get { return (string)GetValue(ArrivalTimeProperty); }
            set { SetValue(ArrivalTimeProperty, value); }
        }

        public static readonly BindableProperty ArrivalTimeMeasurementProperty = BindableProperty.Create(
            propertyName: nameof(ArrivalTimeMeasurement),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: ArrivalTimeMeasurementPropertyChanged);
        public string ArrivalTimeMeasurement
        {
            get { return (string)GetValue(ArrivalTimeMeasurementProperty); }
            set { SetValue(ArrivalTimeMeasurementProperty, value); }
        }

        public static readonly BindableProperty StopNameProperty = BindableProperty.Create(
            propertyName: nameof(StopName),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: StopNamePropertyChanged);
        public string StopName
        {
            get { return (string)GetValue(StopNameProperty); }
            set { SetValue(StopNameProperty, value); }
        }

        public static readonly BindableProperty IsGPSProperty = BindableProperty.Create(
            propertyName: nameof(IsGPS),
            returnType: typeof(bool),
            declaringType: typeof(BusArrivalControl),
            defaultValue: false,
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: IsGPSPropertyChanged);
        public bool IsGPS
        {
            get { return (bool)GetValue(IsGPSProperty); }
            set { SetValue(IsGPSProperty, value); }
        }

        public BusArrivalControl()
        {
            InitializeComponent();
        }

        private static void RouteNumberPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.RouteNumberLabel.Text = newValue.ToString();
            Debug.WriteLine($"RouteNumber Changed: {oldValue} -> {newValue}");
        }
        private static void RouteNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.RouteNameLabel.Text = newValue.ToString();
            Debug.WriteLine($"RouteName Changed: {oldValue} -> {newValue}");
        }
        private static void ArrivalTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.ArrivalTimeLabel.Text = newValue.ToString();
            Debug.WriteLine($"ArrivalTime Changed: {oldValue} -> {newValue}");
        }
        private static void ArrivalTimeMeasurementPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.ArrivalTimeMeasurementLabel.Text = newValue.ToString();
            Debug.WriteLine($"ArrivalTimeMeasurement Changed: {oldValue} -> {newValue}");
        }
        private static void StopNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.StopNameLabel.Text = newValue.ToString();
            Debug.WriteLine($"StopName Changed: {oldValue} -> {newValue}");
        }
        private static void IsGPSPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.GPSIcon.IsVisible = (bool)newValue;
            Debug.WriteLine($"IsGPS Changed: {oldValue} -> {newValue}");
        }

    }
}