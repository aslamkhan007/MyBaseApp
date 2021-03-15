using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class OPS_OutOfOffice : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    string script = "";
    string areacode;
    List<String> AreaCodes = new List<String>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grd.Visible = true;
            sql = "SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE (([STATUS] = 'A') AND ([UserCode] = '"+ Session["EmpCode"] +"'))";
            obj1.FillGrid(sql, ref grd);
        }
        
    }
    protected void lnkApply_Click(object sender, EventArgs e)
    {
        AreaCodesList();
        try
        {
        sql = "JCT_OPS_SANCTIONNOTE_OUT_OFFICE_INSERT";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EMPCODE", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        cmd.Parameters.Add("@DATEFROM", SqlDbType.VarChar, 25).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DATETO", SqlDbType.VarChar ,25).Value = txtDateTo.Text;
        cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar, 500).Value = txtRemarks.Text ;
        cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar, 500).Value = areacode;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 50).Value = ddlPlant.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        sql = "SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE (([STATUS] = 'A') AND ([UserCode] = '" + Session["EmpCode"] + "'))";
        obj1.FillGrid(sql, ref grd);
        script = "alert('Record Submitted Successfully..!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch {
            script = "alert('Some Error Occured While Submitting Record..!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }


    protected void AreaCodesList()
    {

        for (int i = 0; i <= chbArea.Items.Count - 1; i++)
        {
            if (chbArea.Items[i].Selected == true)
            { 
                
         
                AreaCodes.Add(chbArea.Items[i].Value);
         

            }
        }

        areacode = string.Join(",", AreaCodes.ToArray());
    }

    protected void chbArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
   if (chbArea.SelectedItem.Text == "All")
        {
            for (int i = 0; i <= chbArea.Items.Count - 1; i++)
            {
                chbArea.Items[i].Selected = true;

                if (chbArea.SelectedItem.Text != "All")
                {
                    AreaCodes.Add(chbArea.Items[i].Value);
                }

            }

          
            
        }
        }

        catch

        { 
        
        }
     
        
        
    }
}