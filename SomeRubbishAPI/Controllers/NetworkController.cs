using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SomeRubbishAPI.DTOs;
using SomeRubbishAPI.Models;

namespace SomeRubbishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        InfraDbContext _context;

        public NetworkController(InfraDbContext context)
        {
            _context = context;
        }

        // GET: api/GetAllNetworks
        [HttpGet]
        [Route("GetAllNetworks")]
        public async Task<IActionResult> GetAllNetworks()
        {
            var networks = await _context.Networks.ToListAsync();
            return Ok(networks);
        }

        // GET: api/GetNetworkById/5
        [HttpGet]
        [Route("GetNetworkById/{id}")]
        public IActionResult GetNetworkById(int id)
        {
            var network = _context.Networks.FirstOrDefault(n => n.Id == id);
            if (network == null)
            {
                return NotFound();
            }
            return Ok(network);
        }

        // POST: api/AddNetwork
        [HttpPost]
        [Route("AddNetwork")]
        public IActionResult AddNetwork(NetworkDTO network)
        {
            var newNetwork = _context.Networks.Add(new Network { Name = network.Name });
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetNetworkById), new { id = newNetwork.Entity.Id }, network);
        }

        // PUT: api/UpdateNetwork/5
        [HttpPut]
        [Route("UpdateNetwork/{id}")]
        public IActionResult UpdateNetwork(int id, Network network)
        {
            var existingNetwork = _context.Networks.FirstOrDefault(n => n.Id == id);
            if (existingNetwork == null)
            {
                return NotFound();
            }
            existingNetwork.Name = network.Name;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/DeleteNetwork/5
        [HttpDelete]
        [Route("DeleteNetwork/{id}")]
        public IActionResult DeleteNetwork(int id)
        {
            var network = _context.Networks.FirstOrDefault(n => n.Id == id);
            if (network == null)
            {
                return NotFound();
            }
            _context.Networks.Remove(network);
            _context.SaveChanges();
            return Ok();
        }

    }
}
