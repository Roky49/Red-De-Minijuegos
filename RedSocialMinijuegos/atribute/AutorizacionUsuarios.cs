using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedSocialMinijuegos.atribute
{
    public class AutorizacionUsuarios : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                GenericPrincipal usuario = filterContext.HttpContext.User as GenericPrincipal;


                filterContext.Result = GetRutaRedirect("Validador", "login");
               
           
            }


        }


        public RedirectToRouteResult GetRutaRedirect(String controlador, String accion)
        {
            RouteValueDictionary ruta = new RouteValueDictionary(new { controller = controlador, Action = accion });
            RedirectToRouteResult direcion = new RedirectToRouteResult(ruta);

            return direcion;
        }
    }


}
