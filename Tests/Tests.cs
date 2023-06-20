using System.Data.SqlTypes;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests;

public class Tests
{
    private static readonly string ConnectionString =
        $"Data Source=.;Initial Catalog=EF_Test_{Guid.NewGuid()};Integrated Security=True;Encrypt=False";

    private static IServiceProvider _serviceProvider = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(config => config.AddConsole());
        serviceCollection.AddDbContext<AppDbContext>(builder => builder.UseSqlServer(ConnectionString));

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        var appDbContext = _serviceProvider.GetRequiredService<AppDbContext>();
        appDbContext.Database.EnsureDeleted();
    }

    [Test]
    public void Test()
    {
        var appDbContext = _serviceProvider.GetRequiredService<AppDbContext>();

        appDbContext.Add(new Child2Entity(Guid.NewGuid(), "Name"));
        appDbContext.SaveChanges();

        Assert.Catch<SqlNullValueException>(() => appDbContext.Set<BaseEntity>().ToList());
    }
}
