using RedSocialMinijuegos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RedSocialMinijuegos.Repositories
{
    
    public class RepositoryMinijuegos : IRepositoryMinijuegos
    {
        MinijuegosContexto contex;
        public RepositoryMinijuegos()
        {
            this.contex = new MinijuegosContexto();
        }

        public void ModificarJuego(Juego juego)
        {
            var consulta = from datos in contex.Juego where datos.Nombre == juego.Nombre select datos;
            Juego j1 = consulta.FirstOrDefault();
            j1.Nombre = juego.Nombre;
            j1.hyml = juego.hyml;
            j1.imagen = juego.imagen;
            j1.Nveces = 0;
            j1.Tipo = juego.Tipo;
            j1.Valoracion = 0;
            j1.css = juego.css;
            j1.scritp = juego.scritp;

            
            this.contex.SaveChanges();
        }
        public void CrearJuego(Juego juego)
        {
            Juego j1 = new Juego();
            j1.Nombre = juego.Nombre;
            j1.hyml = juego.hyml;
            j1.imagen = juego.imagen;
            j1.Nveces = 0;
            j1.Tipo = juego.Tipo;
            j1.Valoracion = 0;
            j1.css = juego.css;
            j1.scritp = juego.scritp;

            this.contex.Juego.Add(j1);
            this.contex.SaveChanges();
        }

        public void EliminarJuego(String nombre)
        {
            Juego j = BuscarJuego(nombre);
            
            this.contex.Juego.Remove(j);
            this.contex.SaveChanges();
        }
        public List<Usuario> GetUsuarios()
        {
            var consulta = from datos in contex.Usuario select datos;
            return consulta.ToList();
        }

        public List<Juego> GetJuegos()
        {
            var consulta = from datos in contex.Juego select datos;
            return consulta.ToList();
        }

        public Juego  BuscarJuego(String nombre)
        {
            var consulta = from datos in contex.Juego where datos.Nombre==nombre select datos;
            return consulta.FirstOrDefault();
        }
        public List<Juego> BuscarJuegoCategoria(int id)
        {
            var consulta = from datos in contex.Juego where datos.Tipo == id select datos;
            return consulta.ToList();
        }

        public void Puntuacion(int estrellas, String nombre)
        {
            Juego j1 = BuscarJuego(nombre);
            
            if(j1.Nveces==null && j1.Valoracion== null)
            {
                j1.Nveces = 1;
                j1.Valoracion = estrellas;
            }
            else
            {

                j1.Nveces += 1 ;
                j1.Valoracion += estrellas;
            }
            this.contex.SaveChanges();

            
        }

        public Usuario ExisteUsuario(string usuario)
        {
            var consulta = from datos in contex.Usuario
                           where datos.Email == usuario
                          
                           select datos;


            return consulta.FirstOrDefault();

        }

        public void NuevoUsuario(String usuario, String email, String password)
        {
            Usuario usu = new Usuario();
            var ultimonumero = contex.Usuario.OrderByDescending(i => i.IdUsuario).FirstOrDefault();
            if (ultimonumero == null)
            {
                usu.IdUsuario = 1;
            }
            else
            {
                usu.IdUsuario = ultimonumero.IdUsuario + 1;
            }
            usu.Gemas = 100;
            usu.UltimaConexion = DateTime.Now.Date;
            usu.Puntiacion = 1;
            String salt = ModeloToolkit.GenerarSalt();
            byte[] passcifrada =
                ModeloToolkit.Encriptar(password, salt);
            usu.Email = email;
            usu.Usuario1 = usuario;
            usu.Salt = salt;
            usu.Roles = "User";
            usu.PassWord = passcifrada;
            this.contex.Usuario.Add(usu);
            this.contex.SaveChanges();
        }

        public Usuario ComprobarUsuario(String username
               , String password)
        {
            //BUSCAMOS EL USUARIO POR SU USERNAME
            var consulta = from datos in contex.Usuario
                           where datos.Email == username
                           select datos;
            Usuario usuario = consulta.FirstOrDefault();
            if (usuario != null)
            {
                String salt = usuario.Salt;
                byte[] datospassword = usuario.PassWord;
                byte[] datoscifrados =
                    ModeloToolkit.Encriptar(password, salt);
                //COMPARAMOS LOS DOS ARRAYS
                bool iguales = true;
                if (datospassword.Length
                    != datoscifrados.Length)
                {
                    return null;
                }


                for (int i = 0; i <= datoscifrados.Length - 1; i++)
                {
                    if (datoscifrados[i].Equals(datospassword[i]) == false)
                    {
                        iguales = false;
                        break;
                    }
                }

                if (iguales == false)
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            return null;
        }


        public Usuario BuscarUsuario(int idusuario)
        {
            var consulta = from datos in contex.Usuario where datos.IdUsuario == idusuario select datos;

            return consulta.FirstOrDefault();
        }

        

        public Usuario BuscarUsuarioEmail(string Email)
        {
            var consulta = from datos in contex.Usuario where datos.Email == Email select datos;

            return consulta.FirstOrDefault();
        }

        public Usuario BuscarUsuarioMote(string usuario)
        {
            var consulta = from datos in contex.Usuario where datos.Usuario1 == usuario select datos;

            return consulta.FirstOrDefault();
        }


        public void InsertarPuntuacion(int puntos, string nombre)
        {
            Partida nepartida = new Partida();
            nepartida.NombreJuego = nombre;
            nepartida.Puntuacion = puntos;
            String id = HttpContext.Current.User.Identity.Name;
            nepartida.idUsuario = (this.BuscarUsuarioMote(id)).IdUsuario ;
            nepartida.Fecha = DateTime.Now ;
            
                var ultimonumero = contex.Partida.OrderByDescending(i => i.IdPartida).FirstOrDefault();
            if (ultimonumero == null)
            {
                nepartida.IdPartida = 1;
            }
            else
            {
                nepartida.IdPartida = ultimonumero.IdPartida + 1;
            }

            this.contex.Partida.Add(nepartida);
            this.contex.SaveChanges();

        }

        public List<Categoria> lista()
        {
            var consulta = from datos in contex.Categoria select datos;

            return consulta.ToList();
        }

        public List<Categoria> Categorias()
        {
            return this.contex.Categoria.ToList();
        }

        public void EliminarCategoria(int id)
        {
            Categoria j = this.BuscarCategoria(id);

            this.contex.Categoria.Remove(j);
            this.contex.SaveChanges();
        }

        public void CrearCategoria(Categoria Categoria)
        {
            Categoria j = new Categoria();
            var ultimonumero = contex.Categoria.OrderByDescending(i => i.IdCategoria).FirstOrDefault();
           
            if (ultimonumero == null)
            {
                j.IdCategoria = 1;
            }
            else
            {
                j.IdCategoria = 1 + ultimonumero.IdCategoria;
            }
          
            j.Nombre = Categoria.Nombre;

            this.contex.Categoria.Add(j);
            this.contex.SaveChanges();
        }

        public void ModificarCategoria(Categoria categoria)
        {
            Categoria j = this.BuscarCategoria(categoria.IdCategoria);
            j.Nombre = categoria.Nombre;
            
            this.contex.SaveChanges();
        }
        public Categoria BuscarCategoria(int id)
        {
            var consulta = from datos in contex.Categoria where datos.IdCategoria == id select datos;
            return consulta.FirstOrDefault();
        }

        public void BorrarUsuarios(int id)
        {
            Usuario j = this.BuscarUsuario(id);

            this.contex.Usuario.Remove(j);
            this.contex.SaveChanges();
        }

        public void EditarUsuarios(Usuario u)
        {
            Usuario j = this.BuscarUsuario(u.IdUsuario);
            j.Roles = u.Roles;

            this.contex.SaveChanges();
        }

      

        public List<RANKING> GetTodos(int clave, ref int totalregistros)
        {
            var consulta = from datos in contex.RANKING
                           
                            select datos;
            
            totalregistros = consulta.Count();
            return consulta.OrderByDescending(z => z.Clave).Skip(clave).Take(20).ToList();

          
        }

        public List<RANKING> GetTodosJuego(int clave, ref int totalregistros, string juego)
        {
            var consulta = from datos in contex.RANKING
                           where datos.NombreJuego == juego
                           select datos;
            totalregistros = consulta.Count();
           
            return consulta.OrderByDescending(z => z.Puntuacion).Skip(clave).Take(7).ToList();
        }

        public List<string> Nombrejuego()
        {
            var consulta = from datos in contex.Juego
                           
                           select datos.Nombre;

            return consulta.ToList();
        }

        public List<MostrarPerfil> GetMostrarPerfils(String Usuario)
        {
            var consulta = from datos in contex.MostrarPerfil
                           where datos.Usuario== Usuario
                           select datos;

            return consulta.ToList();
        }
    }
}
