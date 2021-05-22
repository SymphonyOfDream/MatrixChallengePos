using MatrixChallengePos.Models;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Implementors will provide ICrudService functionality for their specific data stores.
    /// </summary>
    public interface ICustomerService : ICrudService<Customer, int>
    {
    }
}