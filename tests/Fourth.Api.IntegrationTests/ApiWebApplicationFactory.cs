using Fourth.Api.IntegrationTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Testcontainers.MsSql;

//Microsoft.SqlServer.Smo.dll
using Microsoft.SqlServer.Management.Smo;
//Microsoft.SqlServer.ConnectionInfo.dll
using Microsoft.SqlServer.Management.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Fourth.IntegrationTests;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ConnectionStrings:DefaultConnectionString", _dbContainer.GetConnectionString());
	}

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var connectionString = _dbContainer.GetConnectionString();
		CreateDatabase(connectionString);
		CreateTablesAndData("instnwnd.sql", connectionString);
	}

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }

	public void CreateDatabase(string connectionString)
	{
		// Build connection string to master database
		SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
		string masterConnectionString = builder.ConnectionString;
		var databaseName = builder.InitialCatalog;

		using (SqlConnection conn = new SqlConnection(masterConnectionString))
		{
			conn.Open();
			// Check if the database exists
			string checkDbQuery = $"SELECT database_id FROM sys.databases WHERE name = '{databaseName}'";
			using (SqlCommand checkDbCmd = new SqlCommand(checkDbQuery, conn))
			{
				object result = checkDbCmd.ExecuteScalar();
				if (result == null)
				{
					// Database does not exist, create it
					string createDbQuery = $"CREATE DATABASE {databaseName}";
					using (SqlCommand createDbCmd = new SqlCommand(createDbQuery, conn))
					{
						createDbCmd.ExecuteNonQuery();
						Console.WriteLine($"Database '{databaseName}' created successfully.");
					}
				}
				else
				{
					Console.WriteLine($"Database '{databaseName}' already exists.");
				}
			}
		}
	}

	public void CreateTablesAndData(string scriptName, string dbConnectionString)
	{
		// Build connection string to the specified database.
		SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(dbConnectionString);
		string connectionString = builder.ConnectionString;

		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			conn.Open();
			// Read the SQL script from the file
			string script = File.ReadAllText(scriptName);
			// Use a try-catch block to handle potential errors during script execution
			try
			{
				Server server = new Server(new ServerConnection(conn));
				server.ConnectionContext.ExecuteNonQuery(script);
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"Error executing SQL script: {ex.Message}");
				// Optionally, you might want to log the error to a file or database.
				// You could also re-throw the exception if you want the caller to handle it.
				throw; // Re-throw the exception to propagate it.
			}
			catch (IOException ex)
			{
				Console.WriteLine($"Error reading SQL script file: {ex.Message}");
				throw;
			}
		}
	}
}
