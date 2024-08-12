using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface ICountDAO
    {
        Task<int> AllUsers();
        

        Task<string> GetFarmer();
        Task<string> GetUser();

        Task<string> AllProducts();
        Task<int> AllCategories();

        Task<string> SaveMessage(string msg);
        Task<List<Message>> getMessage();
    }
}
