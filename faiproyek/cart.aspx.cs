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
    public partial class cart : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email, nama = "";
        string id_sepatu, Id_cart, jumlah, id_detail= "";
        int stokdsepatu, stokskrg = 0;
        object total;
        string idOrder = "";
        string acc_iddetail, accjumlah = "";
        int stok, stok_new;


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
                    cart_details.Visible = false;

                
                    Session["edit"] = null;
                    find_namaUser();
                    datatable_cart();
                    get_sumTotal();
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
           
            id_sepatu = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label6") as Label).Text;
            Id_cart = (GridView1.Rows[e.NewSelectedIndex].FindControl("Label7") as Label).Text;
            Session["edit"] = id_sepatu;
            Response.Redirect("showdetailbarang.aspx?Id_sepatu="+id_sepatu+"&Id_cart="+Id_cart + "&show=edit");
        }

        public void get_sumTotal()
        {
            try
            {
                connection();
                email = Session["email"].ToString();
                SqlCommand cmd = new SqlCommand("select SUM(Total) from Cart where Status='UC' and Email_pembeli='" + email + "'", sqlconn);
                total = cmd.ExecuteScalar();
                sqlconn.Close();

                CultureInfo culture = CultureInfo.GetCultureInfo("id-ID");
                double price_total = Convert.ToDouble(total);
                string result_total = string.Format(culture, "{0:C2}", price_total);
                lb_subtotal.Text = result_total;
                lb_total.Text = result_total;
                lb_subtotalTable.Text = result_total; //di gridview
            }
            catch (Exception ex)
            {
                lb_subtotal.Text = ex.Message;
            }

        }


        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            //memunculkan bagian cart details pembayaran
            cart_details.Visible = true;
            btn_checkout.Visible = false;

            //meghilangkan edit dan delete pada gridview
            foreach (GridViewRow row in GridView1.Rows)
            {               
                Button btnedit = (Button)row.FindControl("Button1");
                Button btndel = (Button)row.FindControl("Button2");
                btnedit.Visible = false;
                btndel.Visible = false;
            }

            //mengubah label subtotal dan total di cart details menjadi hasil (Sum)
            get_sumTotal();
            get_kota();

            
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            //delete -- tidak akan mempengaruhi stok karena kita set stok akan berkurang saaat dia sudah bayar
            id_sepatu = (GridView1.Rows[e.RowIndex].FindControl("Label6") as Label).Text;
            Id_cart = (GridView1.Rows[e.RowIndex].FindControl("Label7") as Label).Text;
            jumlah = (GridView1.Rows[e.RowIndex].FindControl("Label4") as Label).Text;
            id_detail = (GridView1.Rows[e.RowIndex].FindControl("Label8") as Label).Text;
            acc_iddetail = id_detail;
            accjumlah = jumlah;
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("delete from Cart where Id_cart=" + Id_cart + " and Status='UC'", sqlconn);      
                cmd.ExecuteNonQuery();
                sqlconn.Close();
                datatable_cart();
                get_sumTotal();
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.Message);
            }
            datatable_cart();
           
        }

       

        public void datatable_cart()
        {
            connection();
            string cek_cart; Boolean cek = false;
            email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand("", sqlconn);
            cmd.CommandText = "select * from Cart where Status='UC' and Email_pembeli='" + email + "'";          
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                cek_cart = (myReader["Id_cart"].ToString());
                if (cek_cart != "")
                {
                    cek = true;
                }
                else if (cek_cart == null)
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
                adapter.Fill(ds, "Cart");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                sqlconn.Close();
            }
            if (cek == false)
            {
                GridView1.Visible = false;
                lb_subtotalTable.Text = "cart kosong";
                btn_checkout.Visible = false;
            }
          
            sqlconn.Close();
        }

