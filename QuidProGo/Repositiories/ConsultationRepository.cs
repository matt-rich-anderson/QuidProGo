using QuidProGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly IConfiguration _config;
        public ConsultationRepository(IConfiguration config)
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

        public List<Consultation> GetAllConsultations()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Title, [Description], ClientUserId, AttorneyUserId, CreateDateTime
                        FROM Consultation
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Consultation> consultations = new List<Consultation>();
                        while (reader.Read())
                        {
                            Consultation consultation = new Consultation
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ClientUserId = reader.GetInt32(reader.GetOrdinal("ClientUserId")),
                                AttorneyUserId = reader.GetInt32(reader.GetOrdinal("AttorneyUserId")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                            };

                            consultations.Add(consultation);
                        }

                        return consultations;
                    }
                }
            }
        }

        public Consultation GetConsultationById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Title, [Description], ClientUserId, AttorneyUserId, CreateDateTime
                        FROM Consultation
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Consultation consultation = new Consultation
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ClientUserId = reader.GetInt32(reader.GetOrdinal("ClientUserId")),
                                AttorneyUserId = reader.GetInt32(reader.GetOrdinal("AttorneyUserId")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                            };

                            return consultation;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public List<Consultation> GetConsultationsByClientId(int clientId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Title, [Description], ClientUserId, AttorneyUserId, CreateDateTime
                        FROM Consultation
                        WHERE ClientUserId = @clientId
                    ";

                    cmd.Parameters.AddWithValue("@clientId", clientId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<Consultation> consultations = new List<Consultation>();

                        while (reader.Read())
                        {
                            Consultation consultation = new Consultation()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ClientUserId = reader.GetInt32(reader.GetOrdinal("ClientUserId")),
                                AttorneyUserId = reader.GetInt32(reader.GetOrdinal("AttorneyUserId")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                            };

                            consultations.Add(consultation);
                        }

                        return consultations;
                    }
                }
            }
        }
    }
}
