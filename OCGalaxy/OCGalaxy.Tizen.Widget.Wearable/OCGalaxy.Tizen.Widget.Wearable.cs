using System;
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
