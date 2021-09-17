using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }
        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_HabilidadeRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade)
        {
            return Ok(_HabilidadeRepository.BuscarPorId(idHabilidade));
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novoHabilidade)
        {
            _HabilidadeRepository.Cadastrar(novoHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{idHabilidade}")]
        public IActionResult Atualizar(byte idHabilidade, Habilidade HabilidadeAtualizado)
        {
            _HabilidadeRepository.Atualizar(idHabilidade, HabilidadeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idHabilidade}")]
        public IActionResult Deletar(int idHabilidade)
        {
            _HabilidadeRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }
    }
}
