using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Repository.DAO
{
    public class CartDAO : ICartDAO
    {
        private readonly ProjectDataContext _context;
        public CartDAO()
        {
            _context = new DataContext.ProjectDataContext();
        }

        public async Task ConfirmOrderByUser(int UserID)
        {
            try {
                List<Cart> lst = await _context.Cart.Where(x => x.UserID == UserID &&
                  x.Status == null).ToListAsync();
                for (int i = 0; i < lst.Count; i++) {
                    lst[i].Status = "Pending";
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<int> GetCartCount(int UserID)
        {
            try {


                int? sum = await _context.Cart.Where(x => x.UserID == UserID && x.Status == null)
                    .SumAsync(x => (int?)x.Qty);
                if (sum == null) {
                    return 0;
                }
                return sum.Value;
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<List<Cart>> GetCartDetails(int UserID)
        {
            try {
                List<Cart> lst = await _context.Cart.Include("Products")
                    .Include("Categories")
                    .Where(x => x.UserID == UserID)
                    .OrderBy(x => x.Dated)
                    .ToListAsync();
                return lst;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task AddToCart(Cart cart)
        {
            try
            {
                
                    Cart existCart = await _context.Cart.Where(x => x.UserID == cart.UserID &&
                    x.ProductID == cart.ProductID && x.CatID == cart.CatID && x.Status == null).FirstOrDefaultAsync();
                    if (existCart == null) 
                    {
                        //insert
                        _context.Cart.Add(cart);
                    }
                    else
                    {
                        //update
                        existCart.Qty += cart.Qty;
                    }
                    await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}