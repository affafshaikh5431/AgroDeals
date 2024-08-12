using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface IUnitDAO
    {
        Task<List<Units>> GetUnitType();
        Task<Units> GetOne(int id);

        Task<string> AddUnit(Units p);

        Task<string> UpdateUnit(Units u);
    }
}
