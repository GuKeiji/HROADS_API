using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();
        Habilidade BuscarPorId(int idHabilidade);
        void Cadastrar(Habilidade novoHabilidade);
        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado);
        void Deletar(int idHabilidade);
        List<Habilidade> ListarComTipoHabilidade();
    }
}
