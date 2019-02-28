using RedSocialMinijuegos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialMinijuegos.Repositories
{
     public interface IRepositoryMinijuegos
    {
       
        void BorrarUsuarios(int id);
        void EditarUsuarios(Usuario u);

       

        List<Categoria> Categorias();

        void EliminarCategoria(int id);
        void CrearCategoria(Categoria Categoria);
        void ModificarCategoria(Categoria categoria);
        Categoria BuscarCategoria(int id);

        void ModificarJuego(Juego juego);
        List<Categoria> lista();
        List<Usuario> GetUsuarios();
        List<Juego> BuscarJuegoCategoria(int tipo);
        List<Juego> GetJuegos();

        Usuario ExisteUsuario(string usuario);

        Usuario BuscarUsuario(int idusuario);

        Usuario BuscarUsuarioEmail(String Email);
        Usuario BuscarUsuarioMote(String usuario);

        Usuario ComprobarUsuario(String username
                , String password);

        void NuevoUsuario(String usuario, String email, String password);
        void EliminarJuego(String nombre);
        void CrearJuego(Juego juego);
        void InsertarPuntuacion(int puntos, String nombre);

        void Puntuacion(int Puntuacion,String nombre);
         Juego BuscarJuego(String nombre);

        List<RANKING> GetTodos(int clave, ref int totalregistros);

        List<MostrarPerfil> GetMostrarPerfils(String Usuario);

        List<RANKING> GetTodosJuego(int clave, ref int totalregistros ,String juego);
        List<string> Nombrejuego();
    }
}
