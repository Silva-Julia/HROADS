using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> ListarTodas();
        Personagem BuscarPorId(int id);
        void Cadastrar(Personagem novoPersonagem);
        void Atualizar(int id, Personagem PersonagemAtualizado);
        void Deletar(int id);
    }
}
