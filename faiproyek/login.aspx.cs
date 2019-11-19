﻿using System;
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

        public void reset()
        {
            tx_email.Text = "";
            tx_password.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                connection();
                string email = Request.QueryString["email"];
                tx_email.Text = email;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Boolean cek = false;
            String role = "";  //B (pembeli) buyer -- S (seller) penjual
            connection();
            SqlDataAdapter da = new SqlDataAdapter("select * from Person", sqlconn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (tx_email.Text == dt.Rows[i]["Email"].ToString() &&
                    tx_password.Text == dt.Rows[i]["Password"].ToString())
                {
                    cek = true;
                }

            }
            if (cek == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select Role from Person where Email='" + tx_email.Text + "'", sqlconn);
                    SqlDataReader myReader = null;
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        role = (myReader["Role"].ToString());
                    }

                    //untuk customer atau pembeli biasa nanti diarahkan ke home.aspx
                    //seller tidak dapat pergi ke home.aspx karena home.aspx dikhususkan hanya utk pembeli
                    if (role == "B")
                    {
                        Response.Redirect("home.aspx?email=" + tx_email.Text);
                    }

                    //khusus seller nanti tampilannya beda lagi. 
                    if (role == "S")
                    {
                        Response.Redirect("home.aspx?nama=" + tx_email.Text);
                    }
                }
                catch (Exception ex)
                {

                    lb_notif.Text = ex.Message.ToString();
                }
            }
            if (cek == false || tx_email.Text == "" || tx_password.Text == "")
            {
                lb_notif.Text = "cek kembali username dan password anda";
            }

            sqlconn.Close();
            reset();
        }
    }
}