using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    Class1 mylogin = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;

        string EnPswdStr = mylogin.md5(txtPwd.Text, 16);

        string password = EnPswdStr;

        string sql = "select * from Login where username='" + username.Replace("'","''") + "'and password='" + password.Replace("'","''") + "'";

        try
        {
            DataTable table1 = mylogin.select(sql);

            if (table1.Rows.Count > 0)
            {
                //生成的验证码被保存到session中
                if (Session["CheckCode"] != null)
                {
                    string checkcode = Session["CheckCode"].ToString();

                    if (this.TextBox1.Text == checkcode)
                    {
                        string nickname = table1.Rows[0][3].ToString();

                        Session["name"] = username;

                        Session["nickname"] = nickname;

                        Response.Write("<script>alert('登录成功！');location='Personal_center.aspx'</script>");

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('验证码输入错误!')", true);
                    }
                }
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