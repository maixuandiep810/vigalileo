using System;
using System.Threading.Tasks;
using vigalileo.Data.RepositoryPattern.IRepositories;

namespace vigalileo.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAppConfigRepository AppConfigRepository { get; }
        IApplicationRoleRepository ApplicationRoleRepository { get; }
        IApplicationUserRepository ApplicationUserRepository{ get; }
        IBrandRepository BrandRepository { get; }
        IBrandInCategoryRepository BrandInCategoryRepository { get; }
        ICartRepository CartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICategoryTranslationRepository categoryTranslationRepository { get; }
        IContactRepository ContactRepository { get; }
        ICustomerDetailRepository CustomerDetailRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductInCategoryRepository productInCategoryRepository { get; }
        IProductTranslationRepository ProductTranslationRepository { get; }
        ISellerDetailRepository SellerDetailRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStoreInOrderRepository storeInOrderRepository { get; }
        ITransactionRepository TransactionRepository { get; }
    

        Task CommitAsync();
    }
}