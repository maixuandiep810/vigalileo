using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction, int>, IGenericRepository<Transaction, int>
    {
        public TransactionRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}