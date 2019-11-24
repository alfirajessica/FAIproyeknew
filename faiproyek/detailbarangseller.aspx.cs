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
    public partial class detailbarangseller : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama, deskripsi = "";

        //simpan data sementara edit
        string id_detail, size, warna, stok;

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
                    detail_barang_false();
                    list_sepatu();
                }
                else if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                }
               
            }
        }

        protected void dl_daftarsepatu_SelectedIndexChanged(object sender, EventArgs e)
        {
            detail_Hsepatu();
            btn_ok.Enabled = true;
            lb_notif1.Visible = true;
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            detail_barang_true();
        }

        protected void btn_pilihbrglain_Click(object sender, EventArgs e)
        {
            detail_barang_false();
            reset();
        }

        protected void btn_addDetail_Click(object sender, EventArgs e)
        {
            connection();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Dsepatu values (@Id_sepatu, @Size, @Warna, @Stok)", sqlconn);
                cmd.Parameters.AddWithValue("@Id_sepatu", dl_daftarsepatu.SelectedValue);
                cmd.Parameters.AddWithValue("@Size", tx_sizesepatu.Text);
                cmd.Parameters.AddWithValue("@Warna", dl_warnasepatu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Stok", tx_stoksepatu.Text);
                cmd.ExecuteNonQuery();
                lb_notif2.Text = "berhasil tambah detail";
            }
            catch (Exception ex)
            {

                lb_notif2.Text = ex.Message.ToString();
            }

            sqlconn.Close();
            getData_Dsepatu();
            reset();
            lb_notif3.Visible = false;
        }

        //berfungsi pada button action - edit
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btn_update.Visible = true;
            lb_notif2.Visible = false;
            lb_notif3.Visible = true;
            lb_notif3.Text = "Yakin ingin update detail barang ini?";
            btn_addDetail.Visible = false;

            
            id_detail = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label1") as Label).Text;
            size = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label3") as Label).Text;
            warna = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label4") as Label).Text;
            stok = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label5") as Label).Text;

            lb_notif2.Text = id_detail;
           
            tx_sizesepatu.Text = size;
            tx_stoksepatu.Text = stok;
            dl_warnasepatu.SelectedValue = warna;

        }

        protected void tx_stoksepatu_TextChanged(object sender, EventArgs e)
        {
            lb_notif3.Visible = true;
        }

        //update detail barang
        protected void btn_update_Click(object sender, EventArgs e)
        {
            connection();
            try
            {
                SqlCommand cmd = new SqlCommand("update Dsepatu set Size=@Size, Warna=@Warna, Stok=@Stok where Id_detail=" + lb_notif2.Text + "", sqlconn);
                cmd.Parameters.AddWithValue("@Size", tx_sizesepatu.Text);
                cmd.Parameters.AddWithValue("@Warna", dl_warnasepatu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Stok", tx_stoksepatu.Text);
                cmd.ExecuteNonQuery();
                lb_notif2.Text = "Update berhasil";
                
            }
            catch (Exception ex)
            {

                lb_notif2.Text = ex.Message.ToString();
            }
            sqlconn.Close();
            getData_Dsepatu();
            reset();
            lb_notif3.Visible = false;
            btn_addDetail.Visible = true;
            btn_update.Visible = false;
        }

        //delete detail barang
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            id_detail = (GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text;

            connection();
            SqlCommand cmd = new SqlCommand("delete from Dsepatu where Id_detail=" + id_detail + "", sqlconn);
            cmd.ExecuteNonQuery();
            sqlconn.Close();

            getData_Dsepatu();
        }

        //--------------------------------------------------------------------------------------------//
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
            }

            sqlconn.Close();
        }

        public void reset()
        {
            tx_sizesepatu.Text = "";
            tx_stoksepatu.Text = "";
            dl_warnasepatu.SelectedIndex = -1;
        }

        

        //untk daftar sepatu yang ada di dropdownlist
        public void list_sepatu()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select Id_sepatu, Nama_sepatu from Hsepatu where Email_seller='" + email + "'", sqlconn);

            dl_daftarsepatu.DataSource = cmd.ExecuteReader();
            dl_daftarsepatu.DataTextField = "Nama_sepatu";
            dl_daftarsepatu.DataValueField = "Id_sepatu";
            dl_daftarsepatu.DataBind();

            sqlconn.Close();
            
        }

        //untuk menampilkan detail Hsepatu dari sepatu yang diplih
        public void detail_Hsepatu()
        {
            string valueId = dl_daftarsepatu.SelectedValue.ToString();
            Label1.Text = valueId.ToString();

            connection();
            SqlCommand cmd = new SqlCommand("select Deskripsi from Hsepatu where Id_sepatu="+ dl_daftarsepatu.SelectedValue + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                deskripsi = (myReader["Deskripsi"].ToString());
                lb_deskripsi.Text = deskripsi;
            }

            sqlconn.Close(); getData_Dsepatu();
        }

        

        //saat pertama kali user membuka halaman detail, 
        //bagian detail barang akan enabled false
        public void detail_barang_false()
        {
            tx_sizesepatu.Enabled = false;
            tx_stoksepatu.Enabled = false;
            dl_warnasepatu.Enabled = false;
            dl_warnasepatu.SelectedIndex = -1;
            btn_addDetail.Enabled = false;
            btn_update.Visible = false;
            lb_notif2.Visible = false;
            lb_notif3.Visible = false;

            btn_pilihbrglain.Visible = false;
            Label1.Enabled = true;
            lb_deskripsi.Enabled = true;
            dl_daftarsepatu.Enabled = true;
            btn_ok.Enabled = false;
            lb_notif1.Visible = false;

        }

       






        //jika user telah memilih barang mana yang mau ditambahkan detailnya
        //detail akan enabled true
        //pilih barang akan enabled false
        public void detail_barang_true()
        {
            tx_sizesepatu.Enabled = true;
            tx_stoksepatu.Enabled = true;
            dl_warnasepatu.Enabled = true;
            btn_addDetail.Enabled = true;
            btn_update.Visible = false;
            lb_notif2.Visible = true;
            lb_notif3.Visible = true;

            btn_pilihbrglain.Visible = true;
            Label1.Enabled = false;
            lb_deskripsi.Enabled = false;
            dl_daftarsepatu.Enabled = false;
            btn_ok.Visible = false;
            lb_notif1.Visible = false;
            
        }


        //utk ngeload jika pada id_sepatu tsb telah memiliki detail sepatu
        public void getData_Dsepatu()
        {
            connection();
            SqlCommand cmd = new SqlCommand("select * from Dsepatu WHERE Id_sepatu="+dl_daftarsepatu.SelectedValue+"", sqlconn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Hsepatu");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlconn.Close();
        }
    }
}