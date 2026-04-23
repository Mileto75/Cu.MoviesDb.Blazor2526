using Cu_ServicePattern_Movies.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Cu_ServicePattern_Movies.Core.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder) 
        {
            //companies
            var companies = new Company[]
            {
                new Company { Id = 1, Name = "Universal Pictures" },
                new Company { Id = 2, Name = "Sony Pictures" },
                new Company { Id = 3, Name = "Warner Bros." },
                new Company { Id = 4, Name = "Marvel Studios" },
                new Company { Id = 5, Name = "Amblin Entertainment" },
                new Company { Id = 6, Name = "Village Roadshow Pictures" },
                new Company { Id = 7, Name = "20th Century Fox" },
                new Company { Id = 8, Name = "Paramount Pictures" }
            };
            //Movie
            var movies = new Movie[]
            {
                new Movie {
                    Id = 1,
                    Title = "Transformers",
                    Price = 50.00M,
                    ReleaseDate = new DateTime(2007, 7, 3),
                    CompanyId = 1
                },
                new Movie {
                    Id = 2,
                    Title = "Transformers: Revenge of the Fallen",
                    Price = 55.00M,
                    ReleaseDate = new DateTime(2009, 6, 24),
                    CompanyId = 2
                },
                new Movie {
                    Id = 3,
                    Title = "Inception",
                    Price = 60.00M,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    CompanyId = 3
                },
                new Movie {
                    Id = 4,
                    Title = "The Dark Knight",
                    Price = 65.00M,
                    ReleaseDate = new DateTime(2008, 7, 18),
                    CompanyId = 3
                },
                new Movie {
                    Id = 5,
                    Title = "Avengers: Endgame",
                    Price = 70.00M,
                    ReleaseDate = new DateTime(2019, 4, 26),
                    CompanyId = 4
                },
                new Movie {
                    Id = 6,
                    Title = "Interstellar",
                    Price = 58.00M,
                    ReleaseDate = new DateTime(2014, 11, 7),
                    CompanyId = 3
                },
                new Movie {
                    Id = 7,
                    Title = "Jurassic World",
                    Price = 52.00M,
                    ReleaseDate = new DateTime(2015, 6, 12),
                    CompanyId = 5
                },
                new Movie {
                    Id = 8,
                    Title = "The Matrix",
                    Price = 48.00M,
                    ReleaseDate = new DateTime(1999, 3, 31),
                    CompanyId = 6
                },
                new Movie {
                    Id = 9,
                    Title = "Avatar",
                    Price = 68.00M,
                    ReleaseDate = new DateTime(2009, 12, 18),
                    CompanyId = 7
                },
                new Movie {
                    Id = 10,
                    Title = "Top Gun: Maverick",
                    Price = 72.00M,
                    ReleaseDate = new DateTime(2022, 5, 27),
                    CompanyId = 8
                }
            };

            //users
            var users = new User[]
            {
                new User{Id = 1, Firstname = "Bart", Lastname = "Soete", Username = "bart.soete@movierating.com"},
                new User{Id = 2, Firstname = "Karel", Lastname = "Soete", Username = "karel.soete@movierating.com"},
            };
            //ratings
            var ratings = new Rating[]
            {
                new Rating{Id = 1,Score = 9,UserId = 1,MovieId = 1,Review = "Very good!!"},
                new Rating{Id = 2,Score = 8,UserId = 2,MovieId = 2, Review = "good!!"},
                new Rating{Id = 3,Score = 6,UserId = 2 ,MovieId = 1,Review = "Ok"},
                new Rating{Id = 4,Score = 5,UserId = 1,MovieId = 2,Review = "Average.."},
                new Rating{Id = 5,Score = 9,UserId = 1,MovieId = 3,Review = "Very good!!"},
                new Rating{Id = 6,Score = 8,UserId = 2,MovieId = 4, Review = "good!!"},
                new Rating{Id = 7,Score = 6,UserId = 2 ,MovieId = 3,Review = "Ok"},
                new Rating{Id = 8,Score = 5,UserId = 1,MovieId = 4,Review = "Average.."},
                new Rating{Id = 9,Score = 9,UserId = 1,MovieId = 5,Review = "Very good!!"},
                new Rating{Id = 10,Score = 8,UserId = 2,MovieId = 6, Review = "good!!"},
                new Rating{Id = 11,Score = 6,UserId = 2 ,MovieId = 3,Review = "Ok"},
                new Rating{Id = 12,Score = 5,UserId = 1,MovieId = 5,Review = "Average.."},
                new Rating{Id = 13,Score = 9,UserId = 1,MovieId = 6,Review = "Very good!!"},
                new Rating{Id = 14,Score = 8,UserId = 2,MovieId = 7, Review = "good!!"},
                new Rating{Id = 15,Score = 6,UserId = 2 ,MovieId = 8,Review = "Ok"},
                new Rating{Id = 16,Score = 5,UserId = 1,MovieId = 7,Review = "Average.."},
                new Rating{Id = 17,Score = 9,UserId = 1,MovieId = 8,Review = "Very good!!"},
                new Rating{Id = 18,Score = 8,UserId = 2,MovieId = 9, Review = "good!!"},
                new Rating{Id = 19,Score = 6,UserId = 2 ,MovieId = 10,Review = "Ok"},
                new Rating{Id = 20,Score = 5,UserId = 1,MovieId = 9,Review = "Average.."},
                new Rating{Id = 21,Score = 5,UserId = 1,MovieId = 10,Review = "Average.."},
            };
            //Actors
            var actors = new Actor[] 
            {
                new Actor{Id = 1,Firstname = "Brad", Lastname = "Pitt"},
                new Actor{Id = 2,Firstname = "Julia", Lastname = "Roberts"},
            };
            //Directors
            var directors = new Director[]
            {
                new Director{Id = 1,Firstname = "Martin", Lastname = "Scorsese"},
                new Director{Id = 2,Firstname = "Ron", Lastname = "Wood"},
            };
            //many to manys
            //ActorMovie
            var actorsMovies = new[]
            {
                new {ActorsId = 1, MoviesId = 1 },
                new {ActorsId = 1, MoviesId = 2 },
                new {ActorsId = 2, MoviesId = 1 },
                new {ActorsId = 2, MoviesId = 2 },
                new {ActorsId = 1, MoviesId = 3 },
                new {ActorsId = 1, MoviesId = 4 },
                new {ActorsId = 2, MoviesId = 3 },
                new {ActorsId = 2, MoviesId = 4 },
                new {ActorsId = 1, MoviesId = 5 },
                new {ActorsId = 1, MoviesId = 6 },
                new {ActorsId = 2, MoviesId = 5 },
                new {ActorsId = 2, MoviesId = 6 },
                new {ActorsId = 1, MoviesId = 7 },
                new {ActorsId = 1, MoviesId = 8 },
                new {ActorsId = 2, MoviesId = 7 },
                new {ActorsId = 2, MoviesId = 8 },
                new {ActorsId = 1, MoviesId = 9 },
                new {ActorsId = 1, MoviesId = 10 },
                new {ActorsId = 2, MoviesId = 9 },
                new {ActorsId = 2, MoviesId = 10 },
            };
            //DirectorMovie
            var directorsMovies = new[]
            {
                new {DirectorsId = 1, MoviesId = 1},
                new {DirectorsId = 2, MoviesId = 1},
                new {DirectorsId = 1, MoviesId = 2},
                new {DirectorsId = 2, MoviesId = 2},
            };
            //call the hasdata methods
            modelBuilder.Entity<Company>().HasData(companies);
            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Rating>().HasData(ratings);
            modelBuilder.Entity<Actor>().HasData(actors);
            modelBuilder.Entity<Director>().HasData(directors);
            modelBuilder.Entity($"{nameof(Actor)}{nameof(Movie)}").HasData(actorsMovies);
            modelBuilder.Entity($"{nameof(Director)}{nameof(Movie)}").HasData(directorsMovies);
        }
    }
}
