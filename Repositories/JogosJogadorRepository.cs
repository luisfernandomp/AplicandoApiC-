using Jogadores.Contexts;
using Jogadores.Domains;
using Jogadores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogadores.Repositories
{
    public class JogosJogadorRepository : IJogosJogador
    {
        private readonly JogadoresContext _ctx;

        public JogosJogadorRepository()
        {
            _ctx = new JogadoresContext();
        }

        /// <summary>
        /// Método para adicionar uma relação entre jogo e jogador
        /// </summary>
        /// <param name="jogosJ">Objeto do tipo JogosJogador</param>
        /// <returns>Objeto JogosJogador cadastrado</returns>
        public JogosJogador Adicionar(JogosJogador jogosJ)
        {
            try
            {

                _ctx.JogosJogador.Add(jogosJ);

                _ctx.SaveChanges();

                return jogosJ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método para Alterar uma relação entre jogo e jogador
        /// </summary>
        /// <param name="jogosJ">Objeto JogosJogador</param>
        /// <param name="id">Id de JogosJogador</param>
        public void Alterar(int id, JogosJogador jogosJ)
        {
            try
            {
                JogosJogador jogoJTemp = BuscarPorId(id);

                if (jogoJTemp == null)
                    throw new Exception("Jogo não encontrado!");

                jogoJTemp.IdJogador = jogosJ.IdJogador;
                jogoJTemp.IdJogo = jogosJ.IdJogo;

                _ctx.JogosJogador.Update(jogoJTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma relação específica entre jogo e jogador
        /// </summary>
        /// <param name="id">Id de Jogos Jogador</param>
        /// <returns>O objeto encontrado JogosJogador</returns>
        public JogosJogador BuscarPorId(int id)
        {
            try
            {
                return _ctx.JogosJogador
                            .Include(c => c.IdJogadorNavigation)
                            .Include(y => y.IdJogoNavigation)
                            .FirstOrDefault(y => y.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para listar todas as relações entre jogo e jogador
        /// </summary>
        /// <returns>Lista com todos os JogosJogador</returns>
        public List<JogosJogador> Listar()
        {
            try
            {
                return _ctx.JogosJogador
                    .Include(c => c.IdJogadorNavigation)
                    .Include(y => y.IdJogoNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para remover uma relação jogo e jogador
        /// </summary>
        /// <param name="id">Id de JogosJogador</param>
        public void Remover(int id)
        {
            try
            {
                JogosJogador jogosJTemp = BuscarPorId(id);

                if (jogosJTemp == null)
                    throw new Exception("Nada foi encontrado!");

                _ctx.JogosJogador.Remove(jogosJTemp);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
