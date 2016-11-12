using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor_book : System.Web.UI.Page
{
    Class2 myeditor = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)//使得Page_Load只在第一次加载页面时执行
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                string sql = "select * from Book where id='" + id + "'";

                DataTable dt = new DataTable();

                dt = myeditor.select(sql);

                string name = dt.Rows[0][1].ToString();

                string author = dt.Rows[0][2].ToString();

                string count = dt.Rows[0][3].ToString();

                txtName.Text = name;

                txtAuthor.Text = author;

                txtCount.Text = count;
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

        string amend_name = txtName.Text;

        string amend_author = txtAuthor.Text;

        string amend_count = txtCount.Text;

        string sql = "update Book set bookname='" + amend_name + "',author='" + amend_author + "',count='" + amend_count + "' where id='"+id+"'";

        myeditor.store_change(sql);

        Response.Write("<script>alert('修改成功！');location='Books.aspx'</script>");


    }
}