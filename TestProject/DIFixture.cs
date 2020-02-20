using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_example_app.Data;
using MVC_example_app.Interfaces;
using NetCore.AutoRegisterDi;
using System.Reflection;
using WebApplication1.Services;

public class DIFixture
{
    public DIFixture()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
         .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
         .Where(c => c.Name.EndsWith("Service"))
         .AsPublicImplementedInterfaces();

        serviceCollection.AddTransient<IAccountService, AccountService>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}