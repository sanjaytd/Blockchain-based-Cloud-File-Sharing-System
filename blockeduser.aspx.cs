using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blockeduser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0ES5ISQ\SQLEXPRESS;Initial Catalog=CrowdFunding;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "unblock")
        {
            String i2 = Convert.ToString(e.CommandArgument.ToString());
            string up = "update login set Status ='Unblocked' where Uid='" + i2 + "'";
            SqlCommand cmd = new SqlCommand(up, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string del = "delete from blocked where Uid='" + i2 + "'";
            SqlCommand cmd1 = new SqlCommand(del, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            Session["Add"] = "Data";
            
            Response.Redirect("blockeduser.aspx");
         
        }
    }
}