using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Areas.Admin.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitDAO _unit;
        public UnitController(IUnitDAO unit)
        {
            _unit = unit;
        }
        public async Task<ActionResult> Index()
        {
            
            return View(await _unit.GetUnitType());
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<JsonResult> Add(Units u)
        {
            try
            {
                var c = await _unit.AddUnit(u);
                if (c== "UnitType exists") {
                    return Json(c, JsonRequestBehavior.AllowGet);
                }
                if (c == "Unit Added Successfully") {
                    return Json(c, JsonRequestBehavior.AllowGet);

                }
                else {
                    return Json("Failed to Add Unit!!");
                }
                return Json("UnitType Added Successfully!", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex) 
            {
                throw ex;
                return Json("An error occurred while processing your request.", JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.GetOne(id));
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Units u)
        {
            try 
            {
                var c = await _unit.UpdateUnit(u);
                if (c == "exists") 
                {
                    TempData["Msg"] = "UnitType already exists.";
                    return View(u);
                }
                if (c == "UnitType Updated Successfully") {
                    TempData["Msg"] = "UnitType Updated Successfully";
                    

                }
                else {
                    TempData["Msg"] = "UnitType Failed to updated";
                    return View(u);
                }
                return View();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}