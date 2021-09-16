using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email || u.Senha == senha);
        }
    }
}
