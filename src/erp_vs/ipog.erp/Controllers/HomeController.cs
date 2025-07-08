using System.Numerics;
using ipog.erp.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly string _connString;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _connString = config.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        // POST: Insert employee
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            Employee employee = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_usersget(@p_action, @p_id)", conn);
            cmd.Parameters.AddWithValue("p_action", "GETBYID");
            cmd.Parameters.AddWithValue("p_id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                employee = new Employee
                {
                    Name = reader["name"]?.ToString(),
                    Email = reader["email"]?.ToString(),
                    Position = reader["mobile"]?.ToString()
                };
            }
            else
            {
                return NotFound($"No user found with id {id}");
            }
            return Ok(employee);
        }

        // POST: Insert employee
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Employee> employees = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_usersget(@p_action)", conn);
            cmd.Parameters.AddWithValue("p_action", "GETALL");
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Name = reader["name"]?.ToString(),
                    Email = reader["email"]?.ToString(),
                    Position = reader["mobile"]?.ToString()
                });
            }
            else
            {
                return NotFound($"No user found");
            }
            return Ok(employees);
        }

        // POST: Insert employee
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter()
        {
            List<Employee> employees = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_usersget(@p_action)", conn);
            cmd.Parameters.AddWithValue("p_action", "FILTER");
            cmd.Parameters.AddWithValue("p_skip", 0);
            cmd.Parameters.AddWithValue("p_take", 10);
            cmd.Parameters.AddWithValue("p_ordercol", "id");
            cmd.Parameters.AddWithValue("p_orderdir", "ASC");
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Name = reader["name"]?.ToString(),
                    Email = reader["email"]?.ToString(),
                    Position = reader["mobile"]?.ToString()
                });
            }
            else
            {
                return NotFound($"No user found");
            }
            return Ok(employees);
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
