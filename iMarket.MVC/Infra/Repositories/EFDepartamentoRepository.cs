using iMarket.Models;
using System.Collections.Generic;
using iMarket.Infra.Context;

namespace iMarket.Infra.Repositories
{
    public class EFDepartamentoRepository
    {
        private IMarketDBContext Db = new IMarketDBContext();

        public IEnumerable<Departamento> Departamentos
        {
            get { return Db.Departamentos; }
        }

        public void SalvarDepartamento(Departamento departamento)
        {

            if (departamento.Id == 0)
            {
                Db.Departamentos.Add(departamento);
            }
            else
            {
                Departamento dbEntry = Db.Departamentos.Find(departamento.Id);
                if (dbEntry != null)
                {
                    dbEntry.Nome = departamento.Nome;
                    dbEntry.Descricao = departamento.Descricao;
                }
            }
            Db.SaveChanges();
        }

        public Departamento DeletarDepartamento(int departamentoId)
        {
            Departamento dbEntry = Db.Departamentos.Find(departamentoId);
            if (dbEntry != null)
            {
                Db.Departamentos.Remove(dbEntry);
                Db.SaveChanges();
            }
            return dbEntry;
        }
    }
}