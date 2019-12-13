using System;
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
            if (btn_submitsepatu1.Text == "Update")
            {
                connection();
                try
                {
                    SqlCommand cmd = new SqlCommand("update H_sepatu set Nama_sepatu=@Nama_sepatu, Jenis_Sepatu=@Jenis_Sepatu, Deskripsi=@Deskripsi, Gender=@Gender where Id_sepatu=" + Label1.Text + "", sqlconn);
                    cmd.Parameters.AddWithValue("@Nama_sepatu", tx_namasepatu.Text);
                    cmd.Parameters.AddWithValue("@Jenis_Sepatu", dl_jenissepatu.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Deskripsi", tx_deskripsi.Text);
                    cmd.Parameters.AddWithValue("@Gender", dl_gender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Update berhasil";
                    btn_submitsepatu1.Text = "Submit";
                    datatable();
                    reset();

                }
                catch (Exception ex)
                {

                    Label1.Text = ex.Message.ToString();
                }
                sqlconn.Close();
            }
            else if (btn_submitsepatu1.Text == "Submit")
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
            
          
        }

        protected void tx_namasepatu_TextChanged(object sender, EventArgs e)
        {
            if (btn_submitsepatu1.Text == "Submit")
            {
                Label1.Text = "";
            }
           else if (btn_submitsepatu1.Text == "Update")
            {
                Label1.Text = "";
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            datatable();
        }

        //editt
        protected void GridView2_SelectedIndexChanging1(object sender, GridViewSelectEventArgs e)
        {
            //Label1.Text = "cek";
            category();
            
            Label1.Text = (GridView2.Rows[e.NewSelectedIndex].FindControl("Label1") as Label).Text;

            connection();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from H_sepatu where Id_sepatu=" + Label1.Text + "";
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                tx_namasepatu.Text = (myReader["Nama_sepatu"].ToString());
                dl_gender.SelectedItem.Text = (myReader["Gender"].ToString());
                dl_jenissepatu.SelectedItem.Text = (myReader["Jenis_Sepatu"].ToString());
                tx_deskripsi.Text = (myReader["Deskripsi"].ToString());
                tx_harga.Text = (myReader["Harga"].ToString());
            }
            sqlconn.Close();
            btn_submitsepatu1.Text = "Update";

        }

        //delete data sepatu pilihan
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label1.Text = (GridView2.Rows[e.RowIndex].FindControl("Label1") as Label).Text;

            connection();
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from H_sepatu where Id_sepatu=" + Label1.Text + "", sqlconn);
              
                cmd.ExecuteNonQuery();
                Label1.Text = "Update berhasil";
                btn_submitsepatu1.Text = "Submit";
                datatable();

            }
            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }
            sqlconn.Close();
            reset();
        }

        protected void btn_saveImage_Click(object sender, EventArgs e)
        {
            
        }
    }
}