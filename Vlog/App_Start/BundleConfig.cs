using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Vlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //   cannot use the 'min'  file       
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/scripts/bootstrap.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/scripts/modernizr-{version}.js"/*2.6.2*/
            ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery-{version}.intellisense.js",
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/vlog").Include(
                "~/scripts/vlog.js"));
            bundles.Add(new ScriptBundle("~/bundles/wangEditor").Include(
                "~/dist/js/lib/jquery-2.2.1.js",
                "~/dist/js/wangEditor.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/dist/css/wangEditor").Include(
                "~/dist/css/wangEditor.css"));
            BundleTable.EnableOptimizations = true; //or <system.web> <compilation debug="false>"
        }
    }
}