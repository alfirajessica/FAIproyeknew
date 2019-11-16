using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faiproyek
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (tx_password.Text == "user" && tx_email.Text == "user")
            {
                Response.Redirect("home.aspx?nama=" + tx_email.Text);
            }
        }
    }
}