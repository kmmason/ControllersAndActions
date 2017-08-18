using System;
using System.Web.Mvc;

namespace ControllerAandActions.Controllers
{
    public class DerivedController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult RenameProduct()
        {
            //Access various properties from context objects
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime dateStamp = HttpContext.Timestamp;

            AuditRequest(userName, serverName, clientIP, dateStamp, "Renaming Product");

            //Retrieve posted data from Request.Form
            string oldProductName = Request.Form["OldName"];
            string newProductName = Request.Form["NewName"];

            bool result = AttemptProductRename(oldProductName, newProductName);
            ViewData["RenameResult"] = result;
            return View("ProductRenamed");
        }
    }
}