using RedSocialMinijuegos.Models;
using RedSocialMinijuegos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocialMinijuegos.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryMinijuegos repo;
        public HomeController(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Juego> juegos = this.repo.GetJuegos();
            return View(juegos);
        }
        [HttpPost]
        public ActionResult Index( int estrellas,String nombre)
        {
            this.repo.Puntuacion(estrellas, nombre);
            List<Juego> juegos = this.repo.GetJuegos();
            return View(juegos);
        }


        public ActionResult Compay()
        {
            
            return View();
        }

        public ActionResult Games(int? id )
        {
             

            if (id!=null)
            {
                List<Juego> j = this.repo.BuscarJuegoCategoria((int)id);
                return View(j);
            }
            else
            {
                List<Juego> j = this.repo.GetJuegos();
                return View(j);
            }
           

            
        }
        [HttpPost]
        public ActionResult Games(int? id, int? estrellas,String nombre)
        {
            if(estrellas!= null)
            {
                this.repo.Puntuacion((int)estrellas, nombre);
            }

            if (id != null)
            {
                List<Juego> j = this.repo.BuscarJuegoCategoria((int)id);
                return View(j);
            }
            else
            {
                List<Juego> j = this.repo.GetJuegos();
                return View(j);
            }



        }



        public ActionResult Contac()
        {

            return View();
        }
        public ActionResult _categorias()
        {
            List<Categoria> categoria = this.repo.lista();
            return PartialView(categoria);
        }

        public ActionResult _Navegacion()
        {
            UsuarioPrincipal usu = HttpContext.User as UsuarioPrincipal;
            if (usu != null) { 
            Usuario usuario = this.repo.BuscarUsuario(usu.IdUsuario);
                return PartialView(usuario);
            }

            return PartialView(); 
        }

        public ActionResult _reslayout()
        {
            UsuarioPrincipal usu = HttpContext.User as UsuarioPrincipal;
            if (usu != null)
            {
                Usuario usuario = this.repo.BuscarUsuario(usu.IdUsuario);
                return PartialView(usuario);
            }

            return PartialView(); 
        }

        public ActionResult Ranking(int? clave , String juego)
        {
            if (clave == null)
            {
                clave = 0;
            }
          
            int numregistros = 0;
            List<RANKING> usuarios;
            if (juego != null && juego!= "Elige el juego") { 


             usuarios =
              this.repo.GetTodosJuego(clave.GetValueOrDefault(), ref numregistros, juego);
                ViewBag.juego = juego;
            }
            else 
            {
                clave = 0;
                usuarios = this.repo.GetTodos(clave.GetValueOrDefault(), ref numregistros);
                ViewBag.juego = "a";
            }
            ViewBag.Registros = numregistros;
            List<string> listaJuegos = this.repo.Nombrejuego();
            ViewBag.nombrejuegos = listaJuegos;
           
            return View(usuarios);


            
        }
       
       

    }
}