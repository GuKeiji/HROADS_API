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
    public class TipohabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _TipohabilidadeRepository { get; set; }
        public TipohabilidadesController()
        {
            _TipohabilidadeRepository = new TipoHabilidadeRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TipohabilidadeRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idTipohabilidade}")]
        public IActionResult BuscarPorId(int idTipohabilidade)
        {
            return Ok(_TipohabilidadeRepository.BuscarPorId(idTipohabilidade));
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Cadastrar(Tipohabilidade novoTipohabilidade)
        {
            _TipohabilidadeRepository.Cadastrar(novoTipohabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{idTipohabilidade}")]
        public IActionResult Atualizar(int idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado)
        {
            _TipohabilidadeRepository.Atualizar(idTipohabilidade, TipohabilidadeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idTipohabilidade}")]
        public IActionResult Deletar(int idTipohabilidade)
        {
            _TipohabilidadeRepository.Deletar(idTipohabilidade);

            return StatusCode(204);
        }
    }
}
