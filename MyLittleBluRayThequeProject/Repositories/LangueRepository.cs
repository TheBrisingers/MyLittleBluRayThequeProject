using MyLittleBluRayThequeProject.DTOs;
using Npgsql;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class LangueRepository
    {
        public List<RefLangue> GetListeLangues()
        {
            NpgsqlConnection conn = null;
            List<RefLangue> result = new List<RefLangue>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Langue\" FROM \"BluRayTheque\".\"RefLangue\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    result.Add(new RefLangue
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Langue = dr[1].ToString()
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

        public void LinkLangue (List<RefLangue> langues, long idBluRay)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();
                if (langues != null)
                {
                    foreach (var langue in langues)
                    {
                        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRayLangue\"(\"IdBluRay\", \"IdLangue\") VALUES (@idBluRay, @idLangue);", conn);
                        command.Parameters.AddWithValue("idBluRay", idBluRay);
                        command.Parameters.AddWithValue("idLangue", langue.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void LinkSsTitres(List<RefLangue> langues, long idBluRay)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();
                if (langues != null)
                {
                    foreach (var langue in langues)
                    {
                        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRaySsTitre\"(\"IdBluRay\", \"IdssTitreLangue\") VALUES (@idBluRay, @idLangue);", conn);
                        command.Parameters.AddWithValue("idBluRay", idBluRay);
                        command.Parameters.AddWithValue("idLangue", langue.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }

    
}
