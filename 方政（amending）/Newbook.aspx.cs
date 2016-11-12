using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Newbook : System.Web.UI.Page
{
    Class2 myupdata = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string name = Session["name1"].ToString();
        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    protected void upbook(object sender, EventArgs e)
    {
        string bookname = txtbook.Text;

        string author = txtauthor.Text;

        string count = txtcount.Text;

        string sql = "insert into Book values('" + bookname + "','" + author + "','" + count + "')";

        myupdata.store_change(sql);

        Response.Write("<script>alert('添加成功！')</script>");
    }

}