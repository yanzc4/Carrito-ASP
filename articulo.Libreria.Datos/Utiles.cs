using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace articulo.Libreria.Datos
{
   public class Utiles
    {
       public static string conexion
         = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
  
    }
}
