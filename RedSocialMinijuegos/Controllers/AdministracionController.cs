using RedSocialMinijuegos.atribute;
using RedSocialMinijuegos.Models;
using RedSocialMinijuegos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocialMinijuegos.Controllers
{
    [AutorizacionUsuarios(Roles = "Admin")]
    public class AdministracionController : Controller
    {
        IRepositoryMinijuegos repo;
        public AdministracionController(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
        }

        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Juegos()
        {
            List<Juego> juegos = this.repo.GetJuegos();
            return View(juegos);
        }
        public ActionResult EditJuegos(String id)
        {
              Juego j=  this.repo.BuscarJuego(id);
            
            return View(j);
        }
        [HttpPost]

        public ActionResult EditJuegos(Juego j, HttpPostedFileBase imagen)
        {

            if (imagen != null)
            {


                imagen.SaveAs(Server.MapPath("~/Imagenes/" + imagen.FileName));
            }
          
            this.repo.ModificarJuego(j);
            List<Juego> juegos = this.repo.GetJuegos();
            return View("Juegos",juegos);


        }
        public ActionResult CreateJuegos()
        {
            ViewBag.cate = this.repo.Categorias();
            return View();
        }
        [HttpPost]
        
        public ActionResult CreateJuegos(Juego j, HttpPostedFileBase imagen)
        {
            if (imagen!= null)
            {
                
              
                imagen.SaveAs(Server.MapPath("~/Imagenes/"+imagen.FileName));
            }
            j.imagen = imagen.FileName;
            this.repo.CrearJuego(j);
            List<Juego> juegos = this.repo.GetJuegos();
            return View("Juegos", juegos);
        }

        public ActionResult BorrarJuegos(String id)
        {
            this.repo.EliminarJuego(id);
            List<Juego> juegos = this.repo.GetJuegos();
            return View("Juegos", juegos);
        }

        public ActionResult Categorias()
        {
            List<Categoria> categorias = this.repo.Categorias();

            return View(categorias);
        }
        public ActionResult EditCategoria(int id)
        {
            Categoria j = this.repo.BuscarCategoria(id);

            return View(j);
        }
        [HttpPost]

        public ActionResult EditCategoria(Categoria j)
        {

           
            this.repo.ModificarCategoria(j);
            List<Categoria> categorias = this.repo.Categorias();
            return View("Categorias",categorias);


        }
        public ActionResult CreateCategoria()
        {
            
            return View();
        }
        [HttpPost]

        public ActionResult CreateCategoria(Categoria j)
        {
           
            this.repo.CrearCategoria(j);
            List<Categoria> categorias = this.repo.Categorias();
            return View("Categorias",categorias);
        }

        public ActionResult BorrarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
            List<Categoria> categorias = this.repo.Categorias();
            return View("Categorias", categorias);
        }


     
        public ActionResult Usuarios()
        {
            List<Usuario> usu = this.repo.GetUsuarios();

            return View(usu);
        }

        public ActionResult BorrarUsuarios( int id)
        {
            this.repo.BorrarUsuarios(id);
            List<Usuario> usu = this.repo.GetUsuarios();
            return View("Usuarios",usu);
        }
        public ActionResult EditarUsuarios(int id)
        {
            Usuario u =this.repo.BuscarUsuario(id);

            return View(u);
        }
        [HttpPost]
        public ActionResult EditarUsuarios(Usuario u)
        {
            this.repo.EditarUsuarios(u);
            List<Usuario> usu = this.repo.GetUsuarios();
            return View("Usuarios",usu);
        }




    }
}