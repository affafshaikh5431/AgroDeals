using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Areas.Farmer.Controllers
{
    public class FarmerHomeController : Controller
    {

       
        private readonly ICountDAO _count;
        public FarmerHomeController(ICountDAO count)
        {
            _count = count;

        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ShowMessage()
        {
            List<Message> msg = await _count.getMessage();
            return PartialView("_ShowMessage", msg);
        }
        public ActionResult Logout()
        {
            Session["UserID"] = "";
            Session["RoleID"] = "";
            Session["FullName"] = "";
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}