//--------------------------CART DETAILS -------------------------------------//

        public void get_kota()
        {
           
           // getid = Request.QueryString["Id_sepatu"];
            connection();
            SqlCommand cmd = new SqlCommand("select Nama_kota from Kota", sqlconn);
            dl_city.DataSource = cmd.ExecuteReader();
            dl_city.DataTextField = "Nama_kota";
            dl_city.DataValueField = "Nama_kota";
            dl_city.DataBind();
            sqlconn.Close();
        }

        public void get_IdOrder()
        {
            connection();
            SqlCommand get_idorder = new SqlCommand("select top 1 * from H_Order ORDER BY Id_order desc", sqlconn);
            SqlDataReader myReader = null;
            myReader = get_idorder.ExecuteReader();

            while (myReader.Read())
            {
                idOrder = (myReader["Id_order"].ToString());

            }
            sqlconn.Close();
        }

        //men-save data yang di cart ke dlm H_order
        //status -- P (Paid) UP(blm dibayar)
        string idsepatu, idcart, emailseller;
        protected void btn_checkoutPay_Click(object sender, EventArgs e)
        {
           
            DateTime dateTime = DateTime.UtcNow.Date;
            String tglskrg = dateTime.ToString("dd/MM/yyyy");
            get_sumTotal();
            
          
           
            // idcart = idcarttemp.ToString();

            try
            {
                email = Session["email"].ToString();

                ////Ubah dulu status Cart yang dimiliki email tsb
                //connection();
                //SqlCommand cmd_updatecart = new SqlCommand("Update Cart set Status=@Status where Status='UC' and " +
                //    "Email_pembeli='" + email + "'", sqlconn);
                //cmd_updatecart.Parameters.AddWithValue("@Status", "C");
               
                //cmd_updatecart.ExecuteNonQuery();
                //sqlconn.Close();

                //insert ke table H_order
                connection();                
                SqlCommand cmd = new SqlCommand("insert into H_Order values(@Tgl_order, @City, @Address, @Total, @Status, @Email_pembeli, @Email_seller)", sqlconn);
                cmd.Parameters.AddWithValue("@Tgl_order", tglskrg);
                cmd.Parameters.AddWithValue("@City", dl_city.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Address", tx_address.Text);
                cmd.Parameters.AddWithValue("@Total", int.Parse(total.ToString()));
                cmd.Parameters.AddWithValue("@Status", "UP"); //BELUM DIBAYAR
                cmd.Parameters.AddWithValue("@Email_pembeli",email);
                cmd.Parameters.AddWithValue("@Email_seller", "");
                cmd.ExecuteNonQuery();
                sqlconn.Close();

                //SELECT ID_ORDER TADI
                get_IdOrder();


                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lbid_cart = (Label)row.FindControl("Label7");
                    Label lbid_sepatu = (Label)row.FindControl("Label6");
                    idcart = lbid_cart.Text;
                    idsepatu = lbid_sepatu.Text;

                   

                    //select email seller dari table h_sepatu
                    connection();
                    SqlCommand get_emailseller = new SqlCommand("select * From H_sepatu where Id_sepatu="+idsepatu+"", sqlconn);
                    SqlDataReader myReader = null;
                    myReader = get_emailseller.ExecuteReader();
                    while (myReader.Read())
                    {
                        emailseller = (myReader["Email_seller"].ToString());

                    }
                    sqlconn.Close();

                    //update cart milik user yang statusnya udh C, dengan tambahan id_order
                    connection();
                    SqlCommand update_idcart = new SqlCommand("Update Cart set Status=@Status, Id_order=@Id_order, Email_seller=@Email_seller where Id_cart=@Id_cart" +
                       " and Email_pembeli='" + email + "'", sqlconn);
                    update_idcart.Parameters.AddWithValue("@Status", "C");
                    update_idcart.Parameters.AddWithValue("@Id_order", idOrder);
                    update_idcart.Parameters.AddWithValue("@Id_cart", idcart);
                    update_idcart.Parameters.AddWithValue("@Email_seller", emailseller);

                    update_idcart.ExecuteNonQuery();
                    sqlconn.Close();

                    //connection();
                    //SqlCommand update_emailsellerOrder = new SqlCommand("Update Cart set  where Id_cart=@Id_cart" +
                    //   " and Email_pembeli='" + email + "'", sqlconn);
                    //update_emailsellerOrder.Parameters.AddWithValue("@Id_cart", idcart);
                    //update_emailsellerOrder.Parameters.AddWithValue("@Email_seller", emailseller);
                    //update_emailsellerOrder.ExecuteNonQuery();
                    //sqlconn.Close();
                }
                

                //memunculkan modal success order
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(function () {");
                sb.Append(" $('#exampleModalCenter').modal('show');});");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ModelScript", sb.ToString(), false);

            }
            catch (Exception ex)
            {
                lb_subtotal.Text = ex.Message;
            }
           
        }

    
        //link utk melakukan pembayaran... dianggap langsung sukses bayar jika ke link ini 
        //stok berkurang karena link ini
        protected void link_bayar_Click(object sender, EventArgs e)
        {
        
            //mengubah status pada table H_order
            //status menjadi P(paid)

            //sementara link ini utk update status dia sudah bayar
            get_IdOrder();
            connection();
            SqlCommand paid_status = new SqlCommand("Update H_Order set Status=@Status where Id_order="+idOrder+"", sqlconn);
            paid_status.Parameters.AddWithValue("@Status", "P");
            paid_status.ExecuteNonQuery();
            sqlconn.Close();

            connection();
            SqlCommand paid_statuscart = new SqlCommand("Update Cart set Status=@Status where Id_order=" + idOrder + "", sqlconn);
            paid_statuscart.Parameters.AddWithValue("@Status", "P");
            paid_statuscart.ExecuteNonQuery();
            sqlconn.Close();


            //update stock sepatu
            update_stoksepatu();
            Response.Redirect("shop.aspx");
           
        }

        //update stok sepatu
        public void update_stoksepatu()
        {
            //meghilangkan edit dan delete pada gridview
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label lb_iddetail = (Label)row.FindControl("Label8");
                Label lb_jumlah = (Label)row.FindControl("Label4");
                acc_iddetail = lb_iddetail.Text;
                accjumlah = lb_jumlah.Text;

                try
                {
                    connection();

                    SqlCommand cmd = new SqlCommand("select Stok from Dsepatu where Id_detail=" + int.Parse(acc_iddetail) + "", sqlconn);
                    SqlDataReader myReader = null;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        stok = int.Parse((myReader["Stok"].ToString()));

                    }
                    sqlconn.Close();

                }
                catch (Exception ex)
                {

                    lb_subtotal.Text = "atas :" + ex.Message;
                }

                try
                {
                    stok_new = stok - int.Parse(accjumlah);

                    connection();
                    SqlCommand update_stok = new SqlCommand("Update Dsepatu set Stok=@Stok where Id_detail=" + int.Parse(acc_iddetail) + "", sqlconn);
                    update_stok.Parameters.AddWithValue("@Stok", stok_new);
                    update_stok.ExecuteNonQuery();
                    sqlconn.Close();
                }
                catch (Exception ex)
                {

                    lb_subtotal.Text = "stok: " + accjumlah + " bwh " + ex.Message;
                }
            }
           
           
            
           
        }
    }
}