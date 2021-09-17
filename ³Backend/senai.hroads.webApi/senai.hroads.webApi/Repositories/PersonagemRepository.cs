using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsWebContext hctx = new HroadsWebContext();

        public void Atualizar(int id, Personagem PersonagemAtualizado)
        {
            Personagem personagemBuscada = hctx.Personagems.Find(id);

            if (personagemBuscada.NomePer != null)
            {

                personagemBuscada.NomePer = PersonagemAtualizado.NomePer;

                hctx.Personagems.Update(personagemBuscada);

                hctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int id)
        {
            return hctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            hctx.Personagems.Add(novoPersonagem);

            hctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            hctx.Personagems.Remove(BuscarPorId(id));

            hctx.SaveChanges();
        }

        public List<Personagem> ListarTodas()
        {
            return hctx.Personagems.ToList();
        }
    }
}
