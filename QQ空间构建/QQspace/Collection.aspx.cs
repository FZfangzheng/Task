using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Collection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {

        }
        else
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
    }

    protected void dairy_Click(object sender, EventArgs e)
    {

    }

    protected void say_Click(object sender, EventArgs e)
    {

    }

    protected void say_dairy_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}