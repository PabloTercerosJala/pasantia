using Dapper;
using Microsoft.Data.SqlClient;
using Web.Api.Models;

public class IJService
{
    private readonly string _connectionString;

    public IJService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<InnerJoin>> GetInnerJoinDataAsync()
    {
        using var connection = new SqlConnection(_connectionString);

        const string sql = "SELECT Employees.EmployeeName, Departments.DepartmentName FROM Employees INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID";

        var result = await connection.QueryAsync<InnerJoin>(sql);

        return result;
    }
}