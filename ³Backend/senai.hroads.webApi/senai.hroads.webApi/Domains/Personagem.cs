using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePer { get; set; }
        public int CapaMaxVida { get; set; }
        public int CapaMaxMana { get; set; }
        public DateTime DataAtual { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
