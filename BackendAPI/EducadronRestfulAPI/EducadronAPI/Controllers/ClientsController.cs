using EducadronAPI.Models;
using EducadronAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducadronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public List<Client> GetClients()
        {
            return context.Clients.OrderByDescending(c => c.Id).ToList();
        }


        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Name == clientDto.Name);
            if(otherClient != null)
            {
                ModelState.AddModelError("Name", "This name is already in use");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = new Client
            {
                Name = clientDto.Name,
            };

            context.Clients.Add(client);
            context.SaveChanges();

            return Ok(client);
        }


        [HttpPut("{id}")]
        public IActionResult EditClient(int id, [FromBody] ClientDto clientDto)
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Name == clientDto.Name);
            if (otherClient != null)
            {
                ModelState.AddModelError("Name", "This name is already in use");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = context.Clients.Find(id);
            if(client == null)
            {
                return NotFound();
            }

            client.Name = clientDto.Name;

            context.SaveChanges();

            return Ok(client);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok(); 
        }
    }
}