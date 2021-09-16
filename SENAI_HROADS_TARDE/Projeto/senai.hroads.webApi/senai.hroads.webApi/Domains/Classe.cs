﻿using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Classehabilidades = new HashSet<Classehabilidade>();
            Personagems = new HashSet<Personagem>();
        }

        public byte IdClasse { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<Classehabilidade> Classehabilidades { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
