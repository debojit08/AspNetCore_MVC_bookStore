using BookStore_App.Data;
using BookStore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class languageRepo
    {
        private readonly BookStoreContext _context = null;
        public languageRepo(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<languageModel>> GetLanguage()
        {
           return await _context.language.Select(x=> new languageModel()
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description

            }).ToListAsync();
        }
    }
}
