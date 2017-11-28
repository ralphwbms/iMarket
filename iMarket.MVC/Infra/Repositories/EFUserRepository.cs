using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iMarket.Infra.Context;
using iMarket.Models;

namespace iMarket.Infra.Repositories
{
    public class EFUserRepository
    {
        private IMarketDBContext Db = new IMarketDBContext();

        public IEnumerable<User> Users
        {
            get { return Db.Users; }
        }
    }
}