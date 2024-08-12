using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Filters;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Areas.Admin.Controllers
{
   
    public class AdminHomeController : Controller
    {
        
        private readonly IProductDAO _prod;
        private readonly ICountDAO _count;
        public AdminHomeController(IProductDAO prod,ICountDAO count)
        {
            _prod= prod;
            _count = count;

        }
        [AdminLoginAuthenticationFilter]
        public ActionResult Index()
        {
           
            return View();
        }

        public async Task<JsonResult> CountAllUsers()
        {
            return Json(await _count.AllUsers(), JsonRequestBehavior.AllowGet);
            
        }
        public async Task<JsonResult> CountAllCategories()
        {
            return Json(await _count.AllCategories(), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> CountFarmer()
        {
            return Json(await _count.GetFarmer(), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> CountUser()
        {
            return Json(await _count.GetUser(), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> CountProducts()
        {
            return Json(await _count.AllProducts(), JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ViewAllProducts()
        {

            return View(await _prod.ViewAllProducts());
        }

        public async Task<JsonResult> SendMessage(string message)
        {
            try {

                if(!string.IsNullOrEmpty(message)) 
                {

                    string result = await _count.SaveMessage(message);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return Json("Message can't be empty!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json("Error sending message: " + ex.Message, JsonRequestBehavior.AllowGet);
            }
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