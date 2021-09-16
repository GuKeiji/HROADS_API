using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha incorretos!");
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuario-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                issuer: "senai.hroads.webApi",
                audience: "senai.hroads.webApi",
                claims: minhasClaims,
                expires: DateTime.Now.AddMinutes(50),
                signingCredentials: creds
                );
            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
        }
    }
}
