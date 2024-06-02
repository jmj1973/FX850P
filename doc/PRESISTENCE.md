
# Steps

```
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.Extensions.DependencyInjection
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.Extensions.Configuration       
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add src/Infrastructure/FX850P.Presistence package Newtonsoft.Json
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.AspNetCore.Identity
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/Infrastructure/FX850P.Presistence package System.IdentityModel.Tokens.Jwt
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.EntityFrameworkCore.Sqlserver
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/Infrastructure/FX850P.Presistence package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.EntityFrameworkCore.Tools
dotnet add src/Infrastructure/FX850P.Presistence package Microsoft.EntityFrameworkCore.Design
```  

4.1. Add the Domain reference project

   ```
   dotnet add src/Infrastructure/FX850P.Presistence reference src/Core/FX850P.Domain/FX850P.Domain.csproj
   dotnet add src/Infrastructure/FX850P.Presistence reference src/Core/FX850P.Application/FX850P.Application.csproj
   ```
 
4.2. Create the generic Ripository

   - Repositories\GenericRepository.cs
   - Repositories\UnitOfWork.cs

4.3. Create Extensions
   
    - Extensions\IQueryableExtensions.cs
    - Extensions\PropertyBuilderExtensions.cs

4.4. Create the Services

4.5. Create the Configurations (Seeding)

4.6. Create the DBContext With Identity

    - ApplicationDBContext.cs

4.7. Create the Presistence Services Registration

   - PresistenceServicesRegistration.cs
    
4.8. Create the Presistence Configuration

   - PresistenceConfiguration.cs


Add DBSet to DBContext

Create Configurations

Create Repositories
```
JobRepository.cs

    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public JobRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
```

Register Repositories

Create Migrations

