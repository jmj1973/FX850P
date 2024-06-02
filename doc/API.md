# Steps

```
dotnet add src/Web/FX850P.Api package Microsoft.EntityFrameworkCore.Tools
dotnet add src/Web/FX850P.Api package MediatR
dotnet add src/Web/FX850P.Api package Swashbuckle.AspNetCore
dotnet add src/Web/FX850P.Api package Microsoft.EntityFrameworkCore.Design
dotnet add src/Web/FX850P.Api package Microsoft.Extensions.Hosting.WindowsServices
```      

7.1. Add the reference projects

   ```
   dotnet add src/Web/FX850P.Api reference src/Core/FX850P.Application/FX850P.Application.csproj
   dotnet add src/Web/FX850P.Api reference src/Infrastructure/FX850P.Infrastructure/FX850P.Infrastructure.csproj
   dotnet add src/Web/FX850P.Api reference src/Infrastructure/FX850P.Presistence/FX850P.Presistence.csproj
   ```

7.2. Confirue the clean services in startup.cs


7.3. Migrations

Package Manage Console
```
//
// Examples - Commandline Tools for EF Core
// Make sure the package Microsoft.EntityFrameworkCore.Design in the startup project
// ----------------------------------------------------------------------------------------------------------------------------------
//  - add-migration -project FX850P.Presistence -context ApplicationDbContext -OutputDir Data/Migrations <migrationname>
//  - update-database  -project FX850P.Presistence -context ApplicationDbContext <migrationname>
//  - remove-migration -project FX850P.Presistence -context ApplicationDbContext <migrationname>
//
```

add-migration -project FX850P.Presistence -context ApplicationDBContext -OutputDir Data/Migrations CreateIdentitySchema

CLI

Install tool

```
dotnet tool install --global dotnet-ef
```

Verify tool

```
dotnet ef
```

migration add
```
dotnet ef -s src/Web/FX850P.Api/FX850P.Api.csproj migrations add CreateIdentitySchema -p src/Infrastructure/FX850P.Presistence/FX850P.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/FX850P.Api/FX850P.Api.csproj migrations add AddTechnician -p src/Infrastructure/FX850P.Presistence/FX850P.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

```



7.4. Create the Account Controller to allow login


7.5 Create Web API Controllers

