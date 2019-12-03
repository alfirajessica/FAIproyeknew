using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace faiproyek
{
    public partial class showdetailbarang : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama = "";
        string getid = "";
        int jumlah, total = 0;

        //utk masukin ke cart
        string status = ""; //terkonfirmasi (C) -- belum dikonfirmasi sama vendornya (UC)

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
                    getid = Request.QueryString["Id_sepatu"];
                    find_namaUser();
                    dl_size.SelectedIndex = -1;
                    dl_color.SelectedIndex = -1;
                    get_Dsepatu_data();
                    get_Hsepatu_data();
                    datatable();
                   
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                   
                }

            }

        }

        public void find_namaUser()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Nama from Person where Email='" + email + "'", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                nama = (myReader["Nama"].ToString());
                //lb_namaUser.Text = nama;
            }
            sqlconn.Close();
        }

        //get header data sepatu dari id_sepatu yang didapatkan
        public void get_Hsepatu_data()
        {
            //nama sepatu.jenis sepatu, deskripsi, harga, gender
            connection();

            SqlCommand cmd = new SqlCommand("select Nama_sepatu, Jenis_sepatu, Deskripsi, Harga, Gender" +
                " from H_sepatu where Id_sepatu=" + getid + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
           
            
            while (myReader.Read())
            {
                CultureInfo culture = CultureInfo.GetCultureInfo("id-ID");
                double price = Convert.ToDouble ((myReader["Harga"].ToString()));
                string result = string.Format(culture, "{0:C2}", price);
                lb_harga.Text = result;
                lb_namaproduk.Text = (myReader["Nama_sepatu"].ToString());
                lb_jenis.Text = (myReader["Jenis_Sepatu"].ToString());
                lb_deskripsi.Text = (myReader["Deskripsi"].ToString());
            }
            sqlconn.Close();
        }

        //get DETAIL data sepatu dari id_sepatu yang didapatkan
        public void get_Dsepatu_data()
        {
            //SIZE, WARNA, STOK
           

            connection();
            SqlCommand cmd2 = new SqlCommand("select Size from Dsepatu where Stok > 0 and Id_sepatu=" + getid + " group by Size", sqlconn);
            dl_size.DataSource = cmd2.ExecuteReader();           
            dl_size.DataTextField = "Size";
            dl_size.DataValueField = "Size";
            dl_size.DataBind();
            sqlconn.Close();
        }

        protected void dl_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd = new SqlCommand("select Stok from Dsepatu where Warna='" + dl_color.SelectedItem.Text + "' and Size=" + dl_size.SelectedValue + " " +
                "and Id_sepatu=" + getid + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();


            while (myReader.Read())
            {
                lb_sisanotif.Text = (myReader["Stok"].ToString());
            }
            sqlconn.Close();
        }

        protected void dl_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            dl_color.Items.Clear();
            dl_color.Items.Add("select color");
            getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd = new SqlCommand("select Warna from Dsepatu where Size=" + dl_size.SelectedValue +" and Id_sepatu=" + getid + " ", sqlconn);
            dl_color.DataSource = cmd.ExecuteReader();
            dl_color.DataTextField = "Warna";
            dl_color.DataValueField = "Warna";
            dl_color.DataBind();
            sqlconn.Close();
           
        }
     
        protected void btn_cancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("shop.aspx");
        }

        
        //simpan data ke table cart ------ jika berhasil simpan, balik lagi ke shop.aspx       
        protected void btn_addtocart_Click(object sender, EventArgs e)
        {
            connection();
            try
            {

                email = Session["email"].ToString();
               
                total = int.Parse(tx_jumlah.Text) * int.Parse(lb_harga.Text);
                status = "UC";
                SqlCommand cmd = new SqlCommand("insert into Cart values(@Email_pembeli, @Nama_sepatu, @Size, @Warna, @Jumlah, @Total, @Tanggal_beli, @Status)", sqlconn);
                cmd.Parameters.AddWithValue("@Email_pembeli", email);
                cmd.Parameters.AddWithValue("@Nama_sepatu", lb_namaproduk.Text);
                cmd.Parameters.AddWithValue("@Size", dl_size.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Warna", dl_color.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Jumlah", tx_jumlah.Text);
                cmd.Parameters.AddWithValue("@Total", total.ToString());
              //  cmd.Parameters.AddWithValue("@Tanggal_beli", dl_gender.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();

             
                datatable();
             
            }
            catch (Exception ex)
            {
               // Label1.Text = ex.Message.ToLower();
            }
            sqlconn.Close();
        }

        public void datatable()
        {
            connection();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from H_sepatu where Id_sepatu="+getid+"";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlconn.Close();
        }

    }
}