namespace MovieASP.Models.Mappers
{
    public static class Mapper
    {
        
        public static User Map(this MovieASP.DAL.Models.User user)
        {
            return new User
            {
                Id = user.Id,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

       

        public static Movie Map(this MovieASP.DAL.Models.Movie movie)
        {
            return new Movie
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate
            };
        }


      
        public static MovieASP.DAL.Models.User Map(this User user)
        {
            return new MovieASP.DAL.Models.User
            {
                Id = user.Id,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static MovieASP.DAL.Models.Movie Map(this Movie movie)
        {
            return new MovieASP.DAL.Models.Movie
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate
            };
        }



        public static IEnumerable<Movie> Map(this IEnumerable<MovieASP.DAL.Models.Movie> movies)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (var m in movies)
            {
                movieList.Add(m.Map());
            };
            return movieList;
        }


    }
}
