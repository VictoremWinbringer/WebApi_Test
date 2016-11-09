using System.Web;
using System.Web.Optimization;

namespace SPA
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                         "~/Kendo/js/jquery.min.js", "~/Kendo/js/kendo.all.min.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Kendo/styles/kendo.common.min.css",
                      "~/Kendo/styles/kendo.bootstrap.min.css",
                  "~/Kendo/styles/kendo.bootstrap.mobile.min.css"));
        }
    }
}
