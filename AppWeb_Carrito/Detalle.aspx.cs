using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using System.Text;

namespace AppWeb_Carrito
{
    public partial class Detalle : System.Web.UI.Page
    {
        void LlenarDatos()
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
            TOTAL = 0;

            foreach (DataRow Fila in DT.Rows)
            {
                TOTAL = Convert.ToSingle(Fila["Total"]) + TOTAL;

            }
            

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();

            /* DataRow DR ;*/
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

            try
            {
                if (idarticulo != "" && Page.IsPostBack == false)
                {
                    DataRow FilaExiste = DT.Rows.Find(idarticulo);
                    if (FilaExiste != null)
                    {
                        FilaExiste.BeginEdit();
                        FilaExiste["Cantidad"] = Convert.ToInt32(FilaExiste["Cantidad"]) + 1;
                        FilaExiste["Total"] = Convert.ToDecimal(FilaExiste["Precio"]) * Convert.ToInt32(FilaExiste["Cantidad"]);
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
                
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiAdvertencia('Estas en carrito!');", true);
            }


            if (Page.IsPostBack == false)
            {
                GridView1.DataSource = DT;
                GridView1.DataBind();
               
            }
            (Session["carrito"]) = DT;
            ActualizarTotalPagar();

            lblTotal.Text = TOTAL.ToString();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LlenarDatos();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LlenarDatos();

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
              ActualizarTotalPagar();
            lblTotal.Text = TOTAL.ToString();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable DT;
            int n = e.RowIndex;
            DT = (DataTable)Session["carrito"];
            string codigo = DT.Rows[e.RowIndex]["Codigo"].ToString();
            DataRow FilaEliminar = DT.Rows.Find(codigo);
            if (FilaEliminar != null)
            {
                // Elimina la fila del DataTable
                DT.Rows.Remove(FilaEliminar);
            }
            GridView1.EditIndex = -1;
            GridView1.DataSource = DT;
            GridView1.DataBind();
            Session["carrito"] = DT;
            ActualizarTotalPagar();
            lblTotal.Text = TOTAL.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string direccion = txtDir.Text;
                string nom = txtNombre.Text;
                string correo = txtCorreo.Text;
                string total = lblTotal.Text;
                string cuerpo = "Hola <strong>" + nom + "</strong>" +
                    "<br>" + "Tu pedido ah sido confirmado y sera enviado a la direccion: " + direccion +
                    "<br>" + tabla() +
                    "<br>" + "El total a pagar es: <strong>" + total + "<srtrong>";
                // Configuración del cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.mecawash.tech");
                clienteSmtp.Port = 587;
                clienteSmtp.Credentials = new NetworkCredential("soporte@mecawash.tech", "NWWoK!q9");
                clienteSmtp.EnableSsl = true;

                // Crear el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("soporte@mecawash.tech");
                mensaje.To.Add(correo);
                mensaje.Subject = "Confirmacion de pedido";
                mensaje.Body = cuerpo;

                mensaje.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback = delegate
                    (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                clienteSmtp.Send(mensaje);
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiExito('Comprobante enviado','Se ha enviado los detalles al correo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Verifique que todos los datos son correctos!');", true);
            }
        }


        protected string tabla()
        {
            try
            {
                DataTable DT = (DataTable)Session["carrito"];
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'>");

                // Agregar encabezados de columna
                sb.Append("<tr>");
                foreach (DataColumn column in DT.Columns)
                {
                    sb.AppendFormat("<th>{0}</th>", column.ColumnName);
                }
                sb.Append("</tr>");

                // Agregar filas de datos
                foreach (DataRow row in DT.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in DT.Columns)
                    {
                        sb.AppendFormat("<td>{0}</td>", row[column]);
                    }
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                return sb.ToString();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('La tabla no se renderizo!');", true);
                return "";
            }
        }
    }
}