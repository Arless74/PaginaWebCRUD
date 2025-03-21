using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUD.pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el ID
            if (!IsPostBack) 
            {
                if (Request.QueryString["id"] != null) 
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbDate.TextMode = TextBoxMode.DateTime;
                }

                if (Request.QueryString["op"] != null)
                { 
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo Usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de Usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar Usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar Usuario";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos() 
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbEdad.Text = row[2].ToString();
            tbEmail.Text = row[3].ToString();
            DateTime d= (DateTime)row[4];
            tbDate.Text = d.ToString("dd/MM/yyyy");
            conn.Close();

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolvr_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}