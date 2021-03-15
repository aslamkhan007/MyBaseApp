using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Serial_Master : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpName"] + "' and Active='Y'";
        string empname = sql;
         sql = "Insert into jct_courier_serial_master(UserCode,UserName,Prefix,PostFix,Remarks,STATUS,EntryDate ) values(@UserCode,@UserName,@Prefix,@PostFix,@Remarks,@Status,@EntryDate)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpName"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
        cmd.Parameters.Add("@Prefix", SqlDbType.VarChar, 3).Value =txtPrefix.Text;
        cmd.Parameters.Add("@PostFix", SqlDbType.VarChar, 4).Value = txtPostfix.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = txtRemarks.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
        cmd.ExecuteNonQuery();
        ShowAlertMsg("Record Inserted Successfuly.");
    }

    public void ShowAlertMsg(string error1)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
    }
}