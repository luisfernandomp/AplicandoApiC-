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
        /// Método que lista todos os jogadores
        /// </summary>
        /// <returns>Lista de jogadores</returns>
        List<Jogador> Listar();
        
        /// <summary>
        /// Método para buscar um jogador pelo id
        /// </summary>
        /// <param name="id">Id do jogador</param>
        /// <returns>Retorna um objeto jogador</returns>
        Jogador BuscarPorId(int id);
        
        /// <summary>
        /// Método para buscar um jogador pelo nome
        /// </summary>
        /// <param name="nome">String com nome do jogador</param>
        /// <returns>Lista de jogadores</returns>
        List<Jogador> BuscarPorNome(string nome);
        
        /// <summary>
        /// Método para adicionar um novo jogador
        /// </summary>
        /// <param name="jg">Objeto jogador</param>
        void Adicionar(Jogador jg);

        /// <summary>
        /// Método para editar um jogador
        /// </summary>
        /// <param name="id">Id do jogador a ser editado</param>
        /// <param name="jg">Objeto jogador</param>
        void Editar(int id, Jogador jg);

        /// <summary>
        /// Método para remover um jogador
        /// </summary>
        /// <param name="id">Recebe um id de um jogador como parâmetro</param>
        void Remover(int  id);
    }
}
