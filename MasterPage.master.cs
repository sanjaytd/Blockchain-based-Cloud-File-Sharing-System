﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["fname"]) == "admin")
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;

        }
        else if (Convert.ToString(Session["fname"]) == "user")
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;

        }
        else
        {
          
            Panel3.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
        }
    }
  
}
