using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Services
{
    public class AiModelService
    {
        private readonly My_DB _db;

        public AiModelService()
        {
            _db = new My_DB();
        }

        public void InitializeDatabase()
        {
            try
            {
                using (SqlConnection conn = _db.getConnection)
                {
                    conn.Open();

                    // Check if table exists
                    string checkTableSql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AI_Models'";
                    using (SqlCommand checkCmd = new SqlCommand(checkTableSql, conn))
                    {
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            // Create table
                            string createTableSql = @"
                                CREATE TABLE AI_Models (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    ModelName NVARCHAR(100) NOT NULL,
                                    ApiType NVARCHAR(50) NOT NULL,
                                    ApiUrl NVARCHAR(500) NOT NULL,
                                    ApiModelCode NVARCHAR(100) NULL,
                                    ApiKey NVARCHAR(500) NULL,
                                    IsActive BIT NOT NULL DEFAULT 0
                                );

                                -- Create unique filtered index to ensure only 1 active model
                                CREATE UNIQUE NONCLUSTERED INDEX UX_OneActiveModel ON AI_Models(IsActive) WHERE IsActive = 1;
                            ";
                            using (SqlCommand createCmd = new SqlCommand(createTableSql, conn))
                            {
                                createCmd.ExecuteNonQuery();
                            }

                            // Insert default data
                            string insertSql = @"
                                INSERT INTO AI_Models (ModelName, ApiType, ApiUrl, ApiModelCode, ApiKey, IsActive) 
                                VALUES 
                                (N'Qwen 3 (Bản ~32B)', 'OpenAI', 'https://openrouter.ai/api/v1/chat/completions', 'qwen/qwen-2.5-32b-instruct', NULL, 0),
                                (N'gemini flash-lite 3.1', 'Gemini', 'https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent', NULL, NULL, 1),
                                (N'gemini flash lite 2.5', 'Gemini', 'https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent', NULL, NULL, 0);
                            ";
                            using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                            {
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khởi tạo CSDL AI_Models: " + ex.Message);
            }
        }

        public List<AiModel> GetModels()
        {
            List<AiModel> models = new List<AiModel>();
            try
            {
                using (SqlConnection conn = _db.getConnection)
                {
                    conn.Open();
                    string sql = "SELECT * FROM AI_Models ORDER BY Id ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                models.Add(new AiModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ModelName = reader["ModelName"].ToString(),
                                    ApiType = reader["ApiType"].ToString(),
                                    ApiUrl = reader["ApiUrl"].ToString(),
                                    ApiModelCode = reader["ApiModelCode"] == DBNull.Value ? null : reader["ApiModelCode"].ToString(),
                                    ApiKey = reader["ApiKey"] == DBNull.Value ? null : reader["ApiKey"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách Model: " + ex.Message);
            }
            return models;
        }

        public AiModel GetActiveModel()
        {
            try
            {
                using (SqlConnection conn = _db.getConnection)
                {
                    conn.Open();
                    string sql = "SELECT * FROM AI_Models WHERE IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AiModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ModelName = reader["ModelName"].ToString(),
                                    ApiType = reader["ApiType"].ToString(),
                                    ApiUrl = reader["ApiUrl"].ToString(),
                                    ApiModelCode = reader["ApiModelCode"] == DBNull.Value ? null : reader["ApiModelCode"].ToString(),
                                    ApiKey = reader["ApiKey"] == DBNull.Value ? null : reader["ApiKey"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy Model active: " + ex.Message);
            }
            return null;
        }

        public void SetActiveModel(int id)
        {
            try
            {
                using (SqlConnection conn = _db.getConnection)
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Reset all
                            string resetSql = "UPDATE AI_Models SET IsActive = 0";
                            using (SqlCommand cmd1 = new SqlCommand(resetSql, conn, transaction))
                            {
                                cmd1.ExecuteNonQuery();
                            }

                            // Set new active
                            string setActiveSql = "UPDATE AI_Models SET IsActive = 1 WHERE Id = @Id";
                            using (SqlCommand cmd2 = new SqlCommand(setActiveSql, conn, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@Id", id);
                                cmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi set Model active: " + ex.Message);
            }
        }
    }
}
