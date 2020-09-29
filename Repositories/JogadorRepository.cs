using Jogadores.Contexts;
using Jogadores.Domains;
using Jogadores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jogadores.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly JogadoresContext _ctx;

        public JogadorRepository()
        {
            _ctx = new JogadoresContext();
        }

        /// <summary>
        /// Método para adicionar um novo jogador
        /// </summary>
        /// <param name="jg">Objeto jogador</param>
        public void Adicionar(Jogador jg)
        {
            try
            {
                _ctx.Jogador.Add(jg);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um jogador pelo id
        /// </summary>
        /// <param name="id">Id do jogador</param>
        /// <returns>Retorna um objeto jogador</returns>
        public Jogador BuscarPorId(int id)
        {
            try
            {
                return _ctx.Jogador
                    .Include(c => c.JogosJogador)
                    .FirstOrDefault(y => y.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um jogador pelo nome
        /// </summary>
        /// <param name="nome">String com nome do jogador</param>
        /// <returns>Lista de jogadores</returns>
        public List<Jogador> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Jogador.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para alterar um jogador
        /// </summary>
        /// <param name="jg">Objeto jogador</param>
        public void Editar(int id, Jogador jg)
        {
            try
            {
                Jogador jogadorTemp = BuscarPorId(id);

                if (jogadorTemp == null)
                {
                    throw new Exception("Jogador não encontrado");
                }
                else
                {
                    //Caso exista altera sua propriedades
                    jogadorTemp.Nome = jg.Nome;
                    jogadorTemp.Email = jg.Email;
                    jogadorTemp.Senha = jg.Senha;
                    jogadorTemp.DataNasc = jg.DataNasc;

                    //Altera Jogador no contexto
                    _ctx.Jogador.Update(jogadorTemp);
                    //Salva o contexto
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que lista todos os jogadores
        /// </summary>
        /// <returns>Lista de jogadores</returns>
        public List<Jogador> Listar()
        {
            try
            {
                return _ctx.Jogador
                    .Include(c => c.JogosJogador)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para remover um jogador
        /// </summary>
        /// <param name="id">Recebe um id de um jogador como parâmetro</param>
        public void Remover(int id)
        {
            try
            {
                //Buscar Jogador pelo id
                Jogador jogadorTemp = BuscarPorId(id);

                if(jogadorTemp == null)
                {
                    throw new Exception("Jogador não encontrado");
                }
                else
                {
                    //Remove um jogador do dbSet
                    _ctx.Jogador.Remove(jogadorTemp);
                    //Salva as alterações do contexto
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Inclui erro na tabela de Log
                throw new Exception(ex.Message);
            }
        }
    }
}
