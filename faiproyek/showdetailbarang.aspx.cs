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
        public int getid_detail, hargasepatu, total = 0;
        string getid_detailcart, get_idcart;
        string id_cart = "";
        //utk masukin ke cart
        string status = ""; //terkonfirmasi (C) -- belum dikonfirmasi sama vendornya (UC)

        //keterangan add(dari shop ke showdetailbarang) 
        //keterangan edit (dari cart ke showdetailbarang)
        string show = ""; //add atau edit

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
                    find_namaUser();
                    dl_size.SelectedIndex = -1;
                    dl_color.SelectedIndex = -1;
                    get_Dsepatu_data();
                    get_Hsepatu_data();
                    datatable();

                    if (Session["edit"] != null)
                    {
                        btn_addtocart.Text = "Update Cart";                                         
                        show = Request.QueryString["show"];
                        id_cart = Request.QueryString["Id_cart"];
                        
                        show_data_cart(); //munculin data yg di cart -- warna, size, jumlah yang dipilih sebelumnya
                        datatable();
                    }
                    //else if (Session["edit"] == null)
                    //{

                    //}
                    
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
                //lb_namaUser.Text = nama;
            }
            sqlconn.Close();
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
            //SIZE,

            getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd2 = new SqlCommand("select Size from Dsepatu where Stok > 0 and Id_sepatu=" + getid + " group by Size", sqlconn);
            dl_size.DataSource = cmd2.ExecuteReader();           
            dl_size.DataTextField = "Size";
            dl_size.DataValueField = "Size";
            dl_size.DataBind();
            sqlconn.Close();
        }

        public void get_stok_sepatu()
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
        protected void dl_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_stok_sepatu();
        }

        protected void dl_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            dl_color.Items.Clear();
            dl_color.Items.Add("select color");
            getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd = new SqlCommand("select Warna from Dsepatu where Size=" + dl_size.SelectedValue +" and Id_sepatu=" + getid + " ", sqlconn);
            dl_color.DataSource = cmd.ExecuteReader();
            dl_color.DataTextField = "Warna";
            dl_color.DataValueField = "Warna";
            dl_color.DataBind();
            sqlconn.Close();
           
        }
     
        protected void btn_cancel_Click(object sender, ImageClickEventArgs e)
        {
            //cek dulu apakah session edit != null
            if (Session["edit"] != null)
            {
                Response.Redirect("cart.aspx");
                //hapus session edit, jd pas di view shop hanya ada session dari email saja
                Session["edit"] = null;
            }
            if (Session["edit"] == null)
            {
                Response.Redirect("shop.aspx");
                //hapus session edit, jd pas di view shop hanya ada session dari email saja
              //  Session["edit"] = null;
            }


        }

        public void show_totalprice()
        {
            getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd = new SqlCommand("select Harga" +
                " from H_sepatu where Id_sepatu=" + getid + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                hargasepatu = int.Parse((myReader["Harga"].ToString()));
            }
            sqlconn.Close();

            //digunakan utk insert ke database
            total = int.Parse(tx_jumlah.Text) * hargasepatu;
        }
        protected void tx_jumlah_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(tx_jumlah.Text) > int.Parse(lb_sisanotif.Text))
            {
                lb_total.Text = "Jumlah barang yang diinginkan tidak tersedia";
            }
            else
            {
                show_totalprice();
                //convert total ke rupiah -- hanya show di view saja
                CultureInfo culture = CultureInfo.GetCultureInfo("id-ID");
                double price_total = Convert.ToDouble(total);
                string result_total = string.Format(culture, "{0:C2}", price_total);
                lb_total.Text = result_total;
            }
           

        }

        

      

        //simpan data ke table cart ------ jika berhasil simpan, balik lagi ke shop.aspx       
        protected void btn_addtocart_Click(object sender, EventArgs e)
        {
            show_totalprice(); 
            DateTime dateTime = DateTime.UtcNow.Date;
            String tglskrg = dateTime.ToString("dd/MM/yyyy");
            total = int.Parse(tx_jumlah.Text) * hargasepatu;

            status = "UC";
            getid = Request.QueryString["Id_sepatu"];
            Boolean ada = false;
            email = Session["email"].ToString();

            //cari id detail dulu
            connection();
            SqlCommand cmd_iddetail = new SqlCommand("select Id_detail from Dsepatu where Id_sepatu=" + getid + " and" +
                " Size=" + dl_size.SelectedItem + " and Warna='" + dl_color.SelectedValue + "' and Stok=" + int.Parse(lb_sisanotif.Text) + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd_iddetail.ExecuteReader();
            while (myReader.Read())
            {
                getid_detail = int.Parse((myReader["Id_detail"].ToString()));
            }
          

            //cek apakah ada id_detail yang sama di table cart
            connection();
            try
            {
                SqlCommand cmd_iddetailcart = new SqlCommand("select * from Cart where Status='UC' and Email_pembeli='"+email+"' and Id_detail=" + getid_detail + "", sqlconn);
                SqlDataReader myReadercart = null;
                myReadercart = cmd_iddetailcart.ExecuteReader();

                while (myReadercart.Read())
                {
                    getid_detailcart = (myReadercart["Id_detail"].ToString());
                    get_idcart = (myReadercart["Id_cart"].ToString());
                    if (getid_detailcart == null)
                    {
                        ada = false;
                    }
                    else if (getid_detailcart != "")
                    {
                        ada = true;
                    }
                }
               
                sqlconn.Close();
            }
            catch (Exception ex)
            {

                lb_sisanotif.Text = ex.Message;
            }

            //insert ke table cart sesuai text button text
            //Add to Cart == shop ke showdetailbarang
            //Update Cart == cart ke showdetailbarang -- edit 
            if (btn_addtocart.Text == "Add to Cart")
            {

                try
                {
                    //jika ternyata sepatu yang dimasukkan ke cart sudah pernah sebelumnya dipilih dan ditambahkan ke cart
                    //maka ia mengubah isi cart sebelumnya, namun jumlah tdk akan bertambah (jumlah mengikuti yg baru)
                    if (ada == true)
                    {
                        connection();
                        SqlCommand cmd_updatecart = new SqlCommand("update Cart set Size=@Size, Warna=@Warna, Jumlah=@Jumlah, Total=@Total where Id_cart=" + get_idcart + " and Id_detail=" + getid_detailcart + "", sqlconn);
                        cmd_updatecart.Parameters.AddWithValue("@Size", dl_size.SelectedItem.Text);
                        cmd_updatecart.Parameters.AddWithValue("@Warna", dl_color.SelectedItem.Text);
                        cmd_updatecart.Parameters.AddWithValue("@Jumlah", tx_jumlah.Text);
                        cmd_updatecart.Parameters.AddWithValue("@Total", total.ToString());
                        cmd_updatecart.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                    else if (ada == false)
                    {
                        //simpan data ke table cart 
                        connection();
                        SqlCommand cmd = new SqlCommand("insert into Cart values(@Email_pembeli, @Nama_sepatu, @Size, @Warna, @Jumlah, @Total, @Status, @Id_detail, @Id_sepatu, @Id_order)", sqlconn);
                        cmd.Parameters.AddWithValue("@Email_pembeli", email.ToString());
                        cmd.Parameters.AddWithValue("@Nama_sepatu", lb_namaproduk.Text);
                        cmd.Parameters.AddWithValue("@Size", dl_size.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Warna", dl_color.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Jumlah", tx_jumlah.Text);
                        cmd.Parameters.AddWithValue("@Total", total.ToString());
                        cmd.Parameters.AddWithValue("@Status", status.ToString());
                        cmd.Parameters.AddWithValue("@Id_detail", getid_detail);
                        cmd.Parameters.AddWithValue("@Id_sepatu", getid);
                        cmd.Parameters.AddWithValue("@Id_order", "");
                        cmd.ExecuteNonQuery();
                        sqlconn.Close();
                    }

                    Response.Redirect("shop.aspx");
                }
                catch (Exception ex)
                {
                    lb_deskripsi.Text = ex.Message.ToString();
                }
               
            }

            else if (btn_addtocart.Text == "Update Cart")
            {
                connection();
                try
                {
                    id_cart = Request.QueryString["Id_cart"];

                    SqlCommand cmd1 = new SqlCommand("update Cart set Size=@Size, Warna=@Warna, Jumlah=@Jumlah, Total=@Total where Id_cart=" + id_cart + "", sqlconn);
                    cmd1.Parameters.AddWithValue("@Size", dl_size.SelectedItem.Text);
                    cmd1.Parameters.AddWithValue("@Warna", dl_color.SelectedItem.Text);
                    cmd1.Parameters.AddWithValue("@Jumlah", tx_jumlah.Text);
                    cmd1.Parameters.AddWithValue("@Total", total.ToString());
                    cmd1.ExecuteNonQuery();
                    lb_deskripsi.Text = "Update berhasil";

                    Response.Redirect("cart.aspx");
                }
                catch (Exception ex)
                {

                    lb_deskripsi.Text = ex.Message.ToString();
                }

                sqlconn.Close();
            }


        }

        public void datatable()
        {
            connection();
            getid = Request.QueryString["Id_sepatu"];
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from H_sepatu where Id_sepatu="+getid+"";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "H_sepatu");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            sqlconn.Close();
        }

        //berdasaran isi yang ada di cart sesuai yg dipilih oleh user sat di view cart
        public void show_data_cart()
        {
            connection();
            getid = Request.QueryString["Id_sepatu"];
            id_cart = Request.QueryString["Id_cart"];
            SqlCommand cmd = new SqlCommand("select Size, Warna, Jumlah, Total" +
                " from Cart where Id_sepatu=" + getid + " and Id_cart=" + id_cart + "", sqlconn);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();


            while (myReader.Read())
            {
                CultureInfo culture = CultureInfo.GetCultureInfo("id-ID");
                double price = Convert.ToDouble((myReader["Total"].ToString()));
                string result = string.Format(culture, "{0:C2}", price);
                lb_total.Text = result;

                dl_color.SelectedItem.Text = (myReader["Warna"].ToString());
                dl_size.SelectedItem.Text = (myReader["Size"].ToString());
                tx_jumlah.Text = (myReader["Jumlah"].ToString());
            }
            sqlconn.Close();

            connection();
            SqlCommand get_stok = new SqlCommand("select Stok from Dsepatu where Size=" + dl_size.SelectedValue + 
                " and Warna='"+dl_color.SelectedItem.Text + "' and Id_sepatu="+getid, sqlconn);
           
            SqlDataReader myReaderstok = null;
            myReaderstok = get_stok.ExecuteReader();

            while (myReaderstok.Read())
            {
                lb_sisanotif.Text = (myReaderstok["Stok"].ToString());               
            }
            sqlconn.Close();
        }
    }
}