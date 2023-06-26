using LojaDepartamentos.Shared.DTOs;

namespace LojaDepartamentos.Client.Services
{
	public interface IGerenciaProdutosLocalStorageService
	{
		Task<IEnumerable<ProdutoDTO>> GetCollection();
		Task RemoveCollection();
	}
}
