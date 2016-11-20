using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Selectbook : System.Web.UI.Page
{
    Class2 myborrow = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataBindToRepeater(1);
            }


            if (Session["name"].ToString() == " ")

                Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");

            string name = Session["name"].ToString();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }

    }

    protected void RptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Borrow")
        {
            if (Convert.ToInt32(Session["time"]) == 1)

                Response.Write("<script>alert('有书到期未还，请迅速归还！')</script>");
            else

            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());

                string time = DateTime.Now.ToString();

                DateTime now = DateTime.Now;

                DateTime endtime = now.AddMonths(1);

                string sql1 = "select * from Book where id='" + id + "'";

                DataTable dt = new DataTable();

                dt = myborrow.select(sql1);

                int count1 = Convert.ToInt32(dt.Rows[0][3].ToString());

                count1 = count1 - 1;

                if (count1 >= 0)
                {
                    string count2 = Convert.ToString(count1);

                    string sql2 = "update Book set count='" + count2 + "' where id='" + id + "'";

                    myborrow.store_change(sql2);

                    string bookname = dt.Rows[0][1].ToString();

                    string author = dt.Rows[0][2].ToString();

                    string id1 = Session["id"].ToString();

                    string sql3 = "insert into Borrowbook values('" + id1 + "','" + bookname + "','" + author + "','" + time + "','" + endtime + "')";

                    myborrow.store_change(sql3);

                    Response.Write("<script>alert('借阅成功！');location='Selectbook.aspx'</script>");
                }
                else
                    Response.Write("<script>alert('数量不足，借阅失败！');location='Selectbook.aspx'</script>");
            }
        }


    }

    void DataBindToRepeater(int currentPage)
    {
       

        DataTable dt1 = new DataTable();

        string book = Session["book"].ToString();

        string sql = "select * from Book where bookname like'%" + book + "%' or author like'%" + book + "%'";

        dt1 = myborrow.select(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt1.DefaultView;

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
