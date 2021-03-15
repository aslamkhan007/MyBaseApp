using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_HiteshExcel : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {

         string SqlPass = "EXEC JCTGEN..JCT_OPS_DELAY_PACK_STOCK_SP ";

        SqlCommand cmd = new SqlCommand(SqlPass, obj.Connection());
        cmd.CommandTimeout = 1000000;
        obj.ConOpen();
        cmd.ExecuteNonQuery();
        obj.ConClose();

        string sql = " SELECT    ItemGroupNo ,OrderNo ,LotNo , STATUS , SalePerson ,CustomerName , Rate ,RecdDate , QtyRecd ,MinPacking ,MaxPacking ,UpdateTime , Days  FROM  JCTGEN..JCT_OPS_DELAY_STOCK  ORDER BY  Status ";
      
         cmd = new SqlCommand(sql, obj.Connection());
      
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0];


        string attachment = "attachment; filename=HiteshExcel.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

        obj.ConClose();
    }
}