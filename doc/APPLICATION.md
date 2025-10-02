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
   
   
ApplicationMediator
===================
- Implement Commands and Queries operations.
- Implement Notifications.
- Use Dependency Injection to create a new instance of ApplicationMediator.
- Use ApplicationMediator with Console application and Web API application.

ApplicationMediator has two kinds of messages it dispatches:

- Request/response messages, dispatched to a single handler
- Notification messages, dispatched to multiple handlers


Add New Product
---------------
ApplicationMediator interface
```
IApplicationRequest<out TResponse>
```
DTO
```
public class AddNewProductCommand : IApplicationRequest<int>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
```
Handler
```
public class AddNewProductCommandHandler : IApplicationRequestHandler<AddNewProductCommand, int>
{
    private readonly IApplicationContextInMemoryDB _context;
    private readonly IApplicationMediator _application;

    public AddNewProductCommandHandler(IApplicationContextInMemoryDB context, IApplicationMediator application)
    {
        _context = context;
        _application = application;
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
        //await _mediator.Publish(new ProductCreated(product));

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
  private readonly IApplicationMediator _application;

  public ProductMediatRController(IApplicationMediator application)
  {
      _application = application;
  }
  [HttpPost]
  public async Task<IActionResult> PostAsync(CommandsMediatR.AddNewProductCommand command)
  {
      var response = await _application.Send<AddNewProductCommand,int>(command);
      return NoContent();
  }
}
```

Register ApplicationMediator
----------------------------

```
//CQRS Pattern with ApplicationMediator

        //Appliction Mediator
        services.AddSingleton<IApplicationMediator, ApplicationMediator>();

        //Application Behaviors
        // User        
        services.AddTransient<IApplicationRequestHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();


```



Reference
--------- 

   https://abdelmajid-baco.medium.com/cqrs-pattern-with-c-and-mediatr-part-2-2ded039b7f70
   
   https://github.com/jbogard/MediatR/wiki

