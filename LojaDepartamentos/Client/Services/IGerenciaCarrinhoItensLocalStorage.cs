using LojaDepartamentos.Shared.DTOs;

namespace LojaDepartamentos.Client.Services
{
	public interface IGerenciaCarrinhoItensLocalStorageService
	{
		Task<List<CarrinhoItemDTO>> GetCollection();
		Task SaveCollection(List<CarrinhoItemDTO> carrinhoItensDto);
		Task RemoveCollection();
	}
}
