using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondTaskAPI.Data;
using secondTaskAPI.DTO;
using secondTaskAPI.Models;

namespace secondTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var dep = context.Departments.Select(depdto => new DepartmentResponse() { 
            Id = depdto.Id,
            Name = depdto.Name,
            });
            return Ok(dep); 
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = context.Departments.FirstOrDefault(x => x.Id == id);
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO department)
        {
            var dep = new Department()
            {
                Name = department.Name,
            };
            context.Departments.Add(dep);
            context.SaveChanges();
            return Ok(department);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Department department, int id)
        {
            var emp = context.Departments.Find(id);
            emp.Name = department.Name;
       
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();
        }
    }
}
