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
                    GetChartData();
                    GetChartTypes();
                    //get_header_history();
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
            //connection();
            //email = Session["email"].ToString();
            //SqlCommand cmd = new SqlCommand("", sqlconn);
            //cmd.CommandText = "SELECT * FROM H_Order where Email_pembeli='" + email + "'";
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "H_Order");

            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
            //sqlconn.Close();
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