using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDeContatosMVC.Models
{
    public class Administradores
    {
        [Key]
        public int IdAministrador {get; set;}
        public string Nome {get; set;}
        public string Cpf {get; set;}
        
        [ForeignKey("IdAutenticacaoAdmin")]
        public int IdAutenticacaoAdmin {get; set;}
        public string Ativo {get; set;}
    }
}