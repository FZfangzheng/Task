using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Person2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {

        }
        else
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
    }
}