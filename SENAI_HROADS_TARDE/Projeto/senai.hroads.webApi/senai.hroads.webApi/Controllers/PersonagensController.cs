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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _PersonagemRepository { get; set; }
        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_PersonagemRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_PersonagemRepository.BuscarPorId(idPersonagem));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _PersonagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(short idPersonagem, Personagem PersonagemAtualizado)
        {
            _PersonagemRepository.Atualizar(idPersonagem, PersonagemAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _PersonagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }
    }
}
