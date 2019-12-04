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
    public partial class cart : System.Web.UI.Page
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
                    Session["edit"] = null;
                    find_namaUser();
                    datatable_cart();
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
                lb_namaUser.Text = nama;
            }

            sqlconn.Close();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id_sepatu, Id_cart = "";
            id_sepatu = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label6") as Label).Text;
            Id_cart = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label7") as Label).Text;
            Session["edit"] = id_sepatu;
            Response.Redirect("showdetailbarang.aspx?Id_sepatu="+id_sepatu+"&Id_cart="+Id_cart + "&show=edit");
        }

        public void datatable_cart()
        {
            connection();
            
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from Cart where Email_pembeli='" + email + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Cart");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlconn.Close();
        }
    }
}