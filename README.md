# mediatr-mapper
A Sample C# project for mapping objects with the help of https://github.com/jbogard/MediatR 

# Dependency Injection in a ConsoleApp
https://github.com/PradeepLoganathan/Injector

# Code examples
## Service A - Implementation
```cs
public class SomeServiceA : IService
{
    private readonly IMediator _mediator;

    public SomeServiceA(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ResponseModel> GetResponseModel()
    {
        // This is the ResponseA that needs to be mapped to ResponseModel
        var customResponse = new ResponseA
        {
            Id = 1,
            Description = nameof(SomeServiceA)
        };

        return await _mediator.Send(customResponse);
    }
}
```

## Service A - Handler
```cs
public class ResponseAHandler : IRequestHandler<ResponseA, ResponseModel>
{
    public Task<ResponseModel> Handle(ResponseA request, CancellationToken cancellationToken)
    {
        // Map from ResponseA to ResponseModel
        var response = new ResponseModel
        {
            Id = request.Id,
            Description = request.Description
        };

        return Task.FromResult(response);
    }
}
```

## Consumer 
```cs 
public async Task Run()
{
    var serviceA = _services(nameof(SomeServiceA));
    var modelA = await serviceA.GetResponseModel();            
    Console.WriteLine(modelA); // Id is "1" and Description is "SomeServiceA"

    var serviceB = _services(nameof(SomeServiceB));
    var modelB = await serviceB.GetResponseModel();            
    Console.WriteLine(modelB); // Id is "2" and Description is "SomeServiceB"
}
``` 