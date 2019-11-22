using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Text;

namespace faiproyek
{
    public partial class CaptchaImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int x, y, x1, y1;
            Bitmap bmp = new Bitmap(300, 50);
            Graphics grp = Graphics.FromImage(bmp);
            grp.Clear(Color.DarkGreen);
            //for (int i=0;i<=500;i++)
            //{
            //    x1 = rnd.Next(300);
            //    y1 = rnd.Next(50);
            //    bmp.SetPixel(x1, y1, Color.FromArgb((rnd.Next(256)), (rnd.Next(256)), (rnd.Next(256))));
            //}
            //grp.TextRenderingHint = 
            //untuk random 6 karakter A-Z
            string txt = "";//untuk simpan hasil random
            //for (int i=0;i<=5;i++)
            //{
            //        txt += ((Char)((int)(rnd.Next(26) + 65))).ToString();
            //}
            int a = rnd.Next(10);
            int b = rnd.Next(10);
            txt = a.ToString() + " + " + b.ToString();
            Session["captcha"] = (a + b).ToString();

            //untuk gambar captcha yang sudah dirandom ke bmp
            x = 20;
            for (int i = 0; i <= 5; i++)
            {
                grp.DrawString(txt.Substring(i, 1), new Font("Arial", 12, FontStyle.Bold), Brushes.White, x, 15);
                x += 30;
            }

            Response.Clear();
            Response.ContentType = "image/png";
            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}