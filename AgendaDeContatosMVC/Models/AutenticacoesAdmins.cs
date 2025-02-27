using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDeContatosMVC.Models
{
    public class AutenticacoesAdmins
    {
        [Key]
        public int IdAutenticacao {get; set;}
        public required DateTime DataHora {get;set;}
        public required string HashCode {get;set;} 
        
    }
}