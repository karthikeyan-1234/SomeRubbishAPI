using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SomeRubbishAPI.Models;

namespace SomeRubbishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        InfraDbContext _context;

        public ComputerController(InfraDbContext context)
        {
            _context = context;
        }

        // GET: api/GetAllComputers
        [HttpGet]
        [Route("GetAllComputers")]
        public IActionResult GetAllComputers()
        {
            var computers = _context.Computers.ToList();
            return Ok(computers);
        }

        // GET: api/GetComputerById/5
        [HttpGet]
        [Route("GetComputerById/{id}")]
        public IActionResult GetComputerById(int id)
        {
            var computer = _context.Computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                return NotFound();
            }
            return Ok(computer);
        }

        // POST: api/AddComputer
        [HttpPost]
        [Route("AddComputer")]
        public IActionResult AddComputer(Computer computer)
        {
            _context.Computers.Add(computer);
            _context.SaveChanges();
            return Ok();
        }

        // PUT: api/UpdateComputer/5
        [HttpPut]
        [Route("UpdateComputer/{id}")]
        public IActionResult UpdateComputer(int id, Computer computer)
        {
            var existingComputer = _context.Computers.FirstOrDefault(c => c.Id == id);
            if (existingComputer == null)
            {
                return NotFound();
            }
            existingComputer.Name = computer.Name;
            existingComputer.IpAddress = computer.IpAddress;
            existingComputer.SwitchId = computer.SwitchId;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/DeleteComputer/5
        [HttpDelete]
        [Route("DeleteComputer/{id}")]
        public IActionResult DeleteComputer(int id)
        {
            var computer = _context.Computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                return NotFound();
            }
            _context.Computers.Remove(computer);
            _context.SaveChanges();
            return Ok();
        }

    }
}
