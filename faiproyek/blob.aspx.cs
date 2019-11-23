using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//yang dibutuhkan untuk merubah bytes jd image
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace faiproyek
{
    public partial class blob : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\shoesDatabase.mdf;Integrated Security=True";
        SqlConnection sqlconn;
        string email;

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
            }

            email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand("select foto from Hsepatu where Email=@Email", sqlconn);
            cmd.Parameters.AddWithValue("@Email", email);
            try
            {

                Object temp = (cmd.ExecuteScalar());
                byte[] temp1 = (byte[])temp;
                Bitmap bmp = new Bitmap(new MemoryStream(temp1));
                //merubah ukuran bmp menjadi 100x100 disimpan di bmp2
                Bitmap bmp2 = new Bitmap(bmp, 100, 100);
                MemoryStream io = new MemoryStream();
                bmp2.Save(io, ImageFormat.Png);


                // Output the content of the buffer to the browser
                Response.Clear();
                Response.ContentType = "image/png";
                Response.BinaryWrite(io.GetBuffer());
            }

            catch
            {
                //jika di database null
                Bitmap bmp = new Bitmap(Server.MapPath("th.jpg"));
                Bitmap bmp2 = new Bitmap(bmp, 100, 100);
                MemoryStream io = new MemoryStream();
                bmp2.Save(io, ImageFormat.Png);
                Response.Clear();
                Response.ContentType = "image/png";
                Response.BinaryWrite(io.GetBuffer());
            }
        }
    }
}