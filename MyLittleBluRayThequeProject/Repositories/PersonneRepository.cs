using MyLittleBluRayThequeProject.DTOs;
using Npgsql;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class PersonneRepository
    {

        public PersonneRepository()
        {

        }

        public List<Personne> GetListePersonne()
        {
            NpgsqlConnection conn = null;
            List<Personne> result = new List<Personne>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Nom\", \"Prenom\", \"DateNaissance\", \"Nationalite\" FROM \"BluRayTheque\".\"Personne\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    result.Add(new Personne
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Nom = dr[1].ToString(),
                        Prenom = dr[2].ToString(),
                        DateNaissance = DateTime.Parse(dr[3].ToString()),
                        Nationalite = dr[4].ToString()
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
    }
}
