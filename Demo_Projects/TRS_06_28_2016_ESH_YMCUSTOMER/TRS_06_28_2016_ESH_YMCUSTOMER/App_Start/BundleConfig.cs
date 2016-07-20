using System.Web;
using System.Web.Optimization;

namespace TRS_06_28_2016_ESH_YMCUSTOMER
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/oxbow.css"));

            bundles.Add(new StyleBundle("~/Content/DataTables").Include("~/Content/Datatables/css/jquery.dataTables.min.css","~/Content/Datatables/css/dataTables.bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js"));

        }
    }
}
