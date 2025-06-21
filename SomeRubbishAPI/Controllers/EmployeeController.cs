using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SomeRubbishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        TestDBContext _context;
        public EmployeeController(TestDBContext context)
        {
            _context = context; // Initializing the context in the constructor
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        
    }
}
