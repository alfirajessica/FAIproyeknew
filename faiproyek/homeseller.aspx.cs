using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace faiproyek
{
    public partial class homeseller : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama, id_order, idcart = "";

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
                    GetChartData();
                    GetChartTypes();

                    get_header_history();
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
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
                lb_namauser1.Text = nama;
               // lb_namauser2.Text = nama;
            }

            sqlconn.Close();
        }

        //table pesanan
        public void get_header_history()
        {
            string Idorder; Boolean cek = false;
            connection();
            email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "SELECT HO.Id_order, HO.Tgl_order, HO.City, HO.Address, HO.Email_pembeli, C.Status, HO.Total, C.Id_cart FROM H_Order HO, Cart C where HO.Email_pembeli=C.Email_pembeli and C.Email_seller='"+email+"'";

            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Idorder = (myReader["Id_order"].ToString());
                if (Idorder != "")
                {
                    cek = true;
                }
                else if (Idorder == null)
                {
                    cek = false;
                }
            }
            sqlconn.Close();
            if (cek == true)
            {
                connection();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "H_Order");

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                sqlconn.Close();
            }
            if (cek == false)
            {
                GridView1.Visible = false;
                //string script = "alert(\"Tidak ada history!\");";
                //ScriptManager.RegisterStartupScript(this, GetType(),
                //                      "ServerControlScript", script, true);
                Label7.Text = "Tidak Ada Pesanan";
            }

            sqlconn.Close();
           
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            id_order = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label1") as Label).Text;
            Label7.Text = id_order;
            Label7.Visible = false;
            get_detail();

            GetChartData();
            GetChartTypes();
        }
        public void get_detail()
        {
            email = Session["email"].ToString();
         
            connection();
            SqlCommand cmd = new SqlCommand("select * from Cart where Email_seller='" + email + "' and Id_order=" + Label7.Text + "", sqlconn);
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //update status di Cart dari P(Paid) jd Send (status di vendor)
            id_order = (GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text;
            idcart = (GridView1.Rows[e.RowIndex].FindControl("Label7") as Label).Text;

            email = Session["email"].ToString();
            connection();
            SqlCommand cmd = new SqlCommand("Update Cart set Status=@Status where Id_order=" + id_order + " and Id_cart="+idcart+"", sqlconn);
            cmd.Parameters.AddWithValue("@Status", "S"); //send
            cmd.ExecuteNonQuery();
            sqlconn.Close();

          
            //kirim bukti pengiriman atau bukti pembelian ke email pembeli
            
            get_header_history();
            GetChartData();
            GetChartTypes();
        }

        //chart 
        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                ddlChart.Items.Add(li);
            }
        }

        

        private void GetChartData()
        {
            connection();
            email = Session["email"].ToString();
            //SqlCommand cmd = new SqlCommand("GetPrice", sqlconn);
            //cmd.CommandType = CommandType.StoredProcedure;

            SqlCommand cmd = new SqlCommand("select Nama_Sepatu, Harga from H_sepatu where Email_seller='"+email+"'", sqlconn);
            SqlDataReader rdr = cmd.ExecuteReader();
            // Retrieve the Series to which we want to add DataPoints  
            Series series = chart_category.Series["Series1"];
            // Loop thru each Student record  
            while (rdr.Read())
            {
                // Add X and Y values using AddXY() method  
                series.Points.AddXY(rdr["Nama_sepatu"].ToString(),
                rdr["Harga"]);
            }
            sqlconn.Close();
        }

       

        protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call Get ChartData() method when the user select a different chart type  
            GetChartData();
            this.chart_category.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChart.SelectedValue);
        }

    }
}