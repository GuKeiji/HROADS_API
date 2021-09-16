using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> Listar();
        Personagem BuscarPorId(int idPersonagem);
        void Cadastrar(Personagem novoPersonagem);
        void Atualizar(int idPersonagem, Personagem PersonagemAtualizado);
        void Deletar(int idPersonagem);
    }
}
