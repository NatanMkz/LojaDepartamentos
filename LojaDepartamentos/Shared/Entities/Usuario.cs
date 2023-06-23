using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDepartamentos.Shared.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string NomeUsuario { get; set; } = string.Empty;

        public Carrinho? Carrinho { get; set; }
    }
}
