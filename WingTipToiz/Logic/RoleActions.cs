using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingTipToiz.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using Antlr.Runtime.Misc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace WingTipToiz.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {

            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("canEdit"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "canEdit" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "canEditUser@wingtiptoys.com",
                Email = "canEditUser@wingtiptoys.com"
            };
             IdUserResult = userMgr.Create(appUser, ConfigurationManager.AppSettings["AppUserPasswordKey"]);  //OVDE PUCA //kako je bilo sta ovde nula?
             //System.ArgumentNullException
             //HResult = 0x80004003
             //Message = Value cannot be null.
             //Parameter name: password
             //Source = Microsoft.AspNet.Identity.Core
             //StackTrace:
             //   at Microsoft.AspNet.Identity.UserManager`2.< CreateAsync > d__79.MoveNext()
             //   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
             //   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
             //   at Microsoft.AspNet.Identity.AsyncHelper.RunSync[TResult](Func`1 func)
             //   at WingTipToiz.Logic.RoleActions.AddUserAndRole() in C: \Users\aristic\source\repos\WingTipToiz - Copy - shopping cart ispravka\WingTipToiz\Logic\RoleActions.cs:line 46
             //   at WingTipToiz.Global.Application_Start(Object sender, EventArgs e) in C: \Users\aristic\source\repos\WingTipToiz - Copy - shopping cart ispravka\WingTipToiz\Global.asax.cs:line 32












            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit");
            }
        }
    }
}