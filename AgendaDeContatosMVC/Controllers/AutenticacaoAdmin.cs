using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaDeContatosMVC.data;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatosMVC.Controllers
{
    public class AutenticacaoAdmin
    {
        private readonly AppDbContext _context;

        public AutenticacaoAdmin(AppDbContext context) {

            _context = context;
        }

        private string GetGerarHashMethod () {

            var operacoes = new OperacoesDeAutenticacao(_context);

            string GerarCodigo = operacoes.GerarCodigoDeAcesso();

            return GerarCodigo;
        }

        //Método para criar novos administradores
        public string AddAdministrador (string nome, string cpf) {

            DateTime DataCriacaoHash = new DateTime();

            string HashCode = GetGerarHashMethod();

            var AutenticacoesAdmins = new Models.AutenticacoesAdmins{

                DataHora = DataCriacaoHash,
                HashCode = HashCode
            };

            _context.AutenticacoesAdmins.Add(AutenticacoesAdmins);
            _context.SaveChanges();

            var hashCodeInTable = _context.AutenticacoesAdmins.FirstOrDefault(a => a.HashCode == HashCode);

            //Agora vamos adicionar o administrador a tabela de administradores

            var administradores = new Models.Administradores{

                Nome = nome,

                Cpf = cpf,

                IdAutenticacaoAdmin = hashCodeInTable.IdAutenticacao,

                Ativo = "on"
            };

            _context.Administradores.Add(administradores);
            _context.SaveChanges();

            return HashCode;//Retornando o Hash 
        }
    }
}