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
    public partial class shop : System.Web.UI.Page
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
                    product_Datalist();

                    // isi filter
                    category();
                    get_warna();

                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                    //find_namaUser();
                    //product_Datalist();
                }

            }
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
                lb_namaUser.Text = nama;
            }
            sqlconn.Close();
        }

        protected void dl_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter_category();
        }
        protected void dl_price_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter_price();
        }
        protected void dl_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter_gender();
        }

        //memunculkan product dalam datalist
        public void product_Datalist()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
                "from H_sepatu H, Person P where H.Email_seller=P.Email", sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
            sqlconn.Close();
        }

        public void category()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Id_category, Nama_category from Category", sqlconn);
            dl_category.DataSource = cmd.ExecuteReader();
            dl_category.DataTextField = "Nama_category";
            dl_category.DataValueField = "Id_category";
            dl_category.DataBind();
            sqlconn.Close();
        }

        //get semua warna dari table warna
        public void get_warna()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Id_warna, Nama_warna from Warna", sqlconn);
            dl_warnasepatu.DataSource = cmd.ExecuteReader();
            dl_warnasepatu.DataTextField = "Nama_warna";
            dl_warnasepatu.DataValueField = "Id_warna";
            dl_warnasepatu.DataBind();
            sqlconn.Close();
        }

        
        //get per filter price sepatu
        public void filter_price()
        {
           
            if (dl_price.SelectedIndex == 0)
            {
                connection();
                SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
                   "from H_sepatu H, Person P where H.Email_seller=P.Email and H.Harga >=" + 100000 + "and H.Harga < " + 1000000 + "", sqlconn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "H_sepatu");

                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
                sqlconn.Close();
            }

            if (dl_price.SelectedIndex == 1)
            {
                connection();
                SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
                   "from H_sepatu H, Person P where H.Email_seller=P.Email and H.Harga >=" + 1000000 + "and H.Harga < " + 3000000 + "", sqlconn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "H_sepatu");

                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
                sqlconn.Close();
            }

            if (dl_price.SelectedIndex == 2)
            {
                connection();
                SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
                   "from H_sepatu H, Person P where H.Email_seller=P.Email and H.Harga >=" + 3000000  + "", sqlconn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "H_sepatu");

                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
                sqlconn.Close();
            }
        }

       

        //get per filter gender
        public void filter_category()
        {
            string cat = dl_category.SelectedItem.Text;
            connection();
            SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
               "from H_sepatu H, Person P where H.Email_seller=P.Email and H.Jenis_sepatu='" + cat+"'", sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
            sqlconn.Close();
        }

       

        public void filter_gender()
        {
            string gender = dl_gender.SelectedItem.ToString();
                connection();
                SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga, H.Gender " +
                   "from H_sepatu H, Person P where H.Email_seller=P.Email and H.Gender='"+gender + "'", sqlconn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "H_sepatu");

                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
                sqlconn.Close();
            
        }
    }
}