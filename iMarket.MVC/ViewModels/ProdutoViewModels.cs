using System.Collections.Generic;
using iMarket.Models;

namespace iMarket.ViewModels
{
    public class NewProdutoViewModel
    {
        public IEnumerable<Departamento> Departamentos { get; set; }
        public Produto Produto { get; set; }
    }

    public class EditProdutoViewModel
    {
        public IEnumerable<Departamento> Departamentos { get; set; }
        public Produto Produto { get; set; }
    }

}