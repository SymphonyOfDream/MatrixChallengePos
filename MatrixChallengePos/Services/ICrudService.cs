namespace MatrixChallengePos.Services
{
    public interface ICrudService<T, ID>
    {
        /// <summary>
        /// Saves the specified item to the data store. Populates the item's Id property when finished.
        /// </summary>
        /// <param name="item">Item to save</param>
        void Insert(T item);

        /// <summary>
        /// Retrieves the item having the specified id from the data store.
        /// </summary>
        /// <param name="id">ID of the item being searched for.</param>
        /// <returns>Found item, or null if not found.</returns>
        T Get(ID id);

        /// <summary>
        /// Updates the specified item in the data store.
        /// </summary>
        /// <param name="item">Item to update</param>
        void Update(T item);

        /// <summary>
        /// Deletes the specified item from the data store.
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(T item);
    }
}