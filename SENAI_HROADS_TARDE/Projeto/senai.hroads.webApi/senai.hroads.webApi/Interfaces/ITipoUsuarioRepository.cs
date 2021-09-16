using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<Tipousuario> Listar();
        Tipousuario BuscarPorId(int idTipousuario);
        void Cadastrar(Tipousuario novoTipousuario);
        void Atualizar(int idTipousuario, Tipousuario TipousuarioAtualizado);
        void Deletar(int idTipousuario);
    }
}
