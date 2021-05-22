using System;
using System.Collections.Generic;
using MatrixChallengePos.Models;
using Microsoft.Data.Sqlite;

namespace MatrixChallengePos.Services.Impl.Sqlite
{
    /// <summary>
    /// Implements the IProductService functionality against a SQLite database.
    /// </summary>
    public class ProductServiceSqlite : IProductService
    {
        private readonly IProductCategoryService _productCategoryService;


        public ProductServiceSqlite(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }


        ///<inheritdoc/>
        public void Insert(Product item)
        {
            if (item == null)
                throw new Exception("Product is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                INSERT INTO Products (sku_tx, name_tx, description_tx, product_category_id, wholesale_price_val, retail_price_val) 
                VALUES ($sku, $name, $description, $productCategoryId, $wholesalePrice, $retailPrice);
                ";
            command.Parameters.AddWithValue("$sku", item.Sku);
            command.Parameters.AddWithValue("$name", item.Name);
            command.Parameters.AddWithValue("$description", item.Description);
            if (item.ProductCategory != null)
            {
                command.Parameters.AddWithValue("$productCategoryId", item.ProductCategory.Id);
            }
            else
            {
                command.Parameters.AddWithValue("$productCategoryId", null);
            }
            command.Parameters.AddWithValue("$wholesalePrice", item.WholesalePrice);
            command.Parameters.AddWithValue("$retailPrice", item.RetailPrice);

            var newId = command.ExecuteScalar();

            if (newId != null)
            {
                item.Id = (int)(long)newId;
            }
            else
            {
                throw new Exception("Product insertion failed");
            }
        }


        ///<inheritdoc/>
        public Product Get(int id)
        {
            if (id < 1)
                return null;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT sku_tx, name_tx, description_tx, product_category_id, wholesale_price_val, retail_price_val
                FROM Products
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            // product_id is the PK, so will either return a single record or none
            if (reader.Read())
            {
                var productCategoryId = reader.GetInt32(3);

                var newProduct = new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    WholesalePrice = reader.GetDecimal(4),
                    RetailPrice = reader.GetDecimal(5)
                };

                newProduct.ProductCategory = _productCategoryService.Get(productCategoryId);
                return newProduct;
            }

            return null;
        }


        ///<inheritdoc/>
        public void Update(Product item)
        {
            if (item == null)
                throw new Exception("Product is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                UPDATE Products
                SET sku_tx = $sku, 
                    name_tx = $name, 
                    description_tx = $description, 
                    product_category_id = $productCategoryId, 
                    wholesale_price_val = $wholesalePrice,
                    retail_price_val = $retailPrice
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$sku", item.Sku);
            command.Parameters.AddWithValue("$name", item.Name);
            command.Parameters.AddWithValue("$description", item.Description);
            command.Parameters.AddWithValue("$productCategoryId", item.ProductCategory.Id);
            command.Parameters.AddWithValue("$wholesalePrice", item.WholesalePrice);
            command.Parameters.AddWithValue("$id", item.Id);

            var updateCount = command.ExecuteNonQuery();
            if (updateCount == 0)
                throw new Exception("Product update failed.");
        }


        ///<inheritdoc/>
        public void Delete(Product item)
        {
            if (item == null)
                throw new Exception("Product is null");

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                DELETE FROM Products
                WHERE product_id = $id;
                ";
            command.Parameters.AddWithValue("$id", item.Id);

            var deleteCount = command.ExecuteNonQuery();
            if (deleteCount == 0)
                throw new Exception("Product deletion failed.");
        }


        ///<inheritdoc/>
        public List<Product> FindByName(string name)
        {
            var foundProducts = new List<Product>();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                return foundProducts;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT product_id, sku_tx, name_tx, description_tx, product_category_id, wholesale_price_val, retail_price_val
                FROM Products
                WHERE name_tx LIKE '%$name%';
                ";
            command.Parameters.AddWithValue("$name", name);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var productCategoryId = reader.GetInt32(3);

                var foundProduct = new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    WholesalePrice = reader.GetDecimal(4),
                    RetailPrice = reader.GetDecimal(5)
                };

                foundProduct.ProductCategory = _productCategoryService.Get(productCategoryId);

                foundProducts.Add(foundProduct);
            }

            return foundProducts;
        }


        ///<inheritdoc/>
        public List<Product> FindByCategory(ProductCategory productCategory)
        {
            var foundProducts = new List<Product>();

            if (productCategory == null)
                return foundProducts;

            using var command = ((SqliteConnection)DbServiceSqlite.Instance.SqlConnection).CreateCommand();

            command.CommandText =
                @"
                SELECT product_id, sku_tx, name_tx, description_tx, product_category_id, wholesale_price_val, retail_price_val
                FROM Products
                WHERE product_category_id = $productCategoryId;
                ";
            command.Parameters.AddWithValue("$productCategoryId", productCategory.Id);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var productCategoryId = reader.GetInt32(3);

                var foundProduct = new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                    WholesalePrice = reader.GetDecimal(4),
                    RetailPrice = reader.GetDecimal(5)
                };

                foundProduct.ProductCategory = _productCategoryService.Get(productCategoryId);

                foundProducts.Add(foundProduct);
            }

            return foundProducts;
        }

    }
}