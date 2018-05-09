using System.Web;
using System.Web.Optimization;

namespace HackathonDashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-slider.js", 
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/slider.css"));

            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                "~/Scripts/jquery.signalR-2.2.0.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/AngularJs/angular.min.js",
                "~/Scripts/AngularJs/angular-ui-router.min.js",
                "~/Scripts/AngularJs/angular-resource.min.js",
                "~/Scripts/AngularJs/angular-animate.min.js",
                "~/Scripts/app.js",
                "~/Scripts/apps/services/*.js",
                "~/Scripts/apps/controllers/*.js"

                )); 
        }
    }
}
