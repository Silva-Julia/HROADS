using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static senai.hroads.webApi.Interfaces.IClasseRepository;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto onde serão chamados os métodos do Framework.
        /// </summary>
        HroadsWebContext hctx = new HroadsWebContext();

        public void Atualizar(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = hctx.Classes.Find(id);

            // Verifica se o nome da classe foi passado corretamente
            if (classeAtualizada.TipoClasse != null)
            {
                // Ira analisar se esta tudo certo.
                classeBuscada.TipoClasse = classeAtualizada.TipoClasse;

                // Atualiza a classe que foi buscada
                hctx.Classes.Update(classeBuscada);

                // Salva as informações para serem gravadas no banco de dados
                hctx.SaveChanges();
            }         
        }

        public Classe BuscarPorId(int id)
        {
            return hctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            {
                // Adiciona essa nova classe, Aqui onde definimos o que sera feito
                hctx.Classes.Add(novaClasse);

                // Salva as informações para serem gravadas no banco de dados, Aqui precisa usar pois muda os dados do banco
                hctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            //Vai buscar um classe atraves do metodo BuscarPorId
            Classe classeBuscada = BuscarPorId(id);

            //Vai remover a classe
            hctx.Classes.Remove(classeBuscada);

            // Salva as alterações
            hctx.SaveChanges();

            //---------Outro método---------//
            //---------Método Mais Pratico---------//

            //hctx.Classes.Remove(BuscarPorId(id));

            // hctx.SaveChanges();
        }

        public List<Classe> ListarComPersonagens()
        {
          return hctx.Classes.Include(c => c.Personagems).ToList();
        }

        public List<Classe> ListarTodas()
        {
            return hctx.Classes.ToList();
        }
    }
}
