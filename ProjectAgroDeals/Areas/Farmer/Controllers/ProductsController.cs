using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;
using ProjectAgroDeals.ViewModel;

namespace ProjectAgroDeals.Areas.Farmer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductDAO _prod;
        public ProductsController(IProductDAO prod)
        {
            _prod = prod;
        }

        public ActionResult ViewProducts()
        {
          return View();
        }

        public async Task<PartialViewResult> GetProductsList()
        {
            try {
                string fid = Session["UserID"].ToString();
                List<ProductViewModel> lst = await _prod.GetProduct(fid);
                return PartialView("_GetProductsList", lst);
            }
            catch(Exception ex) {
                throw ex;
            }

        }
        

        public async Task<ActionResult> AddProducts()
        {
            List<Categories> clst=await _prod.GetCategory();
            ViewBag.Cat = clst;

            List<Units> ulst=await _prod.GetUnitType();
            ViewBag.Unit=ulst;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddProducts(Products p, HttpPostedFileBase file1)
        {
            string Fid = @Session["UserID"].ToString();
            p.UserID = int.Parse(Fid);
            try 
            {
                List<Categories> clst = await _prod.GetCategory();
                ViewBag.Cat = clst ?? new List<Categories>();

                List<Units> ulst = await _prod.GetUnitType();
                ViewBag.Unit = ulst ?? new List<Units>();
                if (ModelState.IsValid) {
                    if(await _prod.IsProductNameExists(Fid,p))
                    {
                        TempData["Msg"] = "Product Already Exist";
                        return View();
                    }

                    if (file1 == null)
                    {
                        TempData["Msg"] = "Select image to upload";
                        return View();
                    }

                    string filename = Path.GetFileName(file1.FileName);
                    string strPath = Server.MapPath("~/Files/");
                    strPath = Path.Combine(strPath, file1.FileName);
                    file1.SaveAs(strPath);
                    p.ProductPicture = "../Files/" + filename;
                    await _prod.AddProduct(p);

                    TempData["Msg"] = "Product Added Successfully!";
                    return RedirectToAction("AddProducts","Products");
                }
                return View();
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try {


                List<Categories> clst = await _prod.GetCategory();
                ViewBag.Cat = clst;

                List<Units> ulst = await _prod.GetUnitType();
                ViewBag.Unit = ulst;
                Products p = await _prod.GetOneProduct(id);
                return View(p);
            }

            catch(Exception ex) {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Products p, HttpPostedFileBase file1)
        {
            try 
            {
                List<Categories> clst = await _prod.GetCategory();
                ViewBag.Cat = clst;

                List<Units> ulst = await _prod.GetUnitType();
                ViewBag.Unit = ulst;
                if (ModelState.IsValid) {

                    string serverPath = Server.MapPath("~/Files/");
                    var c = await _prod.UpdateProduct(p, file1, serverPath);
                    if (c == "Product exists") 
                    {
                        TempData["Msg"] = "Product name already exists.";
                        return View(p);
                    }
                    if (c == "Pic Save") {
                        TempData["Msg"] = "Product Updated successfully";
                     
                    }
                    else {
                        TempData["Msg"] = "Product Failed updated";
                        return View(p);
                    }
                }
                return RedirectToAction("ViewProducts");
            }
            catch(Exception ex) {
                throw ex;
            }
        }

    }
}