using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MovieASP.DAL.Models;
using MovieASP.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieASP.DAL.Services
{
    public class MovieService : IMovieRepository
    {
        protected readonly string _connectionString;

        public MovieService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }
        public Movie? GetMovieById(int id)
        {
            
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie WHERE Id = @id";
                    command.Parameters.AddWithValue("id", id);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Movie
                            {
                                Id = reader.GetInt32(0),
                                PosterUrl = reader.GetString(1),
                                Title = reader.GetString(2),
                                Description = reader.GetString(3),
                                Genre = reader.GetString(4),
                                ReleaseDate = reader.GetDateTime(5)
                            };
                        }
                    }

                    return null;
                }
            }   

        }

        public void AddMovie(Movie movie)
        {
        
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Movie (PosterUrl, Title, Description, Genre, ReleaseDate) VALUES (@posterUrl, @title, @description, @genre, @releaseDate)";
                    command.Parameters.AddWithValue("posterUrl", movie.PosterUrl);
                    command.Parameters.AddWithValue("title", movie.Title);
                    command.Parameters.AddWithValue("description", movie.Description);
                    command.Parameters.AddWithValue("genre", movie.Genre);
                    command.Parameters.AddWithValue("releaseDate", movie.ReleaseDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMovie(int id)
        {
            
           
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Movie WHERE Id = @id";
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            
            List<Movie> movies = new List<Movie>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie";
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                Id = reader.GetInt32(0),
                                PosterUrl = reader.GetString(1),
                                Title = reader.GetString(2),
                                Description = reader.GetString(3),
                                Genre = reader.GetString(4),
                                ReleaseDate = reader.GetDateTime(5)
                            });
                        }

                        return movies;
                    }
                }
            }
        }
                    
            public void UpdateMovie(Movie movie)
        {
       
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Movie SET PosterUrl = @posterUrl, Title = @title, Description = @description, Genre = @genre, ReleaseDate = @releaseDate WHERE Id = @id";
                    command.Parameters.AddWithValue("posterUrl", movie.PosterUrl);
                    command.Parameters.AddWithValue("title", movie.Title);
                    command.Parameters.AddWithValue("description", movie.Description);
                    command.Parameters.AddWithValue("genre", movie.Genre);
                    command.Parameters.AddWithValue("releaseDate", movie.ReleaseDate);
                    command.Parameters.AddWithValue("id", movie.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

            
    }
}
