using Cu_ServicePattern_Movies.Core.Entities;
using Cu_ServicePattern_Movies.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cu_ServicePattern_Movies.Core.Services.Interfaces
{
    public interface IMovieService
    {
        Task<ResultModel<Movie>> GetbyIdAsync(int id);
        Task<ResultModel<IEnumerable<Movie>>> GetAllAsync();
        Task<ResultModel<Movie>> CreateAsync(string title, DateTime releaseDate, decimal price, int companyId, string image,
            IEnumerable<int> actorIds, IEnumerable<int> directorIds);
        Task<ResultModel<Movie>> UpdateAsync(int id,DateTime releaseDate ,string title, decimal price, int companyId, string image,
            IEnumerable<int> actorIds, IEnumerable<int> directorIds);
        Task<bool> DeleteAsync(int id);
        IQueryable<Movie> GetAll();
        Task<bool> SaveChangesAsync();
    }
}
