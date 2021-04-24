using System;
using System.Threading.Tasks;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.EF;
using vigalileo.Data.RepositoryPattern.Repositories;

namespace vigalileo.Data.UnitOfWorkPattern

{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly vigalileoDbContext _context;

        public IAppConfigRepository AppConfigRepository { get; }
        public IApplicationRoleRepository ApplicationRoleRepository { get; }
        public IApplicationUserRepository ApplicationUserRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public IBrandInCategoryRepository BrandInCategoryRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICategoryTranslationRepository categoryTranslationRepository { get; }
        public IContactRepository ContactRepository { get; }
        public ICustomerDetailRepository CustomerDetailRepository { get; }
        public IEntityPermissionRepository EntityPermissionRepository { get; }
        public ILanguageRepository LanguageRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IPermissionInRoleRepository PermissionInRoleRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductInCategoryRepository ProductInCategoryRepository { get; }
        public IProductTranslationRepository ProductTranslationRepository { get; }
        public IRoutePermissionRepository RoutePermissionRepository { get; }
        public ISellerDetailRepository SellerDetailRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IStoreInOrderRepository storeInOrderRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IUserInEntityPermissionRepository UserInEntityPermissionRepository { get; }

        public UnitOfWork(vigalileoDbContext context)
        {
            _context = context;
            AppConfigRepository = new AppConfigRepository(_context);
            ApplicationUserRepository = new ApplicationUserRepository(_context);
            ApplicationRoleRepository = new ApplicationRoleRepository(_context);
            BrandInCategoryRepository = new BrandInCategoryRepository(_context);
            BrandRepository = new BrandRepository(_context);
            CartRepository = new CartRepository(_context);
            EntityPermissionRepository = new EntityPermissionRepository(_context);
            PermissionInRoleRepository = new PermissionInRoleRepository(_context);
            RoutePermissionRepository = new RoutePermissionRepository(_context);
            UserInEntityPermissionRepository = new UserInEntityPermissionRepository(_context);
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
            await _context.SaveChangesAsync();
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