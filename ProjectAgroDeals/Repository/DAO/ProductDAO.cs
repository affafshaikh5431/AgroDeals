using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectAgroDeals.DataContext;
using ProjectAgroDeals.Models;
using ProjectAgroDeals.Repository.Interfaces;
using ProjectAgroDeals.ViewModel;

namespace ProjectAgroDeals.Repository.DAO
{
    public class ProductDAO : IProductDAO
    {
        private readonly ProjectDataContext _context;
        public ProductDAO()
        {
            _context = new ProjectDataContext();
        }


        public async Task<List<Products>> ViewAllProducts()
        {
            List<Products> lst = await _context.Products
                .OrderBy(x => x.ProductID).Include("Users").ToListAsync();

            return lst;
        }


        public async Task<List<Categories>> GetCategory()
        {
            List<Categories> lst = await _context.Categories.OrderBy(x => x.CatID).ToListAsync();
            if (lst.Count > 0) {
                lst.Insert(0, new Categories() {
                    CatID = -1,
                    CatName = "--Select Category--"
                });
            }
            return lst;
        }

        public async Task<List<Units>> GetUnitType()
        {
            List<Units> lst = await _context.Units.OrderBy(x => x.UnitID).ToListAsync();
            if (lst.Count > 0) {
                lst.Insert(0, new Units() {
                    UnitID = -1,
                    UnitType = "--Select Size--"
                });
            }
            return lst;
        }

        public async Task<bool> IsProductNameExists(string Fid, Products pName)
        {
            return await _context.Products.AnyAsync(x => x.UserID.ToString() == Fid && x.ProductName.ToLower() == pName.ProductName.ToLower());
        }


        public async Task AddProduct(Products p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetProduct(string fid)
        {
            try {
                List<ProductViewModel> lst = await _context.Products.Where(x => x.UserID.ToString() == fid)
                        .Select(x => new ProductViewModel() {

                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            ProductDescription = x.ProductDescription,
                            ProductPicture = x.ProductPicture,
                            Price = x.Price,
                            CatName = x.Categories.CatName,
                            UnitType = x.Units.UnitType,

                        }).ToListAsync();
                return lst;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<ProductViewModel>> GetProduct()
        {
            try {
                List<ProductViewModel> lst = await _context.Products.Include("Categories").
                    OrderBy(x => x.Categories.CatName).Select(x => new ProductViewModel() {

                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            ProductDescription = x.ProductDescription,
                            ProductPicture = x.ProductPicture,
                            Price = x.Price,
                            CatName = x.Categories.CatName,
                            UnitType = x.Units.UnitType,

                        }).ToListAsync();
                return lst;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<Products> GetOneProduct(int id)
        {
            Products p = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            return p;
        }


        public async Task<string> UpdateProduct(Products p, HttpPostedFileBase file1, string strPath)
        {
            if (_context.Products.Any(x => x.ProductName.ToLower() == p.ProductName.ToLower() && x.ProductID != p.ProductID)) {
                return "Product exists";

            }
            Products prod = _context.Products.Where(x => x.ProductID == p.ProductID).SingleOrDefault();
            if (file1 == null) {
                prod.ProductName = p.ProductName;
                prod.ProductPicture = p.ProductPicture;
                prod.CatID = p.CatID;
                prod.ProductDescription = p.ProductDescription;
                prod.Price = p.Price;
                prod.UnitID = p.UnitID;

                _context.SaveChanges();
                return "Pic Save";
            }

            prod.ProductName = p.ProductName;
            prod.CatID = p.CatID;
            prod.ProductDescription = p.ProductDescription;
            prod.Price = p.Price;
            prod.UnitID = p.UnitID;

            string fileName = Path.GetFileName(file1.FileName);
            string filePath = Path.Combine(strPath, fileName);
            file1.SaveAs(filePath);
            p.ProductPicture = "../Files/" + fileName;
            prod.ProductPicture = p.ProductPicture;
            _context.SaveChanges();
            return "Pic Save";
        }
        public async Task<ProductViewModel> GetProductByID(int id)
        {
            try {
                ProductViewModel pvm = await _context.Products.
                    Include("Categories").
                    Where(x => x.ProductID == id).
                    Select(x => new ProductViewModel()
                    {
                    
                        ProductDescription=x.ProductDescription,
                        CatName = x.Categories.CatName,
                        ProductPicture = x.ProductPicture,
                        Price = x.Price,
                        CatID=x.CatID,
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        UnitType=x.Units.UnitType
                        
                    }).FirstOrDefaultAsync();
                return pvm;
            }
            catch (Exception ex) {
                throw ex;
            }
        }



    }
}
