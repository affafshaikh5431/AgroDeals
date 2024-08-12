using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAgroDeals.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }


        public int UserID { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(80, ErrorMessage = "Max 80 Characters Allowed!")]
        [Required(ErrorMessage = "Product Name is Required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [StringLength(80, ErrorMessage = "Max 100 Characters Allowed!")]
        [Required(ErrorMessage = "Product Description is Required!")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }


        public string ProductPicture { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Set Price to the Product!")]
        public double Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Select Category of Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        public int CatID { get; set; }

        [ForeignKey("CatID")]
        public virtual Categories Categories { get; set; }


        [Display(Name = "Unit")]
        [Required(ErrorMessage = "Select Unit of Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Unit")]
        public int UnitID { get; set; }

        [ForeignKey("UnitID")]
        public virtual Units Units { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

    }
}