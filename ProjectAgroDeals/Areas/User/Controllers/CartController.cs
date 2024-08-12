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
    public class CartController : Controller
    {
        private readonly ICartDAO _cartDAO;
        private readonly IProductDAO _prod;
        public CartController(ICartDAO cartDAO, IProductDAO prod)
        {
            _cartDAO = cartDAO;
            _prod = prod;
        }


        public async Task<ActionResult> AddToCart(Cart mcart)
        {
            try {
                mcart.UserID = Convert.ToInt32(Session["UserID"].ToString());
                mcart.Dated = DateTime.Now;
                await _cartDAO.AddToCart(mcart);
                return Json("success");
            }
            catch (Exception ex) {
                throw ex;
            }
        }



        public async Task<PartialViewResult> GetCartCount()
        {
            try {

                int UserID = 0;
                if(!string.IsNullOrEmpty(Session["UserID"].ToString()))
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                int count = await _cartDAO.GetCartCount(UserID);
                return PartialView("_GetCartCount", count);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<PartialViewResult> GetCart()
        {
            try {

                int UserID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"].ToString()))
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                List<Cart> lst = await _cartDAO
                    .GetCartDetails(UserID);
                return PartialView("_GetCart", lst);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult GetCartList()
        {
            return View();
        }

        public async Task<ActionResult> ProductDetails(int? id)
        {
            try {
                if (id == null) {
                    return HttpNotFound();
                }
                ProductViewModel pvm = await _prod.GetProductByID(id.Value);
                return View(pvm);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<ActionResult> ConfirmOrder()
        {
            try {
                int UserID = Convert.ToInt32(Session["UserID"].ToString());
                await _cartDAO.ConfirmOrderByUser(UserID);
                return Json("success");
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}