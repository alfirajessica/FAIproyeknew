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
    public partial class Register1 : System.Web.UI.Page
    {
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection sqlconn;
        
        string role = ""; //B (pembeli) --- S(penjual) 

        public void connection()
        {
            sqlconn = new SqlConnection(conn);
            if (sqlconn.State == ConnectionState.Closed)
                sqlconn.Open();
        }
        public void reset()
        {
            tx_email.Text = "";
            tx_konpass.Text = "";
            tx_nama.Text = "";
            tx_notelp.Text = "";
            tx_pass.Text = "";
            Label1.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sqlconn = new SqlConnection(conn);
            }
        }

        protected void btn_regist_pembeli_Click(object sender, EventArgs e)
        {
            connection();
            try
            {
                role = "B";
                if (tx_email.Text == null || tx_nama.Text == null ||
                    tx_notelp.Text == null || tx_pass == null )
                {
                    Label1.Text = "tidak dapat register";
                }
                if (tx_email.Text != "" && tx_nama.Text != "" &&
                     tx_notelp.Text != "" && tx_pass.Text != "" && tx_konpass.Text != "")

                {
                    SqlCommand cmd = new SqlCommand("insert into Person values(@Email, @Nama, @Password, @NoTelp, @Role)", sqlconn);
                    cmd.Parameters.AddWithValue("@Email", tx_email.Text);
                    cmd.Parameters.AddWithValue("@Nama", tx_nama.Text);
                    cmd.Parameters.AddWithValue("@Password", tx_pass.Text);
                    cmd.Parameters.AddWithValue("@NoTelp", tx_notelp.Text);
                    cmd.Parameters.AddWithValue("@Role", role.ToString());
                    cmd.ExecuteNonQuery();
                    Label1.Text = "berhasil";
                    Response.Write("<script>alert('register successful');</script>");
                    reset();
                    Response.Redirect("login.aspx");
                }
               
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
                Response.Write("<script>alert('"+ex.Message.ToString() + "');</script>");
                reset();
                
            }
            sqlconn.Close();
           

         //   Response.Redirect("login.aspx");
        }

        protected void btn_regist_penjual_Click(object sender, EventArgs e)
        {
            //menuju dashboard
        }
    }
}