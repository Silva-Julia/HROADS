using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsWebContext hctx = new HroadsWebContext();

        public void Atualizar(int id, TipoHabilidade TipoHabilidadeAtualizado)
        {
            TipoHabilidade TipoHabilidadeBuscado = hctx.TipoHabilidades.Find(id);

            if (TipoHabilidadeBuscado.QualTipoHabi != null)
            {

                TipoHabilidadeBuscado.QualTipoHabi = TipoHabilidadeAtualizado.QualTipoHabi;

                hctx.TipoHabilidades.Update(TipoHabilidadeBuscado);

                hctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return hctx.TipoHabilidades.FirstOrDefault(t => t.IdTipoHabilidade == id);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            hctx.TipoHabilidades.Add(novoTipoHabilidade);

            hctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            hctx.TipoHabilidades.Remove(BuscarPorId(id));

            hctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodas()
        {
            return hctx.TipoHabilidades.ToList();
        }
    }
 }
