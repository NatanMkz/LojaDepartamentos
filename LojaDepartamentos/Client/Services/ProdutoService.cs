
using LojaDepartamentos.Shared.DTOs;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

namespace LojaDepartamentos.Client.Services;

public class ProdutoService : IProdutoService
{
    public HttpClient _httpClient;
    public ILogger<ProdutoService> _logger;

    public ProdutoService(HttpClient httpClient,
        ILogger<ProdutoService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetItens()
    {
        try
        {
            var produtosDto = await _httpClient.
                             GetFromJsonAsync<IEnumerable<ProdutoDTO>>("server/produtos");
            return produtosDto;
        }
        catch (Exception)
        {
            _logger.LogError("Erro ao acessar produtos : server/produtos ");
            throw;
        }
    }

    public async Task<ProdutoDTO> GetItem(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"server/produtos/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(ProdutoDTO);
                }
                return await response.Content.ReadFromJsonAsync<ProdutoDTO>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Erro a obter produto pelo id={id}");
            throw;
        }
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        try
        {
            var response = await _httpClient.GetAsync("server/Produtos/GetCategorias");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CategoriaDTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }

    public async Task<IEnumerable<ProdutoDTO>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"server/Produtos/{categoriaId}/GetItensPorCategoria");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ProdutoDTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }
}
