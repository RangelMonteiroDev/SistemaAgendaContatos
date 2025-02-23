using AgendaDeContatosMVC.data;
using AgendaDeContatosMVC.Models;
using System;
using System.Linq;
using BCrypt.Net;

namespace AgendaDeContatosMVC.Controllers
{
    public class OperacoesDeAutenticacao
    {
        private readonly AppDbContext _context;

        public OperacoesDeAutenticacao (AppDbContext context) {

            _context = context;
        }

        public string CriptografiaDeSenha (string senha) {

            var senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(senha);

            return senhaCriptografada;

        }

        public bool VerificarSenha (string senha, string hash) {

            var listaDeSenhas = _context.Usuarios.Select(u => u.Senha).ToList();

            bool senhaEncontrada = BCrypt.Net.BCrypt.Verify(senha, hash);

            return senhaEncontrada;
        }

        //Esse método gera o Código de acesso
        public string GerarCodigo()
        {
            int tamanho = 8;    
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(caracteres, tamanho)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void AddAutentication (int IdUsuario, DateTime DataHora, string HashCode ) {

           var autenticacoes = new Models.Autenticacoes{

            IdUsuario = IdUsuario,
            DataHora = DataHora,
            HashCode = HashCode

           };

            _context.Autenticacoes.Add(autenticacoes);
            _context.SaveChanges();
        }

        public bool VerifyAcessCode (string code) {

            var existsResults = _context.Autenticacoes.Where(a => a.HashCode == code);

            if (existsResults != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}