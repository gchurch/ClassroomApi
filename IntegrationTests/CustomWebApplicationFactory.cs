using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ClassroomApi;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ClassroomContext>));

                services.Remove(descriptor);

                services.AddDbContext<ClassroomContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: "IntegrationTestDatabase");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ClassroomContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory>>();

                    // Ensure that the database is a fresh version ready for testing
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    db.SaveChanges();

                    
                    try
                    {
                        SeedData.Initialize(scopedServices);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occured seeding the DB.");
                    }
                    
                }
            });
        }
    }
}
