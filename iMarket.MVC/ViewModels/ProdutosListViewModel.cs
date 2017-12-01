using System.Collections.Generic;
using iMarket.Models;

namespace iMarket.ViewModels
{
    public class ProdutosListViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string DepartamentoIdAtual { get; set; }
    }
}