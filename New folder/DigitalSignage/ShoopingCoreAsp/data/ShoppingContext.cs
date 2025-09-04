using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using ShoopingCoreAsp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ShoopingCoreAsp.data;
using ShoopingCoreAsp.utils;
namespace ShoopingCoreAsp.data
{
    public class ShoppingContext
    {
        public string ConnectionString { get; set; }

        public ShoppingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public ShoppingContext()
        {
            this.ConnectionString = "server=localhost;port=3306;database=digital_signage;uid=root;password=";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Admin loginAdmin(String email, String password)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                //MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE email = @email AND password = @password", conn);
                //command.Parameters.AddWithValue("@email", email);
                //command.Parameters.AddWithValue("@password", password);


                MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE email = @email", conn);
                command.Parameters.AddWithValue("@email", email);


                //MySqlCommand command = new MySqlCommand("Select *from admin where email='" + email + "' AND password='" + password + "'", conn);

                ////MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE TRIM(email) = TRIM(@email) AND password = @password", conn);
                //command.Parameters.AddWithValue("@email", email.Trim());
                //command.Parameters.AddWithValue("@password", password);

                MySqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    Admin admin = new Admin();
                    admin.id = dataReader.GetInt32(0);
                    admin.username = dataReader.GetString(1);
                    admin.email = dataReader.GetString(2);
                    return admin;
                }
                else
                {
                    return null;
                }
            }
        }
        

        public int UpdatePassword(String oldpassword, String password,int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update admin set password='"+ password + "' where id='"+id+"' AND password='" + oldpassword + "'", conn);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }


        public Category searchCategory(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from categories where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                MySqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    Category category = new Category();
                    category.id = dataReader.GetInt32(0);
                    category.name = dataReader.GetString(1);
                    category.image = dataReader.GetString(2);
                    return category;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Category> getAllCategories()
        {
            List<Category> categoriesList = new List<Category>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from categories Order by id DESC", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Category cat = new Category();
                    cat.id = dataReader.GetInt32(0);
                    cat.name = dataReader.GetString(1);
                    cat.image = dataReader.GetString(2);
                    cat.status = dataReader.GetInt32(3);
                    categoriesList.Add(cat);
                }

            }
            return categoriesList;
        }
        public List<Category> getAllCategoriesLIMIT7()
        {
            List<Category> categoriesList = new List<Category>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from categories Order by id DESC LIMIT 7", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Category cat = new Category();
                    cat.id = dataReader.GetInt32(0);
                    cat.name = dataReader.GetString(1);
                    cat.image = dataReader.GetString(2);
                    cat.status = dataReader.GetInt32(3);
                    categoriesList.Add(cat);
                }

            }
            return categoriesList;
        }
        public bool saveCategory(String name, String image)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Insert into categories(name,image,status)  values('" + name + "','" + image + "',1) ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public bool updateCategory(String name, String image, int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update categories set name='" + name + "',image='" + image + "' where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool deleteCategory(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from categories  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool saveSubCategory(String name, String image, int category_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Insert into sub_categories(name,image,status,category_id)  values('" + name + "','" + image + "',1,'" + category_id + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public List<SubCategory> getAllSubCategories()
        {
            List<SubCategory> categoriesList = new List<SubCategory>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select sub_categories.id as id, sub_categories.name as subname, sub_categories.image as image, categories.name as cate_name from sub_categories JOIN  categories ON  sub_categories.category_id=categories.id", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    SubCategory cat = new SubCategory();
                    cat.id = dataReader.GetInt32(0);
                    cat.name = dataReader.GetString(1);
                    cat.image = dataReader.GetString(2);
                    cat.sub_name = dataReader.GetString(3);
                    categoriesList.Add(cat);
                }

            }
            return categoriesList;
        }

        public SubCategory searchSubCategory(int id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from sub_categories where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                MySqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    SubCategory category = new SubCategory();
                    category.id = dataReader.GetInt32(0);
                    category.name = dataReader.GetString(1);
                    category.image = dataReader.GetString(2);
                    category.category_id = dataReader.GetInt32(4);
                    return category;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool updateSubCategory(String name, String image, int category_id, int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update sub_categories set name='" + name + "',image='" + image + "', category_id='" + category_id + "' where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool deleteSubCategory(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from sub_categories  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public List<SubCategory> seachByMainCategory(int category_id)
        {
            List<SubCategory> categoriesList = new List<SubCategory>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("select *from sub_categories where category_id='" + category_id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    SubCategory cat = new SubCategory();
                    cat.id = dataReader.GetInt32(0);
                    cat.name = dataReader.GetString(1);
                    cat.image = dataReader.GetString(2);
                    categoriesList.Add(cat);
                }

            }
            return categoriesList;
        }
       

        public bool saveBrand(String name)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Insert into brand(name)  values('" + name + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public List<Brand> getAllBrands()
        {
            List<Brand> BrandList = new List<Brand>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from brand", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Brand brand = new Brand();
                    brand.id = dataReader.GetInt32(0);
                    brand.name = dataReader.GetString(1);
                    BrandList.Add(brand);
                }

            }
            return BrandList;
        }

        public Brand findBrand(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from brand where id='" + id + "'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Brand brand = new Brand();
                    brand.id = dataReader.GetInt32(0);
                    brand.name = dataReader.GetString(1);
                    return brand;

                }
                else
                {
                    return null;

                }

            }


        }

        public bool updateBrand(String name, int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update brand set name='" + name + "' where id='" + id + "' ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool deleteBrand(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from brand  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool saveProduct(Product product)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Insert into products(title,image,brand,new_price,category_id," +
                    "sub_category_id,quantity,qr_code,details,is_top_rate,is_hot_product,is_best_deal,image2,image3,image4)" +
                    "  values('" + product.product_name + "','" + product.product_image + "' ,'" + product.product_brand + "' " +
                    ",'" + product.product_price + "' ,'" + product.cate_id + "','" + product.sub_cate_id + "' " +
                    ",'" + product.product_quantity + "' ,'" + product.product_qrcode + "' ,'" + product.product_details + "'" +
                    " ,'" + product.is_top_rate_product + "' ,'" + product.is_hot_product + "'  ,'" + product.is_best_deal + "' ," +
                    "'"+ product.product_image1 + "' ,'" + product.product_image2 + "' ,'" + product.product_image3 + "'   ) ", conn);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public List<Product> getAllProducts()
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand," +
                    " products.new_price,products.details,products.is_top_rate,products.is_hot_product," +
                    "products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, " +
                    "products.quantity,products.qr_code,brand.name as bandname, categories.name as catname," +
                    " sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id" +
                    " JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }

        public List<Product> SearchProducts(string search)
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, " +
                    "products.new_price,products.details,products.is_top_rate,products.is_hot_product," +
                    "products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, " +
                    "products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, " +
                    "sub_categories.name as subname ,products.image FROM `products` JOIN " +
                    "brand on products.brand=brand.id JOIN categories on " +
                    "products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where products.title LIKE '%"+ search + "%'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }

        public List<Product> GetAlert()
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, " +
                    "products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id " +
                    "JOIN sub_categories on products.sub_category_id = sub_categories.id where products.quantity <  50", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }


        public Product findProduct(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from products where id='" + id + "'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_image = dataReader.GetString(3);
                    product.product_image = dataReader.GetString(4);
                    product.product_image = dataReader.GetString(5);
                    product.product_image = dataReader.GetString(6);
                    product.product_price = dataReader.GetInt32(7);
                    product.product_details = dataReader.GetString(9);
                    product.is_top_rate_product = dataReader.GetInt32(10);
                    product.is_hot_product = dataReader.GetInt32(11);
                    product.is_best_deal = dataReader.GetInt32(12);
                    product.cate_id = dataReader.GetInt32(13);
                    product.sub_cate_id = dataReader.GetInt32(14);
                    product.product_quantity = dataReader.GetInt32(16);
                    product.product_qrcode = dataReader.GetString(16);
                    return product;

                }
                else
                {
                    return null;

                }

            }


        }
        public bool updateProduct(Product product)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update products set title='" + product.product_name + "'" +
                    ",image='" + product.product_image + "', brand='" + product.product_brand + "', new_price='" + product.product_price + "',category_id='" + product.cate_id + "'," +
                    "sub_category_id='" + product.sub_cate_id + "',quantity='" + product.product_quantity + "'," +
                    "qr_code='" + product.product_qrcode + "',details='" + product.product_details + "'," +
                    "is_top_rate='" + product.is_top_rate_product + "',is_hot_product='" + product.is_hot_product + "'," +
                    "is_best_deal='" + product.is_best_deal + "' where id='" + product.id + "' ", conn);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool deleteProduct(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from products  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public List<Product> getAllProductsByCategory(int id)
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand," +
                    " products.new_price,products.details,products.is_top_rate,products.is_hot_product," +
                    "products.is_best_deal,products.category_id,products.sub_category_id," +
                    " products.created_id, products.quantity,products.qr_code,brand.name as bandname," +
                    " categories.name as catname, sub_categories.name as subname ," +
                    "products.image FROM `products` JOIN brand on products.brand=brand.id JOIN " +
                    "categories on products.category_id= categories.id JOIN sub_categories on " +
                    "products.sub_category_id = sub_categories.id where products.sub_category_id='" + id + "'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }
            }
            return ProductList;
        }

        public Product searchSingleProduct(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price," +
                    "products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id," +
                    "products.sub_category_id," +
                    " products.created_id, products.quantity,products.qr_code, products.image , products.image2 , products.image3, products.image4 FROM products" +
                    "  where products.id='"+ id + "' LIMIT 1 ", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                 //   product.brand_name = dataReader.GetString(13);
                  //  product.cat_name = dataReader.GetString(14);
                  //  product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(13);
                    product.product_image1 = dataReader.GetString(14);
                    product.product_image2 = dataReader.GetString(15);
                    product.product_image3 = dataReader.GetString(16);
                    return product;
                }

            }
            return null;
        }
        public List<Product> getAllProductsByBrand(int id)
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where products.brand='" + id + "'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }
        public bool saveWishList(int product_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("select *from  wish_list where product_id = '" + product_id + "'", conn);
                MySqlDataReader dataReader = command1.ExecuteReader();
                if (!dataReader.Read())
                {
                    dataReader.Close();
                    MySqlCommand command = new MySqlCommand("Insert into wish_list(product_id)  values('" + product_id + "') ", conn);
                    //  command.Parameters.AddWithValue("@email", email);
                    //   command.Parameters.AddWithValue("@password",password);
                    int status = command.ExecuteNonQuery();
                }

                return true;
            }
        }

        public List<WhishList> getAllWhishList()
        {
            List<WhishList> whishLists = new List<WhishList>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select wish_list.id as wish_id, products.id as pro_id," +
                    " products.title, products.image, products.new_price,  products.quantity " +
                    " from wish_list Join products   on wish_list.product_id=products.id", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    WhishList whishlist = new WhishList();
                    whishlist.id = dataReader.GetInt32(0);
                    whishlist.product_id = dataReader.GetInt32(1);
                    whishlist.product_name = dataReader.GetString(2);
                    whishlist.product_image = dataReader.GetString(3);
                    whishlist.product_price = dataReader.GetInt32(4);
                    whishlist.product_quantity = dataReader.GetInt32(5);
                    whishLists.Add(whishlist);
                }
            }
            return whishLists;
        }

        public bool deleteWishList(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from wish_list  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        //public int saveAddtoCart(int product_id, string session)
        //{
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand command1 = new MySqlCommand("select *from  cart where product_id = '" + product_id + "' and session='" + session + "'", conn);
        //        MySqlDataReader dataReader = command1.ExecuteReader();
        //        if (!dataReader.Read())
        //        {
        //            dataReader.Close();

        //            MySqlCommand command2 = new MySqlCommand("select quantity  from products where id= '"+ product_id + "'  ", conn);
        //            MySqlDataReader dataReader2 = command2.ExecuteReader();
        //            dataReader2.Read();
        //            int quantity = dataReader2.GetInt32(0);
        //            if (quantity > 0)
        //            {
        //                dataReader2.Close();
        //                MySqlCommand command = new MySqlCommand("Insert into cart(product_id,session,quantity)  values('" + product_id + "'," +
        //                "'" + session + "',1) ", conn);
        //                //  command.Parameters.AddWithValue("@email", email);
        //                //   command.Parameters.AddWithValue("@password",password);
        //                int status = command.ExecuteNonQuery();
        //                return 200;
        //            }
        //            else
        //            {
        //                dataReader2.Close();
        //                return 203;

        //            }

        //        }
        //        else
        //        {
        //            return 202;
        //        }


        //    }
        //}


        public int saveAddtoCart(int product_id, string session)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                // Check if product already exists in cart
                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM cart WHERE product_id = @pid AND session = @sess", conn);
                checkCmd.Parameters.AddWithValue("@pid", product_id);
                checkCmd.Parameters.AddWithValue("@sess", session);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    return 202; // Already in cart
                }

                // Optional: check stock
                var stockCmd = new MySqlCommand("SELECT quantity FROM products WHERE id = @pid", conn);
                stockCmd.Parameters.AddWithValue("@pid", product_id);
                object stockResult = stockCmd.ExecuteScalar();

                if (stockResult != null && Convert.ToInt32(stockResult) > 0)
                {
                    // Insert new item
                    var insertCmd = new MySqlCommand("INSERT INTO cart (product_id, session, quantity) VALUES (@pid, @sess, 1)", conn);
                    insertCmd.Parameters.AddWithValue("@pid", product_id);
                    insertCmd.Parameters.AddWithValue("@sess", session);

                    int status = insertCmd.ExecuteNonQuery();
                    return (status > 0) ? 200 : 500; // 200 = success
                }
                else
                {
                    return 203; // Out of stock
                }
            }
        }


        public int countAddtoCart(string session)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("select count(id) as count from  cart where session='" + session + "'", conn);
                MySqlDataReader dataReader = command1.ExecuteReader();
                if (dataReader.Read())
                {
                    return dataReader.GetInt32(0);
                }
                return 0;
            }
        }

        public List<AddToCart> getAllCart(string session)
        {
            List<AddToCart> addToCartList = new List<AddToCart>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select cart.id as cart_id , products.id as pro_id, cart.quantity, products.title, products.image, products.new_price " +
                    "  from cart Join products   on cart.product_id=products.id where session='" + session + "'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    AddToCart addToCart = new AddToCart();
                    addToCart.id = dataReader.GetInt32(0);
                    addToCart.product_id = dataReader.GetInt32(1);
                    addToCart.quantity = dataReader.GetInt32(2);
                    addToCart.product_name = dataReader.GetString(3);
                    addToCart.product_image = dataReader.GetString(4);
                    addToCart.product_price = dataReader.GetInt32(5);
                    addToCartList.Add(addToCart);
                }
            }
            return addToCartList;
        }
        public bool updateCartList(int quantity, int id, int prod_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command2 = new MySqlCommand("select quantity  from products where id= '" + prod_id + "'  ", conn);
                MySqlDataReader dataReader2 = command2.ExecuteReader();
                if (dataReader2.Read())
                {
                    int count = dataReader2.GetInt32(0);
                    if (count >= quantity)
                    {
                        dataReader2.Close();
                        MySqlCommand command = new MySqlCommand("update cart set quantity = '" + quantity + "' where id = '" + id + "'", conn);
                        //  command.Parameters.AddWithValue("@email", email);
                        //   command.Parameters.AddWithValue("@password",password);
                        int status = command.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        dataReader2.Close();
                        return false;
                    }
                }
               
                return false;
            }
        }
        public bool deleteCat(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from cart  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public int saveOrders(Orders orders)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into orders(username,email,phone_number,city,address,status) " +
                    "VALUES('" + orders.username + "','" + orders.email + "','" + orders.phone_number + "','" + orders.city + "'" +
                    ",'" + orders.address + "','Pending') ", conn);
                command.ExecuteNonQuery();
                int status = (int)command.LastInsertedId;
                return status;
            }
        }
        public int updateOrderStatus( int id,string stats)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update orders set status = '" + stats + "' where id = '" + id + "'", conn);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }
        public List<Orders> getAllOrders()
        {
            List<Orders> ordersList = new List<Orders>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from orders where status='Pending'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Orders order = new Orders();
                    order.id = dataReader.GetInt32(0);
                    order.username = dataReader.GetString(1);
                    order.email = dataReader.GetString(2);
                    order.phone_number = dataReader.GetString(3);
                    order.city = dataReader.GetString(4);
                    order.address = dataReader.GetString(5);
                    order.status = dataReader.GetString(6);
                    ordersList.Add(order);
                }
            }
            return ordersList;
        }

        public Orders searchOrder(int id)
        {
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from orders where id = '"+id+"' LIMIT 1 ", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Orders order = new Orders();
                    order.id = dataReader.GetInt32(0);
                    order.username = dataReader.GetString(1);
                    order.email = dataReader.GetString(2);
                    order.phone_number = dataReader.GetString(3);
                    order.city = dataReader.GetString(4);
                    order.address = dataReader.GetString(5);
                    order.status = dataReader.GetString(6);
                    //order.order_date = dataReader.GetDateTime(7);

                    return order;
                }
            }
            return null;
        }
        public List<Orders> otherOrders()
        {
            List<Orders> ordersList = new List<Orders>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from orders where status!='Pending'", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Orders order = new Orders();
                    order.id = dataReader.GetInt32(0);
                    order.username = dataReader.GetString(1);
                    order.email = dataReader.GetString(2);
                    order.phone_number = dataReader.GetString(3);
                    order.city = dataReader.GetString(4);
                    order.address = dataReader.GetString(5);
                    order.status = dataReader.GetString(6);
                    ordersList.Add(order);
                }
            }
            return ordersList;
        }
        public int saveOrderProducts(OrderProducts orders)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into order_products(order_id,product_id,product_price,quantity) " +
                    "VALUES('" + orders.order_id + "','" + orders.product_id + "','" + orders.product_price + "','" + orders.quantity + "' ) ", conn);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }

        public List<OrderProducts> orderProductLists(int order_id)
        {
            List<OrderProducts> ordersList = new List<OrderProducts>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select  order_products.product_price, order_products.quantity, products.title,  products.image  from order_products  join products on order_products.product_id = products.id where order_id='" + order_id+"' ", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    OrderProducts order = new OrderProducts();
                    order.product_price = dataReader.GetString(0);
                    order.quantity = dataReader.GetString(1);
                    order.name = dataReader.GetString(2);
                    order.image = dataReader.GetString(3);
                    ordersList.Add(order);
                }
            }
            return ordersList;
        }

        public bool updateProductQuantity(int reduce_q, int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update products set quantity= quantity - '" + reduce_q + "'  where id='" + id + "' ", conn);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public bool deleteCatBySession(string session)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from cart  where session='" + session + "'", conn);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }
        public List<Product> compareProduct(int category_id, int price)
        {
            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where" +
                    " products.category_id='" + category_id + "' AND products.new_price='" + price + "' ", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }
        public List<Product> is_best_deal()
        {

            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where" +
                    " products.is_best_deal = 1  LIMIT 7", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }

        public List<Product> is_hot_deal()
        {

            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where" +
                    " products.is_hot_product = 1", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }

        public List<Product> is_top_rated()
        {

            List<Product> ProductList = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT products.id,products.title,products.brand, products.new_price,products.details,products.is_top_rate,products.is_hot_product,products.is_best_deal,products.category_id,products.sub_category_id, products.created_id, products.quantity,products.qr_code,brand.name as bandname, categories.name as catname, sub_categories.name as subname ,products.image FROM `products` JOIN brand on products.brand=brand.id JOIN categories on products.category_id= categories.id JOIN sub_categories on products.sub_category_id = sub_categories.id where" +
                    " products.is_top_rate = 1 LIMIT 7", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.id = dataReader.GetInt32(0);
                    product.product_name = dataReader.GetString(1);
                    product.product_brand = dataReader.GetInt32(2);
                    product.product_price = dataReader.GetInt32(3);
                    product.product_details = dataReader.GetString(4);
                    product.is_top_rate_product = dataReader.GetInt32(5);
                    product.is_hot_product = dataReader.GetInt32(6);
                    product.is_best_deal = dataReader.GetInt32(7);
                    product.cate_id = dataReader.GetInt32(8);
                    product.sub_cate_id = dataReader.GetInt32(9);
                    product.product_quantity = dataReader.GetInt32(11);
                    product.product_qrcode = dataReader.GetString(12);
                    product.brand_name = dataReader.GetString(13);
                    product.cat_name = dataReader.GetString(14);
                    product.sub_cat_name = dataReader.GetString(15);
                    product.product_image = dataReader.GetString(16);
                    ProductList.Add(product);
                }

            }
            return ProductList;
        }
        public int savebanner(string image)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into slider(image) " +
                    "VALUES('" + image + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }

        public int saveSplashBanner(string image)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into splash_banner(image) " +
                    "VALUES('" + image + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }

        public int saveAddress(Address address)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into address(addr,phone,email) " +
                    "VALUES('" + address.addr + "','" + address.phone + "','" + address.email + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }
        public int updateAddress(Address address)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update address set addr='"+address.addr+"'," +
                    "phone='"+ address.phone+ "',email='"+ address.email+"' where id='"+address.id+"' ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }
        public Address getAddress()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from address LIMIT 1", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Address address = new Address();
                    address.id = dataReader.GetInt32(0);
                    address.addr = dataReader.GetString(1);
                    address.email = dataReader.GetString(2);
                    address.phone = dataReader.GetString(3);
                    return address;
                }
            }

            return null;
        }

        public SplashBanner getSplashBanner()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from splash_banner LIMIT 1", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    SplashBanner banner = new SplashBanner();
                    banner.id = dataReader.GetInt32(0);
                    banner.image = dataReader.GetString(1);
                    return banner;
                }
            }

            return null;
        }

        public List<Banner> getAllBanners()
        {
            List<Banner> bannerList = new List<Banner>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from slider", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Banner banner = new Banner();
                    banner.id = dataReader.GetInt32(0);
                    banner.image = dataReader.GetString(1);
                    bannerList.Add(banner);
                }
            }

            return bannerList;
        }

        public bool deleteBanner(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from slider  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public bool deleteSplashBanner(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("delete from splash_banner  where id='" + id + "'", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return true;
            }
        }

        public int saveSocial(Social social)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into social(facebook,twitter,linkdin,google,pinterest) " +
                    "VALUES('" + social.facebook + "','" + social.twitter + "','" + social.linkdin + "', '"+ social.google+ "', '"+ social.pinterest + "') ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }
        public int updateSocial(Social socail)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("update social set facebook='" + socail.facebook + "'," +
                    "twitter='" + socail.twitter + "',linkdin='" + socail.linkdin + "',google='" + socail.google + "'" +
                    ",pinterest='" + socail.pinterest + "'  where id='" + socail.id + "' ", conn);
                //  command.Parameters.AddWithValue("@email", email);
                //   command.Parameters.AddWithValue("@password",password);
                int status = command.ExecuteNonQuery();
                return status;
            }
        }
        public Social getSocial()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select *from social LIMIT 1", conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Social social = new Social();
                    social.facebook = dataReader.GetString(0);
                    social.twitter = dataReader.GetString(1);
                    social.linkdin = dataReader.GetString(2);
                    social.google = dataReader.GetString(3);
                    social.pinterest = dataReader.GetString(4);
                    social.id = dataReader.GetInt32(5);
                    return social;
                }
            }

            return null;
        }

    }

}
