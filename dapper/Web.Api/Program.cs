using Dapper;
using Microsoft.Data.SqlClient;
using Web.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("innerjoin", async (IConfiguration configuration) =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    using var connection = new SqlConnection(connectionString);

    const string sql = "SELECT Employees.EmployeeName, Departments.DepartmentName FROM Employees INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID";

    var customers = await connection.QueryAsync<InnerJoin>(sql);

    return Results.Ok(customers);
});

app.Run();