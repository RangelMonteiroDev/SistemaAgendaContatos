using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendaDeContatosMVC.data;
using AgendaDeContatosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgendaDeContatosMVC.Controllers
{
    [Route("Administradores")]
    public class AdministradoresController : Controller
    {
        private readonly AppDbContext _context;

        public AdministradoresController(AppDbContext context)
        {
            _context = context;
        }

        //Criando novos Administradores
        [HttpPost("Create")]
        [Consumes("application/json")]
        public IActionResult Create ([FromBody] Administradores administradores) {

            if (ModelState.IsValid)
            {
             
            var AutenticacaoAdmin = new AutenticacaoAdmin(_context);

            string nome = administradores.Nome;

            string cpf = administradores.Cpf;

            var hashCode = AutenticacaoAdmin.AddAdministrador(nome, cpf);

            return Ok(new {message = "Dados inseridos com sucesso"});
   
            }
            else
            {
                return BadRequest(new {message = "Error: problema na requisição"});
            }

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll () {

            var existsResults = _context.Usuarios.ToList();

            if (existsResults != null)
            {
                return Ok(existsResults);
            }
            else
            {
                return NotFound(new {message = "Não foi possível encontrar os dados"});
            }
        }

        [HttpGet("GetId")]
        public IActionResult GetId (string cpf, string senha) {

            var existsResults = _context.Administradores.FirstOrDefault(a => a.Cpf == cpf );

            if (existsResults != null)
            {
                return Ok(existsResults.IdAministrador);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get (int id) {

            var existsResults = _context.Administradores.Find(id);

            if (existsResults != null)
            {
                return Ok(existsResults);
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }


        [HttpPut("Update/{id}")]
        public IActionResult Update (int id, [FromForm] Administradores administradores) {

            var existsResults = _context.Administradores.Find(id);

            if (existsResults != null)
            {
                existsResults.Nome = administradores.Nome;
                existsResults.Cpf = administradores.Cpf;
                existsResults.Ativo = administradores.Ativo;

                _context.Administradores.Update(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados atualizados com sucesso"});
            }
            else
            {
                return NotFound(new {message = "Dados não encontrados"});
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id) {

            var existsResults = _context.Administradores.Find(id);

            if (existsResults != null)
            {
                _context.Administradores.Remove(existsResults);
                _context.SaveChanges();

                return Ok(new {message = "Dados removidos com sucesso"});
            }
            else
            {
               return NotFound(new {message = "Dados não encontrados"}); 
            }
        }

    }

}