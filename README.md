# EFCore.Respository
## Generic repository pattern for ASP.NET Core implementing EF Core.

Generic repository pattern for ASP.NET Core, as an abstraction to Entity Framework Core. 
IRepository should be injected (services.AddTransient<IRepository, Repository>) in startup Configure method after DbContext has been registered in the IServicesCollection. 
