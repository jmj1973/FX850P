# FX850P

 This is a project to create the My Old Casio FX-850P functions in an Asp.Net Core application.

 Use Visual Studio Code and .Net 9.0
 
 [Release](doc/RELEASE.md)

## Visual Studio Code
 Microsoft Visual Code (64-bit) - Current
 Version 1.74.3

## .Net 9.0
 Microsoft .NET SDK 9.0.101

## Running the code
 Check the gode out
 Open in Visual Studio
 Change appsettings.json to your SQL/SQLExpress DB


 ## Clean Architeture

``` 
  MVC - API - Application - Domain - Presisence - DB
  |       |   |                   |  |             |
  +-------+   +-------------------+  +-------------+
     Web              Core            Infrastructure
```
  BLAZOR: (Web)
  
  MVC: (Web)

  API: (Web)

  Application: (Core)
  - DTOs
  - Command
  - Queries

  MediatR
  read Queries
  write Commands
  AutoMapper
  DTOs - Entities

  Domain: (Core)
  - Entities
  - Interfaces
  - Resouces

  Presistence: (Infrastructure)
  - Repositories
  - DBContext
  - Configurations(Seed)
  - Migrations

  Infrastructure (Infrastructure)


 ## Steps

 1. Create a blank soloution
    - Folder structure: src and tests
    ```
    dotnet new sln -o FX850P
    cd FX850P
    mkdir doc
    mkdir src
    mkdir test
    ```    

 2. Setup some Clean archtecture projects
    - FX850P.Application (Core)
       Class Library .NET 9.0
       ```
       dotnet new classlib -f net9.0 -n FX850P.Application -o src/Core/FX850P.Application
       dotnet sln add src/Core/FX850P.Application/FX850P.Application.csproj
       ```
    - FX850P.Clean.Domain (Core)
       Class Library .NET 9.0
       ```
       dotnet new classlib -f net9.0 -n FX850P.Domain -o src/Core/FX850P.Domain
       dotnet sln add src/Core/FX850P.Domain/FX850P.Domain.csproj
       ```       
    - FX850P.Infrastructure (Infrastructure)
       Class Library .NET 9.0
       ```
       dotnet new classlib -f net9.0 -n FX850P.Infrastructure -o src/Infrastructure/FX850P.Infrastructure
       dotnet sln add src/Infrastructure/FX850P.Infrastructure/FX850P.Infrastructure.csproj
       ```              
    - FX850P.Presistence (Infrastructure)
       Class Library .NET 9.0
       ```
       dotnet new classlib -f net9.0 -n FX850P.Presistence -o src/Infrastructure/FX850P.Presistence
       dotnet sln add src/Infrastructure/FX850P.Presistence/FX850P.Presistence.csproj
       ```    
    - FX850P.Api (Web)
       ASP.NET Core Web API .NET 9.0
       ```
       dotnet new webapi -f net9.0 -n FX850P.Api -o src/Web/FX850P.Api
       dotnet sln add src/Web/FX850P.Api/FX850P.Api.csproj
       ``` 
    - FX850P.Mvc (Web)
       ASP.NET Core Web App (Model-View-Controller) .NET 9.0
       ```
       dotnet new mvc -f net9.0 -n FX850P.Mvc -o src/Web/FX850P.Mvc
       dotnet sln add src/Web/FX850P.Mvc/FX850P.Mvc.csproj
       ```        
    - FX850P.Ui (Web)
       ASP.NET Core Web App (Model-View-Controller) .NET 9.0
       ```
       dotnet new mvc -f net9.0 -n FX850P.Ui -o src/Web/FX850P.Ui
       dotnet sln add src/Web/FX850P.Ui/FX850P.Ui.csproj
       ```        

    - FX850P.Blazor (Web)
       ASP.NET Core Web App (Blazor Server) .NET 9.0
       ```
       dotnet new install MudBlazor.Templates
       dotnet new mudblazor --host server -n FX850P.Blazor -o src/Web/FX850P.Blazor
       dotnet sln add src/Web/FX850P.Blazor/FX850P.Blazor.csproj
       ```        

    - FX850P.Blazor.Tests (Web)
       xUniy Test project .NET 9.0
       ```
       dotnet new xunit -f net9.0 -o test/Web/FX850P.Blazor.Tests
       dotnet sln add test/Web/FX850P.Blazor.Tests/FX850P.Blazor.Tests.csproj
       ```                    

3. Domain
   [Domain](doc/DOMAIN.md)

4. Presistence
   [Presistence](doc/PRESISTENCE.md)

5. Application
   [Application](doc/APPLICATION.md)

6. Infrastructure
   [Infrastructure](doc/INFRASTRUCTURE.md) 
   
7. API
   [API](doc/API.md) 

8. MVC
   [MVC](doc/MVC.md) 
   
9. UI
   [UI](doc/UI.md) 

10. BLAZOR
   [BLAZOR](doc/BLAZOR.md)    
   
11. TESTING
    [TESTING](doc/TESTING.md) 

Flow of adding new entities
==========================

Domain:
- Entities
- Resources Query
- Presistance Interfaces Repositories

Presistence:
- DatabaseContext
- Reporistory
- Specification

Application:
- Comand
- Queries
- Dtos





   
