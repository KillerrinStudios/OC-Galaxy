using Microsoft.Extensions.Configuration;
using OCGalaxy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IConfiguration Configuration;

        public App(OCApplicationType appType)
        {
            ocApplicationType = appType;
            InitializeComponent();

            var builder = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets("8aa55baf-e1e1-40c2-a1bb-669855870a4a");
            Configuration = builder.Build();
           
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
