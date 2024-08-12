using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectAgroDeals.Models;
using System.Threading.Tasks;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface ICategoryDAO
    {
        Task<List<Categories>> GetCategory();
        string SaveCategory(Categories cat);
    }
}