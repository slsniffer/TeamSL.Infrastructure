using System;
using Autofac;
using TeamSL.Infrastructure.Example.Data;

namespace TeamSL.Infrastructure.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ExampleModule>();
            var container = builder.Build();

            var dbCreator = container.Resolve<IDbCreator>();
            dbCreator.Create();

            var presenter = container.Resolve<IPresenter>();
            presenter.Show();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
