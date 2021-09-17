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

    // Rota da API http://localhost:5000/api/habilidade
    [Route("api/[controller]")]

    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        //ListarTodas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.ListarTodas());
        }

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        //Cadastrar
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Postar(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade HabilidadeAtualizada)
        {
            _habilidadeRepository.Atualizar(id, HabilidadeAtualizada);

            return StatusCode(204);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }



    }
}
