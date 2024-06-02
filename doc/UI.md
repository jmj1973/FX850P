
# Steps

```
dotnet add src/Web/ServiceMate.Api package Microsoft.EntityFrameworkCore.Tools
dotnet add src/Web/ServiceMate.Api package MediatR
dotnet add src/Web/ServiceMate.Api package Swashbuckle.AspNetCore
dotnet add src/Web/ServiceMate.Api package Microsoft.EntityFrameworkCore.Design
dotnet add src/Web/ServiceMate.Api package Microsoft.Extensions.Hosting.WindowsServices    
dotnet add src/Web/ServiceMate.Api package Microsoft.VisualStudio.Web.CodeGeneration.Design
```   

9.1. Add the reference projects

   ```
   dotnet add src/Web/ServiceMate.Api reference src/Core/ServiceMate.Application/ServiceMate.Application.csproj
   dotnet add src/Web/ServiceMate.Api reference src/Infrastructure/ServiceMate.Infrastructure/ServiceMate.Infrastructure.csproj
   dotnet add src/Web/ServiceMate.Api reference src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj
   ```

9.2. Confirue the clean services in startup.cs

9.3. Migrations

Package Manage Console
```
//
// Examples - Commandline Tools for EF Core
// Make sure the package Microsoft.EntityFrameworkCore.Design in the startup project
// ----------------------------------------------------------------------------------------------------------------------------------
//  - add-migration -project ServiceMate.Presistence -context ApplicationDbContext -OutputDir Data/Migrations <migrationname>
//  - update-database  -project ServiceMate.Presistence -context ApplicationDbContext <migrationname>
//  - remove-migration -project ServiceMate.Presistence -context ApplicationDbContext <migrationname>
//
```

add-migration -project ServiceMate.Presistence -context ApplicationDBContext -OutputDir Data/Migrations CreateIdentitySchema

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
dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add CreateIdentitySchema -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddTechnician -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddStatusStateAndStatusFlag -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddCompany -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddLabourCodeAndPartAndProduct -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddChargeType -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddJob -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddDamageProductsAndPartHistories -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add MakeTechnicianOptinalWhenCreatingJob -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddLabourCodesAndNotes -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add MakeJobFieldsOptionalWhenCreatingJob -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddPartInformationToPartHistory -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddQuantityToPartHistory -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddDocuments -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddNotes -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddSeedForLabourCodes -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddPartIdToPartHistories -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddAuditToDocuments -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddFilenameAnTypeToDocuments -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddGuidToDocuments -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AddDamageReportAndDamageReportType -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add ExpandStreetAddressForCompany -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

dotnet ef -s src/Web/ServiceMate.Api/ServiceMate.Api.csproj migrations add AssessmentFeeToDamageReport -p src/Infrastructure/ServiceMate.Presistence/ServiceMate.Presistence.csproj -c ApplicationDBContext -o Data/Migrations

```


9.4. Create the Account Controller to allow login

9.5 Create Web API Controllers

9.6 Add UI 



## Steps:

1. Default ASP.NET Core Web App (Model-View-Controller)select the Authentication Type as Individual accounts
   Using the default Microsoft Identity in the project.

2. Download AdminLTE (https://github.com/ColorlibHQ/AdminLTE/releases)

3. Copy css, js, img and plugins to wwwroot

4. Adding Layout pages & Partial Views

5. Add Options: HostingOptions 

6. Add Helpers
	- NavigationIndicatorHelper.cs
	- EcostEdiablieTagHelper.cs



=====================


2. Define Roles

3. Define Permissions

4. Seeding Users and Roles

5. Displaying a list of registrted users 

6. Displaying a list of roles 

7. Manage User Roles

8. Roles-Permission Management

9. Claims Helper

10. Permission Requirement

11. Authorization Handler

12. Permission Policy Provider

13. Registering the Service


17. Adding Navigation

19. Navigation Indicator

20. Integrating the UI with existing Authentication

21. Authenticated Status Based Menu

22. ProdutType, Product, Reseller and Credit



24. Add JWT Token validation

25. Add JWT Token Controller for the WEB API

26. Publish fist version

27. Add Verify WEB API

28. Custom User data

30. Update UI to be consistent

31. Import products

32. Create Credits

33. Assign Credits

34. Running application as Service

35. Audit Logs
