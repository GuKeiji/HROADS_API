using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<Tipohabilidade> Listar();
        Tipohabilidade BuscarPorId(int idTipohabilidade);
        void Cadastrar(Tipohabilidade novoTipohabilidade);
        void Atualizar(byte idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado);
        void Deletar(int idTipohabilidade);
    }
}
