using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iMarket.Models;
using iMarket.Infra.Repositories;
using iMarket.Dtos;
using AutoMapper;

namespace iMarket.Controllers.Api
{
    public class ProdutosController : ApiController
    {
        private EFProdutoRepository produtoRepo;

        public ProdutosController()
        {
            produtoRepo = new EFProdutoRepository();
        }

        // GET /api/produtos
        public IEnumerable<ProdutoDto> GetProdutos()
        {
            return produtoRepo.Produtos.ToList().Select(Mapper.Map<Produto, ProdutoDto>);
        }

        // GET /api/produtos/1
        public ProdutoDto GetProduto(int id)
        {
            var produto = produtoRepo.Produtos.SingleOrDefault(p => p.Id == id);

            if (produto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Produto, ProdutoDto>(produto);
        }

        // POST /api/produtos
        [HttpPost]
        public ProdutoDto CreateProduto(ProdutoDto produtoDto)
        {
            if (produtoDto == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var produto = Mapper.Map<ProdutoDto, Produto>(produtoDto);
            produtoRepo.SalvarProduto(produto);

            produtoDto.Id = produto.Id;

            return produtoDto;
        }

        // PUT /api/produtos/1
        [HttpPut]
        public void UpdateCustomer(int id, ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var produto = new Produto();
            Mapper.Map<ProdutoDto, Produto>(produtoDto, produto);          

            produto = produtoRepo.AtualizarProduto(id, produto);

            if (produto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        
        // DELETE /api/produtos/1
        [HttpDelete]
        public void DeleteProduto(int id)
        {
            var produto = produtoRepo.DeletarProduto(id);

            if (produto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
