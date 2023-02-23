using Framework.Core.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence
{
    public class EntityIdGenerator<TEntity> : IEntityIdGenerator<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;


        public EntityIdGenerator(IDbContext dbContext)
        {
            this.dbContext = (DbContext)dbContext;
        }


        public long GetNewId()
        {
            lock (dbContext)
            {
                var sqlParameter = new SqlParameter("@Result", System.Data.SqlDbType.BigInt)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                dbContext.Database.ExecuteSqlRaw($"SELECT @Result=( NEXT VALUE FOR shared.[{typeof(TEntity).Name}])", sqlParameter);

                return (long)sqlParameter.Value;

            }
        }
    }
}
