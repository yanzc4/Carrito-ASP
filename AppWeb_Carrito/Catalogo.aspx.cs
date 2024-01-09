using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using articulo.libreria.Negocios;
using articulo.Libreria.Entidad;
namespace AppWeb_Carrito
{
    public partial class Catalogo : System.Web.UI.Page
    {
       

        ArticuloN objN =new ArticuloN();


        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = objN.Listar_articulos();
              DataList1.DataBind ();
        }

       
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("comprar"))
            {
                Label id = (Label)e.Item.FindControl("lblId");
                Label articulo = (Label)e.Item.FindControl("lblArticulo");
                Label precio = (Label)e.Item.FindControl("lblprecio");
                Label stock = (Label)e.Item.FindControl("lblstock");
                Response.Redirect("Detalles.aspx?id=" + id.Text  + "&arti="+ articulo.Text +"&pre="+ precio .Text +"& stock=" +stock .Text  );
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
           
    }
}