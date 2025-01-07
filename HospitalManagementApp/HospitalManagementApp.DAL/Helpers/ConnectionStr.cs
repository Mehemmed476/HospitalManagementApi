using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HospitalManagementApp.DAL.Helpers;

public class ConnectionStr
{
    public static string GetConnectionString()
    {
        ConfigurationManager configurationManager = new ConfigurationManager();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "HospitalManagementApp.API"));
        configurationManager.AddJsonFile("appsettings.json");
        
        string? connectionString = configurationManager.GetConnectionString("PcMsSql");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("No connection string found.");
        }
        
        return connectionString;
    }
}