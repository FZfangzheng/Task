using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    Class1 myregister = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        int a = 0;

        string username="1";

        DataTable table1 = new DataTable();

        Random ran = new Random();

        while (a == 0)
        {
            username = Convert.ToString(ran.Next(100000000, 1000000000));

            string sql1 = "select * from Login where username='" + username + "'";

            table1 = myregister.select(sql1);

            if (table1.Rows.Count == 0)
                a = 1;
        }

        string EnPswdStr = myregister.md5(txtPwd.Text, 16);

        string nickname = txtnickname.Text;

        string location = txtlocation.Text;

        string password = EnPswdStr;

        string sex = radsex.SelectedValue;

        string age = txtage.Text;

        string phonenumble = txtphonenumble.Text;

        string question1 = DropDownList.SelectedValue;

        string answer1 = txtanswer.Text;

        string question2 = DropDownList1.Text;

        string answer2 = txtanswer1.Text;

        string question3 = DropDownList2.Text;

        string answer3 = txtanswer2.Text;

        string sql = "insert into Login(username,password,nickname,sex,age,location,phonenumble) values('" + username + "','" + password + "','" + nickname + "','" + sex + "','" + age + "','" + location + "','" + phonenumble + "')";

        string sql2 = "insert into Question values(1,'" + username + "','" + question1 + "','" + answer1 + "')";

        string sql3 = "insert into Question values(2,'" + username + "','" + question2 + "','" + answer2 + "')";

        string sql4 = "insert into Question values(3,'" + username + "','" + question3 + "','" + answer3 + "')";

        if (((((( CompareValidator1.IsValid == true && RequiredFieldValidator2.IsValid == true) && RequiredFieldValidator3.IsValid == true) && RequiredFieldValidator4.IsValid == true)&& RequiredFieldValidator5.IsValid==true)&& RequiredFieldValidator6.IsValid == true)&& RequiredFieldValidator7.IsValid == true)
        {
            if (txtphonenumble.Text.Length == 11)
            {                            
               if (txtPwd.Text.IndexOf(" ") >= 0)
                  {
                      Response.Write("<script>alert('密码请不要输入空格！')</script>");
                  }
               else
                {
                    if (question1 == question2 || question2 == question3 || question3 == question1)
                    {
                        Response.Write("<script>alert('问题不能选择一样！')</script>");
                    }
                    else
                    {
                        try
                        {
                            myregister.store_change(sql);

                            myregister.store_change(sql2);

                            myregister.store_change(sql3);

                            myregister.store_change(sql4);

                            Response.Write("<script>alert('注册成功！你的用户名是" + username + "，请牢记，本弹窗只出现一次！');location='Login.aspx'</script>");
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