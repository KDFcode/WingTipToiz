using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipToiz.Models;
using System.Web.ModelBinding;
using System.Web.Routing;


namespace WingTipToiz
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WingTipToiz.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }


        //ovo gore zamenimo s ovime po https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing#enable-routes-for-categories-and-products 
        //konkretno sam kraj 'enable routes for categories and products' a pre 'add code for product details'
        //public IQueryable<Product> GetProducts(
        //  [QueryString("id")] int? categoryId,
        //  [RouteData] string categoryName)
        //{
        //    var _db = new WingTipToiz.Models.ProductContext();
        //    IQueryable<Product> query = _db.Products;

        //    if (categoryId.HasValue && categoryId > 0)
        //    {
        //        query = query.Where(p => p.CategoryID == categoryId);
        //    }

        //    if (!String.IsNullOrEmpty(categoryName))
        //    {
        //        query = query.Where(p =>
        //            String.Compare(p.Category.CategoryName,
        //            categoryName) == 0);
        //    }
        //    return query;
        //}
    }
}