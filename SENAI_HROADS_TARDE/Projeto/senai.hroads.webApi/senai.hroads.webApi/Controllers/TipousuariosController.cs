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
    public class TipousuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }
        public TipousuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(idTipoUsuario));
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Cadastrar(Tipousuario novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(int idTipoUsuario, Tipousuario TipoUsuarioAtualizado)
        {
            _TipoUsuarioRepository.Atualizar(idTipoUsuario, TipoUsuarioAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            _TipoUsuarioRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }
    }
}
