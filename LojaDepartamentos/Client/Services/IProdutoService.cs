
using LojaDepartamentos.Shared.DTOs;

namespace LojaDepartamentos.Client.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetItens();
    Task<ProdutoDTO> GetItem(int id);

    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<IEnumerable<ProdutoDTO>> GetItensPorCategoria(int categoriaId);
}
