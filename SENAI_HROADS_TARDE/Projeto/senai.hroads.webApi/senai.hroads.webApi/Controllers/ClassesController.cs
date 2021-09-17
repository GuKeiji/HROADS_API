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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idclasse}")]
        public IActionResult BuscarPorId(int idclasse)
        {
            return Ok(_classeRepository.BuscarPorId(idclasse));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novoclasse)
        {
            _classeRepository.Cadastrar(novoclasse);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{idclasse}")]
        public IActionResult Atualizar(byte idclasse, Classe classeAtualizado)
        {
            _classeRepository.Atualizar(idclasse, classeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idclasse}")]
        public IActionResult Deletar(int idclasse)
        {
            _classeRepository.Deletar(idclasse);

            return StatusCode(204);
        }
    }
}
