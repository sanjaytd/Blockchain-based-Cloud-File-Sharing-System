using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class user_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["status"] == "success")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('RegisteRed Successfully !!  Login From Here.')", true);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlCommand cmd;
        SqlDataReader dr;
        con.Open();
        string email = TextBox1.Text;
        string password = TextBox2.Text;
        //SqlDataAdapter da = new SqlDataAdapter("SELECT uid,name,contact,address,emailid,pass  from users  where emailid='" + TextBox1.Text + "'", con);
        SqlDataAdapter da = new SqlDataAdapter("SELECT uid from users where  emailid='" + TextBox1.Text + "' and pass = '" + TextBox2.Text+"'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string id = dt.Rows[0][0].ToString();
            Session["fname"] = "user";
            Session["Login"] = "Yes";
            Session["uid"] = id;
            Session["Email"] = email;
            Session["Password"] = password;
            Response.Redirect("myprofile.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('Invalid Login Data!!!')", true);
            //Response.Redirect("Login.aspx");
        }

        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Session["fname"] = "user";
        //    if (TextBox2.Text == ds.Tables[0].Rows[0][5].ToString())
        //    {
        //        Session["uid"] = ds.Tables[0].Rows[0][0].ToString();
        //        Session["cname"] = ds.Tables[0].Rows[0][1].ToString();
        //        Session["caddress"] = ds.Tables[0].Rows[0][3].ToString();
        //        Session["emailid"] = ds.Tables[0].Rows[0][4].ToString();
        //        Session["password"] = ds.Tables[0].Rows[0][4].ToString();
        //        Session["contact"] = ds.Tables[0].Rows[0][2].ToString();
        //         Response.Redirect("myprofile.aspx");


        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Invalid Password!!!')", true);

        //    }
        //}
        //else
        //{
        //    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Invalid Username!!!')", true);
        //}
        con.Close();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}