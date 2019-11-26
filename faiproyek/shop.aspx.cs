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

        //memunculkan product dalam datalist
        public void product_Datalist()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select H.Id_sepatu, H.Nama_sepatu, P.Nama, H.Jenis_sepatu, H.Gambar, H.Harga " +
                "from Hsepatu H, Person P where H.Email_seller=P.Email", sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Hsepatu");

            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
            sqlconn.Close();

        }
    }
}