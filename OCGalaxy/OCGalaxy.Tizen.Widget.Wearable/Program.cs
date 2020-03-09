using OCGalaxy.Tizen.Wearable.Widget;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Tizen.Wearable.CircularUI.Forms.Renderer;
using Xamarin.Forms;

namespace OCGalaxy.Tizen.Wearable.Widget
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new OCGalaxyWidgetApp(typeof(OCGalaxyWidgetBase));
            Forms.Init(app);
            FormsCircularUI.Init();
            app.Run(args);
        }
    }
}
