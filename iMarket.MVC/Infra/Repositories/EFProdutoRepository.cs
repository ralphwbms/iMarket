using System.Collections.Generic;
using System.Linq;
using iMarket.Models;
using iMarket.Infra.Context;
using System.Data.Entity;

namespace iMarket.Infra.Repositories
{
    public class EFProdutoRepository
    {
        private IMarketDBContext Db = new IMarketDBContext();

        public IEnumerable<Produto> Produtos
        {
            get { return Db.Produtos.Include(p => p.Departamento); }
        }

        public IEnumerable<Produto> ProdutosBySupermercado(int supermercadoId)
        {
            return Db.Produtos.Where(p => p.SupermercadoId == supermercadoId).
                Include(p => p.Departamento).ToList();
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
                    dbEntry.TemEstoque = produto.TemEstoque;
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

        public Produto AtualizarProduto(int id, Produto produto)
        {
            Produto dbEntry = Db.Produtos.Find(id);

            if (dbEntry == null)
                return null;
            else
            {
                dbEntry.Nome = produto.Nome;
                dbEntry.Preco = produto.Preco;
                dbEntry.PrecoPromocional = produto.PrecoPromocional;
                dbEntry.TemEstoque = produto.TemEstoque;
                dbEntry.DepartamentoId = produto.DepartamentoId;

                Db.SaveChanges();
                return dbEntry;
            }
        }
    }
}