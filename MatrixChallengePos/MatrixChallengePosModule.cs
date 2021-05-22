using MatrixChallengePos.Services;
using MatrixChallengePos.Services.Impl;
using MatrixChallengePos.Services.Impl.Sqlite;
using MatrixChallengePos.ViewModels;
using MatrixChallengePos.Views;
using Ninject.Modules;

namespace MatrixChallengePos
{
    public class MatrixChallengePosModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbService>().To<DbServiceSqlite>();
            
            Bind<IAddressService>().To<AddressServiceSqlite>();

            Bind<IPersonService>().To<PersonServiceSqlite>();
            Bind<ICustomerService>().To<CustomerServiceSqlite>();
            Bind<IEmployeeService>().To<EmployeeServiceSqlite>();

            Bind<IProductCategoryService>().To<ProductCategoryServiceSqlite>();
            Bind<IProductService>().To<ProductServiceSqlite>();
            Bind<IProductInventoryService>().To<ProductInventoryServiceSqlite>();

            Bind<ISecurityService>().To<SecurityService>();

            Bind<ILoginService>().To<LoginServiceSqlite>();


            Bind<PurchaseTransactionViewModel>().ToSelf().InSingletonScope();
            Bind<PurchaseTransactionControl>().ToSelf().InSingletonScope();

            Bind<LoginViewModel>().ToSelf().InSingletonScope();
            Bind<MatrixChallengePosViewModel>().ToSelf().InSingletonScope();
        }
    }
}