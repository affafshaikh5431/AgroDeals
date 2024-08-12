using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Areas.Admin.Controllers
{
    public class ManageOrdersController : Controller
    {
        private readonly IManageOrdersDAO _manageOrder;
        public ManageOrdersController(IManageOrdersDAO manageOrder)
        {
            _manageOrder = manageOrder;
        }
        // GET: ManageOrders
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetPendingOrders()
        {
            try {
                string str = await _manageOrder.GetPendingOrders();
                return Json(str);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}