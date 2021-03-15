using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class EmpGateway_Medical_Insurance : System.Web.UI.Page
{
    string sql;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    DataTable dt;
    SqlTransaction tran;
    SqlCommand cmd;
    SendMail sm = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {

           if(Session["Empcode"] == "") 
        {
           Response.Redirect("~/login.aspx");
        }
         

        if (!Page.IsPostBack)
        {
            sql = "Select * from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and EsiNo is Null AND active='Y'";
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                sql = "Select a.Empname,a.cardno,b.deptname,a.desg,Convert(varchar,a.doj,103) as doj,Convert(varchar,a.dob,103) as dob from jct_empmast_base a inner join deptmast b on a.deptcode=b.deptcode where a.active ='Y' and a.Empcode='" + Session["EmpCode"] + "'";
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblName.Text = dr[0].ToString();
                        lblCardNo.Text = dr[1].ToString();
                        lblDepartment.Text = dr[2].ToString();
                        lblDesignation.Text = dr[3].ToString();
                        lblDoj.Text = dr[4].ToString();
                        lblDob.Text = dr[5].ToString();
                        lblEmpCode.Text = Session["EmpCode"].ToString();
                    }
                }
                dr.Close();
            }
            else
            {
                lnkSubmit.Enabled = false;
                lnkAddRow.Enabled = false;
                pnlGrid.Visible = false;
                ShowAlertMsg("You are not under employee insurance scheme. For further enquiry please contact Varinder Malhotra(Admin.) - 4048.");
            }
            sql = "Select * from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and mode in ('Save','Submit')";
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                Bindgrid();
            }
            else
            {
                SetInitialRow();
            }
        }
        sql = "Select top 1 mode from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' ";
        if (obj1.FetchValue(sql)=="Submit")
        {
            lnkSubmit.Enabled = false;
            lnkAddRow.Enabled = false;
            lnkSave.Enabled = false;
            lblmsg.Text = "You have submitted you record. For any changes please contact Varinder malhotra in Admin Department.";
            lblmsg.Visible = true;
            GridView1.Enabled = false;
        }

    }
    private void Bindgrid()
    {
        //sql = "Select TransNo, [Relation] as Relation,Name,Convert(varchar,CONVERT(DATETIME,DOB),103)  as [Dob],DATEDIFF(yy,Dob,GETDATE()) as [Age],mode as [Mode] from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and mode in ('Submit','Save')";
        sql = "Select top 1 mode from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' ";
        if (obj1.FetchValue(sql)== "Submit")
        {
            lnkSubmit.Enabled = false;
            lnkAddRow.Enabled = false;
            lnkSave.Enabled = false;
            lblmsg.Text = "You have submitted you record. For any changes please contact Varinder Malhotra in Admin Department.";
        }
        sql = "Select TransNo, [Relation] as Relation,Name,CONVERT(VARCHAR,DOB ,103)  as [Dob], YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,Dob,103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,DOB,103),102)),   Convert(varchar,CONVERT(DATETIME,DOB,103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS [age],mode as [Mode] from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and mode in ('Submit','Save') order by TransNo";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ViewState["CurrentTable"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();
     
       
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        sql = "Select max(TransNo) from gmeis2 where status='A'";
        int Transno = (int)obj1.FetchValue(sql);
        dt.Columns.Add(new DataColumn("TransNo", typeof(int)));
        dt.Columns.Add(new DataColumn("Relation", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("DOB", typeof(string)));
        dt.Columns.Add(new DataColumn("Age", typeof(string)));
        dr = dt.NewRow();
        dr["TransNo"]=Transno;
        dr["Relation"] = "--Select--";
        dr["Name"] = string.Empty;
        dr["DOB"] = string.Empty;
        dr["Age"] = string.Empty;
        dt.Rows.Add(dr);
        //dr = dt.NewRow();

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //private void AddNewRowToGrid()
    //{
    //    try 
    //    {

    //        int rowIndex = 0;

    //        if (ViewState["CurrentTable"] != null)
    //        {
    //            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
    //            DataRow drCurrentRow = null;
    //            if (dtCurrentTable.Rows.Count > 0)
    //            {
    //                for (int i = 0; i <= dtCurrentTable.Rows.Count-1; i++)
    //                {
    //                    //extract the TextBox values
    //                    DropDownList box1 = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("ddlRelation");
    //                    TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("txtName");
    //                    TextBox box3 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtDob");
                      
    //                    drCurrentRow = dtCurrentTable.NewRow();
                       
    //                    dtCurrentTable.Rows[i]["Relation"] = box1.SelectedValue;
    //                    dtCurrentTable.Rows[i]["Name"] = box2.Text;
    //                    dtCurrentTable.Rows[i]["DOB"] = box3.Text;
    //                    rowIndex++;
    //                }
    //                dtCurrentTable.Rows.Add(drCurrentRow);
    //                ViewState["CurrentTable"] = dtCurrentTable;

    //                GridView1.DataSource = dtCurrentTable;
    //                GridView1.DataBind();
    //            }
    //        }
    //        else
    //        {
    //            Response.Write("ViewState is null");
    //        }

    //        // Set Previous Data on Postbacks
    //        SetPreviousData();
    //    }
    //    catch(Exception ex)
    //    {
    //        ShowAlertMsg("Error while adding new row.Please Contact at 4212");
    //    }
      
    //}
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlRelation");
                    TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtName");
                    TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtDob");
                    Label TransNo = (Label)GridView1.Rows[rowIndex].Cells[0].FindControl("lblTransNo");
                    drCurrentRow = dtCurrentTable.NewRow();
                  //  drCurrentRow["RowNumber"] = i + 1;

 
                    dtCurrentTable.Rows[i-1]["TransNo"] = 0;
                    dtCurrentTable.Rows[i - 1]["Relation"] = box1.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Name"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["DOB"] = box3.Text;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                GridView1.DataSource = dtCurrentTable;
                GridView1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlRelation");
                    TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtName");
                    TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtDob");
                    box1.Text = dt.Rows[i]["Relation"].ToString();
                    box2.Text = dt.Rows[i]["Name"].ToString();
                    box3.Text = dt.Rows[i]["Dob"].ToString();
                    rowIndex++;
                }
            }
        }
    }
    protected void lnkAddRow_Click(object sender, EventArgs e)
    {
      AddNewRowToGrid();
    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
        string empname = obj1.FetchValue(sql).ToString();
        sql = "Select * from  dbo.GMEIS2 where ecode='" + Session["EmpCode"] +"' and Status='A' and Mode='Save'";
       
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["Relation"].Equals("Self"))
                    { 
                     ViewState["dept"] = dr["dept"].ToString();
                    ViewState["cat"] = dr["cat"].ToString();
                    ViewState["desg"]= dr["Designation"].ToString();
                    }
                }
            
            }
            dr.Close();
            obj.ConOpen();
            tran=obj.Connection().BeginTransaction();
            try
            {
                sql = "Update GMEIS2 set status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and Status='A' and mode='Save' ";
                 cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                    TextBox Name = (TextBox)row.FindControl("txtName");
                    TextBox DOb = (TextBox)row.FindControl("txtDob");
                   // sql = "SELECT DATEDIFF(yy,Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102),GETDATE()) ";

                    sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                    TextBox AGE = new TextBox();
                    AGE.Text = obj1.FetchValue(sql).ToString();
                    sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "',  CONVERT(VARCHAR, CONVERT(DATETIME,'"+ DOb.Text +"',103), 102 ),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Submit') ";
                    cmd = new SqlCommand(sql, obj.Connection(), tran);
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                lnkSubmit.Enabled = false;
                lnkAddRow.Enabled = false;
                lnkSave.Enabled = false;
                GridView1.Enabled = false;
                lblmsg.Text = "You have submitted you record. For any changes please contact Varinder Malhotra in Admin Department.";
                lblmsg.Visible = true;
             
                sm.SendMail("jatindutta@jctltd.com","dummy@jctltd.com","Medical Insurance Entry Submitted by "+ empname +"","Insurance form submitted by '"+ empname +"' of department='"+ ViewState["Dept"] +"' and Salary Code='"+ Session["EmpCode"] +"'");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                ShowAlertMsg("Some Error Occured while updating record.");
                sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Medical Insurance Entry (Error) by " + empname + "", "Error in Insurance form while submitted by '" + empname + "' of department='" + ViewState["Dept"] + "' and Salary Code='" + Session["EmpCode"] + "' and error is '"+ ex.ToString() +"'");
            }
            finally
            {
                obj.ConClose();
            }
        
        }

        Bindgrid();
        ShowAlertMsg("Record Updated Successfully.");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if(lnkSubmit.Enabled)
        {
        if (e.CommandName == "Remove")
        {
            sql = "Update GMEIS2 set Status='D',Updated_date=getdate(),Updated_by='"+ Session["EmpCode"] +"' where TransNo="+ e.CommandArgument +"  and ecode='"+ Session["EmpCode"] +"' and status='A'";
            obj1.UpdateRecord(sql);
            Bindgrid();
          //  ShowAlertMsg("Record Deleted Successfully.");
        }
       }
    }
    
    public void ShowAlertMsg(string error1)
    {
        #region msg
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
        #endregion
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "Select a.ecode as [Salary Code],b.deptname as [Department],a.Name as [Name],a.Designation,a.DOB as [DOB] ,a.Age as [Age],a.Relation as [Relationship] from GMEIS2 a inner join deptmast b on a.dept=b.deptcode and a.status='A' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        //lnkReport.Visible = True
        //lnkReport.Text = "Click here to download the Dispatch detail for Period '" & txtSDate.Text & "' - '" & txtEDate.Text & "'"
        //Response.ClearContent()
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("Employee_Medical_Insurance.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=Employee_Medical_Insurance.xls");
        Response.TransmitFile(Server.MapPath("Employee_Medical_Insurance.xls"));
        Response.End();
        obj.ConClose();
    }

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Employee Medical Insurance Details</TH></TR>";
        string sTableEnd = "</TABLE></BODY></HTML>";
        string sTableData = "";
        int nRow = 0;
        int nCol;
        sTableData += "<TR>";
        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
        {
            sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
        }
        sTableData += "</TR>";
        for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
        {
            sTableData += "<TR>";
            for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
            {
                sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
            }
            sTableData += "</TR>";
        }
        string sTable = sTableStart + sTableData + sTableEnd;
        //  Dim oExcelFile As System.IO.File
        System.IO.StreamWriter oExcelWrite = null;
        string sExcelFile = Server.MapPath("Employee_Medical_Insurance.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        sql = "Select * from  dbo.GMEIS2 where ecode='" + Session["EmpCode"] + "' and Status='A' and Mode <>'Submit'";

        if (obj1.CheckRecordExistInTransaction(sql))
        {
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["Relation"].Equals("Self"))
                    {
                        ViewState["dept"] = dr["dept"].ToString();
                        ViewState["cat"] = dr["cat"].ToString();
                        ViewState["desg"] = dr["Designation"].ToString();
                    }
                }

            }
            dr.Close();

            //sql = "Update GMEIS2 set status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and Status='A' ";
            //obj1.UpdateRecord(sql);
            obj.ConOpen();
            tran = obj.Connection().BeginTransaction();
            try
            {
                sql = "Update GMEIS2 set mode='Save', status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and Status='A' and mode<>'Submit'";
                cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                    TextBox Name = (TextBox)row.FindControl("txtName");
                    TextBox DOb = (TextBox)row.FindControl("txtDob");
                    Label TransNo = (Label)row.FindControl("TransNo");
                    sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                    TextBox AGE = new TextBox();
                    AGE.Text = obj1.FetchValue(sql).ToString();
                    if (DOb.Text == "")
                    {
                        sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,Relation,Entry_Date,Entered_By,Status,Mode)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "','" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save') ";
                    }
                    else
                    {
                        sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "',CONVERT(VARCHAR,CONVERT(DATETIME,'" + DOb.Text + "',103),101),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save') ";
                    }

                    cmd = new SqlCommand(sql, obj.Connection(), tran);
                    cmd.ExecuteNonQuery();
                    sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
                    string empname = obj1.FetchValue(sql).ToString();
                }
                tran.Commit();
                sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Medical Insurance Entry Saved by " + Session["EmpCode"] + "", "Insurance form submitted by '" + Session["EmpCode"] + "' of department='" + ViewState["Dept"] + "' ");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                ShowAlertMsg("Some Error ocuured while Saving your record.");
            }
            finally { obj.ConClose(); }


        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                TextBox Name = (TextBox)row.FindControl("txtName");
                TextBox DOb = (TextBox)row.FindControl("txtDob");
                Label TransNo = (Label)row.FindControl("TransNo");
                sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                TextBox AGE = new TextBox();
                AGE.Text = obj1.FetchValue(sql).ToString();
                if (DOb.Text == "")
                {
                    sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,Relation,Entry_Date,Entered_By,Status,Mode)values('" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "','" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save') ";
                }
                else
                {
                    sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode)values('" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "',CONVERT(VARCHAR,CONVERT(DATETIME,'" + DOb.Text + "',103),101),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save') ";
                }

                cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Medical Insurance Entry Saved by " + Session["EmpCode"] + "", "Insurance form submitted by '" + Session["EmpCode"] + "' of department='" + ViewState["Dept"] + "' ");

            }
        }
        Bindgrid();
        ShowAlertMsg("Record Saved Successfully.");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Visible = false;
        }

     
    }
  
}