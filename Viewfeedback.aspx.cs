using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Viewfeedback : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         using (SqlCommand cmd1 = new SqlCommand("select fid,feedback,u.name,datetime from feedback f inner join users u on u.uid=f.uid "))

            {

                cmd1.Connection = con;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    if (dt1.Rows.Count > 0 && dt1 != null)
                    {

                        GridView2.DataSource = dt1;
                        GridView2.DataBind();
                    }

                    con.Close();
                }
            }
        }
    }
}