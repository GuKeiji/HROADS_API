using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(int idTipousuario, Tipousuario TipousuarioAtualizado)
        {
            Tipousuario TipousuarioBuscado = ctx.Tipousuarios.Find(idTipousuario);

            if (TipousuarioAtualizado.Titulo != null)
            {
                TipousuarioBuscado.Titulo = TipousuarioAtualizado.Titulo;

                ctx.Tipousuarios.Update(TipousuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipousuario BuscarPorId(int idTipousuario)
        {
            return ctx.Tipousuarios.FirstOrDefault(e => e.IdTipoUsuario == idTipousuario);
        }

        public void Cadastrar(Tipousuario novoTipousuario)
        {
            ctx.Tipousuarios.Add(novoTipousuario);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipousuario)
        {
            ctx.Tipousuarios.Remove(BuscarPorId(idTipousuario));

            ctx.SaveChanges();
        }

        public List<Tipousuario> Listar()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
