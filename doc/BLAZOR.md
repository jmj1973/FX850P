
# Steps

```
dotnet tool install --global dotnet-ef --version 8.*

dotnet add src/Web/FX850P.Blazor package Microsoft.EntityFrameworkCore.Tools
dotnet add src/Web/FX850P.Blazor package MediatR
dotnet add src/Web/FX850P.Blazor package Microsoft.EntityFrameworkCore.Design
dotnet add src/Web/FX850P.Blazor package Microsoft.Extensions.Hosting.WindowsServices    
dotnet add src/Web/FX850P.Blazor package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet add src/Web/FX850P.Blazor package Microsoft.Extensions.Identity.Core

// Microsoft.AspNetCore.Authentication is deprecated, replace with
dotnet add src/Web/FX850P.Blazor package Microsoft.AspNetCore.Identity.UI
dotnet add src/Web/FX850P.Blazor package Microsoft.AspNetCore.Identity.EntityFrameworkCore

```   

10.1. Add the reference projects

   ```
   dotnet add src/Web/FX850P.Blazor reference src/Core/FX850P.Application/FX850P.Application.csproj
   dotnet add src/Web/FX850P.Blazor reference src/Infrastructure/FX850P.Infrastructure/FX850P.Infrastructure.csproj
   dotnet add src/Web/FX850P.Blazor reference src/Infrastructure/FX850P.Presistence/FX850P.Presistence.csproj
   ```

10.2. Confirue the clean services in startup.cs


10.3. Migrations

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

```

