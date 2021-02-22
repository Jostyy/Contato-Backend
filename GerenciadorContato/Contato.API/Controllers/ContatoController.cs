
using Contato.DataAccess.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace Contato.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoDAO _contatoDAO;

        public ContatoController(ILogger<ContatoController> logger, IContatoDAO contatoDAO)
        {
            _logger = logger;
            _contatoDAO = contatoDAO;
        }
        [HttpPost]
        public async Task<IActionResult> Create(DataAccess.Model.Contato contato)
        {
            if (contato == null) return BadRequest("Contato vazio");

            var createdContato = await _contatoDAO.CreateContato(contato);

            if (createdContato != null)
                return new CreatedAtActionResult("GetContato", "Contato", new { createdContato.contatoid }, createdContato);
            else
                return BadRequest("Erro ao criar contato");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContato(long? id)
        {
            if (id == null)
                return BadRequest("Id vazio");
            var contato = await _contatoDAO.GetContato(id);
            if (contato == null)
                return NotFound($"Contato com id = {id} nao existe");

            return Ok(contato);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allContato = _contatoDAO.GetAllContato();
            if(allContato.Count != 0)
                return Ok(allContato);
            return NotFound("Nao existe contatos");
        }

        [HttpPut]
        public async Task<IActionResult> Update(DataAccess.Model.Contato contato)
        {
            if (contato == null)
                return BadRequest("Contato nulo");
            var updatedContato = await _contatoDAO.UpdateContato(contato);
            if (updatedContato == null)
                return BadRequest("Erro na atualizacao do contato");
            return Ok(updatedContato);
        }      
        [HttpDelete]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return BadRequest("Id vazio");
            await _contatoDAO.DeleteContato(id);

            return Ok();
        }
    }
}
