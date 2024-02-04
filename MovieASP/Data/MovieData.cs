using MovieASP.Models;

namespace MovieASP.Data
{
    public class MovieData
    {
            private static MovieData _instance;
            private List<Movie> _movies;

            public MovieData()
            {
                _movies = new List<Movie>
        {
            new Movie { Id = 1, PosterUrl= "https://fr.web.img3.acsta.net/c_310_420/medias/nmedia/18/66/14/37/18957591.jpg", Title = "Les Goonies", Description = "Alors que leurs maisons du quartier des Goon Docks vont être prochainement saisies et qu'ils passent leurs derniers jours ensemble, quatre adolescents, Mickey, Brand, Mouth et Data, découvrent dans un grenier une carte dessinée par le célèbre pirate Willy-le-Borgne.", Genre = "Aventure", ReleaseDate = new DateTime(1985,06,07) },
            new Movie { Id = 2, PosterUrl="https://fr.web.img3.acsta.net/c_310_420/medias/nmedia/18/66/84/52/18959063.jpg", Title = "Les petits champions", Description = "Avocat brillant, Gordon , qui a été un bon joueur de hockey est arrêté pour excès de vitesse... Sa peine? Des heures d'intérêt général à entrainer une équipe de hockey d'enfants.", Genre = "Sport", ReleaseDate = new DateTime(1992,10,02) },
       
        };
            }

            public static MovieData Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new MovieData();
                    }
                    return _instance;
                }
            }

            public List<Movie> GetMovies()
            {
                return _movies;
            }

            public Movie GetMovieById(int id)
            {
                return _movies.Find(movie => movie.Id == id);
            }

            public void AddMovie(Movie movie)
            {
                movie.Id = _movies.Count + 1;
                _movies.Add(movie);
            }
        }
}
