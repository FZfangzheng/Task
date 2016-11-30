using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Findback : System.Web.UI.Page
{
    Class1 myfind = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnFound_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;

        Session["name2"] = username;

        string phonenumble = txtPho.Text;

        string sql = "select password from Login where username='" + username + "'and phonenumble='" + phonenumble + "'";

        try
        {
            DataTable table1 = myfind.select(sql);

            if (table1.Rows.Count > 0)
            {
                divfoundback1.Visible = false;
                divfoundback4.Visible = true;
            }
            else

                Response.Write("<script>alert('用户名或手机号码错误！')</script>");

        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }

    }

    protected void Question(object sender, EventArgs e)
    {
        divfoundback1.Visible = false;

        divfoundback2.Visible = true;

    }
    protected void BtnFound_Click2(object sender, EventArgs e)
    {
        Random ran = new Random();

        int id = ran.Next(1, 4);

        string name = username.Text;

        Session["name2"] = name;

        string sql1 = "select * from Question where username='" + name + "' and id='" + id + "'";

        DataTable dt = myfind.select(sql1);

        if (dt.Rows.Count > 0)
        {
            question1.Text = dt.Rows[0][2].ToString();

            Session["answer"] = dt.Rows[0][3].ToString();

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
            divfoundback3.Visible = false;
            divfoundback4.Visible = true;
        }
        else
            Response.Write("<script>alert('答案错误！')</script>");
    }

    protected void btnnewpwd_Click(object sender, EventArgs e)
    {
        if(RequiredFieldValidator1.IsValid==true && RequiredFieldValidator2.IsValid==true && CompareValidator1.IsValid==true)
        {
            string username = Session["name2"].ToString();

            string EnPswdStr = myfind.md5(txtPwd.Text, 16);

            string password = EnPswdStr;

            string sql = "update Login set password ='" + password + "' where username ='" + username + "'";

            myfind.store_change(sql);

            Response.Write("<script>alert('修改成功！');location='Login.aspx'</script>");
        }
    }
}