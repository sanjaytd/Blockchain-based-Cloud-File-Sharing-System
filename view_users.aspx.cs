using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_users : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0ES5ISQ\SQLEXPRESS;Initial Catalog=CrowdFunding;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
           
                using (SqlCommand cmd1 = new SqlCommand("select uid,uname,address,emailid,contact from [user] "))

                {

                    cmd1.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                    {
                        DataTable dt1 = new DataTable();
                        da.Fill(dt1);
                        if (dt1.Rows.Count > 0 && dt1 != null)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            
                        }
                     

                        con.Close();
                    }
                }


            
        }
        catch
        {

        }

    }


    
}