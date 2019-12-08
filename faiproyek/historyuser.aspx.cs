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
    public partial class historyuser : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama = "";
        string id_order;
      
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
                    get_header_history();
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
            id_order = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label1") as Label).Text;
            Label7.Text = id_order;
            get_detail();
        }

        public void get_detail()
        {
            email = Session["email"].ToString();
            connection();
            SqlCommand cmd = new SqlCommand("select * from Cart where Status='C' and Email_pembeli='" + email + "' and Id_order=" + Label7.Text + "", sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            sqlconn.Close();

        }


        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.PageIndex = e.NewPageIndex;
            this.get_detail();
        }

        public void get_header_history()
        {
            connection();
            email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "SELECT * FROM H_Order where Email_pembeli='"+email + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_Order");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlconn.Close();
        }

    }
}