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

    protected void Question(object sender,EventArgs e)
    {
        divfoundback1.Visible = false;

        divfoundback2.Visible = true;

    }
    protected void BtnFound_Click2(object sender,EventArgs e)
    {
        string name = username.Text;

        Session["name2"] = username.Text;

        string sql1 = "select * from Question where username='" + name + "'";

        DataTable dt = myfound.select(sql1);

        if (dt.Rows.Count > 0)
        {
            question1.Text = dt.Rows[0][1].ToString ();

            Session["answer"] = dt.Rows[0][2].ToString();

            divfoundback2.Visible = false;

            divfoundback3.Visible = true;
  
        }
        else
            Response.Write("<script>alert('用户名不正确!')</script>");
  
    }
    protected void BtnFound_Click3(object sender, EventArgs e)
    {
        if (answer.Text == Session["answer"].ToString())
        {
            string name = Session["name2"].ToString();

            string sql = "select password from login2 where username='" + name + "'";

            DataTable table2 = myfound.select(sql);

            string password;

            password = table2.Rows[0][0].ToString();

            Response.Write("<script>alert('成功找回！你的密码是：" + password + "');location='Login.aspx'</script>");
        }
        else
            Response.Write("<script>alert('答案错误！')</script>");
    }
}