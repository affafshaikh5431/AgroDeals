using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDAO _cat;
        public CategoryController(ICategoryDAO cat)
        {
            _cat = cat;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _cat.GetCategory());
        }
    }
}