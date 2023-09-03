using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipToiz.Models;
using System.Web.ModelBinding;


namespace WingTipToiz
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new WingTipToiz.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }


        //po https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing#add-code-for-product-details
        //public IQueryable<Product> GetProduct(
        //[QueryString("ProductID")] int? productId,
        //[RouteData] string productName)
        //{
        //    var _db = new WingTipToiz.Models.ProductContext();
        //    IQueryable<Product> query = _db.Products;
        //    if (productId.HasValue && productId > 0)
        //    {
        //        query = query.Where(p => p.ProductID == productId);
        //    }
        //    else if (!String.IsNullOrEmpty(productName))
        //    {
        //        query = query.Where(p =>
        //              String.Compare(p.ProductName, productName) == 0);
        //    }
        //    else
        //    {
        //        query = null;
        //    }
        //    return query;
        //}
    }
}