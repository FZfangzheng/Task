using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Borrowbook_information : System.Web.UI.Page
{
    Class2 change = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"].ToString() == " ")

            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");

        try
        {
            if (!IsPostBack)
            {
                DataBindToRepeater(1);
            }
        }
        catch(Exception )
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    protected void RptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Return")
        {
            int no = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select bookname from Borrowbook where NO='" + no + "'";//根据主键NO唯一性返回书名

            DataTable dt = new DataTable();

            dt=change.select(sql);

            string bookname = dt.Rows[0][0].ToString();

            string sql1 = "select count from Book where bookname='" + bookname + "'";

            DataTable dt1 = new DataTable();

            dt1 = change.select(sql1);

            int count1 = Convert.ToInt32(dt1.Rows[0][0].ToString());

            count1 = count1 + 1;
        
            string sql2 = "update Book set count='" + count1 + "' where bookname='" + bookname + "'";

            change.store_change(sql2);

            string sql3 = "delete from Borrowbook where NO='" + no + "'";

            change.store_change(sql3);

            Response.Write("<script>alert('还书成功！');location='Borrowbook_information.aspx'</script>");


        }

    }
    void DataBindToRepeater(int currentPage)
    {
            string id = Session["id"].ToString();

            string sql = "select * from Borrowbook where id='" + id + "'";//查询用户名下借阅信息

            DataTable dt = new DataTable();

            dt = change.select(sql);

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
        if (RequiredFieldValidator1.IsValid == true)
        {
            if (Convert.ToInt32(txtJump.Text) <= Convert.ToInt32(lbTotal.Text) && Convert.ToInt32(txtJump.Text) >= 1)
            {
                lbNow.Text = txtJump.Text;

                DataBindToRepeater(Convert.ToInt32(txtJump.Text));
            }
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