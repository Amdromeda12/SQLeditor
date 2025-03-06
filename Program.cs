using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Serilog;
using Serilog.Sinks;
using SQLeditor.Services;

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
            // 🔹 Initialize Serilog for logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Set minimum log level
                .WriteTo.Console()    // Write logs to Console (useful for debugging)
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Save logs in a file
                .CreateLogger();

            try
            {
                Log.Information("Application is starting...");

                string databasePath = "";
                var container = DependencyInjection.Configure(databasePath);

                using (var scope = container.BeginLifetimeScope())
                {
                    var form = scope.Resolve<Form1>();
                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly!");
            }
            finally
            {
                Log.CloseAndFlush(); // 🔹 Ensure all logs are saved before the app exits
            }
        }
    }
}
