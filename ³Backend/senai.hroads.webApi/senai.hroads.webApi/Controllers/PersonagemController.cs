using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    // Rota da API http://localhost:5000/api/personagem
    [Route("api/[controller]")]

    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        //ListarTodas
        [HttpGet]
        [Authorize(Roles = "Jogador,Administrador")]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.ListarTodas());
        }

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        //Cadastrar
        [HttpPost]
        [Authorize(Roles = "Jogador")]
        public IActionResult Postar(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem PersonagemAtualizado)
        {
            _personagemRepository.Atualizar(id, PersonagemAtualizado);

            return StatusCode(204);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.Deletar(id);

            return StatusCode(204);
        }


    }
}
