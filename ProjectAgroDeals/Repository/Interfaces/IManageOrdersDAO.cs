using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface IManageOrdersDAO
    {
        Task<string> GetPendingOrders();
    }
}
