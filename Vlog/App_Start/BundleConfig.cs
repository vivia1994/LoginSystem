using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace Vlog
{
    public class BundleConfig
    {
        public static void VlogBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script/bootstrap").Include(
                "~/scripts/bootstrap.min.js"
                ));
            bundles.Add(new ScriptBundle("~/script/modernizr").Include(
               "~/scripts/modernizr-2.6.2.js"
               ));
            bundles.Add(new ScriptBundle("~/script/jquery").Include(
                //"~/scripts/jquery-1.10.2.intellisense.js",
                "~/Scripts/jquery-1.10.2.min.js"));
            bundles.Add(new ScriptBundle("~/script/vlog").Include(
                "~/scripts/vlog.js"));
            bundles.Add(new ScriptBundle("~/dist/wangEditor").Include(
                "~/dist/js/lib/jquery-1.10.2.min.js",
                "~/dist/js/wangEditor.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/dist/css/wangEditor").Include(
                "~/dist/css/wangEditor.min.css"));
        }
    }
}