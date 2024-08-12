using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Repository.DAO
{
    public class UnitDAO:IUnitDAO
    {
        private readonly ProjectDataContext _context;
        public UnitDAO()
        {
            _context = new ProjectDataContext();
        }
        public async Task<List<Units>> GetUnitType()
        {
            List<Units> lst = await _context.Units.OrderBy(x => x.UnitID).ToListAsync();
            return lst;
        }
        public async Task<Units> GetOne(int id)
        {
            Units u = await _context.Units.FirstOrDefaultAsync(x => x.UnitID == id);
            return u;
        }

        public async Task<string> AddUnit(Units u)
        {
            if (_context.Units.Any(x => x.UnitType == u.UnitType)) {
                return "UnitType exists";
            }
            _context.Units.Add(u);
            await _context.SaveChangesAsync();
            return "Unit Added Successfully";

        }
        public async Task<string> UpdateUnit(Units u)
        {
            if (_context.Units.Any(x => x.UnitType.ToLower() == u.UnitType.ToLower() && x.UnitID != u.UnitID))
                {
                return "UnitType exists";
                }
            Units unit = _context.Units.Where(x => x.UnitID == u.UnitID).SingleOrDefault();
            unit.UnitType = u.UnitType;
            _context.SaveChanges();
            return "UnitType Updated Successfully";
        }
    }
}