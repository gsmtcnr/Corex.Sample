using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Data.Infrastructure.Orders.Order;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Corex.Sample.Presentation.ConsoleApp
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {

            new CorexStartup();
            var orderRepository = IoCManager.Resolve<IOrderRepository>();
            var get = orderRepository.Get(s => s.Position==1);
            Console.WriteLine("Hello World!");
        }

    }
}
