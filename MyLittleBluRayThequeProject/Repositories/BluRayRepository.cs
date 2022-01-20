using MyLittleBluRayThequeProject.DTOs;
using Npgsql;
using NuGet.Packaging.Signing;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayRepository
    {
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BluRayRepository()
        {

        }

        public List<BluRay> GetListeBluRay()
        {
            NpgsqlConnection conn = null;
            List<BluRay> result = new List<BluRay>();
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();
                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"DateSortie\", \"Version\", \"Disponible\" FROM \"BluRayTheque\".\"BluRay\" WHERE \"Disponible\"=true", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

            
                while (dr.Read())
                    result.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        DateSortie = DateTime.Parse(dr[2].ToString()),
                        Version = dr[3].ToString(),
                        Disponible = bool.Parse(dr[4].ToString())

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

        /// <summary>
        /// Récupération d'un BR par son Id
        /// </summary>
        /// <param name="Id">l'Id du bluRay</param>
        /// <returns></returns>
        public BluRay GetBluRay(long Id)
        {
            NpgsqlConnection conn = null;
            BluRay result = new BluRay();
            try
            {
                List<BluRay> qryResult = new List<BluRay>();
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"Duree\", \"Version\" FROM \"BluRayTheque\".\"BluRay\" where \"Id\" = @p", conn);
                command.Parameters.AddWithValue("p", Id);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                    qryResult.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        Duree = TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                        Version = dr[3].ToString()
                    });

                result = qryResult.SingleOrDefault();

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

        /// <summary>
        /// Ajout d'un BR dans la base de données
        /// </summary>
        /// <param name="Id">l'Id du bluRay</param>
        /// <returns></returns>
        public void AddBluRay(BluRay bluRay)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"BluRay\"(\"Titre\", \"Duree\", \"DateSortie\"," +
                    "\"Version\", \"Emprunt\", \"Disponible\", \"Proprietaire\" ) " +
                    "VALUES (@titre, @duree, @dateSortie, @version, @emprunt, @disponible, @proprietaire);", conn);
                command.Parameters.AddWithValue("titre", bluRay.Titre);
                command.Parameters.AddWithValue("duree", bluRay.Duree.TotalSeconds);
                command.Parameters.AddWithValue("dateSortie", bluRay.DateSortie);
                command.Parameters.AddWithValue("version", bluRay.Version);
                command.Parameters.AddWithValue("emprunt", bluRay.Emprunt);
                command.Parameters.AddWithValue("disponible", bluRay.Disponible);
                command.Parameters.AddWithValue("proprietaire", bluRay.Proprietaire);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();


            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }  
        
        public void EditDisponibility(BluRay bluRay)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("UPDATE \"BluRayTheque\".\"BluRay\" SET \"Disponible\"= @dispo " +
                    "WHERE \"Id\" == @id;", conn);
                command.Parameters.AddWithValue("dispo", bluRay.Disponible);
                command.Parameters.AddWithValue("id", bluRay.Id);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();


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
    

