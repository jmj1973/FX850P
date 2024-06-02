# Steps

```
dotnet add src/Core/FX850P.Application package Microsoft.Extensions.DependencyInjection
dotnet add src/Core/FX850P.Application package Microsoft.Extensions.Configuration       
dotnet add src/Core/FX850P.Application package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add src/Core/FX850P.Application package MediatR
dotnet add src/Core/FX850P.Application package FluentValidation
```      

5.1. Add the Domain reference project

   ```
   dotnet add src/Core/FX850P.Application reference src/Core/FX850P.Domain/FX850P.Domain.csproj
   ```

5.2. Create the Application Services Registration

   - ApplicationServicesRegistration.cs

 
5.3. Create the application base infratructure 
    
    - Common\Dtos\BaseDto.cs
    - Common\Dtos\KeyValuePairDto.cs
    - Common\Dtos\PageResultDto.cs
    - Common\Dtos\QueryResultDto.cs
    - Common\Responses\BaseCommandResponse.cs
    
    - Constants\CustomClaimTypes.cs
    
    - Exceptions\BadRequestException.cs
    - Exceptions\DeleteFailureException.cs
    - Exceptions\NotFoundException.cs
    - Exceptions\ValidationException.cs

5.4. Add Identity
     
    - Identity\Interfaces\IAuthService.cs
    - Identity\Interfaces\IUserService.cs
    - Identity\Interfaces\IRoleService.cs
    - Identity\Models\AuthRequest.cs
    - Identity\Models\AuthResponse.cs
    - Identity\Models\JwtSettings.cs
    

Architecture With CQRS
======================

Queries
-------

```
public interface IQuery
{}
public interface IQueryHandler
{}
public interface IQueryHandler<T> : IQueryHandler where T : IQuery
{
  IList<IResult> Handle(T query);
}
public interface IQueryDispatcher
{
  IList<IResult> Send<T>(T query) where T : IQuery;
}
```
   
Commands
--------

```
public interface ICommand
{}
public interface ICommandHandler
{}
public interface ICommandHandler<T> : ICommandHandler where T : ICommand
{   
    Task Handle(T command);
}
public interface ICommandDispatcher
{
    void Send<T>(T command) where T : ICommand;
}   
```



Reference
--------- 
   https://abdelmajid-baco.medium.com/cqrs-pattern-with-c-a9aff05aae3f
   
   https://github.com/AbdelmajidBa/CQRSPattern
   
   
MediatR
=======
- Implement Commands and Queries operations.
- Implement Notifications.
- Use Dependency Injection to create a new instance of MediatR.
- Use MediatR with Console application and Web API application.

MediatR has two kinds of messages it dispatches:

- Request/response messages, dispatched to a single handler
- Notification messages, dispatched to multiple handlers


Add New Product
---------------
MediatR interface
```
IRequest<out TResponse>
```
DTO
```
public class AddNewProductCommand : IRequest<int>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
```
Handler
```
public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
{
    private readonly IApplicationContextInMemoryDB _context;
    private readonly IMediator _mediator;

    public AddNewProductCommandHandler(IApplicationContextInMemoryDB context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
    {
        //validation
        var validator = new AddNewProductCommandValidator();
        ValidationResult results = validator.Validate(request);
        bool validationSucceeded = results.IsValid;
        if (!validationSucceeded)
        {
            var failures = results.Errors.ToList();
            var message = new StringBuilder();
            failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(message.ToString());
        }
        //add new product
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            UnitPrice = 0,
            CurrentStock = 0
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        //notification
        await _mediator.Publish(new ProductCreated(product));

        return 1;
    }
}
```
Raise event (notification for after adding a product)
```
await _mediator.Publish(new ProductCreated(product))
```
DTO
```
 public class ProductCreated : INotification
{
    public Product NewProduct { get; }

    public ProductCreated(Product newProduct)
    {
        NewProduct = newProduct;
    }
}
```
Handler
```
public class NewProductCreatedHandler : INotificationHandler<ProductCreated>
{
    private readonly ILogger<NewProductCreatedHandler> _logger;

    public NewProductCreatedHandler(ILogger<NewProductCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Product {notification.NewProduct.Id} was added to data base.");
        return Task.CompletedTask;
    }
}
```

Calling the 
```
public class ProductMediatRController : ApiController
{
  private readonly IMediator _mediator;

  public ProductMediatRController(IMediator mediator)
  {
      _mediator = mediator;
  }
  [HttpPost]
  public async Task<IActionResult> PostAsync(CommandsMediatR.AddNewProductCommand command)
  {
      var response = await _mediator.Send(command);
      return NoContent();
  }
}
```

Register MediatR
----------------

```
//CQRS Pattern with MediatR

services.AddEntityFrameworkInMemoryDatabase()
      .AddDbContext<ApplicationContextInMemoryDB>(opt => opt.UseInMemoryDatabase(databaseName: "CQRS-MediatR"), ServiceLifetime.Singleton)
      .AddSingleton<IApplicationContextInMemoryDB>(p => p.GetService<ApplicationContextInMemoryDB>());
services.AddMediatR(new Type[] 
{ 
  typeof(CommandsMediatR.AddNewProductCommand),
 
});
```

```
private static IMediator BuildMediator()
{
    var services = new ServiceCollection();

    services.AddDbContext<ApplicationContextInMemoryDB>(opt => opt.UseInMemoryDatabase(databaseName:"CQRS-MediatR"), ServiceLifetime.Singleton);
    services.AddSingleton<IApplicationContextInMemoryDB>(p => p.GetService<ApplicationContextInMemoryDB>());
    services.AddMediatR(new Type[] { typeof(CommandsMediatR.AddNewProductCommand),
    });

    var serilogLogger = new LoggerConfiguration()
                .WriteTo.File($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}Logs{Path.DirectorySeparatorChar}application.log")
                .CreateLogger();

    services.AddLogging(builder =>
    {
        builder.SetMinimumLevel(LogLevel.Information);
        builder.AddSerilog(logger: serilogLogger, dispose: true);
    });


    var provider = services.BuildServiceProvider();
    return provider.GetRequiredService<IMediator>();
}
```


Reference
--------- 

   https://abdelmajid-baco.medium.com/cqrs-pattern-with-c-and-mediatr-part-2-2ded039b7f70
   
   https://github.com/jbogard/MediatR/wiki

