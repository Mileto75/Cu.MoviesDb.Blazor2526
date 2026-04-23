using Cu_ServicePattern_Movies.Core.Data;
using Cu_ServicePattern_Movies.Core.Entities;
using Cu_ServicePattern_Movies.Core.Interfaces;
using Cu_ServicePattern_Movies.Core.Services.Interfaces;
using Cu_ServicePattern_Movies.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cu_ServicePattern_Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly IFileService _fileService;

        public MovieService(MovieDbContext movieDbContext, IFileService fileService)
        {
            _movieDbContext = movieDbContext;
            _fileService = fileService;
        }

        public async Task<ResultModel<Movie>> CreateAsync(string title,DateTime releaseDate, 
            decimal price, int companyId, string image, IEnumerable<int> actorIds, 
            IEnumerable<int> directorIds)
        {
            //create the movie
            var movie = new Movie();
            movie.Title = title;
            movie.Price = price;
            movie.ReleaseDate = releaseDate;
            movie.CompanyId = companyId;
            //actors
            movie.Actors = await _movieDbContext
                .Actors
                .Where(m => actorIds.Contains(m.Id)).ToListAsync();
            //Directors
            movie.Directors = await _movieDbContext
                .Directors
                .Where(d => directorIds.Contains(d.Id)).ToListAsync();
            //image
            if (image != null)
            {
                movie.Image = image;
            }
            //add to context
            _movieDbContext.Movies.Add(movie);
            //savechanges
            if(await SaveChangesAsync())
            {
                return new ResultModel<Movie>
                {
                    IsSuccess = true,
                    Data = movie
                };
            }
            return new ResultModel<Movie> { IsSuccess = false };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await GetbyIdAsync(id);
            if(movie.IsSuccess)
            {
                //delete the movie image
                if (!String.IsNullOrEmpty(movie.Data.Image))
                {
                    _fileService.Delete(movie.Data.Image);
                }
                _movieDbContext.Movies.Remove(movie.Data);
                //savechanges
                return await SaveChangesAsync();
            }
            return false;
        }

        public IQueryable<Movie> GetAll()
        {
            return _movieDbContext.Movies.AsQueryable();
        }

        public async Task<ResultModel<IEnumerable<Movie>>> GetAllAsync()
        {
            var movies = await _movieDbContext.Movies
                .Include(m => m.Company)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .Include(m => m.Ratings)
                .AsSplitQuery()
                .ToListAsync();
            return new ResultModel<IEnumerable<Movie>>
            {
                IsSuccess = true,
                Data = movies
            };
        }

        public async Task<ResultModel<Movie>> GetbyIdAsync(int id)
        {
            var movie = await _movieDbContext.Movies
               .Include(m => m.Company)
               .Include(m => m.Actors)
               .Include(m => m.Directors)
               .Include(m => m.Ratings)
               .FirstOrDefaultAsync(m => m.Id == id);
            if(movie is null)
            {
                return new ResultModel<Movie> 
                {
                    IsSuccess = false,
                    Errors = new List<string>{ "Movie not found!"}
                };
            }
            return new ResultModel<Movie>
            {
                IsSuccess = true,
                Data = movie
            };
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _movieDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
                return false;
            }
        }

        public async Task<ResultModel<Movie>> UpdateAsync(int id,DateTime releasedate, string title, decimal price, int companyId, string image, IEnumerable<int> actorIds, IEnumerable<int> directorIds)
        {
            //update
            var result = await GetbyIdAsync(id);
            if (!result.IsSuccess)
            {
                return new ResultModel<Movie> { IsSuccess = false };
            }
            var movie = result.Data;
            //edit the properties
            movie.Title = title;
            movie.ReleaseDate = releasedate;
            movie.CompanyId = companyId;
            movie.Price = price;
            //actors
            movie.Actors.Clear();
            movie.Actors = await _movieDbContext
                .Actors
                .Where(m => actorIds.Contains(m.Id)).ToListAsync();
            //Directors
            movie.Directors.Clear();
            //get the list of the selected directors
            movie.Directors = await _movieDbContext
                .Directors
                .Where(d => directorIds.Contains(d.Id)).ToListAsync();
            //image
            if (image != null)
            {
                if (movie.Image != null)
                {
                    movie.Image = image;
                }
                else
                {
                    movie.Image = image;
                }

            }
            //savechanges
            if(await SaveChangesAsync())
            {
                return new ResultModel<Movie>
                {
                    IsSuccess = true,
                    Data = movie
                };
            }
            return new ResultModel<Movie> { IsSuccess = false };
        }
    }
}
