using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> ListarTodas();
        TipoHabilidade BuscarPorId(int id);
        void Cadastrar(TipoHabilidade novoTipoHabilidade);
        void Atualizar(int id, TipoHabilidade TipoHabilidadeAtualizado);
        void Deletar(int id);
    }
}
