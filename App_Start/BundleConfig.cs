using System.Web;
using System.Web.Optimization;

namespace College
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js",
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"


          //"~/Scripts/respond.js",
          ));
            //Create bundel for jQueryUI  
            //js  
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-{version}.js"));
            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                   "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //                               "~/Scripts/bootstrap.js",
            //                               "~/Scripts/bootbox.js"
            //));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      // "~/Content/DataTables/css/dataTables.bootstrap.css",
                      // "~/Content/typeahead.css",
                      // "~/Content/toastr.scss",
                      "~/Content/site.css"
                      ));
        }
    }
}
