using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
   
        public class WalkRepository : IWalkRepository
        {
            private readonly IConfiguration _config;

            public WalkRepository(IConfiguration config)
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

            public List<Walk> GetAllWalks()
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                                        SELECT Id, Date, Duration, WalkerId, DogId
                                        FROM Walks";

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Walk> walks = new List<Walk>();
                        while (reader.Read())
                        {
                            Walk walk = new Walk
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                                WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                                DogId = reader.GetInt32(reader.GetOrdinal("DogId"))
                            };

                            walks.Add(walk);
                        }

                        reader.Close();

                        return walks;
                    }
                }
            }

            public List<Walk> GetWalksByWalkerId(int walkerId)
            {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                  SELECT w.Id, w.date, w.duration, w.walkerId, w.dogId, d.Id, d.ownerId, o.name
                from walks w
                left join dog d on d.Id = w.dogId
                left join owner o on d.ownerId = o.id
                WHERE WalkerId = @walkerId
            ";

                    cmd.Parameters.AddWithValue("@walkerId", walkerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walk> walks = new List<Walk>();
                    while (reader.Read())
                    {
                        Walk walk = new Walk
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            Client = new Owner
                            {
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            }

                        };

                        walks.Add(walk);
                    }
                    reader.Close();
                    return walks;
                }
            }
        }

            //public void AddWalk(Walk walk)
            //{
            //    using (SqlConnection conn = Connection)
            //    {
            //        conn.Open();
            //        using (SqlCommand cmd = conn.CreateCommand())
            //        {
            //            cmd.CommandText = @"
            //        INSERT INTO Owner ([Name], Email, Phone, Address, NeighborhoodId)
            //        OUTPUT INSERTED.ID
            //        VALUES (@name, @email, @phoneNumber, @address, @neighborhoodId);
            //    ";

            //            cmd.Parameters.AddWithValue("@name", owner.Name);
            //            cmd.Parameters.AddWithValue("@email", owner.Email);
            //            cmd.Parameters.AddWithValue("@phoneNumber", owner.Phone);
            //            cmd.Parameters.AddWithValue("@address", owner.Address);
            //            cmd.Parameters.AddWithValue("@neighborhoodId", owner.NeighborhoodId);

            //            int id = (int)cmd.ExecuteScalar();

            //            owner.Id = id;
            //        }
            //    }
            //}

            //public void UpdateWalk(Walk walk)
            //{
            //    using (SqlConnection conn = Connection)
            //    {
            //        conn.Open();

            //        using (SqlCommand cmd = conn.CreateCommand())
            //        {
            //            cmd.CommandText = @"
            //                UPDATE Owner
            //                SET 
            //                    [Name] = @name, 
            //                    Email = @email, 
            //                    Address = @address, 
            //                    Phone = @phone, 
            //                    NeighborhoodId = @neighborhoodId
            //                WHERE Id = @id";

            //            cmd.Parameters.AddWithValue("@name", owner.Name);
            //            cmd.Parameters.AddWithValue("@email", owner.Email);
            //            cmd.Parameters.AddWithValue("@address", owner.Address);
            //            cmd.Parameters.AddWithValue("@phone", owner.Phone);
            //            cmd.Parameters.AddWithValue("@neighborhoodId", owner.NeighborhoodId);
            //            cmd.Parameters.AddWithValue("@id", owner.Id);

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}

            //public void DeleteWalk(int walkId)
            //{
            //    using (SqlConnection conn = Connection)
            //    {
            //        conn.Open();

            //        using (SqlCommand cmd = conn.CreateCommand())
            //        {
            //            cmd.CommandText = @"
            //                DELETE FROM Owner
            //                WHERE Id = @id
            //            ";

            //            cmd.Parameters.AddWithValue("@id", ownerId);

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
        }
    
}
