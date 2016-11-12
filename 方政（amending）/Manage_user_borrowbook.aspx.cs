using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_user_borrowbook : System.Web.UI.Page
{
        Class2 myeditor = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string name = Session["name1"].ToString();

            if (!IsPostBack)//使得Page_Load只在第一次加载页面时执行
            {
                DataBindToRepeater(1);
            }
        }
        catch (Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    void DataBindToRepeater(int currentPage)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        string sql = "select * from Borrowbook where id='" + id + "'";//查询id下借阅信息

        DataTable dt = new DataTable();

        dt = myeditor.select(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        RptBook.DataSource = pds;

        RptBook.DataBind();

    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lbNow.Text) + 1 <= Convert.ToInt32(lbTotal.Text))
        {
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);

            DataBindToRepeater(Convert.ToInt32(lbNow.Text));
        }
    }
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = Convert.ToString(1);
        DataBindToRepeater(1);
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        lbNow.Text = lbTotal.Text;

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text));
    }
    protected void btnJump_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtJump.Text) <= Convert.ToInt32(lbTotal.Text) && Convert.ToInt32(txtJump.Text) >= 1)
        {
            lbNow.Text = txtJump.Text;

            DataBindToRepeater(Convert.ToInt32(txtJump.Text));
        }
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lbNow.Text) - 1 >= 1)
        {
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);

            DataBindToRepeater(Convert.ToInt32(lbNow.Text));
        }
    }
}