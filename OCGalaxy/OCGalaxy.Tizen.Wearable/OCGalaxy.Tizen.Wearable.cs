using System;
using Xamarin.Forms;

namespace OCGalaxy
{
    class OCGalaxyApplication : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            var app = new App(Models.OCApplicationType.Application);
            LoadApplication(app);
        }
    }
}
