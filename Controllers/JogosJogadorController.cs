using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogadores.Domains;
using Jogadores.Interfaces;
using Jogadores.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Jogadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosJogadorController : ControllerBase
    {
        private readonly IJogosJogador _jogosRepository;

        public JogosJogadorController()
        {
            _jogosRepository = new JogosJogadorRepository();
        }

        // GET: api/<JogosJogadorController>
        [HttpGet]
        public IActionResult Get()
        {
            try { 
                var jogos = _jogosRepository.Listar();

                if (jogos.Count == 0)
                    return NoContent();
              
                return Ok(new
                {
                    totalCount = jogos.Count,
                    data = jogos
                });
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/Jogos"
                });
            }
        }

        // GET api/<JogosJogadorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var jogosTemp = _jogosRepository.BuscarPorId(id);

                if (jogosTemp == null)
                    return NoContent();

                return Ok(jogosTemp);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<JogosJogadorController>
        [HttpPost]
        public IActionResult Post(JogosJogador jogos)
        {
            try
            {
                _jogosRepository.Adicionar(jogos);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<JogosJogadorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, JogosJogador jogos)
        {
            try
            {
                _jogosRepository.Alterar(id, jogos);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<JogosJogadorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try { 
            
                var produto = _jogosRepository.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                _jogosRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
