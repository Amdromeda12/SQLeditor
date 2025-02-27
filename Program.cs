using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace SQLeditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string databasePath = "";
            var container = DependencyInjection.Configure(databasePath);
            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<Form1>();
                Application.Run(form);
            }
        }
    }
}
