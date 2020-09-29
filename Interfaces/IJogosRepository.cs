using Jogadores.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogadores.Interfaces
{
    interface IJogosRepository
    {
        /// <summary>
        /// Método para listar os objetos JogosJogador
        /// </summary>
        /// <returns>Lista de JogosJogador</returns>
        List<Jogo> Listar();

        /// <summary>
        /// Método que buscar um objeto JogosJogador pelo id
        /// </summary>
        /// <param name="id">Id de um JogosJogador</param>
        /// <returns>Objeto JogosJogador</returns>
        Jogo BuscarPorId(int id);

        /// <summary>
        /// Método para adicionar um novo jogo
        /// </summary>
        /// <param name="jogos">Objeto do tipo jogo</param>
        /// <param name="jogosJogador">Lista de jogosJogador</param>
        /// <returns></returns>
        Jogo Adicionar(Jogo jogo);

        /// <summary>
        /// Método para removar um Jogo
        /// </summary>
        /// <param name="id">Id do Jogo</param>
        /// <returns>Id removido</returns>
        void Remover(int id);

        /// <summary>
        /// Método para alterar um Jogo
        /// </summary>
        /// <param name="jogo">Objeto Jogo</param>
        /// <param name="id">Id do Jogo</param>
        /// <returns></returns>
        void Alterar(Jogo jogo, int id);
    }
}
