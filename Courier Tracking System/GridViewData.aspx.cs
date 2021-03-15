using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class GridViewData : System.Web.UI.Page
{
    string _connStr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
    int _startRowIndex = 0;
    int _pageSize = 20;
    int _thisPage = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        HandleRequestObjects();

        try
        {
            if (!IsPostBack)
            {
                BindMyGrid();
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    /// <summary>
    /// Handles the request objects.
    /// </summary>
    private void HandleRequestObjects()
    {
        try
        {
            // check for paging
            if (Request.Form["startRowIndex"] != null && Request.Form["thisPage"] != null)
            {
                _startRowIndex = int.Parse(Request.Form["startRowIndex"].ToString());
                _thisPage = int.Parse(Request.Form["thisPage"].ToString());
            }

            // check for edit
            if (Request.Form["editId"] != null)
            {
                UpdateInsertData(Request.Form["editId"]);
            }

            // check for deletion
            if (Request.Form["deleteId"] != null)
            {
                DeleteRecord(Request.Form["deleteId"]);
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    /// <summary>
    /// Updates the data.
    /// </summary>
    private void UpdateInsertData(string editId)
    {
        string sql = string.Empty;
        string message = "Added";
        if (editId.EndsWith("0"))
        {
            sql = "insert into jct_courier_Type_Master (CourierType, Description, LongDesc, EffecFrom,EffecTo) values " +
          " (@CourierType, @Description, @LongDesc, @EffecFrom,@EffecTo)";
        }
        else
        {
            message = "Update";
            sql = "Update jct_courier_Type_Master set CourierType = @CourierType, Description = @Description, " +
                 " LongDesc = @LongDesc, EffecFrom = Convert(datetime,@EffecFrom),EffecTo=Convert(datetime,@EffecTo) WHERE Sr_no = @Sr_no ";
        }

        // get the data now
        //  using (SqlConnection conn = new SqlConnection(_connStr))
        //{
        using (SqlCommand cmd = new SqlCommand(sql, obj.Connection()))
        {
            cmd.CommandType = CommandType.Text;

            SqlParameter p = new SqlParameter("@CourierType", SqlDbType.VarChar, 100);
            p.Value = Request.Form["CourierType"];
            cmd.Parameters.Add(p);
            p = new SqlParameter("@Description", SqlDbType.VarChar, 100);
            p.Value = Request.Form["Description"];
            cmd.Parameters.Add(p);
            p = new SqlParameter("@LongDesc", SqlDbType.VarChar, 100);
            p.Value = Request.Form["LongDesc"];
            cmd.Parameters.Add(p);
            p = new SqlParameter("@EffecFrom", SqlDbType.VarChar, 100);
            p.Value = Request.Form["EffecFrom"];
            cmd.Parameters.Add(p);
            p = new SqlParameter("@EffecTo", SqlDbType.VarChar, 100);
            p.Value = Request.Form["EffecTo"];
            cmd.Parameters.Add(p);
            p = new SqlParameter("@Sr_no", SqlDbType.Int);
            p.Value = int.Parse(editId);
            cmd.Parameters.Add(p);
            string sql1 = sql;
            obj.ConOpen();
            cmd.ExecuteNonQuery();
            obj.ConClose();
        }
        // }

        lblMessage.Text = "Selected record " + message + " successfully !";

        // rebind the data again
        BindMyGrid();
    }
    private void BindMyGrid()
    {
        // sql for paging. In production write this in the Stored Procedure
        string sql = "SELECT * FROM ( " +
            " Select Sr_no,CourierType, Description,LongDesc,EffecFrom,EffecTo" +
            " FROM jct_courier_Type_Master where Status='A' ) as table1 " +
            " WHERE  Sr_no BETWEEN @startRowIndex AND (@startRowIndex + @pageSize) - 1 " +
            "ORDER BY Sr_no DESC";


        DataTable table = new DataTable();
        int totalCount = 0;

        // get the data now
        // using (SqlConnection conn = new SqlConnection())
        //{
        using (SqlCommand cmd = new SqlCommand(sql, obj.Connection()))
        {
            cmd.CommandType = CommandType.Text;
            SqlParameter p = new SqlParameter("@startRowIndex", SqlDbType.Int);
            p.Value = _startRowIndex + 1;
            cmd.Parameters.Add(p);
            p = new SqlParameter("@pageSize", SqlDbType.Int);
            p.Value = _pageSize;
            cmd.Parameters.Add(p);

            obj.ConOpen();
            // get the data first
            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            {
                ad.Fill(table);
            }

            // get the total count of the records now
            sql = "select count(Sr_no) from jct_courier_Type_Master where status='A'";
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            object obj2 = cmd.ExecuteScalar();
            totalCount = Convert.ToInt32(obj2);

            obj.ConClose();
        }
        // }

        // do the paging now
        litPaging.Text = DoPaging(_thisPage, totalCount, _pageSize);

        // bind the data to the grid
        GridView1.DataSource = table;
        GridView1.DataBind();

    }
    /// <summary>
    /// Deletes the record.
    /// </summary>
    /// <param TrialNo="id">The id.</param>
    private void DeleteRecord(string id)
    {
        int TransNo = int.Parse(id);
        string sql = "Update JCT_Sample_Process_Trans set Status='D' where TransNo = @TransNo";

        using (SqlConnection conn = new SqlConnection(_connStr))
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TransNo", TransNo);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        lblMessage.Text = "Selected record deleted successfully !";

        // rebind the data again
        BindMyGrid();
    }

    /// <summary>
    /// Binds my grid.
    /// </summary>
   

    /// <summary>
    /// Do the paging now
    /// </summary>
    /// <param TrialNo="thisPageNo"></param>
    /// <param TrialNo="totalCount"></param>
    /// <param TrialNo="pageSize"></param>
    /// <returns></returns>
    private string DoPaging(int thisPageNo, int totalCount, int pageSize)
    {
        if (totalCount.Equals(0))
        {
            return "";
        }

        int pageno = 0;
        int start = 0;
        int loop = totalCount / pageSize;
        int remainder = totalCount % pageSize;
        int startPageNoFrom = thisPageNo - 6;
        int endPageNoTo = thisPageNo + 6;
        int lastRenderedPageNo = 0;

        StringBuilder strB = new StringBuilder("<div>Page: ", 500);

        // write 1st if required
        if (startPageNoFrom >= 1)
        {
            strB.Append("<a href=\"javascript:LoadGridViewData(0, 1)\" title=\"Page 1\">1</a> | ");
            if (!startPageNoFrom.Equals(1))
            {
                strB.Append(" ... | ");
            }
        }

        for (int i = 0; i < loop; i++)
        {
            pageno = i + 1;
            if (pageno > startPageNoFrom && pageno < endPageNoTo)
            {
                if (pageno.Equals(thisPageNo))
                    strB.Append("<span>" + pageno + "</span>&nbsp;| ");
                else
                    strB.Append("<a href=\"javascript:LoadGridViewData(" + start + ", " + pageno + ")\" title=\"Page " + pageno + "\">" + pageno + "</a> | ");

                lastRenderedPageNo = pageno;
            }
            start += pageSize;
        }

        // write ... if required just before end
        if (!pageno.Equals(lastRenderedPageNo))
        {
            strB.Append(" ... | ");
        }

        if (remainder > 0)
        {
            pageno++;
            if (pageno.Equals(thisPageNo))
                strB.Append("<span>" + pageno + "</span>&nbsp;| ");
            else
                strB.Append("<a href=\"javascript:LoadGridViewData(" + start + ", " + pageno + ")\" title=\"Page " + pageno + "\">" + pageno + "</a> | ");
        }
        else // write last page number
        {
            if (loop >= endPageNoTo)
            {
                if (loop.Equals(thisPageNo))
                    strB.Append("<span>" + loop + "</span>&nbsp;| ");
                else
                    strB.Append("<a href=\"javascript:LoadGridViewData(" + start + ", " + pageno + ")\" title=\"Page " + loop + "\">" + loop + "</a> | ");
            }
        }

        return strB.ToString() + "</div>";
    }
}
