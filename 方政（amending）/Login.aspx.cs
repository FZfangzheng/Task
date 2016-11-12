using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
   
    Class2 mylogin= new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;

        string password = txtPwd.Text;

        string sql = "select * from login2 where username='" + username + "'and password='" + password + "'";

        try
        {
            DataTable table1 = mylogin.select(sql);

            if (table1 .Rows .Count  > 0)
            {
                string nickname = table1.Rows[0][4].ToString();

                Response.Write("<script>alert('登录成功！');location='Welcome.aspx'</script>");

                Session["name"] = username;

                Session["nickname"] = nickname;
               

            }

            else
            {
                Response.Write("<script>alert('登录失败！')</script>");

            }
          
        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }




    }

}
