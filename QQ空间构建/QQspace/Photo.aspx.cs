using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Photo2 : System.Web.UI.Page
{
    Class1 myphoto = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            if (!IsPostBack)
            {
                DataBindToRepeater(1);
            }
        }
        else
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
    }

    protected void Rptphoto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            string photoname = e.CommandArgument.ToString();

            string sql = "delete from Photo_name where photoname='" + photoname + "'";

            myphoto .store_change(sql);

            Response.Write("<script>alert('删除成功！');location='Photo.aspx'</script>");

        }
        if(e.CommandName=="Photo")
        {
            string photoname = e.CommandArgument.ToString();

            Session["photoname"] = photoname;

            Response.Write("<script>window.location='Photo_list.aspx'</script>");
        }

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
    void DataBindToRepeater(int currentPage)
    {
        string sql = "select * from Photo_name where username='" + Session["name"].ToString() + "'";

        DataTable dt = new DataTable();

        dt = myphoto.select(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        Rptphoto.DataSource = pds;

        Rptphoto.DataBind();

    }

    protected void creatphoto_Click(object sender, EventArgs e)
    {
        pn_creatphoto.Visible = true;
    }

    protected void yes_Click(object sender, EventArgs e)
    {
        string photoname = this.photoname.Text;

        string sql = "insert into Photo_name(photoname,username) values('" + photoname + "','" + Session["name"].ToString() + "')";

        string sql1 = "select * from Photo_name where photoname='" + photoname + "' and username='" + Session["name"].ToString() + "'";

        DataTable dt = myphoto.select(sql1);

        if (dt.Rows.Count == 0)
        {
            myphoto.store_change(sql);

            Response.Write("<script>alert('创建成功！');location='Photo.aspx'</script>");
        }
        else
            Response.Write("<script>alert('相册名不可重复！');location='Photo.aspx'</script>");
    }

    protected void no_Click(object sender, EventArgs e)
    {
        pn_creatphoto.Visible = false;
    }
}