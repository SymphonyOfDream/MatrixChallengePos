using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IProductCategoryService functionality against a SQLite database.
    /// </summary>
    public class ProductCategoryServiceSqlite : IProductCategoryService
    {
        private static Dictionary<int, ProductCategory> _allCategories = new Dictionary<int, ProductCategory>();

        public ProductCategoryServiceSqlite()
        {
            if (ProductCategoryServiceSqlite._allCategories.Count == 0)
                PopulateAllCategories();
        }


        private void AddNewCategory(int id, string name)
        {
            ProductCategoryServiceSqlite._allCategories[id] = new ProductCategory()
            {
                Id = id,
                Name = name
            };
        }


        private void PopulateAllCategories()
        {
            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM ProductCategories";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                AddNewCategory(reader.GetInt32(0), reader.GetString(1));
            }
        }


        ///<inheritdoc/>
        public void Insert(ProductCategory item)
        {
            if (item == null)
                throw new Exception("ProductCategory is null");

            if (ProductCategoryServiceSqlite._allCategories.ContainsKey(item.Id))
                throw new Exception("ProductCategory already exists, cannot be inserted");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO ProductCategories (name_tx) 
                VALUES ($name) 
                RETURNING product_category_id;
                ";
            command.Parameters.AddWithValue("$name", item.Name);
            var newId = command.ExecuteScalar();
            item.Id = (int)(long)newId;

            AddNewCategory(item.Id, item.Name);
        }

        public ProductCategory Get(int id)
        {
            if (id < 1)
                return null;

            if (ProductCategoryServiceSqlite._allCategories.TryGetValue(id, out var foundCategory))
                return foundCategory;

            return null;
        }

        ///<inheritdoc/>
        public void Update(ProductCategory item)
        {
            if (item == null)
                throw new Exception("ProductCategory is null");

            if (ProductCategoryServiceSqlite._allCategories.ContainsKey(item.Id))
                throw new Exception("ProductCategory does not exist, cannot be updated");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE ProductCategories 
                SET name_tx = $name
                WHERE product_category_id = $id;
                ";
            command.Parameters.AddWithValue("$name", item.Name);
            command.Parameters.AddWithValue("$id", item.Id);

            command.ExecuteNonQuery();

            AddNewCategory(item.Id, item.Name);
        }

        ///<inheritdoc/>
        public void Delete(ProductCategory item)
        {
            if (item == null)
                throw new Exception("ProductCategory is null");

            if (!ProductCategoryServiceSqlite._allCategories.ContainsKey(item.Id))
                throw new Exception("ProductCategory does not exist, cannot be deleted");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM ProductCategories WHERE product_category_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Id);
        }


        public List<ProductCategory> All => _allCategories.Values.ToList();

    }
}