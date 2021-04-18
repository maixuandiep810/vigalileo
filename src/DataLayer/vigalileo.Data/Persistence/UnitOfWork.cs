using System;
using System.Threading.Tasks;
using vigalileo.Data.Core;
using vigalileo.Data.Core.Repositories;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly vigalileoDbContext _vigalileoDbContext;

        public IAppConfigRepository AppConfigRepository { get; set; }
        public IApplicationRoleRepository ApplicationRoleRepository { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IBrandInCategoryRepository BrandInCategoryRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ICategoryTranslationRepository categoryTranslationRepository { get; set; }
        public IContactRepository ContactRepository { get; set; }
        public ICustomerDetailRepository CustomerDetailRepository { get; set; }
        public ILanguageRepository LanguageRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductInCategoryRepository productInCategoryRepository { get; set; }
        public IProductTranslationRepository ProductTranslationRepository { get; set; }
        public ISellerDetailRepository SellerDetailRepository { get; set; }
        public IStoreRepository StoreRepository { get; set; }
        public IStoreInOrderRepository storeInOrderRepository { get; set; }
        public ITransactionRepository TransactionRepository { get; set; }

        public UnitOfWork(vigalileoDbContext vigalileoDbContext)
        {
            _vigalileoDbContext = vigalileoDbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// TODO: 
        /// 1.<!-- Dispose ALL REPOSITORY-->
        /// </summary>
        /// <param name="disposing"></param>
        /// 
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO-1
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Save All Changes To Db using DbContext
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _vigalileoDbContext.SaveChangesAsync();
        }

        // public void Rollback()
        // {
        //     _context
        //         .ChangeTracker
        //         .Entries()
        //         .ToList()
        //         .ForEach(x => x.Reload());
        // }
    }
}