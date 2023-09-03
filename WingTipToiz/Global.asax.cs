using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WingTipToiz.Models;
using WingTipToiz.Logic;

namespace WingTipToiz
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Initialize the product database.
            Database.SetInitializer(new ProductDatabaseInitializer());


            // Create the custom role and user.
            //RoleActions roleActions = new RoleActions();
            //roleActions.AddUserAndRole();


            // Add Routes.      //po https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing#mapping-and-registering-routes
            //RegisterCustomRoutes(RouteTable.Routes);
        }

        //void RegisterCustomRoutes(RouteCollection routes)
        //{
        //    routes.MapPageRoute(
        //        "ProductsByCategoryRoute",
        //        "Category/{categoryName}",
        //        "~/ProductList.aspx"
        //    );
        //    routes.MapPageRoute(
        //        "ProductByNameRoute",
        //        "Product/{productName}",
        //        "~/ProductDetails.aspx"
        //    );
        //}
       // RouteActions Routes = RouteActions.RegisterCustomRoutes(RouteCollection routes);
        //    RouteActions Routes = RegisterCustomRoutes(RouteCollection routes);
        //kako to najbolje ako ne ovako? https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing#mapping-and-registering-routes
        //mi fali mozda konstruktor neki posebni pa onda ovo da radim?

    }

}