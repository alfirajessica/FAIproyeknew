﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace faiproyek
{
    public partial class tambahbarangseller : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama = "";

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
                if (Session["email"] != null)
                {
                    email = Session["email"].ToString();
                    find_namaUser();
                    datatable();
                    category();
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
        public void reset()
        {
            tx_deskripsi.Text = "";
            tx_harga.Text = "";
            tx_namasepatu.Text = "";
            dl_gender.SelectedIndex = -1;
            dl_jenissepatu.SelectedIndex = -1;
        }
        //function utk menemukan nama user setelah user melakukan login
        //nama user akan ditampilkan di bagian paling kanan
        public void find_namaUser()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Nama from Person where Email='" + email + "'", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                nama = (myReader["Nama"].ToString());
                lb_namauser1.Text = nama;
                // lb_namauser2.Text = nama;
            }

            sqlconn.Close();
        }


        //read semua kategori yanng ada pada table category
        public void category()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Id_category, Nama_category from Category", sqlconn);
            dl_jenissepatu.DataSource = cmd.ExecuteReader();
            dl_jenissepatu.DataTextField = "Nama_category";
            dl_jenissepatu.DataValueField = "Id_category";
            dl_jenissepatu.DataBind();
            sqlconn.Close();

        }

       
        protected void btn_submitsepatu1_Click(object sender, EventArgs e)
        {

            //Condition to check if the file uploaded or not
            if (FileUpload1.HasFile)
            {
                //getting length of uploaded file
                int length = FileUpload1.PostedFile.ContentLength;
                //create a byte array to store the binary image data
                byte[] imgbyte = new byte[length];
                //store the currently selected file in memeory
                HttpPostedFile img = FileUpload1.PostedFile;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);

                connection();
                try
                {

                    email = Session["email"].ToString();
                    SqlCommand cmd = new SqlCommand("insert into H_sepatu values(@Email_seller, @Nama_sepatu, @Jenis_sepatu, @Deskripsi, @Gambar, @Harga, @Gender)", sqlconn);
                    cmd.Parameters.AddWithValue("@Email_seller", email);
                    cmd.Parameters.AddWithValue("@Nama_sepatu", tx_namasepatu.Text);
                    cmd.Parameters.AddWithValue("@Jenis_sepatu", dl_jenissepatu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Deskripsi", tx_deskripsi.Text);
                    cmd.Parameters.AddWithValue("@Harga", tx_harga.Text);
                    cmd.Parameters.Add("@Gambar", SqlDbType.Image).Value = imgbyte;
                    cmd.Parameters.AddWithValue("@Gender", dl_gender.SelectedItem.Text);
                    cmd.ExecuteNonQuery();

                    Label1.Text = "Uploaded successfully";
                    datatable();
                    reset();
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message.ToLower();
                }
                sqlconn.Close();
            }
            else
            {
                Label1.Text = "gagal";
            }
           
        }

        public void dataSubmitsepatu()
        {

            connection();
            SqlCommand cmd = new SqlCommand("select top 1 * from H_sepatu order by Id_sepatu desc", sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            sqlconn.Close();
        }

        public void datatable()
        {
            connection();
            email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from H_sepatu where Email_seller='"+email+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            sqlconn.Close();
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
            string Id_sepatu, Nama_sepatu, Jenis_sepatu, Deskripsi = "";
            Id_sepatu = (GridView2.Rows[e.NewSelectedIndex].FindControl("Label1") as Label).Text;
            Nama_sepatu = (GridView2.Rows[e.NewSelectedIndex].FindControl("Label3") as Label).Text;
            Jenis_sepatu = (GridView2.Rows[e.NewSelectedIndex].FindControl("Label4") as Label).Text;
            Deskripsi = (GridView2.Rows[e.NewSelectedIndex].FindControl("Label5") as Label).Text;

            tx_deskripsi.Text = Deskripsi.ToString();
            tx_namasepatu.Text = Nama_sepatu.ToString();
            dl_jenissepatu.SelectedItem.Text = Jenis_sepatu.ToString();
            lb_idsepatu.Text = Id_sepatu.ToString();
        }

        protected void tx_namasepatu_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void btn_saveImage_Click(object sender, EventArgs e)
        {
            
        }
    }
}