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
    public class JogosRepository : IJogosRepository
    {
        private readonly JogadoresContext _ctx;

        public JogosRepository()
        {
            _ctx = new JogadoresContext();
        }

        public Jogo Adicionar(Jogo jogos)
        {
            try
            {

                _ctx.Jogo.Add(jogos);
                
                _ctx.SaveChanges();

                return jogos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Jogo jogo, int id)
        {
            try
            {
                Jogo jogoTemp = BuscarPorId(id);

                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado!");

                jogoTemp.Descricao = jogo.Descricao;
                jogoTemp.DataLanc = jogo.DataLanc;

                _ctx.Jogo.Update(jogoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Jogo BuscarPorId(int id)
        {
            try
            {
                return _ctx.Jogo
                            .Include(c => c.JogosJogador)
                            .FirstOrDefault(y => y.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Jogo> Listar()
        {
            try
            {
                return _ctx.Jogo
                    .Include(c => c.JogosJogador)
                    .ToList();
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public void Remover(int id)
        {
            try
            {
                Jogo jogosTemp = BuscarPorId(id);

                if (jogosTemp == null)
                    throw new Exception("Jogo não encontrado!");

                _ctx.Jogo.Remove(jogosTemp);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
