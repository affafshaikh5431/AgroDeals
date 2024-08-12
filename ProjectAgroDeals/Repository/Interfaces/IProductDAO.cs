using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.ViewModel;

namespace ProjectAgroDeals.Repository.Interfaces
{
    public interface IProductDAO
    {
        Task<List<Categories>> GetCategory();
        Task<List<Units>> GetUnitType();

        Task<bool> IsProductNameExists(string Fid,Products pName);


        Task<string> UpdateProduct(Products p, HttpPostedFileBase file1, string strPath);
        
        Task AddProduct(Products p);

        Task<List<ProductViewModel>> GetProduct(string fid);

        Task<List<ProductViewModel>> GetProduct();

        Task<ProductViewModel> GetProductByID(int id);


        Task<List<Products>> ViewAllProducts();
        Task<Products> GetOneProduct(int id);
    }
}
