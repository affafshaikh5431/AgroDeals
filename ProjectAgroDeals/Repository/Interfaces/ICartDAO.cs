using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface ICartDAO
    {
        Task<List<Cart>> GetCartDetails(int UserID);
        Task<int> GetCartCount(int UserID);
        Task AddToCart(Cart cart);
        Task ConfirmOrderByUser(int UserID);
    }
}
