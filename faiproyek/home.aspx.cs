﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faiproyek
{
    public partial class home : System.Web.UI.Page
    {
        string namauser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_namaUser.Text = Request.QueryString["nama"];
        }
    }
}