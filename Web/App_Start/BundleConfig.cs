using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BUNDLE JS
            bundles.Add(new ScriptBundle("~/bundles/myBundle").Include(
                        "~/Scripts/spectrum.min.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery-3.6.0.slim.min.js",
                        "~/Scripts/bootstrap-datetimepicker.min.js",
                        "~/Scripts/bootstrap.js"));
            //STYLE BUNDLE CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/site.css",
                      "~/Content/sweetalert.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/all.min.css",
                      "~/Content/jquery-confirm.min.css",
                      "~/Content/spectrum.min.css",
                      "~/Content/MiEstilo.css",
                      "~/Content/bootstrap_united.css"
                      ));
        }

    }
}
