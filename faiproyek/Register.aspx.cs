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
            tx_captcha.Text = "";
            captcha();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                connection();
                captcha();
            }
            
            
        }

        public void captcha()
        {
            lb_notif.Text = "";
            tx_captcha.Text = "";
            //Untuk random captcha
            Random ra = new Random();
            int noc = ra.Next(6, 10);
            string cap = "";
            int tot = 0;
            do
            {
                int ch = ra.Next(48, 123);
                if ((ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
                {
                    cap = cap + (char)ch;
                    tot++;
                    if (tot == noc)
                    {
                        break;
                    }
                }
            } while (true);
            Label3.Text = cap;
            Label4.Text = Label3.Text;
        }

        public void register_insertDB()
        {
            string email; Boolean cek = false;
            connection();
          
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "SELECT Email from Person where Email='"+tx_email.Text+"'";

            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                email = (myReader["Email"].ToString());
                if (email != "")
                {
                    cek = true;
                }
                else if (email == null)
                {
                    cek = false;
                }
            }
            sqlconn.Close();
            if (cek == true)
            {
                Response.Write("<script>alert('register failed, Email telah digunakan');</script>");
                reset();
            }
            if (cek == false)
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("insert into Person values(@Email, @Nama, @Password, @NoTelp, @Role, @Status)", sqlconn);
                cmd1.Parameters.AddWithValue("@Email", tx_email.Text);
                cmd1.Parameters.AddWithValue("@Nama", tx_nama.Text);
                cmd1.Parameters.AddWithValue("@Password", tx_pass.Text);
                cmd1.Parameters.AddWithValue("@NoTelp", tx_notelp.Text);
                cmd1.Parameters.AddWithValue("@Role", role.ToString());
                cmd1.Parameters.AddWithValue("@Status", status.ToString());
                cmd1.ExecuteNonQuery();
                sqlconn.Close();
            }

            sqlconn.Close();

            
        }

        public void sent_emailkonfirmasi()
        {
            //konfirmasi email yang dikirim email user
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;

            //ini email dan password khusus proyek fai
            client.Credentials = new NetworkCredential("shoesfai@gmail.com", "Fai123FAI");
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("shoesfai@gmail.com");
            mail.To.Add(tx_email.Text);
            mail.Subject = "welcome to Shoes";


            string body = "Hello " + tx_nama.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href=http://localhost:62767/Activation.aspx?email=" + tx_email.Text + "> Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            mail.Body = body;

            //  mail.Body = "COBA AJA";
            mail.CC.Add(tx_email.Text);
            mail.IsBodyHtml = true;
            client.Send(mail);
            
        }

        
        protected void btn_regist_penjual_Click(object sender, EventArgs e)
        {
            //menuju dashboard
            Boolean hasil = false;
            connection();
            try
            {
                role = "S"; status = "U";
                if (tx_captcha.Text == Label3.Text)
                {
                    if (tx_email.Text == null || tx_nama.Text == null ||
                    tx_notelp.Text == null || tx_pass == null)
                    {
                        Label1.Text = "tidak dapat register";
                    }
                    if (tx_email.Text != "" && tx_nama.Text != "" &&
                            tx_notelp.Text != "" && tx_pass.Text != "" && tx_konpass.Text != "")

                    {
                        register_insertDB();
                        sent_emailkonfirmasi();
                        hasil = true;
                    }
                }
                else if (tx_captcha.Text != Label3.Text)
                {
                    lb_notif.Text = " CAPTCHA SALAH";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('register failed, Email telah digunakan');</script>");
                Label1.Text = ex.Message.ToString();
                Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                reset();

            }
            if (hasil == true)
            {
                lb_notif.Text = "register berhasil";
                Response.Write("<script>alert('register successful, Konfirmasi email anda sekarang!');</script>");
                reset();
            }
            sqlconn.Close();
            

        }

        protected void btn_regist_pembeli_Click1(object sender, EventArgs e)
        {
            //menuju dashboard
            Boolean hasil = false;
            connection();
            try
            {
                role = "B"; status = "U";
                if (tx_captcha.Text == Label3.Text)
                {
                    if (tx_email.Text == null || tx_nama.Text == null ||
                    tx_notelp.Text == null || tx_pass == null)
                    {
                        Label1.Text = "tidak dapat register";
                    }
                    if (tx_email.Text != "" && tx_nama.Text != "" &&
                            tx_notelp.Text != "" && tx_pass.Text != "" && tx_konpass.Text != "")

                    {
                        register_insertDB();
                        sent_emailkonfirmasi();
                        hasil = true;
                       
                    }
                }
                else if (tx_captcha.Text != Label3.Text)
                {
                    lb_notif.Text = " CAPTCHA SALAH";
                    captcha();
                        
                }

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
                Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                reset();

            }
            if (hasil == true)
            {
                lb_notif.Text = "register berhasil";
                Response.Write("<script>alert('register successful, Konfirmasi email anda sekarang!');</script>");
                reset();
            }
            sqlconn.Close();
            
        }

        protected void tx_pass_TextChanged(object sender, EventArgs e)
        {
            lb_notif.Text = "";
        }
    }
}