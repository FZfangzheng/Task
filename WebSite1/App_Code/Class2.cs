using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Class2 的摘要说明
/// </summary>
public class Class2
{
    string str = @"server=DESKTOP-34MDJJN;Integrated Security=SSPI;database=fangsiji;";
    public Class2()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable select(string sql)//用于查询并输出查询结果
    {
        
        SqlConnection conn = new SqlConnection(str);
        DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public void store_change(string sql)//用于增删改等作用
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
   

}