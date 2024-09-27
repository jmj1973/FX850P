

1.0.0.1
=======

- CHANGE:   Updating your project to use File Scoped Namespaces

dotnet tool update --global dotnet-format
dotnet format FX850P.sln --severity info --diagnostics=IDE0161

- CHANGE:   Update net8 SDK to 8.0.401
- CHANGE:   Update net8 SDK to 8.0.400
- CHANGE:   Update net8 SDK to 8.0.303
- CHANGE:   Update net8 SDK to 8.0.302
- CHANGE:   Update net8 SDK to 8.0.301
- FIX:      Remove Management from the user name
- ADD:      Add serilog to file
- CHANGE:   MudBlazor 7.6.0. 
- CHANGE:   MudBlazor 7.5.0. 
- CHANGE:   MudBlazor 7.3.0. 
- CHANGE:   MudBlazor 7.0.0. 
            https://github.com/MudBlazor/MudBlazor/issues/8447

- ADD:      Static Code analysis
            https://www.milanjovanovic.tech/blog/improving-code-quality-in-csharp-with-static-code-analysis?utm_source=newsletter&utm_medium=email&utm_campaign=tnw101    

- CHANGE:   Upgrade donet-ef tools
dotnet tool update --global dotnet-ef



NOTE:
=====
Make sure the correct db is confiured for the migrations in appsettings.json

MSSQL
=====

dotnet ef -s src/Web/FX850P.Blazor/FX850P.Blazor.csproj migrations add CreateIdentitySchema -p src/Infrastructure/FX850P.Presistence.MSSQL/FX850P.Presistence.MSSQL.csproj -c ApplicationDBContext -o Data/Migrations

PostgreSQL
==========

dotnet ef -s src/Web/FX850P.Blazor/FX850P.Blazor.csproj migrations add CreateIdentitySchema -p src/Infrastructure/FX850P.Presistence.PostgreSQL/FX850P.Presistence.PostgreSQL.csproj -c ApplicationDBContext -o Data/Migrations

SQLite
======

dotnet ef -s src/Web/FX850P.Blazor/FX850P.Blazor.csproj migrations add CreateIdentitySchema -p src/Infrastructure/FX850P.Presistence.SQLite/FX850P.Presistence.SQLite.csproj -c ApplicationDBContext -o Data/Migrations
