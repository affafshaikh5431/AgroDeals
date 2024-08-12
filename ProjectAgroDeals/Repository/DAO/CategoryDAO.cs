using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Repository.DAO
{
    public class CategoryDAO:ICategoryDAO
    {
        private readonly ProjectDataContext _context;
        public CategoryDAO()
        {   
            _context = new ProjectDataContext();
        }
        public async Task<List<Categories>> GetCategory()
        {
            List<Categories> lst = await _context.Categories.OrderBy(x => x.CatID).ToListAsync();
            return lst;
        }
        public string SaveCategory(Categories cat)
        {
            throw new NotImplementedException();

        }
    }
}