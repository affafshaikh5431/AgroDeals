using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAgroDeals.Controllers
{
    public class AccountController : Controller
    {
        private ProjectDataContext _context;
        public AccountController()
        {
            _context = new ProjectDataContext();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
         
            try {
                if (ModelState.IsValid) {
                    Users user = _context.Users.Where(x => x.Email == lvm.Email).FirstOrDefault();
                    if (user == null) {
                        TempData["Msg"] = "Invalid Username. Please Try Again!";
                        return View();
                    }
                    if (user.Password != lvm.Password) {
                        TempData["Msg"] = "Invalid Password. Please Try Again!";
                        return View();
                    }
                    Session["UserID"] = user.UserID.ToString();
                    Session["RoleID"] = user.RoleID.ToString();
                    Session["FullName"] = user.FullName.ToString();

                    if (user.RoleID == 1) {
                        return RedirectToAction("Index", "AdminHome", new { @area = "Admin" });
                    }
                    if (user.RoleID == 2) {
                        return RedirectToAction("Index", "FarmerHome", new { @area = "Farmer" });
                    }
                    if (user.RoleID == 3) {
                        return RedirectToAction("Index", "UserHome", new { @area = "User" });
                    }


                }
            }
            catch(Exception ex) {
                throw ex;
            }
            return View();
        }
        private void LoadRoles()
        {
            try {
                List<Roles> lst = _context.Roles.Where(x => x.RoleName != "Admin").OrderBy(x => x.RoleID).ToList();
                if (lst.Count > 0) {
                    lst.Insert(0, new Roles() {
                        RoleID = -1,
                        RoleName = "--Select Role--"
                    });
                }
                ViewBag.Des = lst;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public ActionResult Register()
        {
            LoadRoles();
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users u)
        {
            try {
                LoadRoles();
                if (ModelState.IsValid) {
                    if (_context.Users.Any(x => x.Email == u.Email) && _context.Users.Any(x => x.RoleID == u.RoleID)) {
                        TempData["Msg"] = "User already Exists";
                        return View();
                    }
                    _context.Users.Add(u);
                    _context.SaveChanges();
                    TempData["Msg"] = "User saved successfully! ";
                    return RedirectToAction("Login", "Account");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}