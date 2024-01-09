using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using articulo.Libreria.Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AppWeb_Carrito
{
    public partial class Detalles : System.Web.UI.Page
    {
      //  #region Procedimientos

       /* void LlenarDatos()
        {
            DataTable DT;
            DT = (DataTable)Session["carrito"];
            GridView1.DataSource = DT;
            GridView1.DataBind();
            Session["carrito"] = DT;
        }

        Single TOTAL;
        
        void ActualizarTotalPagar()
        {

            DataTable DT;
           
            DT = (DataTable)Session["carrito"];

          
            foreach (DataRow Fila in DT.Rows)
            {
                TOTAL = Convert.ToSingle(Fila["Total"]) + TOTAL;
                
            }
          
          
        }

        #endregion*/
                
        protected void Page_Load(object sender, EventArgs e)
        {
            /*  DataTable DT = new DataTable();

               DataRow DR ;
              String idarticulo;
              idarticulo = Request.QueryString["id"];
              if (Session["carrito"] == null)
              {

                  DT.Columns.Add("Codigo", typeof(String)).MaxLength = 50;
                  DT.Columns.Add("Nombre", typeof(String)).MaxLength = 50;
                  DT.Columns.Add("Precio", typeof(Decimal));
                  DT.Columns.Add("Cantidad", typeof(Int32));
                  DT.Columns.Add("Total", typeof(Decimal));
                  DataColumn[] PK = new DataColumn[1];
                  PK[0] = DT.Columns["Codigo"];
                  DT.PrimaryKey = PK;
                  GridView1.DataSource = DT;

                  GridView1.DataBind();
              }
              else
              {
                  // En Session se almacenan tipos de tipo Object, se tiene que hacer el casting (conversion de tipo)
                  DT = (DataTable)Session["carrito"];
              }

              if (idarticulo != "" && Page.IsPostBack == false)
              {
                  DataRow FilaExiste = DT.Rows.Find("idarticulo");
                  if (FilaExiste != null)
                  {
                      FilaExiste.BeginEdit();
                      FilaExiste["Cantidad"] = Convert.ToInt16(FilaExiste["Cantidad"]) + 1;
                      FilaExiste["Total"] = Convert.ToInt16(FilaExiste["Precio"]) * Convert.ToInt16(FilaExiste["Cantidad"]);
                      FilaExiste.EndEdit();
                  }
                  else
                  {

                      string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

                      SqlDataAdapter cmd = new SqlDataAdapter("usp_Articulo_Traer_X_ID", cn);
                      cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                      cmd.SelectCommand.Parameters.Add("@idarticulo", SqlDbType.Char, 5).Value = idarticulo;
                      cmd.SelectCommand.Parameters.Add("@nomarticulo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                      cmd.SelectCommand.Parameters.Add("@precio", SqlDbType.Decimal, 5).Direction = ParameterDirection.Output;
                      cmd.Fill(DT);
                      DataRow DR = DT.NewRow();
                      DR.BeginEdit();
                      DR["Codigo"] = idarticulo;
                      DR["Nombre"] = cmd.SelectCommand.Parameters["@nomarticulo"].Value;
                      DR["Precio"] = cmd.SelectCommand.Parameters["@precio"].Value;

                      if (DR["Cantidad"] == DBNull.Value)
                      {
                          DR["Cantidad"] = 1;
                      }
                      else
                      {
                          DR["Cantidad"] = Convert.ToInt16(DR["Cantidad"]) + 1;
                      }

                      DR["Total"] = Convert.ToInt16(DR["Precio"]) * Convert.ToInt16(DR["Cantidad"]);

                      DR.EndEdit();

                      DT.Rows.Add(DR);
                  }

              }
              if (Page.IsPostBack == false)
              {
                  GridView1.DataSource = DT;
                  GridView1.DataBind();

              }
              (Session["carrito"]) = DT;
              ActualizarTotalPagar();

              lblTotal.Text = TOTAL.ToString();

      */
            
             txtCodigo.Text = Request.QueryString["id"];
            txtArticulo.Text= Request.QueryString["arti"];
           txtPrecio.Text = Request.QueryString["pre"];
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           GridView1.EditIndex= e.NewEditIndex;
            //LlenarDatos();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            DataTable DT;
            Int16 cantidad;
            int n = e.RowIndex;
            TextBox txtcantidad = (TextBox)GridView1.Rows[n].FindControl("txtCantidad");
            cantidad = Convert.ToInt16(txtcantidad.Text);
            DT = (DataTable)Session["carrito"];
            DT.Rows[e.RowIndex]["Cantidad"] = txtcantidad.Text;
            DT.Rows[e.RowIndex]["Total"] = Convert.ToInt16(DT.Rows[e.RowIndex]["Precio"]) * cantidad;
            GridView1.EditIndex = -1;
            GridView1.DataSource = DT;
            GridView1.DataBind();
            Session["carrito"] = DT;
          

            //ActualizarTotalPagar();
          
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //LlenarDatos();

          

        }
    }
}