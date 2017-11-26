using iMarket.Models;
using System.Collections.Generic;
using iMarket.Infra.Context;

namespace iMarket.Infra.Repositories
{
    public class EFProdutoRepository
    {
        private IMarketDBContext Db = new IMarketDBContext();

        public IEnumerable<Produto> Produtos
        {
            get { return Db.Produtos; }
        }

        public void SalvarProduto(Produto produto)
        {

            if (produto.Id == 0)
            {
                Db.Produtos.Add(produto);
            }
            else
            {
                Produto dbEntry = Db.Produtos.Find(produto.Id);
                if (dbEntry != null)
                {
                    dbEntry.Nome = produto.Nome;
                    dbEntry.Preco = produto.Preco;
                    dbEntry.PrecoPromocional = produto.PrecoPromocional;
                    dbEntry.DepartamentoId = produto.DepartamentoId;
                }
            }
            Db.SaveChanges();
        }

        public Produto DeletarProduto(int productID)
        {
            Produto dbEntry = Db.Produtos.Find(productID);
            if (dbEntry != null)
            {
                Db.Produtos.Remove(dbEntry);
                Db.SaveChanges();
            }
            return dbEntry;
        }
    }
}