using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }
        protected void Application_Error()
        {
            // Código que se ejecuta cuando ocurre un error
            var ex = Server.GetLastError();
            Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod());
            Server.ClearError(); // borra el error para que se pueda continuar
                                 //Redireccionar a la página personalizada de errores
            Response.Redirect(String.Format("~/Error/", ex));
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //Configurar
            CultureInfo myCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            myCulture.NumberFormat.NumberDecimalSeparator = ".";
            myCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            myCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = myCulture;
        }
    }
}
