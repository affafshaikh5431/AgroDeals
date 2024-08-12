using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Filters;
using ProjectAgroDeals.Models;

namespace ProjectAgroDeals.Areas.User.Controllers
{
    public class OrderController : Controller
    {

        private readonly ProjectDataContext _context;
        public OrderController()
        {
            _context = new ProjectDataContext();
        }
        [UserLoginAuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AcceptedOrder()
        {
            int uid = Convert.ToInt32(Session["UserID"].ToString());
            List<Cart> carts = await _context.Cart.Where(x => x.UserID == uid  && x.Status=="Approved").ToListAsync();
            return View(carts);

        }
        public async Task<ActionResult> PendingOrder()
        {
            int uid = Convert.ToInt32(Session["UserID"].ToString());
            List<Cart> carts = await _context.Cart.Where(x => x.UserID == uid && x.Status == "Pending").ToListAsync();
            return View(carts);
        }
        public async Task<ActionResult> RejectOrder()
        {
            int uid = Convert.ToInt32(Session["UserID"].ToString());
            List<Cart> carts = await _context.Cart.Where(x => x.UserID == uid && x.Status == "Reject").ToListAsync();
            return View(carts);
        }
    }
}