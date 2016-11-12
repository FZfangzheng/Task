using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
  
    Class2 myregister = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string nickname = txtnickname.Text;

        string username = txtName.Text;

        string password = txtPwd.Text;

        string phonenumble = txtphonenumble.Text;

        string sql = "insert into login2 values('" + username + "','" + password + "','" + phonenumble + "','"+nickname+"')";

        string sql1 = "select * from login2 where username='" + username + "'";

        DataTable table1 = myregister.select(sql1);

        if ((((RequiredFieldValidator1.IsValid == true && CompareValidator1.IsValid == true) && RequiredFieldValidator2.IsValid == true) && RequiredFieldValidator3.IsValid == true) && RequiredFieldValidator4.IsValid == true) 
        {
            if (txtphonenumble.Text.Length == 11)
            {
                if (txtName.Text.IndexOf(" ") >= 0)
                {
                    Response.Write("<script>alert('用户名请不要输入空格！')</script>");

                }
                else
                {
                    if (txtPwd.Text.IndexOf(" ") >= 0)
                    {
                        Response.Write("<script>alert('密码请不要输入空格！')</script>");
                    }
                    else
                    {
                        try
                        {
                            
                            if (table1 .Rows .Count  == 0)
                            {
                                myregister.store_change(sql);

                                Response.Write("<script>alert('注册成功！');location='Login.aspx'</script>");
                            }
                            else
                                Response.Write("<script>alert('用户名已存在')</script>");
                        }

                        catch (Exception ex)
                        {
                            Response.Write(ex);
                        }
                    }
                }
            }
            else
                Response.Write("<script>alert('手机号码长度不正确！')</script>");
        }




    }

}