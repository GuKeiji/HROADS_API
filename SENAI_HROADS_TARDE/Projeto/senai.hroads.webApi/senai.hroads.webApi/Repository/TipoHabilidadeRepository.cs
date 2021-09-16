using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(int idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado)
        {
            Tipohabilidade TipohabilidadeBuscado = ctx.Tipohabilidades.Find(idTipohabilidade);

            if (TipohabilidadeAtualizado.NomeTipoHabilidade != null)
            {
                TipohabilidadeBuscado.NomeTipoHabilidade = TipohabilidadeAtualizado.NomeTipoHabilidade;

                ctx.Tipohabilidades.Update(TipohabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipohabilidade BuscarPorId(int idTipohabilidade)
        {
            return ctx.Tipohabilidades.FirstOrDefault(e => e.IdTipoHabilidade == idTipohabilidade);
        }

        public void Cadastrar(Tipohabilidade novoTipohabilidade)
        {
            ctx.Tipohabilidades.Add(novoTipohabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipohabilidade)
        {
            ctx.Tipohabilidades.Remove(BuscarPorId(idTipohabilidade));

            ctx.SaveChanges();
        }

        public List<Tipohabilidade> Listar()
        {
            return ctx.Tipohabilidades.ToList();
        }
    }
}
