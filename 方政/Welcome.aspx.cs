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

                    string sql3 = "update Question set id='"+id+"' where username='"+username+"'";

                    myselect.store_change(sql3);

                    string time = DateTime.Now.ToString();

                    string sql2 = "select endtime from Borrowbook where id='" + id + "'";

                    DataTable dt2 = myselect.select(sql2);

                    int count = dt2.Rows.Count;

                    int i;

                    for(i=0;i<count;i++)
                    {
                        if(Convert.ToDateTime ( dt2.Rows[0][i].ToString ())<Convert .ToDateTime(time))
                        {
                            Response.Write("<script>alert('有书到期未还，请迅速归还！')</script>");

                            Session["time"] = 1;

                            break;
                        }
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