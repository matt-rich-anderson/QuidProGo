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
                        List<Category> consultations = new List<Category>();
                        while (reader.Read())
                        {
                            Category consultation = new Category
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CatergoryName")),
                            };

                            consultations.Add(consultation);
                        }

                        return consultations;
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
    }
}
