using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    Class2 myselect = new Class2();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["name"].ToString() != " ")
            {
                string username = Session["name"].ToString();

                string nickname = Session["nickname"].ToString();

                lbname.Text = nickname;

                if (!IsPostBack)
                {
                    string sql1 = "select id from login2 where username ='" + username + "'";

                    DataTable dt1 = new DataTable();

                    dt1 = myselect.select(sql1);

                    string id = dt1.Rows[0][0].ToString();

                    Session["id"] = id;

                    string time = DateTime.Now.ToString();

                    string sql2 = "select * from Borrowbook where id='" + id + "' and endtime='" + time + "'";

                    DataTable dt2 = myselect.select(sql2);

                    if(dt2.Rows.Count >0)
                    {
                        Response.Write("<script>alert('有书到期未还，请迅速归还！')</script>");
                    }           
                }
            }
                else
                    Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
        catch (Exception)
        {
            Response.Write("<script>alert('尚未登录！');location='Login.aspx'</script>");
        }
    }
    protected void select(object sender, EventArgs e)
    {
        string content = txtselect.Text.Trim ();

        string sql = "select * from Book where bookname like'%" + content + "%' or author like'%" + content + "%'";

        DataTable dt = new DataTable();

        dt = myselect.select(sql);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('查无此书！')</script>");
        }
        else

        {
            Session["book"] = content;

            Response.Write("<script>window.location='Selectbook.aspx'</script>");
        }
    }
    protected void up(object sender, EventArgs e)
    {
        Session["name"] = " ";
        Response.Write("<script>window.location='Login.aspx'</script>");
    }
 
   
}