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

    // Rota da API http://localhost:5000/api/tipousuario
    [Route("api/[controller]")]

    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        //ListarTodas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.ListarTodas());
        }

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        //Cadastrar
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Postar(TipoUsuario novoTipoUsu)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsu);

            return StatusCode(201);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(id, TipoUsuAtualizado);

            return StatusCode(204);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
