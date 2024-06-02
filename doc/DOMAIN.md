# Steps

```
dotnet add src/Core/FX850P.Domain package Microsoft.Extensions.DependencyInjection
dotnet add src/Core/FX850P.Domain package Microsoft.Extensions.Configuration
dotnet add src/Core/FX850P.Domain package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```       

3.1. Create the Common Classes
   - Common\BaseDomainEntity.cs
   - Common\BaseAuditDomainEntity.cs
   - Common\PageResult.cs
   - Common\QueryResult.cs
   - Common\ValueObject.cs

3.2. Create the Presistence Interfaces
   - Presistence\Interfaces\IGenericRepository.cs   
   - Presistence\Interfaces\IUnitOfWork.cs
   - Presistence\Interfaces\IQueryObject.cs
   - Presistence\Interfaces\IUserService.cs
   - Presistence\Interfaces\IRoleService.cs


3.3. Create the Entities for Identiry

    - Entities\Identity\ApplicationUser.cs
    - Entities\Identity\ApplicationRole.cs 

3.4. Create Entiries

3.5. Create Repository interfaces

```
IJobRepository.cs

public interface IJobRepository : IGenericRepository<Job> { }
```
3.6. Create Query Resouce







