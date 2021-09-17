using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Interface responsável pelo ClasseRepository
        /// </summary>
        interface IClasseRepository
        {
            /// <summary>
            /// Lista todas as Classes
            /// </summary>
            /// <returns>Retorna uma lista com todas as classes</returns>
            List<Classe> ListarTodas();

            /// <summary>
            /// Busca uma classe pelo id
            /// </summary>
            /// <param name="id"> nome da Id da classe buscada</param>
            /// <returns>Classe buscada</returns>
            Classe BuscarPorId(int id);

            /// <summary>
            /// Cadastra uma nova classe
            /// </summary>
            /// <param name="novaClasse"> Objeto chamado "novaClasse" que será cadastrado</param>
            void Cadastrar(Classe novaClasse);


            /// <summary>
            /// Atualiza uma classe já existente
            /// </summary>
            /// <param name="id">id da classe que será atualizada</param>
            /// <param name="classeAtualizada"> objeto chamado "classeAtualizada" com as novas informações que serão atualizadas</param>
            void Atualizar(int id, Classe classeAtualizada);

            /// <summary>
            /// Deleta uma classe existente
            /// </summary>
            /// <param name="id">esse é o Id da classe que será deletada</param>
            void Deletar(int id);

            List<Classe> ListarComPersonagens();
        }
    }
}
