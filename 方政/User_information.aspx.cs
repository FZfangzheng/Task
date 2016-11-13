using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_information : System.Web.UI.Page
{
    Class2 change = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"].ToString() == " ")

            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");

        try
        {
            string username = Session["name"].ToString();

            string sql = "select * from login2 where username='" + username + "'";

            DataTable dt = new DataTable();

            dt = change.select(sql);

            RptBook.DataSource = dt;

            RptBook.DataBind();
        }
        catch (Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
   }     
}