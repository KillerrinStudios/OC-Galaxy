using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms.Renderer;
using Tizen.Wearable.CircularUI.Forms.Renderer.Widget;
using Xamarin.Forms;

namespace OCGalaxy.Tizen.Wearable.Widget
{
    class OCGalaxyWidgetBase : FormsWidgetBase
    {
        public override void OnCreate(Bundle content, int w, int h)
        {
            base.OnCreate(content, w, h);

            //var directory = "apps_rw/org.tizen.KillerrinStudios.OCGalaxy.Tizen.Widget.Wearable";
            //var secrets = "ec399b9d-08bf-4dd8-8d30-31c3bdeeea61";

            var app = new App(Models.OCApplicationType.Widget);
            LoadApplication(app);
        }
    }

    class OCGalaxyWidgetApp : FormsWidgetApplication
    {
        public OCGalaxyWidgetApp(Type type) : base(type)
        {
        }
    }
}
