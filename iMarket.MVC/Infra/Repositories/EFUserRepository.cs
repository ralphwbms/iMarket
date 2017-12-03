using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        public void AddUserToRole(string userId, string roleName)
        {
            var userStore = new UserStore<User>(Db);
            var userManager = new UserManager<User>(userStore);
            userManager.AddToRole(userId, roleName);
        }

        public void RemoveUserToRole(string userId, string roleName)
        {
            var userStore = new UserStore<User>(Db);
            var userManager = new UserManager<User>(userStore);
            userManager.RemoveFromRole(userId, roleName);
        }

    }
}