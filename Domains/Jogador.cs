using System;
using System.Collections.Generic;

namespace Jogadores.Domains
{
    public partial class Jogador
    {
        public Jogador()
        {
            JogosJogador = new HashSet<JogosJogador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNasc { get; set; }

        public virtual ICollection<JogosJogador> JogosJogador { get; set; }
    }
}
