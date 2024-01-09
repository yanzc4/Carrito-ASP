using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient ;
using articulo.Libreria.Entidad;

namespace articulo.Libreria.Datos
{
    public class ArticuloD:Utiles
    {
        public DataTable Listar_articulos()
        {
            DataTable tb = new DataTable();
            using (SqlDataAdapter adap =
                new SqlDataAdapter("usp_articulos", conexion))
            {
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.Fill(tb);

            }
            return tb;

        }
     }
}
