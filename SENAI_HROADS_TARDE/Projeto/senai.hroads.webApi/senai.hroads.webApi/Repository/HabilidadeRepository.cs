using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado)
        {
            Habilidade HabilidadeBuscado = ctx.Habilidades.Find(idHabilidade);

            if (HabilidadeAtualizado.NomeHabilidade != null)
            {
                HabilidadeBuscado.NomeHabilidade = HabilidadeAtualizado.NomeHabilidade;

                ctx.Habilidades.Update(HabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novoHabilidade)
        {
            ctx.Habilidades.Add(novoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }
        public List<Habilidade> ListarComTipoHabilidade()
        {
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
