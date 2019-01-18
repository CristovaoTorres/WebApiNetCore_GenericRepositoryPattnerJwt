# WebApiNetCore_GenericRepositoryPattnerJwt

Install-Package Swashbuckle.AspNetCore -Version 3.0.0	

Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 2.2.0	

Install-Package AutoMapper -Version 7.0.1	

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 2.1.4

Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.4



https://docs.microsoft.com/pt-br/ef/core/get-started/aspnetcore/existing-db
Scaffold-DbContext "Server=.;Database=Escola;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
