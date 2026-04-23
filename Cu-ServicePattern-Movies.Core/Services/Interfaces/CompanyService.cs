using Cu_ServicePattern_Movies.Core.Data;
using Cu_ServicePattern_Movies.Core.Entities;
using Cu_ServicePattern_Movies.Core.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cu_ServicePattern_Movies.Core.Services.Interfaces
{
    public class CompanyService : ICompanyService
    {
        //also refactor this to use Factory pattern
        private readonly MovieDbContext _movieDbContext;

        public CompanyService(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<bool> CreateAsync(string name)
        {
            if (await _movieDbContext.Companies.AnyAsync(c => c.Name.Equals(name)))
            {
                return false;
            }
            var company = new Company { Name = name };
            _movieDbContext.Companies.Add(company);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await GetbyIdAsync(id);
            if(result.IsSuccess)
            {
                _movieDbContext.Companies.Remove(result.Data);
                await SaveChangesAsync();
            }
            return result.IsSuccess;
        }

        public IQueryable<Company> GetAll()
        {
            return _movieDbContext.Companies.AsQueryable();
        }

        public async Task<ResultModel<IEnumerable<Company>>> GetAllAsync()
        {
            var companies = await _movieDbContext.Companies.ToListAsync();
            return new ResultModel<IEnumerable<Company>> 
            {
                IsSuccess = true,
                Data = companies
            };
        }

        public async Task<ResultModel<Company>> GetbyIdAsync(int id)
        {
            var company = await _movieDbContext.Companies.FindAsync(id);
            if(company is null)
            {
                return new ResultModel<Company>
                {
                    IsSuccess = false,
                    Errors = new List<string>{ "Company not found!" }
                };
            }
            return new ResultModel<Company> 
            {
                IsSuccess = true,
                Data = company
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

        public async Task<bool> UpdateAsync(int id, string name)
        {
            var result = await GetbyIdAsync(id);
            if(result.IsSuccess)
            {
                result.Data.Name = name;
                await SaveChangesAsync();
            }
            return result.IsSuccess;
        }
    }
}
