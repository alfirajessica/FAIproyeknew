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
        Boolean cek = false;
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
                button_ubahdata();
                connection();
                if (Session["email"] != null)
                {
                    tx_email.Text = Session["email"].ToString();
                  //  Label1.Text = Session["email"].ToString();
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

        public void button_ubahdata()
        {
            //yang ditampilkan: email, nama, notelp, dan password
            nama.Visible = true;
            notelp.Visible = true;
            pass_lama.Visible = true;
            submit.Visible = true;

            //yg tdk ditampilkan : pass baru, pass lama
            tx_passbaru.Visible = false;
            pass_baru.Visible = false;
            submitpass.Visible = false;

            lb_notif.Text = "";
        }

        public void button_ubahpass()
        {
            //yg tidak ditampilkan nama, notelp, btn submit
            nama.Visible = false;
            notelp.Visible = false;
            submit.Visible = false;

            //yg ditampilkan : pass_baru, pass_lama, konpas
            pass_baru.Visible = true;
            tx_passbaru.Visible = true;
            submitpass.Visible = true;

            lb_notif.Text = "";
        }
      
       
        protected void btn_tampilformUbahdata_Click(object sender, EventArgs e)
        {
            button_ubahdata();  
        }

        protected void btn_ubahpass_Click(object sender, EventArgs e)
        {
            button_ubahpass();
        }

        public void cek_auth_pass_email()
        {
            //ini utk ngecek apakah benar email tsb memiliki password tsb
            connection();
            SqlDataAdapter da = new SqlDataAdapter("select * from Person where Email='" + tx_email.Text + "'", sqlconn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (tx_email.Text == dt.Rows[i]["Email"].ToString() &&
                    tx_passlama.Text == dt.Rows[i]["Password"].ToString())
                {
                    cek = true;
                }

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //ini digunakan untuk submit data diri baru
            //nama, notelp
            //jadi yg di update nama, dan notelp saja
           
            
            connection();
            try
            {
                cek_auth_pass_email();
                if (cek == true)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Person set Nama=@Nama, Notelp=@NoTelp where Email='" + tx_email.Text + "'", sqlconn);
                        cmd.Parameters.AddWithValue("@Nama", tx_nama.Text);
                        cmd.Parameters.AddWithValue("@Notelp", tx_notelp.Text);
                        cmd.ExecuteNonQuery();
                        lb_notif.Text = "berhasil update data diri";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('"+ex.Message+"');</script>");

                    }
                }
                if (cek == false)
                {
                    lb_notif.Text = "password salah";
                }
            }
            catch (Exception ex)
            {

                lb_notif.Text = ex.Message.ToLower();
            }

            sqlconn.Close();
        }

        protected void btn_submitpassbaru_Click(object sender, EventArgs e)
        {
            //ini digunakan untuk submit pass baru
            //yang diupdate password saja

            connection();
            try
            {
                cek_auth_pass_email();
                if (cek == true)
                {
                    
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Person set Password=@Password where Email='" + tx_email.Text + "'", sqlconn);
                        cmd.Parameters.AddWithValue("@Password", tx_passbaru.Text);
                        cmd.ExecuteNonQuery();
                        lb_notif.Text = "berhasil update password";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");

                    }
                }
                if (cek == false)
                {
                    lb_notif.Text = "password salah";
                }
            }
            catch (Exception ex)
            {

                lb_notif.Text = ex.Message.ToLower();
            }

            sqlconn.Close();
        }
    }
}