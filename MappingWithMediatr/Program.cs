using System;
using System.Reflection;
using System.Threading.Tasks;
using MappingWithMediatr.ServiceB;
using MappingWithMediatr.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MappingWithMediatr
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            RegisterServices();

            var scope = _serviceProvider.CreateScope();

            await scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<SomeServiceA>();
            services.AddTransient<SomeServiceB>();
            services.AddTransient<Func<string, IService>>(serviceProvider => key =>
            {
                return key switch
                {
                    nameof(SomeServiceA) => serviceProvider.GetService<SomeServiceA>(),
                    nameof(SomeServiceB) => serviceProvider.GetService<SomeServiceB>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
                };
            });

            services.AddSingleton<ConsoleApplication>();

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            switch (_serviceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }

}