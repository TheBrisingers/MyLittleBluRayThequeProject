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
                NpgsqlCommand command = new NpgsqlCommand("SELECT \"Id\", \"Titre\", \"Duree\", \"Version\", \"DateSortie\" FROM \"BluRayTheque\".\"BluRay\"", conn);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                // Output rows
                /*while (dr.Read())x
                    result.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        Scenariste = (new Personne
                        {
                            Id = long.Parse(dr[2].ToString()),
                            Nom = dr[2].ToString(),
                            Prenom = dr[2].ToString(),
                            *//*DateNaissance = long.Parse(dr[2].ToString()),
                            Nationalite = long.Parse(dr[2].ToString()),
                            Professions = long.Parse(dr[2].ToString()),*//*
                        }),
                        Realisateur = (new Personne
                        {
                            Id = long.Parse(dr[2].ToString()),
                            Nom = dr[2].ToString(),
                            Prenom = dr[2].ToString(),
                            *//*DateNaissance = long.Parse(dr[2].ToString()),
                            Nationalite = long.Parse(dr[2].ToString()),
                            Professions = long.Parse(dr[2].ToString()),*//*
                        }),
                        //Faire une boucle for
                        Acteurs = {(new Personne
                        {
                            Id = long.Parse(dr[2].ToString()),
                            Nom = dr[2].ToString(),
                            Prenom = dr[2].ToString(),
                            DateNaissance = DateTime.Parse(dr[2].ToString()),
                            Nationalite = dr[2].ToString(),
                            Professions = null
                        }), (new Personne
                        {
                            Id = long.Parse(dr[2].ToString()),
                            Nom = dr[2].ToString(),
                            Prenom = dr[2].ToString(),
                            DateNaissance = DateTime.Parse(dr[2].ToString()),
                            Nationalite = dr[2].ToString(),
                            Professions = null
                        })},
                        Duree = TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                        DateSortie = DateTime.Parse(dr[4].ToString()),
                        *//*Langues = "ghb",
                        SsTitres = ,
                        Version = dr[3].ToString(),
                        Genre = dr[3].ToString(),
                        Resume = dr[3].ToString(),
                        Note = dr[3].ToString(),
                        Emprunt = dr[3].ToString(),
                        Proprietaire = dr[3].ToString(),
                        Disponible = dr[3].ToString(),*//*
                    });*/
                while (dr.Read())
                    result.Add(new BluRay
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        Duree = TimeSpan.FromSeconds(long.Parse(dr[2].ToString())),
                        Version = dr[3].ToString(),
                        DateSortie = DateTime.Parse(dr[4].ToString())

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
                    "\"Version\", \"Emprunt\", \"Disponible\") " +
                    "VALUES (@titre, @duree, @dateSortie, @version, @emprunt, @disponible);", conn);
                command.Parameters.AddWithValue("titre", bluRay.Titre);
                command.Parameters.AddWithValue("duree", bluRay.Duree.TotalSeconds);
                command.Parameters.AddWithValue("dateSortie", bluRay.DateSortie);
                command.Parameters.AddWithValue("version", bluRay.Version);
                command.Parameters.AddWithValue("emprunt", bluRay.Emprunt);
                command.Parameters.AddWithValue("disponible", bluRay.Disponible);

                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();

                /*if (bluRay.Acteurs != null)
                {
                    foreach (var acteur in bluRay.Acteurs)
                    {
                        command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Acteur\"(\"IdBluRay\", \"IdActeur\") VALUES (@idBluRay, @idActeur);", conn);
                        command.Parameters.AddWithValue("idBluRay", acteur.Id);//TODO change with id bluRay
                        command.Parameters.AddWithValue("idActeur", acteur.Id);
                        command.ExecuteNonQuery();
                    }
                }

                if (bluRay.Scenariste != null)
                {
                    NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Scenariste\"(\"IdBluRay\", \"IdScenariste\") VALUES (@idBluRay, @idScenariste);", conn);
                    command2.Parameters.AddWithValue("idBluRay", bluRay.Scenariste.Id);//TODO change with id bluRay
                    command2.Parameters.AddWithValue("idScenariste", bluRay.Scenariste.Id);
                    command2.ExecuteNonQuery();
                    
                }

                if (bluRay.Realisateur != null)
                {
                    NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Realisateur\"(\"IdBluRay\", \"IdRealisateur\") VALUES (@idBluRay, @idRealisateur);", conn);
                    command3.Parameters.AddWithValue("idBluRay", bluRay.Realisateur.Id);//TODO change with id bluRay
                    command3.Parameters.AddWithValue("idRealisateur", bluRay.Realisateur.Id);
                    command3.ExecuteNonQuery();

                }
                */

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
    

