using System;
using System.Collections.Generic;

namespace Jogadores.Domains
{
    public partial class Jogo
    {
        public Jogo()
        {
            JogosJogador = new HashSet<JogosJogador>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLanc { get; set; }

        public virtual ICollection<JogosJogador> JogosJogador { get; set; }
    }
}
