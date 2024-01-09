using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using articulo.Libreria.Datos;
using System.Data;


namespace articulo.libreria.Negocios
{
    public class ArticuloN
    {
        ArticuloD objd = new ArticuloD();
        public DataTable Listar_articulos()
        {
            return objd.Listar_articulos();

        }

    }
}
