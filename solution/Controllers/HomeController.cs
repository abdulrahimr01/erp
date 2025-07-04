using erp.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ERP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        string connString = "Host=192.168.1.3;Port=5432;Username=postgres;Password=gopi123@;Database=erp";

        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello from Controller!");
        }

        // POST: Insert employee
        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
        {
            using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("CALL sp_users(@name, @email, @position)", conn);
            cmd.Parameters.AddWithValue("name", employee.Name);
            cmd.Parameters.AddWithValue("email", employee.Email);
            cmd.Parameters.AddWithValue("position", employee.Position);
            await cmd.ExecuteNonQueryAsync();
            return Ok("Inserted.");
        }

        // // PUT: Update employee name by ID
        // app.MapPut("/employee/{id}", async (int id, string name) =>
        // {
        //     using var conn = new NpgsqlConnection(connString);
        //     await conn.OpenAsync();

        //     using var cmd = new NpgsqlCommand("CALL sp_update_employee(@id, @name)", conn);
        //     cmd.Parameters.AddWithValue("id", id);
        //     cmd.Parameters.AddWithValue("name", name);
        //     await cmd.ExecuteNonQueryAsync();

        //     return Results.Ok("Updated.");
        // });

        // // DELETE: Remove employee by ID
        // app.MapDelete("/employee/{id}", async (int id) =>
        // {
        //     using var conn = new NpgsqlConnection(connString);
        //     await conn.OpenAsync();

        //     using var cmd = new NpgsqlCommand("CALL sp_delete_employee(@id)", conn);
        //     cmd.Parameters.AddWithValue("id", id);
        //     await cmd.ExecuteNonQueryAsync();

        //     return Results.Ok("Deleted.");
        // });

    }
}