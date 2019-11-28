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
                    dl_size.SelectedIndex = -1;
                    dl_color.SelectedIndex = -1;
                    get_Dsepatu_data();
                    get_Hsepatu_data();
                   
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                   
                }

            }

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
            getid = Request.QueryString["Id_sepatu"];
            connection();
                SqlCommand cmd = new SqlCommand("select Warna, Size from Dsepatu where Size=" + dl_size.SelectedValue +" and Id_sepatu=" + getid + " ", sqlconn);
                dl_color.DataSource = cmd.ExecuteReader();
                dl_color.DataTextField = "Warna";
                dl_color.DataValueField = "Warna";
                dl_color.DataBind();
                sqlconn.Close();
           
        }


        //untuk cek stok ada atau tidak
        public void cek_stok()
        {
            if (dl_size.SelectedIndex >= 0 && dl_color.SelectedIndex >= 0)
            {
                
            }
        }

    }
}