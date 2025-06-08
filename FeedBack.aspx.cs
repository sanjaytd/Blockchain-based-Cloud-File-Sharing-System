using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeedBack : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;string fid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string com = "select top 1 fid From feedback ORDER BY fid Desc;";
        con.Open();
        cmd = new SqlCommand(com, con);
        object count = cmd.ExecuteScalar();
        if (count != null)
        {
            int i = Convert.ToInt32(count);
            i++;
            fid = i.ToString();
           
        }
        else
        {
       fid= "1";
        
        }
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into feedback(fid,feedback,uid,datetime)  values('"+fid+"','"+TextBox1.Text+"','"+Session["uid"]+"','"+DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")+"')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgtype()", "alert('Feedback Added Successfully'); window.location='myprofile.aspx';", true);

    }
}