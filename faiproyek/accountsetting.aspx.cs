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
    public partial class accountsetting : System.Web.UI.Page
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
                ubahpass();
                connection();
                if (Session["email"] != null)
                {
                    tx_email.Text = Session["email"].ToString();
                    Label1.Text = Session["email"].ToString();
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                }

            }
        }

        public void find_dataUser()
        {

        }

        public void ubahpass()
        {
            tx_passbaru.Visible = false;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "a";
        }

        protected void btn_tampilformUbahdata_Click(object sender, EventArgs e)
        {
            ubahpass();
        }

        protected void btn_ubahpass_Click(object sender, EventArgs e)
        {
            tx_passbaru.Visible = true;
        }
    }
}