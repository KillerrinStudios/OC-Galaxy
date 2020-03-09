using Xamarin.Forms;

namespace OCGalaxy.Tizen.Wearable
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new OCGalaxyApplication();
            Forms.Init(app);
            app.Run(args);
        }
    }
}
