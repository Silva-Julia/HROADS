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

    // Rota da API http://localhost:5000/api/usuario
    [Route("api/[controller]")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //ListarTodas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.ListarTodas());
        }

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        //Cadastrar
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Postar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            _usuarioRepository.Atualizar(id, UsuarioAtualizado);

            return StatusCode(204);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }



    }
}
