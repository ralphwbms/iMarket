using iMarket.Models;
using System.Collections.Generic;
using iMarket.Infra.Context;

namespace iMarket.Infra.Repositories
{
    public class EFProdutoRepository
    {
        private IMarketDBContext context = new IMarketDBContext();

        public IEnumerable<Produto> Produtos
        {
            get { return context.Produtos; }
        }

        public void SalvarProduto(Produto produto)
        {

            if (produto.Id == 0)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                Produto dbEntry = context.Produtos.Find(produto.Id);
                if (dbEntry != null)
                {
                    dbEntry.Nome = produto.Nome;
                    dbEntry.Preco = produto.Preco;
                    dbEntry.PrecoPromocional = produto.PrecoPromocional;
                    dbEntry.DepartamentoId = produto.DepartamentoId;
                }
            }
            context.SaveChanges();
        }

        public Produto DeletarProduto(int productID)
        {
            Produto dbEntry = context.Produtos.Find(productID);
            if (dbEntry != null)
            {
                context.Produtos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}