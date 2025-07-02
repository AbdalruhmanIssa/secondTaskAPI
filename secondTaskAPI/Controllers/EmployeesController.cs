using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondTaskAPI.Data;
using secondTaskAPI.DTO;
using secondTaskAPI.Models;
using System.Runtime.Intrinsics.Arm;

namespace secondTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext context=new ApplicationDbContext();
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var employees=context.Employees.ToList();   
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) { 
        var emp=context.Employees.FirstOrDefault(x => x.Id == id);
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult Create(EmployeeDTO employee) {
             var dep = new Employee()
            {
                Name = employee.Name,
                Description=employee.Description,

            };
            context.Employees.Add(dep);
            context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Employee employee,int id) {
            var emp = context.Employees.Find(id);
            emp.Name= employee.Name;
            emp.Description= employee.Description;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp= context.Employees.Find(id);
            context.Employees.Remove(emp);  
            context.SaveChanges();
            return Ok();
        }
    }
}
