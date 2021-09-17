using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static senai.hroads.webApi.Interfaces.IClasseRepository;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    // Rota da API http://localhost:5000/api/classe
    [Route("api/[controller]")]

    [ApiController]
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Aqui sera listado todas as classes
        /// </summary>
        /// <returns> Com uma lista de classes e um status code 200(Ok)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Classe> listaClasse = _classeRepository.ListarTodas();

            return Ok(listaClasse);

            //Existe este metodo ||return Ok(_classeRepository.ListarTodas());|| que faz a mesma coisa de forma mais bonitinha
        }

        /// <summary>
        /// Aqui sera buscado uma classe na qual o usuario desejar, pelo ID
        /// </summary>
        /// <returns> Com um status code 200(Ok)</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_classeRepository.BuscarPorId(id));
        }

        [HttpDelete]

        /// <summary>
        /// Aqui sera feito o cadastro de uma nova classe
        /// </summary>
        /// <returns> Com um status code 201(created)</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Postar(Classe novaClasse)
        {
            // Faz a chamada para o método
            _classeRepository.Cadastrar(novaClasse);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Aqui sera feito a atualização de uma classe
        /// </summary>
        /// <returns> Com um status code 204(No Content)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            // Faz a chamada para o método
            _classeRepository.Atualizar(id, classeAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Aqui sera feito o delete da classe
        /// </summary>
        /// <returns> Com um status code 204(No Content)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _classeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpGet("personagem")]
        public IActionResult ListarComPersonagem()
        {
            return Ok(_classeRepository.ListarComPersonagens());
        }
    }
}
