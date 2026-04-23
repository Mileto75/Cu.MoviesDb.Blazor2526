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
    public interface ICompanyService
    {
        Task<ResultModel<Company>> GetbyIdAsync(int id);
        Task<ResultModel<IEnumerable<Company>>> GetAllAsync();
        Task<bool> CreateAsync(string name);
        Task<bool> UpdateAsync(int id, string name);
        Task<bool> DeleteAsync(int id);
        IQueryable<Company> GetAll();
        Task<bool> SaveChangesAsync();
    }
}
