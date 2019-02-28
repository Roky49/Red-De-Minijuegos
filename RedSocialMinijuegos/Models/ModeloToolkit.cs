using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RedSocialMinijuegos.Models
{
    public class ModeloToolkit
    {
        public static String GenerarSalt()
        {
            Random rnd = new Random();
            String salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int aleatorio = rnd.Next(0, 255);
                char letra = Convert.ToChar(aleatorio);
                salt += letra;
            }
            return salt;
        }

        public static byte[] Encriptar(String password, String salt)
        {
            String contenido = password + salt;
            SHA256Managed cifrado = new SHA256Managed();
            byte[] salida;
            //CONVERTIMOS EL CONTENIDO A BYTE
            salida = Encoding.UTF8.GetBytes(contenido);
            //CIFRAMOS EL CONTENIDO n VECES
            for (int i = 1; i <= 100; i++)
            {
                salida = cifrado.ComputeHash(salida);
            }
            return salida;
        }

    }
}