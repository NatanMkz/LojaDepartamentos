using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDepartamentos.Shared.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; } =
            new List<CarrinhoItem>();

        //public List<CarrinhoItem> Itens { get; set; }
    }
}
