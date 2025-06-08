using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox2.Text == "Admin" && TextBox1.Text == "Admin")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Login Successful!!!')", true);
            Session["fname"] = "admin";
            Response.Redirect("manage_users.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Invalid UserName or Password!!!')", true);

        }

        
    }
}