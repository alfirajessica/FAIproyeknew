using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Configuration;

namespace faiproyek
{
    public partial class shop : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama = "";
        string getid = "";
        //PAGING
        int PageSize = 9;
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
                   // get_warna();
                    this.GetCustomersPageWise(1);

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
        //public void get_warna()
        //{
        //    connection();
        //    SqlCommand cmd = new SqlCommand("select Id_warna, Nama_warna from Warna", sqlconn);
        //    dl_warnasepatu.DataSource = cmd.ExecuteReader();
        //    dl_warnasepatu.DataTextField = "Nama_warna";
        //    dl_warnasepatu.DataValueField = "Id_warna";
        //    dl_warnasepatu.DataBind();
        //    sqlconn.Close();
        //}

        //------------------ paging ------------------------------------------------------//
        private void GetCustomersPageWise(int pageIndex)
        {
            connection();
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", sqlconn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection();
                    IDataReader idr = cmd.ExecuteReader();
                    DataList1.DataSource = idr;
                    DataList1.DataBind();
                    idr.Close();
                    sqlconn.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("First", "1"));
                
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("Last", pageCount.ToString()));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCustomersPageWise(pageIndex);
        }

        //------------------ paging end ------------------------------------------------------//



        //------------------ FILTER ------------------------------------------------------//

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            product_Datalist();
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
        //------------------ END FILTER ------------------------------------------------------//

    }
}