using System.Collections.Generic;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Implementors will provide ICrudService functionality for their specific data stores.
    /// </summary>
    public interface IProductCategoryService : ICrudService<ProductCategory, int>
    {
        List<ProductCategory> All { get; }
    }
}