using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Repository.Interfaces;
using System.Data.Entity;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.Repository.DAO
{
    public class CountDAO:ICountDAO
    {
        private readonly ProjectDataContext _context;
        public CountDAO()
        {
            _context = new ProjectDataContext();
        }

        public async Task<int> AllUsers()
        {
             
            return await _context.Users.CountAsync(); 
        }
        public async Task<int> AllCategories()
        {
            return await _context.Categories.CountAsync();

        }
        public async Task<string> GetFarmer()
        {
            int roleIdToCompare = 2;
           int count=await _context.Users.CountAsync(x => x.RoleID == roleIdToCompare);
            if (count == 0) {
                return "0";
            }
            return count.ToString();
        }
        public async Task<string> GetUser()
        {
            int roleIdToCompare = 3;
            int count = await _context.Users.CountAsync(x => x.RoleID == roleIdToCompare);
            if(count==0)
            {
                return "0";
            }
            return count.ToString();
        }
        public async Task<string> AllProducts()
        {
            int count= await _context.Products.CountAsync();
            if(count==0) {
                return "0";
            }
            return count.ToString();
        }
        public async Task<string> SaveMessage(string message)
        {
            try {
                Message msg = new Message {
                    Dated = DateTime.Today,
                    MessageBody = message
                };

                _context.Message.Add(msg);
                await _context.SaveChangesAsync();

                return "Message Sent to All Farmers";
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<List<Message>> getMessage()
        {
             List<Message> msg = await _context.Message.OrderByDescending(m => m.Dated)
                .Take(3).ToListAsync();

            return msg;
        }

    }
}