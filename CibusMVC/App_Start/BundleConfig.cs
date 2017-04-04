using System.Web;
using System.Web.Optimization;

namespace CibusMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/assets/custom/scripts.js")
                        .Include("~/assets/custom/VideoPlugin.js")
                        .Include("~/assets/custom/VideoPluginFin.js")
                        .Include("~/assets/vendor/anicounter/jquery.counterup.min.js")
                        // .Include("~/assets/vendor/animatedheader/js/cbpAnimatedHeader.js")
                        // .Include("~/assets/vendor/animatedheader/js/cbpAnimatedHeader.min.js")
                        //.Include("~/assets/vendor/animatedheader/js/classie.js")
                        .Include("~/assets/vendor/animatedheader/js/modernizr.custom.js")
                        .Include("~/assets/vendor/bootstrap/js/bootstrap.js")
                        .Include("~/assets/vendor/bootstrap/js/bootstrap.min.js")
                        //.Include("~/assets/vendor/bootstrap/js/npm.js")
                        .Include("~/assets/vendor/circle-progress/js/circle-progress.min.js")
                        .Include("~/assets/vendor/goalprogress/goalProgress.js")
                        .Include("~/assets/vendor/goalprogress/goalProgress.min.js")
                        .Include("~/assets/vendor/imagesloaded/js/imagesloaded.pkgd.min.js")
                        //.Include("~/assets/vendor/isotope/js/isotope.pkgd.min.js")
                        .Include("~/assets/vendor/jquery/js/jquery-1.12.0.min.js")
                        .Include("~/assets/vendor/jquery/js/jquery-2.2.0.min.js")
                        .Include("~/assets/vendor/jquery/js/jquery-2.1.4.js")
                        .Include("~/assets/vendor/jquery-parallax/js/jquery.localscroll-1.2.7-min.js")
                        .Include("~/assets/vendor/jquery-parallax/js/jquery.parallax-1.1.3.js")
                        .Include("~/assets/vendor/jquery-parallax/js/jquery.scrollTo-1.4.2-min.js")
                        .Include("~/assets/vendor/mfp/js/jquery.magnific-popup.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.actions.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.carousel.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.kenburn.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.layeranimation.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.migration.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.navigation.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.parallax.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.slideanims.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/source/revolution.extension.video.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.actions.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.carousel.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.kenburn.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.layeranimation.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.migration.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.navigation.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.parallax.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.slideanims.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/extensions/revolution.extension.video.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/jquery.thempunch.enablelog.js")
                        //.Include("~/assets/vendor/rs-plugin/js/jquery.thempunch.revolution.min.js")
                        //.Include("~/assets/vendor/rs-plugin/js/jquery.thempunch.tools.min.js")
                        .Include("~/assets/vendor/waypoints/waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery1").IncludeDirectory("~/assets/vendor/anicounter", "*.js")
                .IncludeDirectory("~/assets/custom/js", "*.js")
                .IncludeDirectory("~/assets/vendor/animatedheader/js", "*.js")
                .IncludeDirectory("~/assets/vendor/bootstrap/js", "*.js")
                .IncludeDirectory("~/assets/vendor/circle-progress", "*.js")
                .IncludeDirectory("~/assets/vendor/goalprogress", "*.js")
                .IncludeDirectory("~/assets/vendor/imagesloaded/js", "*.js")
                .IncludeDirectory("~/assets/vendor/isotope/js", "*.js")
                .IncludeDirectory("~/assets/vendor/jquery/js", "*.js")
                .IncludeDirectory("~/assets/vendor/jquery-parallax/js", "*.js")
                .IncludeDirectory("~/assets/vendor/mfp/js", "*.js")
                .IncludeDirectory("~/assets/vendor/rs-plugin/js", "*.js")
                .IncludeDirectory("~/assets/vendor/rs-plugin/js/extensions/source", "*.js")
                .IncludeDirectory("~/assets/vendor/rs-plugin/js/extensions", "*.js")
                .IncludeDirectory("~/assets/vendor/rs-plugin/js/source", "*.js")
                .IncludeDirectory("~/assets/vendor/waypoints", "*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/css")
                .IncludeDirectory("~/assets/custom/css", "*.css")
                .IncludeDirectory("~/assets/vendor/animatedheader/css", "*.css")
                .IncludeDirectory("~/assets/vendor/bootstrap/css", "*.css")
                .IncludeDirectory("~/assets/vendor/fontawesome/css", "*.css")
                .IncludeDirectory("~/assets/vendor/jquery-parallax", "*.css")
                .IncludeDirectory("~/assets/vendor/mfp/css", "*.css")
                .IncludeDirectory("~/assets/vendor/pe-icon-7-stroke/css", "*.css")
                .IncludeDirectory("~/assets/vendor/rs-plugin/css", "*.css")
                .IncludeDirectory("~/assets/vendor/rs-plugin/css/navigation-skins", "*.css")
                .IncludeDirectory("~/assets/vendor/rs-plugin/fonts/font-awesome/css", "*.css")
                .IncludeDirectory("~/assets/vendor/rs-plugin/fonts/pe-icon-7-stroke/css", "*.css"));





        }
    }
}
