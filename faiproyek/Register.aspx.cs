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
    public partial class Register1 : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        
        string role = ""; //B (pembeli) --- S(penjual) 
        string status = ""; //C (CONFIRM) --- U(UNCONFIRM)

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
                connection();
            }
        }

        protected void btn_regist_pembeli_Click(object sender, EventArgs e)
        {
            connection();
            try
            {
                role = "B"; status = "U";
                if (tx_email.Text == null || tx_nama.Text == null ||
                    tx_notelp.Text == null || tx_pass == null )
                {
                    Label1.Text = "tidak dapat register";
                }
                if (tx_email.Text != "" && tx_nama.Text != "" &&
                     tx_notelp.Text != "" && tx_pass.Text != "" && tx_konpass.Text != "")

                {
                    SqlCommand cmd = new SqlCommand("insert into Person values(@Email, @Nama, @Password, @NoTelp, @Role, @Status)", sqlconn);
                    cmd.Parameters.AddWithValue("@Email", tx_email.Text);
                    cmd.Parameters.AddWithValue("@Nama", tx_nama.Text);
                    cmd.Parameters.AddWithValue("@Password", tx_pass.Text);
                    cmd.Parameters.AddWithValue("@NoTelp", tx_notelp.Text);
                    cmd.Parameters.AddWithValue("@Role", role.ToString());
                    cmd.Parameters.AddWithValue("@Status", status.ToString());
                    cmd.ExecuteNonQuery();

                    //konfirmasi email yang dikirim email user
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("alfirajessica@gmail.com", "@AJS1499");
                    //parameter : email(gmail), password email
                    client.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("alfirajessica@gmail.com");
                    mail.To.Add(tx_email.Text);
                    mail.Subject = "welcome to Shoes";

                  

                    mail.Body = "<br /><a href = '" +
                        Request.Url.AbsoluteUri.Replace("Register.aspx", "login.aspx" +
                        tx_email.Text) + "'>Click here to activate your account.</a>";

                    mail.CC.Add("alfirajessica@gmail.com");
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                    Response.Write("email terkirim");

                    Label1.Text = "berhasil";
                    lb_notif.Text = "Konfirmasi email anda sekarang!";
                    Response.Write("<script>alert('register successful');</script>");
                    reset();
                    //Response.Redirect("login.aspx");
                }
               
            }
            catch (Exception ex)
            {
                lb_notif.Text = "";
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