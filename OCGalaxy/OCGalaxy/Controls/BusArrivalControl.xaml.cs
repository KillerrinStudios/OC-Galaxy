using OCGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OCGalaxy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusArrivalControl : ContentView
    {
        public string RouteNumber
        {
            get { return (string)GetValue(RouteNumberProperty); }
            set { SetValue(RouteNumberProperty, value); }
        }

        public string RouteName
        {
            get { return (string)GetValue(RouteNameProperty); }
            set { SetValue(RouteNameProperty, value); }
        }

        public string ArrivalTime
        {
            get { return (string)GetValue(ArrivalTimeProperty); }
            set { SetValue(ArrivalTimeProperty, value); }
        }

        public string ArrivalTimeMeasurement
        {
            get { return (string)GetValue(ArrivalTimeMeasurementProperty); }
            set { SetValue(ArrivalTimeMeasurementProperty, value); }
        }

        public string StopName
        {
            get { return (string)GetValue(StopNameProperty); }
            set { SetValue(StopNameProperty, value); }
        }

        public bool IsGPS
        {
            get { return (bool)GetValue(IsGPSProperty); }
            set { SetValue(IsGPSProperty, value); }
        }

        public ICommand GPSCommand
        {
            get { return (ICommand)GetValue(GPSCommandProperty); }
            set { SetValue(GPSCommandProperty, value); }
        }

        public ICommand GPSCommandParameter
        {
            get { return (ICommand)GetValue(GPSCommandParameterProperty); }
            set { SetValue(GPSCommandParameterProperty, value); }
        }

        public event EventHandler GPSClicked;

        public BusArrivalControl()
        {
            InitializeComponent();
        }

        private void GPSIcon_Clicked(object sender, EventArgs e)
        {
            GPSClicked?.Invoke(this, e);
        }

        #region Bindable Properties
        public static readonly BindableProperty RouteNumberProperty = BindableProperty.Create(
            propertyName: nameof(RouteNumber),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: RouteNumberPropertyChanged);

        public static readonly BindableProperty RouteNameProperty = BindableProperty.Create(
            propertyName: nameof(RouteName),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: RouteNamePropertyChanged);

        public static readonly BindableProperty ArrivalTimeProperty = BindableProperty.Create(
            propertyName: nameof(ArrivalTime),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: ArrivalTimePropertyChanged);

        public static readonly BindableProperty ArrivalTimeMeasurementProperty = BindableProperty.Create(
            propertyName: nameof(ArrivalTimeMeasurement),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: ArrivalTimeMeasurementPropertyChanged);

        public static readonly BindableProperty StopNameProperty = BindableProperty.Create(
            propertyName: nameof(StopName),
            returnType: typeof(string),
            declaringType: typeof(BusArrivalControl),
            defaultValue: "",
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: StopNamePropertyChanged);

        public static readonly BindableProperty IsGPSProperty = BindableProperty.Create(
            propertyName: nameof(IsGPS),
            returnType: typeof(bool),
            declaringType: typeof(BusArrivalControl),
            defaultValue: false,
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: IsGPSPropertyChanged);

        public static readonly BindableProperty GPSCommandProperty = BindableProperty.Create(
            propertyName: nameof(GPSCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(BusArrivalControl),
            defaultValue: null,
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: GPSCommandPropertyChanged);

        public static readonly BindableProperty GPSCommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(GPSCommandParameter),
            returnType: typeof(object),
            declaringType: typeof(BusArrivalControl),
            defaultValue: null,
            defaultBindingMode: Xamarin.Forms.BindingMode.OneWay,
            propertyChanged: GPSCommandParameterPropertyChanged);

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
            Debug.WriteLine($"ArrivalTime Changed: {oldValue} -> {newValue}");

            string value = newValue.ToString();
            control.ArrivalTimeLabel.Text = value;

            if (value == "0" || string.IsNullOrWhiteSpace(value))
            {
                control.ArrivalTimeLabel.IsVisible = false;
                control.ArrivalTimeMeasurementLabel.IsVisible = false;
            }
            else
            {
                control.ArrivalTimeLabel.IsVisible = true;
                control.ArrivalTimeMeasurementLabel.IsVisible = true;
            }
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

            var value = (bool)newValue;
            control.GPSIcon.IsVisible = value;
            control.GPSIcon.IsEnabled = value;
            Debug.WriteLine($"IsGPS Changed: {oldValue} -> {newValue}");
        }
        private static void GPSCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.GPSIcon.Command = (ICommand)newValue;
            Debug.WriteLine($"GPSCommand Changed: {oldValue} -> {newValue}");
        }
        private static void GPSCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BusArrivalControl control = (BusArrivalControl)bindable;
            control.GPSIcon.CommandParameter = newValue;
            Debug.WriteLine($"GPSCommandParameter Changed: {oldValue} -> {newValue}");
        }
        #endregion
    }
}