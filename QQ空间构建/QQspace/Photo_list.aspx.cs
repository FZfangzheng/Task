using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Photo_list : System.Web.UI.Page
{
    Class1 myphoto_list = new Class1();
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
    protected void btnphoto_Click(object sender, EventArgs e)
    {
        Boolean fileOk = false;
        //指定文件路径，pic是项目下的一个文件夹；～表示当前网页所在的文件夹
        String path = Server.MapPath("~/photo/");//物理文件路径

        int length = this.upphoto.PostedFile.ContentLength;//获取图片大小，以字节为单位
                                                           //文件上传控件中如果已经包含文件
        if (upphoto.HasFile)
        {
            //得到文件的后缀
            String fileExtension = System.IO.Path.GetExtension(upphoto.FileName).ToLower();

            //允许文件的后缀
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };

            //看包含的文件是否是被允许的文件的后缀
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOk = true;
                }
            }
        }
        if (fileOk)
        {
            try
            {
                //文件另存在服务器的指定目录下     
                string name = upphoto.FileName;//获取上传的文件名

                path = "~/photo/" + name;

                string sql = "insert into Photo values('" + Session["name"].ToString() + "','" + path + "',0,'" + Session["photoname"].ToString() + "') ";

                upphoto.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));

                myphoto_list.store_change(sql);//保存文件路径数据到数据库

                Response.Write("<script>alert('文件上传成功！');location='Photo_list.aspx'</script>");
            }
            catch
            {
                Response.Write("<script>alert('文件上传失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('只能上传gif,png,jpeg,jpg,bmp图象文件！');</script>");
        }
    }
    protected void Rptphoto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Photo where id='" + id + "'";

            myphoto_list.store_change(sql);

            Response.Write("<script>alert('删除成功！');location='Photo_list.aspx'</script>");

        }
        if (e.CommandName == "Good")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select good from Photo where id='" + id + "'";

            DataTable dt = new DataTable();

            dt = myphoto_list.select(sql);

            int good = Convert.ToInt32(dt.Rows[0][0].ToString());

            good += 1;

            string sql1 = "update Photo set good='" + good + "' where id='" + id + "'";

            myphoto_list.store_change(sql1);

            Response.Write("<script>window.location='Photo_list.aspx'</script>");
        }
        if(e.CommandName=="Cover")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select photo from Photo where id='" + id + "'";

            DataTable dt = myphoto_list.select(sql);

            string sql1 = "update Photo_name set cover='" + dt.Rows[0][0] + "' where photoname='" + Session["photoname"].ToString() + "'";

            myphoto_list.store_change(sql1);

            Response.Write("<script>alert('设置成功！')</script>");
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
        string sql = "select * from Photo where username='" + Session["name"].ToString() + "' and photoname='" + Session["photoname"].ToString() + "'";

        DataTable dt = new DataTable();

        dt = myphoto_list.select(sql);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        Rptphoto.DataSource = pds;

        Rptphoto.DataBind();

    }
}