using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class ClasseRepository : IClasseRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte idClasse, Classe classeAtualizado)
        {
            Classe classeBuscado = ctx.Classes.Find(idClasse);

            if (classeAtualizado.NomeClasse != null)
            {
                classeBuscado.NomeClasse = classeAtualizado.NomeClasse;

                ctx.Classes.Update(classeBuscado);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novoClasse)
        {
            ctx.Classes.Add(novoClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            ctx.Classes.Remove(BuscarPorId(idClasse));
            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }

        /*
        public List<Classe> ListarComHabilidade()
        {
            return ctx.Classes.Include(e => e.Habilidade).ToList();
        }
        */
    }
}
