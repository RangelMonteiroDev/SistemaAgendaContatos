using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaDeContatosMVC.data;
using AgendaDeContatosMVC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgendaDeContatosMVC.Controllers
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuariosController : Controller
    {

        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {

            _context = context;
        }

        [HttpGet("FormCadastro")]
        public IActionResult FormCadastro()
        {

            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet("UserList/{code}")]
        public IActionResult UserList (string code) {

            var operacoes = new OperacoesDeAutenticacao(_context);

            var codigoValidado = operacoes.VerifyAcessCode(code);

            if (codigoValidado)
            {
               var listUsers = _context.Usuarios.ToList();

                List<AgendaDeContatosMVC.Models.Usuarios> usuariosList = [.. listUsers.Cast<AgendaDeContatosMVC.Models.Usuarios>()];

                return View(listUsers);  
            }
            else
            {
                return Unauthorized(new {message = "Você não possui acesso a essa página"});
            }

        }


        [HttpPost("Create")]
        public IActionResult Create([FromForm] Usuarios usuarios)
        {

            if (ModelState.IsValid)
            {
                var operacoes = new OperacoesDeAutenticacao(_context);

                string senha = usuarios.Senha;

                string senhaCriptografada = operacoes.CriptografiaDeSenha(senha);

                usuarios.Senha = senhaCriptografada;

                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                return BadRequest(new { message = "Erro ao inserir novos dados" });
            }
        }

        //Rota de Login
        [HttpPost("Login")]
        public IActionResult Login([FromForm] Usuarios usuarios)
        {   
            var operacoes = new OperacoesDeAutenticacao(_context);

            var existsResults = _context.Usuarios.FirstOrDefault(u => u.Email == usuarios.Email);

            if (existsResults != null)
            {
                var senhaEncontrada = operacoes.VerificarSenha(usuarios.Senha, existsResults.Senha);

                if (senhaEncontrada)
                {
                    var codigoDeAcesso = operacoes.GerarCodigo();

                    var DataHora = new DateTime();

                    operacoes.AddAutentication(existsResults.IdUsuario, DataHora, codigoDeAcesso);

                    return RedirectToAction("UserList", new {code = codigoDeAcesso});
                }
                else
                {
                    return NotFound(new {message = "Dados não encontrados"});
                }
            }
            else
            {
                return NotFound(new { message = "Error: Dados não encontrados" });
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var resultado = _context.Usuarios.ToList();

            if (resultado.Any())
            {
                return NotFound(new { message = "Dados não encontrados" });
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ReturnId")]
        [Consumes("application/json")]
        public IActionResult ReturnId([FromBody] string senha)
        {

            var existsResults = _context.Usuarios.FirstOrDefault(u => u.Senha == senha);

            if (existsResults != null)
            {
                return Ok(existsResults.IdUsuario);
            }
            else
            {
                return NotFound(new { message = "Dados não encontrados" });
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {

            var existsResults = _context.Usuarios.Find(id);

            if (existsResults != null)
            {
                return Ok(existsResults);
            }
            else
            {
                return NotFound(new { message = "Dados não encontrados" });
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromForm] Usuarios usuarios)
        {

            var existsResults = _context.Usuarios.Find(id);

            if (existsResults != null)
            {
                existsResults.Nome = usuarios.Nome;
                existsResults.Email = usuarios.Email;
                existsResults.Senha = usuarios.Senha;
                existsResults.Ativo = usuarios.Ativo;

                _context.Usuarios.Update(existsResults);
                _context.SaveChanges();

                return Ok(new { message = "Dados atualizados com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Dados não foram encontrados" });
            }
        }

        //Método de exclusão lógica
        [HttpPut("ParcialUpdate/{id}")]
        public IActionResult ParcialUpdade(int id, [FromForm] string ativo)
        {

            var existsResults = _context.Usuarios.Find(id);

            if (existsResults != null)
            {
                existsResults.Ativo = ativo;

                _context.Usuarios.Update(existsResults);
                _context.SaveChanges();

                return Ok(new { message = "Exclusão lógica realizada com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Não foi possível atualizar dados" });
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {

            var existsResults = _context.Usuarios.Find(id);

            if (existsResults != null)
            {
                _context.Usuarios.Remove(existsResults);
                _context.SaveChanges();

                return Ok(new { message = "Dados deletados com sucesso" });
            }
            else
            {
                return NotFound(new { message = "Não foi possível deletar os dados" });
            }
        }
    }
}