using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingTipToiz.Logic;

namespace WingTipToiz
{
    public partial class AddToCart : System.Web.UI.Page //sto  se ovako sivi deo koda? 

    //navodno "Gray block: The portion of the file that's currently being displayed"
    //https://visualstudiomagazine.com/Blogs/Tool-Tracker/2018/04/What-the-Colors-Mean.aspx

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");//ovde puca?
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");//ovde puca ako kliknem ono ignore
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}