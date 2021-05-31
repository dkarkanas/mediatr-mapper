using System;
using System.Threading.Tasks;
using MappingWithMediatr.ServiceB;
using MappingWithMediatr.Services;

namespace MappingWithMediatr
{
    public class ConsoleApplication
    {
        private readonly Func<string, IService> _services;

        public ConsoleApplication(Func<string, IService> services)
        {
            _services = services;
        }

        public async Task Run()
        {
            var serviceA = _services(nameof(SomeServiceA));
            var modelA = await serviceA.GetResponseModel();
            Console.WriteLine(modelA);

            var serviceB = _services(nameof(SomeServiceB));
            var modelB = await serviceB.GetResponseModel();
            Console.WriteLine(modelB);
        }
    }
}
