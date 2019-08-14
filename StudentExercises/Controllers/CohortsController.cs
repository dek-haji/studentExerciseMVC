using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercises.Models;

namespace StudentExercises.Controllers
{
    public class CohortsController : Controller
    {
        private readonly IConfiguration _config;

        public CohortsController(IConfiguration config)
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
        // GET: Cohorts
        public ActionResult Index()
        {
            var cohorts = new List<Cohort>();
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT Id, Name FROM Cohort";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cohorts.Add(new Cohort()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        });
                    }
                }
            }
            return View(cohorts);
        }

        // GET: Cohorts/Details/5
        public ActionResult Details(int id)
        {
            Cohort cohort = null;
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id , Name FROM Cohort
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cohort = new Cohort()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                    }
                }
            }
            return View(cohort);
        }

        // GET: Cohorts/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Cohorts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cohort cohort)
        {
            try
            {
                
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @" 
                         INSERT INTO Cohort
                            ([Name]) VALUES ( @name) 
                    ";
                        cmd.Parameters.AddWithValue("name", cohort.Name);
                        cmd.ExecuteNonQuery();
                    }
                }
                        // TODO: Add insert logic here

                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }
            
        // GET: Cohorts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cohorts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cohorts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cohorts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}