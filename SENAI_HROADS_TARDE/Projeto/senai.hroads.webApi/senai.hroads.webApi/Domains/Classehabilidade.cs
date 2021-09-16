#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Classehabilidade
    {
        public short IdClasseHabilidade { get; set; }
        public byte? IdClasse { get; set; }
        public byte? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
