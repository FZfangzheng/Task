using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Foundback : System.Web.UI.Page
{
    Class2 myfound = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected  void BtnFound_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;

        string phonenumble = txtPho.Text;

        string sql = "select password from login2 where username='" + username + "'and phonenumble='" + phonenumble + "'";

        try
        {
            DataTable table1 = myfound.select(sql);

            string password;

            if (table1.Rows.Count > 0)
            {
                password = table1.Rows[0][0].ToString();

                Response.Write("<script>alert('成功找回！你的密码是：" + password + "');location='Login.aspx'</script>");
            }
            else

                Response.Write("<script>alert('用户名或手机号码错误！')</script>");

        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }

    }
}