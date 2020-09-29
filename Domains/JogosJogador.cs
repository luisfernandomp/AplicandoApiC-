using System;
using System.Collections.Generic;

namespace Jogadores.Domains
{
    public partial class JogosJogador
    {
        public int Id { get; set; }
        public int IdJogo { get; set; }
        public int IdJogador { get; set; }

        public virtual Jogador IdJogadorNavigation { get; set; }
        public virtual Jogo IdJogoNavigation { get; set; }
    }
}
