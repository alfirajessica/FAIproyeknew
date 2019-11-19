using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace faiproyek
{
    public partial class Activation : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email = "";
        string status = "C";

        public void connection()
        {
            sqlconn = new SqlConnection(conn);
            if (sqlconn.State == ConnectionState.Closed)
                sqlconn.Open();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                connection();
                email = Request.QueryString["email"];
                lb_notif.Text = "akun " + email + " berhasil diaktifkan";
                changeStatus_Activation();

            }
        }

        public void changeStatus_Activation()
        {
            connection();

            try
            {
                SqlCommand cmd = new SqlCommand("update Person set Status=@Status where Email='" + email + "'", sqlconn);
                cmd.Parameters.AddWithValue("@Status", status.ToString());
                cmd.ExecuteNonQuery();
                sqlconn.Close();
                Response.Redirect("login.aspx?email="+email);
            }
            catch (Exception ex)
            {

                lb_notif.Text = ex.Message.ToString();
            }
           
        }
    }
}