using Jogadores.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogadores.Interfaces
{
    interface IJogadorRepository
    {
        /// <summary>
        /// Método para listar todas as relações entre jogo e jogador
        /// </summary>
        /// <returns>Lista com todos os JogosJogador</returns>
        List<JogosJogador> Listar();

        /// <summary>
        /// Método para buscar uma relação específica entre jogo e jogador
        /// </summary>
        /// <param name="id">Id de Jogos Jogador</param>
        /// <returns>O objeto encontrado JogosJogador</returns>
        JogosJogador BuscarPorId(int id);

        /// <summary>
        /// Método para adicionar uma relação entre jogo e jogador
        /// </summary>
        /// <param name="jogosJ">Objeto do tipo JogosJogador</param>
        /// <returns>Objeto JogosJogador cadastrado</returns>
        void Adicionar(JogosJogador jogosJ);

        /// <summary>
        /// Método para Alterar uma relação entre jogo e jogador
        /// </summary>
        /// <param name="jogosJ">Objeto JogosJogador</param>
        /// <param name="id">Id de JogosJogador</param>
        void Alterar(int id, JogosJogador jogosJ);

        /// <summary>
        /// Método para remover uma relação jogo e jogador
        /// </summary>
        /// <param name="id">Id de JogosJogador</param>
        void Remover(int id);
    }
}
