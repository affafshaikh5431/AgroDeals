using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ProjectAgroDeals.Filters
{
    public class AdminLoginAuthenticationFilter:ActionFilterAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            string RoleID = HttpContext.Current.Session["RoleID"].ToString();
            if (!string.IsNullOrEmpty(filterContext.HttpContext.Session["UserID"].ToString())) {
                if (RoleID != "1") {
                    filterContext.Result = new HttpUnauthorizedResult();

                }
            }
            else {
                filterContext.Result = new HttpUnauthorizedResult();

            }

        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult) {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"area","" },
                    {"controller","Account"},
                    {"action","Login" }
                });
            }
        }
    }
}
