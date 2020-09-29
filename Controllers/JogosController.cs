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
        public IActionResult Get()
        {
            try
            {
                //Lista os jogos
                var jogos = _jogosRepository.Listar();

                //Verifica se existe algum jogo
                if (jogos.Count == 0)
                    return NoContent();
                    //NoContetn - Sem conteúdo

                //Caso exista retorno Ok e os jogos cadastrados
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

        // GET api/<JogosController>/5
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

        // POST api/<JogosController>
        [HttpPost]
        public IActionResult Post(Jogo jogos)
        {
            try
            {

                //Adiciona um novo jogador
                _jogosRepository.Adicionar(jogos);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<JogosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogo jogos)
        {
            try
            {
                //Edita o produto
                _jogosRepository.Alterar(jogos, id);

                //Retorna Ok com os dados do produto
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<JogosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _jogosRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _jogosRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
