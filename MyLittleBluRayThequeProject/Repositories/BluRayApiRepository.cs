using MyLittleBluRayThequeProject.DTOs;
using Newtonsoft.Json;
using Npgsql;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayApiRepository
    {
        public List<BluRayApi> GetBluRays(string baseUrl)
        {
            HttpClient client = new HttpClient();
            List<BluRayApi> result = new List<BluRayApi>();
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}/BluRays").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<BluRayApi>>(responseBody);
            }
            finally
            {
                client.Dispose();
            }
            return result;
        }

        public bool PostEmprunt(string baseUrl, long idBluRay)
        {
            HttpClient client = new HttpClient();
            List<BluRayApi> result = new List<BluRayApi>();
            try
            {
                HttpResponseMessage response = client.PostAsync($"{baseUrl}/BluRays/{idBluRay}/Emprunt", null).Result;
                response.EnsureSuccessStatusCode();
            }
            finally
            {
                client.Dispose();
            }
            return true;
        }
        public Loueur GetLoueur(long idLoueur)
        {
            NpgsqlConnection conn = null;
            List<Loueur> result = new List<Loueur>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();
                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Nom\", \"baseUrl\" FROM \"BluRayTheque\".\"SourceEmprunt\" WHERE \"Id\"=@p", conn);
                command.Parameters.AddWithValue("p", idLoueur);
                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                    result.Add(new Loueur
                    {
                        Id = idLoueur,
                        Nom = dr[0].ToString(),
                        BaseUrl = dr[1].ToString()

                    });
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result[0];
        }

        public List<Loueur> GetListeLoueur()
        {
            NpgsqlConnection conn = null;
            List<Loueur> result = new List<Loueur>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();
                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Nom\", \"baseUrl\" FROM \"BluRayTheque\".\"SourceEmprunt\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                    result.Add(new Loueur
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Nom = dr[1].ToString(),
                        BaseUrl = dr[2].ToString()

                    });
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
