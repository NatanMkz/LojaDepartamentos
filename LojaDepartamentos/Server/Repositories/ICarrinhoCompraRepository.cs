using LojaDepartamentos.Shared.DTOs;
using LojaDepartamentos.Shared.Entities;

namespace LojaDepartamentos.Server.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDTO carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDTO
            carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletaItem(int id);

        Task<CarrinhoItem> GetItem(int id);

        Task<IEnumerable<CarrinhoItem>> GetItens(string usuarioId);
    }
}
