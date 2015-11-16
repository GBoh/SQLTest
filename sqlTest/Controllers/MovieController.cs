using sqlTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sqlTest.Controllers {
    public class MovieController : ApiController {
        private DbContext db = new DataContext();

        [HttpGet]
        public IList<Movie> Get() {
            return db.Database.SqlQuery<Movie>("SELECT * FROM dbo.Movies ORDER BY Title").ToList();
        }

        [HttpPost]
        public HttpResponseMessage Post(Movie newMovie) {
            if (ModelState.IsValid) {
                if (newMovie.Id == 0) {
                    var sql = @"INSERT INTO dbo.Movies(Title, Director, Description) VALUES (@Title, @Director, @Description)";

                    List<SqlParameter> ParamList = new List<SqlParameter>();
                    ParamList.Add(new SqlParameter("@Title", newMovie.Title));
                    ParamList.Add(new SqlParameter("@Director", newMovie.Director));
                    ParamList.Add(new SqlParameter("@Description", newMovie.Description));

                    db.Database.ExecuteSqlCommand(sql, ParamList.ToArray());
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, newMovie);
                }
                else {
                    var sql = @"UPDATE dbo.Movies SET Title = @Title, Director = @Director, Description = @Description WHERE Id = @Id";
                    List<SqlParameter> ParamList = new List<SqlParameter>();
                    ParamList.Add(new SqlParameter("@Title", newMovie.Title));
                    ParamList.Add(new SqlParameter("@Director", newMovie.Director));
                    ParamList.Add(new SqlParameter("@Description", newMovie.Description));
                    ParamList.Add(new SqlParameter("@Id", newMovie.Id));

                    db.Database.ExecuteSqlCommand(sql, ParamList);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, newMovie);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        public void Delete(int id) {
            var sql = @"DELETE FROM dbo.Movies WHERE Id = @Id";
            db.Database.ExecuteSqlCommand(sql, new SqlParameter("@Id", id));
        }
    }
}
