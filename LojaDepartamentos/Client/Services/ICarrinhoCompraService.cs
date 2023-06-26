using LojaDepartamentos.Shared.DTOs;

namespace LojaDepartamentos.Client.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDTO>> GetItens(string usuarioId);
        Task<CarrinhoItemDTO> AdicionaItem(CarrinhoItemAdicionaDTO carrinhoItemAdicionaDto);
        Task<CarrinhoItemDTO> DeletaItem(int id);
        Task<CarrinhoItemDTO> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDTO carrinhoItemAtualizaQuantidadeDto);

        event Action<int> OnCarrinhoCompraChanged;
        void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade);
    }
}
