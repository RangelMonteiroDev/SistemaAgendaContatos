using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDeContatosMVC.Models
{
    public class Usuarios
    {   
        [Key]
        public int IdUsuario {get; set;}
        public string? Nome {get; set;}
        public string? Email {get; set;}
        public string? Senha {get; set;}
        public string? CellNumber {get; set;}
        public string? Ativo {get; set;}

    }
}