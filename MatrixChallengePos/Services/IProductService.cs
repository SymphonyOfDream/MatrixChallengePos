using System.Collections.Generic;
using MatrixChallengePos.Models;

namespace MatrixChallengePos.Services
{
    /// <summary>
    /// Implementors will provide ICrudService functionality for their specific data stores.
    /// </summary>
    public interface IProductService : ICrudService<Product, int>
    {

        /// <summary>
        /// Returns a list of all Products having the specified
        /// name. Leading and trailing wildcards are implicit.
        /// </summary>
        /// <param name="name">Name, or partial name, of interest.</param>
        /// <returns>List of all Products having the specified name,
        /// or an empty list if none found.</returns>
        List<Product> FindByName(string name);


        /// <summary>
        /// Returns a list of all Products having the specified
        /// ProductCategory. Leading and trailing wildcards are implicit.
        /// </summary>
        /// <param name="productCategory">ProductCategory of interest.</param>
        /// <returns>List of all Products having the specified ProductCategory,
        /// or an empty list if none found.</returns>
        List<Product> FindByCategory(ProductCategory productCategory);
    }
}