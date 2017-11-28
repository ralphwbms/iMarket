using System.Linq;
using System.Collections.Generic;
using iMarket.Infra.Context;
using iMarket.Models;

namespace iMarket.Infra.Repositories
{
    public class EFSupermercadoRepository
    {
        private IMarketDBContext Db = new IMarketDBContext();

        public IEnumerable<Supermercado> Supermercados
        {
            get { return Db.Supermercados; }
        }

        public Supermercado LocalizarPorCNPJ( string CNPJ)
        {
            return Db.Supermercados.First(s => s.CNPJ == CNPJ);
        }

        public Supermercado LocalizarPorUserId(string userId)
        {
            return Db.Supermercados.FirstOrDefault(s => s.UsuarioId == userId);
        }

        public void SalvarSupermercado(Supermercado supermercado)
        {

            if (supermercado.Id == 0)
            {
                Db.Supermercados.Add(supermercado);
            }
            else
            {
                Supermercado dbEntry = Db.Supermercados.Find(supermercado.Id);
                if (dbEntry != null)
                {
                    dbEntry.RazaoSocial = supermercado.RazaoSocial;
                    dbEntry.NomeFantasia = supermercado.NomeFantasia;
                    dbEntry.CNPJ = supermercado.CNPJ;
                    dbEntry.Logradouro = supermercado.Logradouro;
                    dbEntry.Numero = supermercado.Numero;
                    dbEntry.Complemento = supermercado.Complemento;
                    dbEntry.Bairro = supermercado.Bairro;
                    dbEntry.CEP = supermercado.CEP;
                    dbEntry.UF = supermercado.UF;
                    dbEntry.Cidade = supermercado.Cidade;
                    dbEntry.Ativo = supermercado.Ativo;
                    dbEntry.UsuarioId = supermercado.UsuarioId;
                }
            }
            Db.SaveChanges();
        }

        public Supermercado DeletarSupermercado(int supermercadoId)
        {
            Supermercado dbEntry = Db.Supermercados.Find(supermercadoId);
            if (dbEntry != null)
            {
                Db.Supermercados.Remove(dbEntry);
                Db.SaveChanges();
            }
            return dbEntry;
        }
    }
}