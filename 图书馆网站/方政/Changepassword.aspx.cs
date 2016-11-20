using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Changpassword : System.Web.UI.Page
{
    Class2 mychange = new Class2() ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"].ToString() == " ")

            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
    }
    protected void changepassword(object sender, EventArgs e)
    {
        try
        {
            string password = txtpwd.Text;

            string password1 = txtpwd1.Text;

            string username = Session["name"].ToString();

            string sql = "update login2 set password= '" + password1 + "' where password='" + password + "'";

            string sql1 = "select * from login2 where username='" + username + "'and password='" + password + "'";

            DataTable dt = mychange.select(sql1);

            if (dt.Rows.Count == 0)

                Response.Write("<script>alert('原密码错误！')</script>");

            else
            {
                mychange.store_change(sql);

                Response.Write("<script>alert('修改成功！');location='Login.aspx'</script>");
            }
        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }

    }
}