# Steps

```
dotnet tool install -g dotnet-coverage
dotnet tool install -g dotnet-reportgenerator-globaltool

```   
11.1. Add package refrences

```
dotnet add test/Web/FX850P.Blazor.Tests package Microsoft.NET.Test.Sdk
dotnet add test/Web/FX850P.Blazor.Tests package xunit
dotnet add test/Web/FX850P.Blazor.Tests package xunit.runner.visualstudio
dotnet add test/Web/FX850P.Blazor.Tests package coverlet.collector    

```

Must be repeated for all the test projects

11.2. Add project refrences

```
dotnet add test/Web/FX850P.Blazor.Tests/FX850P.Blazor.Tests.csproj reference src/Web/FX850P.Blazor/FX850P.Blazor.csproj
```

Must be repeated for all the test projects


11.3. Write necessary test

Unit Tests
Integration Tests
Load Tests

11.4. run test and coverage report

### Navigate to test project

Windows

cd c:\projects\jmj1973\FX850P\test\Web\FX850P.Blazor.Tests\

Linux

cd ~/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests


### Delete previous test results

Windows

del /s /q c:\projects\jmj1973\FX850P\test\Web\FX850P.Blazor.Tests\TestResults
del /s /q c:\projects\jmj1973\FX850P\test\Web\FX850P.Blazor.Tests\coveragereport

Linux

rm -R ~/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/TestResults
rm -R ~/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/coveragereport

### Run the Coverlet.Collector

dotnet test ../../../FX50P.sln --collect:"XPlat Code Coverage"

### Generate the Code Coverage HTML Report

Windows

reportgenerator -reports:"c:/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/**/coverage.cobertura.xml" -targetdir:"c:/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/coveragereport" -reporttypes:Html -historydir:c:/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/CoverageHistory

Linux

reportgenerator -reports:"/home/jan/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/**/coverage.cobertura.xml" -targetdir:"/home/jan/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.Tests/coveragereport" -reporttypes:Html -historydir:/home/jan/projects/jmj1973/FX850P/test/Web/FX850P.Blazor.TestsCoverageHistory







