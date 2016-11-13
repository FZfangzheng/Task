using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor_user_information : System.Web.UI.Page
{
    Class2 myeditor = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { if (!IsPostBack)//使得Page_Load只在第一次加载页面时执行
            {
                string username = Session["name"].ToString();

                string sql = "select id from login2 where username='" + username + "'";

                DataTable dt = new DataTable();

                dt = myeditor.select(sql);

                int id = Convert.ToInt32(dt.Rows[0][0]);

                string sql1 = "select * from login2 where id='" + id + "'";

                DataTable dt1 = new DataTable();

                dt1 = myeditor.select(sql1);

                string phone = dt1.Rows[0][3].ToString();

                string nickname = dt1.Rows[0][4].ToString();

                txtphone.Text = phone;

                txtnickname.Text = nickname;
            }

        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    protected void amend(object sender, EventArgs e)
    {
        string username = Session["name"].ToString();
     
        string amend_phone = txtphone.Text;

        string amend_nickname = txtnickname.Text;

        string sql = "update login2 set phonenumble='" + amend_phone + "',nickname='"+amend_nickname +"' where username='" + username + "'";

        myeditor.store_change(sql);

        Response.Write("<script>alert('修改成功！');location='User_information.aspx'</script>");


    }
}