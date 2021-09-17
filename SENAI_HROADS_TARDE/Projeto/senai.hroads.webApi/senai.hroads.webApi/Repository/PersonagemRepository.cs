using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(short idPersonagem, Personagem PersonagemAtualizado)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(idPersonagem);

            if (PersonagemAtualizado.NomePersonagem != null)
            {
                PersonagemBuscado.NomePersonagem = PersonagemAtualizado.NomePersonagem;

                ctx.Personagems.Update(PersonagemBuscado);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.ToList();
        }
    }
}
