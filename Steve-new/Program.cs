using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.CSharp;
namespace Steve
{
    class program
    {
        static void Main(string[] args)
        {
            Graphics.Vector2 Size;
            Size.X = 90;//60;
            Size.Y = 30;

            var ConsoleOutput = new Graphics.Console.ConsoleWriter(Size);

            List<Application> TestApps = new List<Application>();
            TestApps.Add(new TestApplication());
            TestApps.Add(new TestApplication());
            TestApps.Add(new TestApplication());
            TestApps.Add(new TestApplication());
            TestApps.Add(new TestApplication());

            Application Menu = new App_menu(TestApps, new Graphics.Vector2(10,0));
            Application.RunApplication(Menu);

        }
    }
}