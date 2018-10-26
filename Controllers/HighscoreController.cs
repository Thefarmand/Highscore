using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scores;


namespace HigHIscore.Controllers
{
    [Route("api/Highscore")]
    [ApiController]
    public class HigHIscoreController : ControllerBase
    {
        private static string connString ="Server=tcp:thefarmand.database.windows.net,1433;Initial Catalog=Thefarmand;Persist Security Info=False;User ID=Thefarmand;Password=Killer1963;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;
        private static List<HIscore> higHIscores = new List<HIscore>();

        // POST: api/HigHIscore
        [HttpPost] // bruges når man poster til api'et
        public void Post([FromBody] HIscore Data)
        {
            higHIscores.Add(Data);
        }

        // GET: api/HigHIscore
        [HttpGet] // når jeg beder om en liste fra scores med alt
        public IEnumerable<HIscore> Get()
        {
            //Laver en ny connection til sgl connsttring hiver fai i databasen
            SqlConnection conn = new SqlConnection(connString);
            //Sql query
            SqlCommand query = new SqlCommand("SELECT * FROM scores", conn);
            //Åbner forbindelse
            conn.Open();
            //Eksekverer min query
            SqlDataReader reader = query.ExecuteReader();
            //Laver en ny liste
            List<HIscore> listscores = new List<HIscore>();
            //Hvis der findes mindst en række
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    //Hent alt og put det i en liste
                    HIscore hs = new HIscore {Name = reader[0].ToString(), Score = reader.GetInt32(1)};
                    listscores.Add(hs);
                }
            }
            return listscores;
        }

        // GET: api/HigHIscore/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/HigHIscore/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
