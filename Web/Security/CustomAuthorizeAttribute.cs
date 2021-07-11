using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Security
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        //Roles permitidos
        private readonly int[] allowedroles;

        public CustomAuthorizeAttribute(params int[] roles)
        {
            //roles obtiene los roles de ususario autorizados
            //para acceder al controlador o al métodos de acción
            this.allowedroles = roles;
        }

        //verificaciones de autorización personalizadas
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            var oUsuario = (Usuario)httpContext.Session["User"];

            if (oUsuario != null)
            {
                foreach (var rol in allowedroles)
                {
                    if (rol == oUsuario.IdTipoUsuario)
                    {
                        return true;
                    }
                }
            }
            return authorize;
        }

        //Procesa solicitudes HTTP que fallan en la autorización
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Si hubo un error redirecciona a el siguiente controller y View
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Login"},
                    {"action", "UnAuthorized"}
                }
                );
        }


    }
}