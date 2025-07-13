using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // ✅ Required for JWT
using WebAPI_WEEK_4.Models;
using WebAPI_WEEK_4.Services;              // ✅ Kafka service
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.Json;                    // ✅ For serializing employee to JSON
using System.Threading.Tasks;

namespace WebAPI_WEEK_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ✅ Enforce JWT token
    public class EmployeeController : ControllerBase
    {
        private readonly IKafkaProducerService _kafkaProducer;

        // In-memory employee list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 50000,
                Permanent = true,
                Department = new Department { DepartmentId = 1, DepartmentName = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { SkillId = 1, SkillName = "C#" },
                    new Skill { SkillId = 2, SkillName = "SQL" }
                },
                DateOfBirth = new DateTime(1990, 1, 1)
            }
        };

        // ✅ Constructor injection for Kafka producer
        public EmployeeController(IKafkaProducerService kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        [HttpGet("get-all")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> Get()
        {
            return employees;
        }

        /// <summary>
        /// Add a new employee and send to Kafka
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            if (emp == null || string.IsNullOrWhiteSpace(emp.Name))
                return BadRequest("Employee details are invalid.");

            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);

            // ✅ Send event to Kafka topic
            var message = JsonSerializer.Serialize(emp);
            await _kafkaProducer.ProduceAsync("employee-events", message);

            return Ok(employees);
        }

        /// <summary>
        /// Update an existing employee by ID
        /// </summary>
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee ID.");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found.");

            if (updatedEmp == null || string.IsNullOrWhiteSpace(updatedEmp.Name))
                return BadRequest("Employee name is required.");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;
            emp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(emp);
        }

        /// <summary>
        /// Delete employee by ID
        /// </summary>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee ID.");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found.");

            employees.Remove(emp);
            return Ok($"Employee with ID {id} deleted successfully.");
        }
    }
}
