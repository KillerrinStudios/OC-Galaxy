using Microsoft.Extensions.Configuration;
using OCGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OCGalaxy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static App GetCurrentApp() { return (App)App.Current; }
        public OCApplicationType ocApplicationType;

        public App(OCApplicationType appType)
        {
            ocApplicationType = appType;
            InitializeComponent();

            if (appType == OCApplicationType.Application)
            {
                MainPage = new MainPage();
            }
            else if (appType == OCApplicationType.Widget)
            {
                MainPage = new MainWidgetPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
