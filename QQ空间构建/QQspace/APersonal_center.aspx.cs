using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personal_center : System.Web.UI.Page
{
    Class1 mycenter = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            string nickname = Session["nickname"].ToString();

            string qq = "QQ空间";

            lable.Text = qq;

            lbname.Text = nickname;

            string sql = "select photo from Login where username='" + Session["name"].ToString() + "'";

            DataTable dt = new DataTable();

            dt = mycenter.select(sql);

            if(dt.Rows.Count > 0)
            {
                Image1.ImageUrl = dt.Rows[0][0].ToString();
            }

            string sql1 = "select * from Login";

            DataTable dt1 = mycenter.select(sql1);

            RptPerson.DataSource = dt1;

            RptPerson.DataBind();
        }
        else
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        Boolean fileOk = false;
        //指定文件路径，pic是项目下的一个文件夹；～表示当前网页所在的文件夹
        String path = Server.MapPath("~/Images/");//物理文件路径

        int length = this.FileUpload1.PostedFile.ContentLength;//获取图片大小，以字节为单位
                                                               //文件上传控件中如果已经包含文件
        if (FileUpload1.HasFile)
        {
            //得到文件的后缀
            String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

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
                string name = FileUpload1.FileName;//获取上传的文件名

                path = "~/Images/" + name;

                string sql = "update Login set photo ='" + path + "' where username='" + Session["name"].ToString() + "'";

                Image1.ImageUrl = path;

                FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));

                mycenter.store_change (sql);//保存文件路径数据到数据库

                panel.Visible = false;

                Response.Write("<script>alert('文件上传成功！');</script>");
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

    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        panel.Visible = true;
    }

    protected void RptPerson_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int Name = Convert.ToInt32(drvw["username"]);

            string sql = "select * from Say where username=" + Name + "";

            DataTable dt = new DataTable();

            dt = mycenter.select(sql);

            Repeater rept = (Repeater)e.Item.FindControl("RptSay");

            // rept = (Repeater)e.Item.FindControl("RptBook");

            rept.DataSource = dt;

            rept.DataBind();

        }
    }

    protected void personal_center_Click(object sender, EventArgs e)
    {

    }

    protected void printsay_Click(object sender, EventArgs e)
    {

    }

    protected void out_Click(object sender, EventArgs e)
    {

    }
}