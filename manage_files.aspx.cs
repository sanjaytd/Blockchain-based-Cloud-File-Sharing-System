using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_files : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=SG2NWPLS19SQL-v09.mssql.shr.prod.sin2.secureserver.net;Initial Catalog=Cloudblockhain;Persist Security Info=True;User ID=Cloudblockhain;Password=La7*b7v2");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            gridview();

        }
    }

    protected void DownloadFile(object sender, EventArgs e)
    {
        string fileName = (sender as LinkButton).CommandArgument;

        //FTP Server URL.
        string ftp = "ftps://waws-prod-dm1-143dr.ftp.azurewebsites.windows.net/site/wwwroot/";

        //FTP Folder name. Leave blank if you want to Download file from root folder.
        string ftpFolder = "";

        try
        { 
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder +fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            request.Credentials = new NetworkCredential("Cloudblockhain\\$Cloudblockhain", "N5vt7fhdFQp1PobJQB5qF8mAEacqZo3x8olP90yF59gbL6hhYTrLN41zeCDB");
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (MemoryStream stream = new MemoryStream())
            {
                //Download the File.
                response.GetResponseStream().CopyTo(stream);
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }
        catch (WebException ex)
        {
            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        }
    }

    protected void btnregister_Click(object sender, EventArgs e)
    {

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            ImageButton b = (ImageButton)sender;

            string Cid = b.CommandArgument;
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from product where pid='" + Cid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Product Deleted Successfully !')", true);

        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from product where pid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('Product Deleted Successfully !')", true);
        Response.Redirect("Manage_Products.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        Session["fid"] = Cid;

        Response.Redirect("~/add_file.aspx?pid=" + Cid.Trim() + "&status=edit");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        Session["fid"] = Cid;

        Response.Redirect("~/add_file.aspx?pid=" + Cid.Trim() + "&status=view");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;

        string Cid = b.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from files where fid='" + Cid + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype()", "alert('File Deleted Successfully !')", true);
        Response.Redirect("Manage_files.aspx");
    }

    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("add_file.aspx");
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
       Button b = (Button)sender;

        string Cid = b.CommandArgument;
        Response.Redirect("Allow_access.aspx?fid="+Cid+"");

    }

    protected void lnkrevoke_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        string Cid = b.CommandArgument;
        Response.Redirect("Revoke_access.aspx?fid="+ Cid+"");
    }

    protected void gridview()
    {
        string q = "";
        if (q == "")
        {
            q = "select top 10 fid,filename,type,size,content,prehash,path,description from files ";

        }
        else
        {
            q = "select  fid,filename,type,size,content,prehash,path,description from files where (filename'%"+TextBox1.Text+"%' and type like'%"+TextBox1.Text+"%')";

        }

        SqlDataAdapter da = new SqlDataAdapter(q, con);
        DataTable dt2 = new DataTable();
        da.Fill(dt2);

        if (dt2.Rows.Count > 0)
        {
            dt2.Columns.Add("isManupilated");
            string blockans = "";
            List<Blocklist> blocklist = getBlockList();
            for (int z = 0; z < blocklist.Count; z++)
            {
                Blocklist block1 = blocklist[z];
                DataRow row = dt2.Rows[z];
                Block blocks = new Block();
                blocks.gethash(block1.fid, block1.filename,block1.size,block1.contents,block1.previoushash);
                string block1hash = blocks.getFinalBlock();

                if (block1hash == block1.block)
                {
                    blockans = "Match\n";
                    row["isManupilated"] = "No";
                    

                }
                else
                {
                    blockans = "Not Match\n";
                    row["isManupilated"] = "Yes";
                }

            }
            string isManipulate = blockans;
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            GridView2.Visible = true;

        }
        else
        {


            GridView2.Visible = false;
        }

    }

    public List<Blocklist> getBlockList()
    {
        List<Blocklist> blocklist = new List<Blocklist>();
        DataTable dt = new DataTable("Blocklist");

        string q = "";
        if (q == "")
        {
            q = "select top 10 fid,filename,type,size,content,prehash,path,description,currhash from files";

        }
        else
        {
            q = "select  fid,filename,type,size,content,prehash,path,description,currhash from files where (filename'%" + TextBox1.Text + "%' and type like'%" + TextBox1.Text + "%')";

        }
        SqlDataAdapter da = new SqlDataAdapter(q, con);
        da.Fill(dt);

        int count = dt.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            Blocklist blst = new Blocklist();
            blst.fid = dt.Rows[i]["fid"].ToString();
           blst.filename = dt.Rows[i]["filename"].ToString();
            blst.type = dt.Rows[i]["type"].ToString();
            blst.size = dt.Rows[i]["size"].ToString();
            blst.contents = dt.Rows[i]["content"].ToString();
               blst.previoushash = dt.Rows[i]["prehash"].ToString();
            blst.block= dt.Rows[i]["currhash"].ToString();
            blocklist.Add(blst);
        }

        return blocklist;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        gridview();
    }
}