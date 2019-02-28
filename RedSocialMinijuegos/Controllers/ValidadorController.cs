using RedSocialMinijuegos.Models;
using RedSocialMinijuegos.Repositories;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RedSocialMinijuegos.Controllers
{
    public class ValidadorController : Controller
    {
        IRepositoryMinijuegos repo;
       

        public ValidadorController(IRepositoryMinijuegos repo)
        {
        
            this.repo =  repo;;
        }

        // GET: Validacion
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(String usuario, String password)
        {




            Usuario Ususario = this.repo.ComprobarUsuario(usuario, password);




            if ( Ususario != null)
            {


                FormsAuthenticationTicket ticket
                    = new
                    FormsAuthenticationTicket(1, Ususario.Usuario1, DateTime.Now, DateTime.Now.AddMinutes(10), true, Ususario.IdUsuario.ToString());

                String cifrado = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie("ticketUsuario", cifrado);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");

               
            }
            else
            {
                ViewBag.men = "Datos incorrectos";
                return View();

            }


        }
           



        
        public ActionResult CerrarSesion()
        {
            //CERRAR SESION 

            HttpContext.User = null;
            //salir de la autentificacion
            FormsAuthentication.SignOut();
            //recuperar la cookie y expirar
            HttpCookie cokie = Request.Cookies["ticketUsuario"];
            cokie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cokie);
            //donde me lo llevo
            return RedirectToAction("Index", "Home");
        }


        // get de consulta
        public ActionResult NuevoRegistro ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoRegistro(String usuario, String email, String password, String password2)
        {
            Usuario ExistEmail = this.repo.BuscarUsuarioEmail(email);
            Usuario ExisteMote = this.repo.BuscarUsuarioMote(usuario);
            if (password != password2)
            {
                ViewBag.men = "la contraseña no coincide";
                return View();



            }
            else if (ExistEmail != null)
            {
                ViewBag.men = "El email ya existe";
                return View();

            }
            else if (ExisteMote != null)
            {
                ViewBag.men = "El usuario ya existe";
                return View();
            }
            else
            {

                this.repo.NuevoUsuario( usuario, email, password);

                return RedirectToAction("Index", "Home");


            }



        }



    }
}