using System;
using System.Threading.Tasks;
using MappingWithMediatr.ServiceA;
using MappingWithMediatr.ServiceB;

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
            Console.WriteLine(modelA); // Id is "1" and Description is "SomeServiceA"

            var serviceB = _services(nameof(SomeServiceB));
            var modelB = await serviceB.GetResponseModel();            
            Console.WriteLine(modelB); // Id is "2" and Description is "SomeServiceB"
        }
    }
}
