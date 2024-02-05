using MovieASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieASP.DAL.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie? GetMovieById(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
