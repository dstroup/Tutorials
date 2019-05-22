using NoesisApp;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Buttons
{
    partial class App : Application
    {
        protected override Display CreateDisplay()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new XDisplay();
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Win32Display();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        protected override RenderContext CreateRenderContext()
    {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //return new RenderContextGLX();
                return new RenderContextEGL();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new RenderContextWGL();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }
        static void Main(string[] args)
        {
            App app = new App();
            app.Uri = "App.xaml";
            app.Run();
        }
    }
}
