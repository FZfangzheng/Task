using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_use : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["name1"].ToString() != " ")
            {
                string username = Session["name1"].ToString();

                lbname.Text = username;
            }
            else
                Response.Write("<script>alert('尚未登录');location='manager.aspx'</script>");
        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='manager.aspx'</script>");
        }
    }

    protected void exit (object sender, EventArgs e)
    {
        Session["name1"] = " ";
        Response.Write("<script>window.location='manager.aspx'</script>");
    }
}