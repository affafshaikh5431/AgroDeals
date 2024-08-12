using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;

namespace ProjectAgroDeals.Repository.DAO
{
    public class ManageOrdersDAO : IManageOrdersDAO
    {
        private readonly ProjectDataContext _context;
        public ManageOrdersDAO()
        {
            _context = new DataContext.ProjectDataContext();
        }
        public async Task<string> GetPendingOrders()
        {
            try {

                double finalAmt = 0.0;

                
                int[] userid = await _context.Cart.Where(x => x.Status == "Pending")
                    .Select(x => x.UserID).Distinct().ToArrayAsync();
               
                List<Users> carts = await _context.Users.
                    Where(x => userid.Contains(x.UserID)).ToListAsync();




                StringBuilder sb = new StringBuilder();




                var orderNo = 1;
                sb.Append("<div class='container'>");
                foreach (var itm in carts) 
                {
                    sb.Append("<div class='row justify-content-center'>");
                   
                   
                    sb.Append("<div class='col-md-10'>");
                    sb.Append("<div class='card card-primary collapsed-card'>");
                    sb.Append("<div class='card-header'>");
                    sb.Append("<h3 class='card-title'>  Pending Order  From: &nbsp; <i class='fa-solid fa-user fa-xs'></i>&nbsp;" + itm.FullName+"</h3>") ;

                    sb.Append("<div class='card-tools'>");
                    sb.Append("<button type='button' class='btn btn-tool' data-card-widget='collapse'><i class='fas fa-plus'></i></button>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='card-body'>");

                    
                    sb.Append("<table id='table1' class='table text-center'>");
                    sb.Append("<tr>");
                    //sb.Append("<td>Customer Name</td>");
                    sb.Append("<td>Product Details</td>");
                    //sb.Append("<td>Action</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    //sb.Append("<td data-id=" + itm.UserID + ">" + itm.FullName + "</td>");
                    sb.Append("<td>");
                    
                    //load product details.

                    List<Cart> products = await _context.Cart.Include("Products")
                        .Include("Categories").Where(x => x.UserID == itm.UserID && x.Status == "Pending").ToListAsync();
                    
                    
                    StringBuilder prod = new StringBuilder();
                    prod.Append("<table class='table'>");
                    prod.Append("<tr>");
                    
                    prod.Append("<td>Product</td>");
                    prod.Append("<td>Price</td>");
                    prod.Append("<td>Quantity</td>");
                    prod.Append("<td>Amount</td>");
                    prod.Append("</tr>");
                    foreach (var p in products) 
                    {
                        
                       
                        prod.Append("<tr>");
                        prod.Append("<td>" + p.Products.ProductName + "</td>");
                        prod.Append("<td>" + p.Price.ToString() + "</td>");
                        prod.Append("<td>" + p.Qty + "</td>");
                        prod.Append("<td>" + (p.Qty * p.Price).ToString() + "</td>");
                        prod.Append("</tr>");
                        finalAmt += p.Qty * p.Price;
                        
                    }

                    prod.Append("<tr>");
                    prod.Append("<td colspan='3'></td>");
                    prod.Append("<td colspan='3'> Total Amount: " +finalAmt+" Rs/- </td>");
                    prod.Append("</tr>");
                    prod.Append("<tr>");
                    prod.Append("<td colspan='2'></td>");
                    prod.Append("<td colspan='1'>");
                    prod.Append("<button type='button' class='btn btn-success btnApprove mr-2' data-id=" + itm.UserID + "><i class='fa-regular fa-circle-check'></i>&nbsp; Approve</button>");
                    prod.Append("<button type='button' class='btn btn-danger btnReject' data-id=" + itm.UserID + "><i class='fa-regular fa-circle-xmark''></i>&nbsp; Reject</button>");
                    prod.Append("</td>");
                    prod.Append("</tr>");

                    prod.Append("</table>");

                    sb.Append(prod);
                    sb.Append("</td>");
                    //sb.Append("<td>");
                    //sb.Append("<button type='button' class='btn btn-success btnApprove mr-2' data-id=" + itm.UserID + ">Approve</button>");
                    //sb.Append("<button type='button' class='btn btn-danger btnReject' data-id=" + itm.UserID + ">Reject</button>");
                    //sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");

                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");

                }
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
