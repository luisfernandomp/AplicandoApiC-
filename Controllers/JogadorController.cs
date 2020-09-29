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
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorController()
        {
            _jogadorRepository = new JogadorRepository();
        }


        // GET: api/<JogadorController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os jogadores
                var jogadores = _jogadorRepository.Listar();

                //Verifico se existe o jogador
                //Caso não exista eu retorno NoContent
                if (jogadores.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e os jogadores cadastrados
                return Ok(new
                {
                    totalCount = jogadores.Count,
                    data = jogadores
                });
            }
            catch (Exception)
            {
                //TODO : Cadastrar mensagem de erro no dominio logErro
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie um e-mail para email@email.com informando"
                });
            }
        }

        // POST api/<JogadorController>
        [HttpPost]
        public IActionResult Post(Jogador jogador)
        {
            try
            {

                //Adiciona um novo jogador
                _jogadorRepository.Adicionar(jogador);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<JogadorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogador jogador)
        {
            try
            {
                //Edita o produto
                _jogadorRepository.Editar(id, jogador);

                //Retorna Ok com os dados do produto
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<JogadorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _jogadorRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _jogadorRepository.Remover(id);
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
