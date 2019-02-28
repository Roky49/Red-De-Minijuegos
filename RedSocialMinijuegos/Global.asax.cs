
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using RedSocialMinijuegos.Repositories;
using RedSocialMinijuegos.Models;
using RedSocialMinijuegos.App_Start;
using System.Security.Principal;
using System.Collections.Generic;

namespace RedSocialMinijuegos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IoCConfiguration.Configure();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_PostAuthenticateRequest()
        {

            HttpCookie cokie = Request.Cookies["ticketUsuario"];
            if (cokie != null)
            {
                String datos = cokie.Value;

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(datos);

                String rol = ticket.UserData ;
                

                String username = ticket.Name;
                RepositoryMinijuegos repo = new RepositoryMinijuegos();
                int idusuario = int.Parse(ticket.UserData);
                Usuario usuario = repo.BuscarUsuario(idusuario);
                GenericIdentity identidad = new GenericIdentity(username);
                
               //GenericPrincipal usuarios = new GenericPrincipal(identidad, roles);
               
                // de donde saco este empleado;
               
              
                List<String> roles = new List<string>() { rol };
                UsuarioPrincipal usu = new UsuarioPrincipal(identidad, roles);
                usu.Usuario1 = usuario.Usuario1;
                usu.Roles = usuario.Roles ;
                usu.UltimaConexion = usuario.UltimaConexion;
                usu.IdUsuario = usuario.IdUsuario;
                //ALMACENAMOS EL USUARIO PRINCIPAL EN LA SESION
                usu.Identity = identidad;
                HttpContext.Current.User = usu;









            }
        }


    }
}
