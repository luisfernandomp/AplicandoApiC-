using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogadores.Domains;
using Jogadores.Interfaces;
using Jogadores.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jogadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogosRepository _jogosRepository;

        public JogosController()
        {
            _jogosRepository = new JogosRepository(); 
        }

        // GET: api/<JogosController>
        [HttpGet]
        public string Get()
        {
            return "a";
        }

        // GET api/<JogosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JogosController>
        [HttpPost]
        public IActionResult Post(List<JogosJogador> jogosJogadores)
        {

            try
            {
                Jogo j = _jogosRepository.Adicionar(jogosJogadores);
                
                return Ok(j);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<JogosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JogosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
