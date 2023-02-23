using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext dbContext;


        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Commit()
        {
            dbContext.SaveChanges();
        }


        public void Rollback()
        {
            dbContext.Dispose();
        }
    }
}
