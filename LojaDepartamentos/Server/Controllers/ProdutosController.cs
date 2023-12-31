﻿using LojaDepartamentos.Server.Mappings;
using LojaDepartamentos.Server.Repositories;
using LojaDepartamentos.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LojaDepartamentos.Server.Controllers
{
    [Route("server/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetItems()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtoDtos = produtos.ConverterProdutosParaDto();
                    return Ok(produtoDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> GetItem(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetItem(id);
                if (produto is null)
                {
                    return NotFound("Produto não localizado");
                }
                else
                {
                    var produtoDto = produto.ConverterProdutoParaDto();
                    return Ok(produtoDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erro ao acessar o banco de dados");
            }
        }

        [HttpGet]
        [Route("{categoriaId}/GetItensPorCategoria")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>>
            GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
                var produtosDto = produtos.ConverterProdutosParaDto();
                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao acessar o banco de dados");
            }
        }

        [HttpGet]
        [Route("GetCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            try
            {
                var categorias = await _produtoRepository.GetCategorias();
                var categoriasDto = categorias.ConverterCategoriasParaDto();
                return Ok(categoriasDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "Erro ao acessar o banco de dados");
            }
        }
    }
}
