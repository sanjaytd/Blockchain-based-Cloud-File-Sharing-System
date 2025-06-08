using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Change_Password : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    string str = null; 
    int up = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = Session["Email"].ToString();
        
        if (TextBox1.Text!="" && TextBox3.Text != "")
        {
            if (TextBox1.Text== TextBox3.Text)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Old Password Cannot be same as New One')", true);
            }
            else
            {
                
                 con.Open();
                str = "select * from users";
                cmd = new SqlCommand(str, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (TextBox1.Text == reader["pass"].ToString())
                    {
                        up = 1;
                    }
                }
                reader.Close();
                con.Close();
                if (up == 1)
                {
                    con.Open();
                    str = "update users set pass='" + TextBox3.Text + "' where emailid = '" + email + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Password"].Value = TextBox3.Text;
                    cmd.ExecuteNonQuery();

                    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Password Updated Successfully')", true);
                    //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "swal", "success('CahngePassword.aspx', 'Successfully Added..!!');", true);
                    con.Close();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Somethig went wrong')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "swal", "error('CahngePassword.aspx', 'Please Enter Correct Password');", true);
                }
            }
        }

    }
}