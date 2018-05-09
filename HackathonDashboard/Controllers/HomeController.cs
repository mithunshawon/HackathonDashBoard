using HackathonDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Policy;
using System.DirectoryServices.AccountManagement;
using System.Data.Entity.Infrastructure;

namespace HackathonDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();

            //using (var context = new HackathonDashboardContext())
            //{

            //    var index = 6;
            //    using (var ctx = new PrincipalContext(ContextType.Domain, "INTERNAL"))
            //    {
            //        using (var PSearcher = new PrincipalSearcher(new UserPrincipal(ctx)))
            //        {
            //            foreach (var account in PSearcher.FindAll())
            //            {
            //                if (!String.IsNullOrEmpty(Convert.ToString(account.UserPrincipalName)) && Convert.ToString(account.UserPrincipalName).Contains("bd.imshealth.com") && !Convert.ToString(account.UserPrincipalName).StartsWith("DACA") && !Convert.ToString(account.UserPrincipalName).Contains("ConfRoom"))
            //                {
            //                    string Name = Convert.ToString(account.DisplayName);
            //                    string SAMAccountName = Convert.ToString(account.SamAccountName);
            //                    string EmailAddress = Convert.ToString(account.UserPrincipalName);

            //                    context.Members.Add(new Member() { MemberId = "M" + (index++), MemberName = Name, MemberEmail = EmailAddress });
            //                }
            //            }
            //        }
            //    }
            //    try
            //    {
            //        System.Diagnostics.Debug.WriteLine(index);
            //        context.SaveChanges();
            //    }
            //    catch (DbUpdateException e)
            //    {
            //        System.Diagnostics.Debug.WriteLine(e);
            //    }

            //}
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}