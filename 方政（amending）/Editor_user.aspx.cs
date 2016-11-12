using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor_user : System.Web.UI.Page
{
    Class2 myeditor = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)//使得Page_Load只在第一次加载页面时执行
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                string sql = "select * from login2 where id='" + id + "'";

                DataTable dt = new DataTable();

                dt = myeditor.select(sql);

                string username = dt.Rows[0][1].ToString();

                string password = dt.Rows[0][2].ToString();

                string phonenumble = dt.Rows[0][3].ToString();

                txtName.Text = username;

                txtAuthor.Text = password;

                txtCount.Text = phonenumble;
            }
        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    protected void amend(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        string amend_username = txtName.Text;

        string amend_password = txtAuthor.Text;

        string amend_phonenumble = txtCount.Text;

        string sql = "update login2 set username='" + amend_username + "',password='" + amend_password + "',phonenumble='" + amend_phonenumble + "' where id='" + id + "'";

        myeditor.store_change(sql);

        Response.Write("<script>alert('修改成功！');location='Users.aspx'</script>");


    }
}