ASP.NET Core
============

ASP.NET Core is an open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. ASP.NET Core apps can run on .NET Core or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux. [Learn more about ASP.NET Core](https://docs.microsoft.com/aspnet/core/).


# Generic Repository
GenericRepository project is generic implementation of Repository pattern in .NET.

Swashbuckle.AspNetCore
=========

1. Install the standard Nuget package into your ASP.NET Core application.

    ```
    Package Manager : Install-Package Swashbuckle.AspNetCore
    CLI : dotnet add package Swashbuckle.AspNetCore
    ```

2. In the _ConfigureServices_ method of _Startup.cs_, register the Swagger generator, defining one or more Swagger documents.

    ```csharp
    using Swashbuckle.AspNetCore.Swagger;
    
    services.AddMvc();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
    });
    ```

3. Ensure your API actions and non-route parameters are decorated with explicit "Http" and "From" bindings.

    ```csharp
    [HttpPost]
    public void CreateProduct([FromBody]Product product)
    ...

    [HttpGet]
    public IEnumerable<Product> SearchProducts([FromQuery]string keywords)
    ...
    ```

    _NOTE: If you omit the explicit parameter bindings, the generator will describe them as "query" params by default._

4. In the _Configure_ method, insert middleware to expose the generated Swagger as JSON endpoint(s)

    ```csharp
    app.UseSwagger();
    ```

    _At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."_

5. Optionally insert the swagger-ui middleware if you want to expose interactive documentation, specifying the Swagger JSON endpoint(s) to power it from.

    ```csharp
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    ```

    _Now you can restart your application and check out the auto-generated, interactive docs at "/swagger"._

# .Net Core WebApi 

Install-Package Swashbuckle.AspNetCore -Version 3.0.0	

Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 2.2.0	

Install-Package AutoMapper -Version 7.0.1	

Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 5.0.1

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 2.1.4

Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.4




https://docs.microsoft.com/pt-br/ef/core/get-started/aspnetcore/existing-db
Scaffold-DbContext "Server=.;Database=Escola;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


# Example 1: C# .NET Core Service Integration

Repository: [eg-01-csharp-jwt-core](https://github.com/docusign/eg-01-csharp-jwt-core)

<!--
## Articles and Screencasts

* Guide: Using bearrer JWT flow with DocuSign.
* Screencast: Using OAuth JWT flow with DocuSign.
* Guide: Sending an envelope with the Node.JS SDK.
* Screencast: Sending an example with Node.JS SDK.
-->

## Introduction



## Installation

Requirements: C# and .NET Core 2.1 or later.

This repository has been tested as a Visual Studio 2017
Community Edition solution.

### Short installation instructions
* Download or clone this repository.
* The repository includes a Visual Studio 2017 solution file and 
  NuGet package references in the project file.
* Configure the project by editing the existing project file
  `common/App.config`
  
  See the Configuration section, below, for more information.
* The solution's Main class is in `common/Program.cs`

## Configure the example



**Recommendation:** add `common/App.config` to your `.gitignore` file so your 
private information will not be added to your repository.

Do not store your Integration Key, private key, or other
private information in your code repository.


## Run the examples

Build, then run the solution to see its output.
## Support, Contributions, License

Submit support questions to [StackOverflow](https://stackoverflow.com). Use tag `docusignapi`.

Contributions via Pull Requests are appreciated. Pull requests for the common
files must be contributed to the 
[eg-01-csharp-jwt-common](https://github.com/docusign/eg-01-csharp-jwt-common)
repository.

This repository uses the MIT license, see the
LICENSE file.
