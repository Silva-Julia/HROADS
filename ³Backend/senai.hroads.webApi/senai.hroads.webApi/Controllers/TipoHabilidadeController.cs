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

    // Rota da API http://localhost:5000/api/tipohabilidade
    [Route("api/[controller]")]

    [ApiController]
    public class TipoHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        //ListarTodas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodas());
        }

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        //Cadastrar
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Postar(TipoHabilidade novoTipoHabilidade)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade TipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(id, TipoHabilidadeAtualizado);

            return StatusCode(204);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoHabilidadeRepository.Deletar(id);

            return StatusCode(204);
        }


    }
}
