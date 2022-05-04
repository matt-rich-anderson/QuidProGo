using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _config;
        public CategoryRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }



        public List<Category> GetAllCategorys()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Category AS CatergoryName
                        FROM Category
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Category> categories = new List<Category>();
                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CatergoryName")),
                            };

                            categories.Add(category);
                        }

                        return categories;
                    }
                }
            }
        }
        public void AddConsultationCatagory(int consultationId, int categoryId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO ConsultationCategory (ConsultationId, CategoryId)
                    OUTPUT INSERTED.ID
                    VALUES (@consultationId, @categoryId);
                ";

                    cmd.Parameters.AddWithValue("@consultationId", consultationId);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Category> GetCategByConsultId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT CategoryId, Category AS CategoryName
                        FROM ConsultationCategory cc
                        JOIN Category cat ON cc.CategoryId = cat.Id
                        WHERE cc.ConsultationId = @id 
                    ";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Category> categories = new List<Category>();
                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                            };

                            categories.Add(category);
                        }

                        return categories;
                    }
                }
            }
        }
        public void DeleteConsultCateg(int id) { }


    }
}
