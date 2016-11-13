using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manager : System.Web.UI.Page
{
    Class2 mylogin = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnManager_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;

        string password = txtPwd.Text;

        string sql = "select * from login1 where username='" + username + "'and password='" + password + "'";

        try
        {
            DataTable table1 = mylogin.select(sql);

            if (table1.Rows.Count > 0)
            {
                Response.Write("<script>alert('登陆成功！');location='Manager_use.aspx'</script>");

                Session["name1"] = username;

            }

            else
            {
                Response.Write("<script>alert('登陆失败！')</script>");

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }

    }
}