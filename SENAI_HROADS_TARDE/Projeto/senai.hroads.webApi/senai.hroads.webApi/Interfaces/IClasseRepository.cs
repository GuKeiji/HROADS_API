using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> Listar();
        Classe BuscarPorId(int idClasse);
        void Cadastrar(Classe novoClasse);
        void Atualizar(byte idClasse, Classe classeAtualizado);
        void Deletar(int idClasse);
    }
}
