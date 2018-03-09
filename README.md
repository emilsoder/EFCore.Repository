# EFCore.Respository
### Generic repository pattern for ASP.NET Core implementing EF Core.

Generic repository pattern for ASP.NET Core as an abstraction to Entity Framework Core. 
 

## HOW TO (ASP.NET Core)
 
In the `ConfigureServices` method in the Startup class, EFCore.Repository provides extensions to `IServiceCollection` to inject `DbContext` and `EFCore.Repository.IRepository` with a single method.


### Example 1
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRepositoryWithDbContext<AppDbContext>(builder =>
    {
        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    });

    services.AddMvc();
}
```

Calling `AddRepositoryWithDbContext<DbContext>(...)` in Startup makes `IRepository` configured to use the supplied `DbContext`. Thus, `IRepository` can be used anywhere in the application.

### Example 2
Assumed the DbContext has a DbSet of class `Product`, we can use it this way to return a model of List<Product> using IRepository.
```csharp
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.ToList<Product>();

            return View(model);
        }
    }
```
