using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Persistance;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ELibraryAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("DefaultConnection")
                   ?? throw new InvalidOperationException("DefaultConnection is not configured.");
        }
    }
}
