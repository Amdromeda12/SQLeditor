using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace SQLeditor
{
    public static class DependencyInjection
    {
        public static IContainer Configure(string databasePath)
        {
            var builder = new ContainerBuilder();

            // Register DatabaseService as a singleton
            builder.Register(c => new DatabaseService(databasePath)).AsSelf().SingleInstance();

            // Register Form1 and inject DatabaseService
            builder.RegisterType<Form1>().AsSelf();

            return builder.Build();
        }
    }
}
