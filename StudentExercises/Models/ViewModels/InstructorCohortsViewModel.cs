﻿//using System.Collections.Generic;
//using System.Data.SqlClient;

//namespace StudentExercises.Models.ViewModels
//{
//    public class InstructorCohortsViewModel
//    {

//        public List<Cohort> Cohorts { get; set; }
//        public List<Instructor> Instructors { get; set; }

//        private string _connectionString;

//        private SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_connectionString);
//            }
//        }

//        public InstructorCohortsViewModel(string connectionString)
//        {
//            _connectionString = connectionString;
//            GetAllCohorts();
//            GetAllInstructors();
        
//        }

//        private void GetAllCohorts()
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        SELECT
//                            Id,
//                            FirstName,
//                            LastName,
//                            Specialty,
//                            SlackHandle
//                        FROM Instructor";
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Cohorts = new List<Cohort>();
//                    while (reader.Read())
//                    {
//                        Cohorts.Add(new Cohort
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            Name = reader.GetString(reader.GetOrdinal("Name")),
                         
//                        });
//                    }

//                    reader.Close();
//                }
//            }
//        }
//        private Instructor GetSingleInstructor(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                Instructor instructor = null;
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        SELECT Id, FirstName, LastName, SlackHandle, Specialty, CohortId
//                        FROM Instructor
//                        WHERE Id = @id
//                    ";

//                    cmd.Parameters.Add(new SqlParameter("@id", id));
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    if (reader.Read())
//                    {
//                        instructor = new Instructor()
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
//                            Specialty = reader.GetString(reader.GetOrdinal("Specialty")),
//                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
//                        };
//                    }
//                }
//                return instructor;
//            }
//        }
//        private void GetAllInstructors()
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                            SELECT
//                            Id,
//                            FirstName,
//                            LastName,
//                            SlackHandle
//                        FROM Instructor";
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Instructors = new List<Instructor>();
//                    while (reader.Read())
//                    {
//                        Instructors.Add(new Instructor
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                            Specialty = reader.GetString(reader.GetOrdinal("Specialty")),
//                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
//                        });
//                    }

//                    reader.Close();
//                }
//            }
//        }
//    }
//}