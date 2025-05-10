using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TodoListApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TodoListAppDbContextFactory : IDesignTimeDbContextFactory<TodoListAppDbContext>
{
    public TodoListAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        TodoListAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<TodoListAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new TodoListAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TodoListApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
