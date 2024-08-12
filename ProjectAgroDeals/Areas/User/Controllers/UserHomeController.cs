using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;
using ProjectAgroDeals.ViewModel;

namespace ProjectAgroDeals.Areas.User.Controllers
{
    public class UserHomeController : Controller
    {

        private readonly IProductDAO _prod;
        private readonly ICategoryDAO _cat;
        public UserHomeController(IProductDAO prod,ICategoryDAO cat)
        {
            _prod = prod;
            _cat = cat;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public async Task<PartialViewResult> ShowProducts()
        {
            
            try 
            {
                List<ProductViewModel> pvm = await _prod.GetProduct();
                return PartialView("_ShowProducts",pvm);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public async Task<ActionResult> LoadCategory()
        {
            try {
                List<Categories> lst = await _cat.GetCategory();
                if (lst.Count > 0) {
                    lst.Insert(0, new Categories() {
                        CatID = -1,
                        CatName = "All"
                    });
                }
                return Json(lst);
            }
            catch (Exception ex) {
                throw ex;
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