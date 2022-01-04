﻿using MyLittleBluRayThequeProject.DTOs;
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

        /// <summary>
        /// Ajout d'une personne dans la base de données
        /// </summary>
        /// <param name="Id">l'Id de la personne</param>
        /// <returns></returns>
        public void AddPersonne(Personne personne)
        {
            NpgsqlConnection conn = null;
            try
            {
                // Connect to a PostgreSQL database
                conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=matim;Database=postgres;");
                conn.Open();

                // Define a query returning a single row result set
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"BluRayTheque\".\"Personne\"(\"Nom\", \"Prenom\", \"DateNaissance\", \"Nationalite\") " +
                    "VALUES (@nom, @prenom, @dateNaissance, @nationalite);", conn);
                command.Parameters.AddWithValue("nom", personne.Nom);
                command.Parameters.AddWithValue("prenom", personne.Prenom);
                command.Parameters.AddWithValue("dateNaissance", personne.DateNaissance);
                command.Parameters.AddWithValue("nationalite", personne.Nationalite);

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
