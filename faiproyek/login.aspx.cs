using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


namespace faiproyek
{
    public partial class login : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;

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
                string email = Request.QueryString["email"];
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (tx_password.Text == "user" && tx_email.Text == "user")
            {
                Response.Redirect("home.aspx?nama=" + tx_email.Text);
            }
        }
    }
}