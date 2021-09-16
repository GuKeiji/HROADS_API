using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int idUsuario);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);
        void Deletar(int idUsuario);
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
