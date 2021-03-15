using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.Mail;

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

            if (Session["EmpCode"].ToString() == "A-00098" || Session["EmpCode"].ToString() == "K-02107")
                Panel1.Visible = true;
            else
                Panel1.Visible = false;

            sql = "Select * from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and EsiNo is Null AND active='Y' UNION Select * from jct_empmast_base where  active='Y' AND empcode IN  ('V-04353','S-13794','R-03334','P-03163','A-00190','B-00221','R-03314','S-13828','D-00721','M-02528','R-03595','V-04338','A-00254','T-T2001','M-02557','N-02733','B-00342','D-00757','S-13738','S-13766','N-02645','MUM-A06','L-02306','P-03111','D-00745','H-01447','J-01924','R-03614','R-03643','R-03599','B-00235') and empcode='" + Session["EmpCode"] + "'"; // 
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                sql = "SELECT  a.Empname ,a.cardno ,b.deptname ,a.desg ,CONVERT(VARCHAR, a.doj, 103) AS doj ,CONVERT(VARCHAR, a.dob, 103) AS dob,ISNULL(c.mobile,'') FROM    jct_empmast_base a INNER JOIN deptmast b ON a.deptcode = b.deptcode LEFT OUTER JOIN dbo.MISTEL AS c ON a.empcode = c.empcode WHERE   a.active = 'Y' and a.Empcode='" + Session["EmpCode"] + "'";
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
                        txtMobile.Text = dr[6].ToString();
                    }
                }
                dr.Close();
            }
            else
            {
                lnkSubmit.Enabled = false;
                lnkAddRow.Enabled = false;
                lnkSave.Enabled = false;
                pnlGrid.Visible = false;
                ShowAlertMsg("You are not under employee insurance scheme. For further enquiry please contact Kamal Kishore Sharma(Admin.) - 4048.");
            }
            
            sql = "Select * from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and mode in ('Save','Submit')";
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                Bindgrid(Session["EmpCode"].ToString());
            }
            else
            {
                SetInitialRow();
            }
           
        }
        try
        {
        string FinYear = getFinancialYear();
        sql = "Select top 1 mode from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and FinancialYear='"+ FinYear +"'";
        if (obj1.FetchValue(sql).Equals("Submit"))
        {
            lnkSubmit.Enabled = false;
            lnkAddRow.Enabled = false;
            lnkSave.Enabled = false;
            lblmsg.Text = "You have submitted your record. For any changes please contact Kamal Kishore Sharma in Admin Department.";
            lblmsg.Visible = true;
            GridView1.Enabled = false;
        }
        }
        catch (Exception ex)
        {
           
        }     
    }

    private string getFinancialYear()
    {
        string FinYear="";
        sql = "JCT_OPS_FINANCIAL_YEAR";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                FinYear= (dr["FinYear"].ToString());
            }
        }
        dr.Close();
        return FinYear;      
    }

    private void Bindgrid(String EmpCode)
    {
        string FinYear = getFinancialYear();
        //sql = "Select TransNo, [Relation] as Relation,Name,Convert(varchar,CONVERT(DATETIME,DOB),103)  as [Dob],DATEDIFF(yy,Dob,GETDATE()) as [Age],mode as [Mode] from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A' and mode in ('Submit','Save')";

        sql = "Select distinct FinancialYear from gmeis2 where TransNo= (Select max(TransNo) from GMEIS2 where ecode='" + EmpCode + "' and status='A')";

        if (FinYear == obj1.FetchValue(sql).ToString())
        {
            sql = "Select top 1 mode from GMEIS2 where ecode='" + EmpCode + "' and status='A' and FinancialYear='" + FinYear + "'";
            if (obj1.FetchValue(sql) == "Submit")
            {
                lnkSubmit.Enabled = false;
                lnkAddRow.Enabled = false;
                lnkSave.Enabled = false;
                lblmsg.Text = "You have submitted your record. For any changes please contact Kamal Kishore Sharma in Admin Department.";             
            }

            sql = "Select TransNo,  LTRIM(RTRIM(Relation)) as Relation,Name,CONVERT(VARCHAR,DOB ,103)  as [Dob], YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,Dob,103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,DOB,103),102)),   Convert(varchar,CONVERT(DATETIME,DOB,103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS [age],mode as [Mode] , DisableFlag from GMEIS2 where ecode='" + EmpCode + "' and status='A' and FinancialYear='" + FinYear + "' and mode in ('Submit','Save')  order by TransNo";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // FOR ENABLING AND MAKING CHECKBOX CHECKED IN CASE OF DISABLED ITEMS SAVED IN DATABASE.
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (Convert.ToString(dt.Rows[i]["DisableFlag"]) == "Y")
                {
                    CheckBox text1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                    text1.Checked = true;
                    text1.Enabled = true;
                }

                if (Convert.ToString(dt.Rows[i]["Relation"]) == "Son" || Convert.ToString(dt.Rows[i]["Relation"]) == "Daughter")
                {
                    CheckBox text1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                    text1.Enabled = true;
                }

            }  
        }
        else
        {
            string FinancialYear = obj1.FetchValue(sql).ToString();
            sql = "Select top 1 mode from GMEIS2 where ecode='" + EmpCode + "' and status='A' and FinancialYear='" + obj1.FetchValue(sql).ToString() + "'";
            if (obj1.FetchValue(sql) == "Submit")
            {
                lnkSubmit.Enabled = false;
                lnkAddRow.Enabled = false;
                lnkSave.Enabled = false;
                lblmsg.Text = "You have submitted your record. For any changes please contact Kamal Kishore Sharma in Admin Department.";
            }

            sql = "Select TransNo,  LTRIM(RTRIM(Relation)) as Relation,Name,CONVERT(VARCHAR,DOB ,103)  as [Dob], YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,Dob,103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,DOB,103),102)),   Convert(varchar,CONVERT(DATETIME,DOB,103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS [age],mode as [Mode],DisableFlag from GMEIS2 where ecode='" + EmpCode + "' and status='A' and FinancialYear='" + FinancialYear + "' and mode in ('Submit','Save')  order by TransNo";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // FOR ENABLING AND MAKING CHECKBOX CHECKED IN CASE OF DISABLED ITEMS SAVED IN DATABASE.
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (Convert.ToString(dt.Rows[i]["DisableFlag"]) == "Y")
                {
                    CheckBox text1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                    text1.Checked = true;
                    text1.Enabled = true;
                }

                if (Convert.ToString(dt.Rows[i]["Relation"]) == "Son" || Convert.ToString(dt.Rows[i]["Relation"]) == "Daughter")
                {
                    CheckBox text1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                    text1.Enabled = true;
                }

            }   
        }                                
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
        dt.Columns.Add(new DataColumn("DisableFlag", typeof(string)));
        dr = dt.NewRow();
        dr["TransNo"]=Transno;
        dr["Relation"] = "--Select--";
        dr["Name"] = string.Empty;
        dr["DOB"] = string.Empty;
        dr["Age"] = string.Empty;
        dr["DisableFlag"] = string.Empty;
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
                    CheckBox box5 = (CheckBox)GridView1.Rows[rowIndex].Cells[5].FindControl("CheckBox1");
                    drCurrentRow = dtCurrentTable.NewRow();
                  //  drCurrentRow["RowNumber"] = i + 1;

 
                    dtCurrentTable.Rows[i-1]["TransNo"] = 0;
                    dtCurrentTable.Rows[i - 1]["Relation"] = box1.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Name"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["DOB"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["DisableFlag"] = Convert.ToBoolean(Convert.ToString(box5.Checked));
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
                for (int i = 0; i < dt.Rows.Count-1; i++)
                {
                    DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlRelation");
                    TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtName");
                    TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtDob");
                    CheckBox box5 = (CheckBox)GridView1.Rows[rowIndex].Cells[5].FindControl("CheckBox1");
                    box5.Checked = Convert.ToBoolean(Convert.ToString(dt.Rows[i]["DisableFlag"]));
                    box1.Text = dt.Rows[i]["Relation"].ToString();
                    box2.Text = dt.Rows[i]["Name"].ToString();
                    box3.Text = dt.Rows[i]["Dob"].ToString();
                    if (box5.Checked == true)
                    {
                        box5.Enabled = true;
                    }
                    if (box1.SelectedItem.Text == "Son" || box1.SelectedItem.Text == "Daughter")
                    {
                        CheckBox text1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                        text1.Enabled = true;
                    }
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
        Boolean isScuess;
        isScuess = false;
        string FinYear = getFinancialYear();
        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
        string empname = obj1.FetchValue(sql).ToString();

        sql = "Select distinct FinancialYear from gmeis2 where TransNo = (Select max(TransNo) from GMEIS2 where ecode='" + Session["EmpCode"] + "' and status='A')";

        if (FinYear == obj1.FetchValue(sql).ToString())
        {
            sql = "Select * from  dbo.GMEIS2 where ecode='" + Session["EmpCode"] + "' and Status='A' and Mode='Save' and FinancialYear='" + FinYear + "'";

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
                obj.ConOpen();

                tran = obj.Connection().BeginTransaction();
                try
                {
                    sql = "Update GMEIS2 set status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and Status='A' and mode='Save' and FinancialYear='" + FinYear + "'";
                    cmd = new SqlCommand(sql, obj.Connection(), tran);
                    cmd.ExecuteNonQuery();
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                        TextBox Name = (TextBox)row.FindControl("txtName");
                        TextBox DOb = (TextBox)row.FindControl("txtDob");
                        CheckBox Disable = (CheckBox)row.FindControl("CheckBox1");
                        string DisableFlag;
                        if (Disable.Checked == true && Disable.Enabled == true)
                        {
                            DisableFlag = "Y";
                        }
                        else
                        {
                            DisableFlag = null;
                        }
                        sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                        TextBox AGE = new TextBox();
                        AGE.Text = obj1.FetchValue(sql).ToString();
                        //sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "',  CONVERT(VARCHAR, CONVERT(DATETIME,'" + DOb.Text + "',103), 102 ),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Submit','" + FinYear + "') ";
                        sql = "Exec  gmeis2_Save  '" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Submit','" + FinYear + "' ,'" + DisableFlag + "' ";
                        cmd = new SqlCommand(sql, obj.Connection(), tran);
                        cmd.ExecuteNonQuery();
                        DisableFlag = null;
                    }
                    tran.Commit();

                    isScuess = true;

                    lnkSubmit.Enabled = false;
                    lnkAddRow.Enabled = false;
                    lnkSave.Enabled = false;
                    GridView1.Enabled = false;
                    lblmsg.Text = "You have submitted you record. For any changes please contact Kamal Kishore Sharma in Admin Department.";
                    lblmsg.Visible = true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    isScuess = false;

                    ShowAlertMsg("Some Error Occured while updating record.");
                    sm.SendMail("ashish@jctltd.com", "harendra@jctltd.com", "Medical Insurance Entry (Error) by " + empname + "", "Error in Insurance form while submitted by '" + empname + "' of department='" + ViewState["Dept"] + "' and Salary Code='" + Session["EmpCode"] + "' and error is '" + ex.ToString() + "'");
                }
                finally
                {
                    obj.ConClose();
                }
            }
            
           
        }

        else
        {
            string FinancialYear = obj1.FetchValue(sql).ToString();
            string NewFinYear = getFinancialYear();
            sql = "Select * from  dbo.GMEIS2 where ecode='" + Session["EmpCode"] + "' and Status='A'  and FinancialYear='" + FinancialYear + "'";

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
                obj.ConOpen();

                tran = obj.Connection().BeginTransaction();
                try
                {
                    sql = "Update GMEIS2 set status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and Status='A'   and FinancialYear='" + NewFinYear + "'";
                    cmd = new SqlCommand(sql, obj.Connection(), tran);
                    cmd.ExecuteNonQuery();
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                        TextBox Name = (TextBox)row.FindControl("txtName");
                        TextBox DOb = (TextBox)row.FindControl("txtDob");
                        // sql = "SELECT DATEDIFF(yy,Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102),GETDATE()) ";

                        CheckBox Disable = (CheckBox)row.FindControl("CheckBox1");
                        string DisableFlag;
                        if (Disable.Checked == true && Disable.Enabled == true)
                        {
                            DisableFlag = "Y";
                        }
                        else
                        {
                            DisableFlag = null;
                        }


                        sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                        TextBox AGE = new TextBox();
                        AGE.Text = obj1.FetchValue(sql).ToString();
                       // sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "',  CONVERT(VARCHAR, CONVERT(DATETIME,'" + DOb.Text + "',103), 102 ),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Submit','" + NewFinYear + "') ";
                        sql = "Exec  gmeis2_Save  '" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Submit','" + NewFinYear + "' ,'" + DisableFlag + "' ";
                        cmd = new SqlCommand(sql, obj.Connection(), tran);
                        cmd.ExecuteNonQuery();
                        DisableFlag = null;
                    }
                    tran.Commit();

                    isScuess = true;

                    lnkSubmit.Enabled = false;
                    lnkAddRow.Enabled = false;
                    lnkSave.Enabled = false;
                    GridView1.Enabled = false;
                    lblmsg.Text = "You have submitted your record. For any changes please contact Kamal Kishore Sharma in Admin Department.";
                    lblmsg.Visible = true;
                }
                catch (Exception ex)
                {
                    isScuess = false;
                    tran.Rollback();
                    ShowAlertMsg("Some Error Occured while updating record.");
                    sm.SendMail("ashish@jctltd.com", "harendra@jctltd.com", "Medical Insurance Entry (Error) by " + empname + "", "Error in Insurance form while submitted by '" + empname + "' of department='" + ViewState["Dept"] + "' and Salary Code='" + Session["EmpCode"] + "' and error is '" + ex.ToString() + "'");
                }
                finally
                {
                    obj.ConClose();
                }
            }



        }

        if (isScuess == true)
        {
            SendMail();
            Bindgrid(Session["EmpCode"].ToString());
            ShowAlertMsg("Record Updated Successfully.");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if(lnkSubmit.Enabled)
        {
        if (e.CommandName == "Remove")
        {
            string FinYear = getFinancialYear();
            sql = "Update GMEIS2 set Status='D',Updated_date=getdate(),Updated_by='"+ Session["EmpCode"] +"' where TransNo="+ e.CommandArgument +"  and ecode='"+ Session["EmpCode"] +"' and status='A' and FinancialYear='"+ FinYear +"'";
            obj1.UpdateRecord(sql);
            Bindgrid(Session["EmpCode"].ToString());
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
        string FinYear = getFinancialYear();
        sql = "Select a.ecode as [Salary Code],b.deptname as [Department],a.Name as [Name],a.Designation,a.DOB as [DOB] ,a.Age as [Age],a.Relation as [Relationship] from GMEIS2 a inner join deptmast b on a.dept=b.deptcode and a.status='A' and FinancialYear ='"+ FinYear +"'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];

        string attachment = "attachment; filename=MedicalInsuranceDetails.xls";
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

    //public bool CreateExcelFile(DataTable dt)
    //{
    //    bool bFileCreated = false;
    //    string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Employee Medical Insurance Details</TH></TR>";
    //    string sTableEnd = "</TABLE></BODY></HTML>";
    //    string sTableData = "";
    //    int nRow = 0;
    //    int nCol;
    //    sTableData += "<TR>";
    //    for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
    //    {
    //        sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
    //    }
    //    sTableData += "</TR>";
    //    for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
    //    {
    //        sTableData += "<TR>";
    //        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
    //        {
    //            sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
    //        }
    //        sTableData += "</TR>";
    //    }
    //    string sTable = sTableStart + sTableData + sTableEnd;
    //    //  Dim oExcelFile As System.IO.File
    //    System.IO.StreamWriter oExcelWrite = null;
    //    string sExcelFile = Server.MapPath("Employee_Medical_Insurance.xls");
    //    oExcelWrite = System.IO.File.CreateText(sExcelFile);
    //    oExcelWrite.WriteLine(sTable);
    //    oExcelWrite.Close();
    //    bFileCreated = true;
    //    return bFileCreated;

    //}

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        string FinYear = getFinancialYear();
        sql = "Select * from  dbo.GMEIS2 where ecode='" + Session["EmpCode"] + "' and Status='A' and Mode <>'Submit' and FinancialYear='"+ FinYear +"'";

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
 
            obj.ConOpen();
            tran = obj.Connection().BeginTransaction();
            try
            {
                sql = "Update GMEIS2 set mode='Save', status='D',Updated_Date=getdate(),Updated_By='" + Session["EmpCode"] + "'  where ecode='" + Session["EmpCode"] + "' and FinancialYear='"+ FinYear +"' and Status='A' and mode<>'Submit'";
                cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                    TextBox Name = (TextBox)row.FindControl("txtName");
                    TextBox DOb = (TextBox)row.FindControl("txtDob");
                    Label TransNo = (Label)row.FindControl("TransNo");
                    CheckBox Disable = (CheckBox)row.FindControl("CheckBox1");
                    string DisableFlag;
                    if (Disable.Checked == true && Disable.Enabled == true)
                    {
                        DisableFlag = "Y";
                    }
                    else
                    {
                        DisableFlag = null;
                    }
                    sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                    TextBox AGE = new TextBox();
                    AGE.Text = obj1.FetchValue(sql).ToString();
                    if (DOb.Text == "")
                    {
                        //sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "','" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save','"+ FinYear +"') ";
                        sql = "Exec  gmeis2_Save  '" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Save','" + FinYear + "' ,'" + DisableFlag + "' ";
                    }
                    else
                    {
                        //sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "',CONVERT(VARCHAR,CONVERT(DATETIME,'" + DOb.Text + "',103),101),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save','" + FinYear + "') ";
                        sql = "Exec  gmeis2_Save  '" + Session["EmpCode"] + "','" + ViewState["dept"] + "','" + Name.Text + "','" + ViewState["desg"] + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Save','" + FinYear + "' ,'" + DisableFlag + "' ";
                    }

                    cmd = new SqlCommand(sql, obj.Connection(), tran);
                    cmd.ExecuteNonQuery();
                    sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
                    string empname = obj1.FetchValue(sql).ToString();
                    DisableFlag = null;
                }
                sql = "UPDATE dbo.MISTEL SET mobile = '" + txtMobile.Text + "' WHERE empcode = '" + Session["EmpCode"] + "'";
                cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                tran.Commit();
                //sm.SendMails("jatindutta@jctltd.com", "dummy@jctltd.com", "Medical Insurance Entry Saved by " + Session["EmpCode"] + "", "Insurance form submitted by '" + Session["EmpCode"] + "' of department='" + ViewState["Dept"] + "' ");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                ShowAlertMsg("Some Error ocuured while Saving your record.");
            }
            finally { obj.ConClose();
            }
        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
                TextBox Name = (TextBox)row.FindControl("txtName");
                TextBox DOb = (TextBox)row.FindControl("txtDob");
                Label TransNo = (Label)row.FindControl("TransNo");
                CheckBox Disable = (CheckBox)row.FindControl("CheckBox1");
                string DisableFlag;
                if (Disable.Checked == true && Disable.Enabled == true)
                {
                    DisableFlag = "Y";
                }


                else
                {
                    DisableFlag = null;
                }
                sql = "SELECT  YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102))+ CASE WHEN DATEADD(year, YEAR(Convert(varchar,CONVERT(DATETIME,getdate(),103),102)) - YEAR(Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)),   Convert(varchar,CONVERT(DATETIME,'" + DOb.Text + "',103),102)) > Convert(varchar,CONVERT(DATETIME,getdate(),103),102) THEN -1  ELSE 0 END AS age";
                TextBox AGE = new TextBox();
                AGE.Text = obj1.FetchValue(sql).ToString();
                if (DOb.Text == "")
                {
                   // sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "','" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save','" + FinYear + "') ";
                    sql = "Exec  gmeis2_Save  '" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Save','" + FinYear + "' ,'" + DisableFlag + "' ";
                }
                else
                {
                   // sql = "Insert into GMEIS2(ecode,dept,Name,Designation,Age,DOB,Relation,Entry_Date,Entered_By,Status,Mode,FinancialYear)values('" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "',CONVERT(VARCHAR,CONVERT(DATETIME,'" + DOb.Text + "',103),101),'" + relation.SelectedItem.Text + "',getdate(),'" + Session["EmpCode"] + "','A','Save','" + FinYear + "') ";
                    sql = "Exec  gmeis2_Save '" + Session["EmpCode"] + "','" + lblDepartment.Text + "','" + Name.Text + "','" + lblDesignation.Text + "','" + AGE.Text + "','" + DOb.Text + "','" + relation.SelectedItem.Text + "','" + Session["EmpCode"] + "','Save','" + FinYear + "' ,'" + DisableFlag + "' ";
                }
                cmd = new SqlCommand(sql, obj.Connection(), tran);
                cmd.ExecuteNonQuery();
                //sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Medical Insurance Entry Saved by " + Session["EmpCode"] + "", "Insurance form submitted by '" + Session["EmpCode"] + "' of department='" + ViewState["Dept"] + "' ");
                DisableFlag = null;
            }

            sql = "UPDATE dbo.MISTEL SET mobile = '" + txtMobile.Text + "' WHERE empcode = '" + Session["EmpCode"] + "'";
            cmd = new SqlCommand(sql, obj.Connection(), tran);
            cmd.ExecuteNonQuery();
        }
        Bindgrid(Session["EmpCode"].ToString());
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    private void SendMail()
    {
        string from, to, bcc, cc, subject, body,Name="";
        string Dept="", Relation="", DOB="", Age="" ;
        StringBuilder sb = new StringBuilder();

        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "'";
        string RequestBy = obj1.FetchValue(sql).ToString();

        sql = "Select e_mailid from mistel where empcode='"+ Session["EmpCode"] +"'";
        to = obj1.FetchValue(sql).ToString() == "" ? "ashish@jctltd.com" : obj1.FetchValue(sql).ToString();

        string FinYear = getFinancialYear();

      
        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("<style type=\"text/css\">");
        sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
        sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
        sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
        sb.AppendLine("Hello " + RequestBy + ",<br/><br/>");
        sb.AppendLine("Your Medical Insurance Details have been submitted successfully.<br/><br/>");
        sb.AppendLine("Detail is shown below :<br/><br/>");
        sb.AppendLine("<table class=\"gridtable\">");
        sb.AppendLine("<tr><th> EmpCode </th> <th> Department </th><th> Name </th> <th> Relation </th> <th> DOB </th> <th> Age </th> <th> FinancialYear</th></tr>");
        sql = "Select dept,Name,Age,Relation,Convert(varchar,DOB,106) as DOB from Gmeis2 where ecode='" + Session["EmpCode"] + "' and Status='A' and FinancialYear='" + FinYear + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Dept = dr["dept"].ToString();
                Relation = dr["Relation"].ToString();
                Age = dr["Age"].ToString();
                DOB = dr["DOB"].ToString();
                Name = dr["Name"].ToString();
                sb.AppendLine("<tr> <td>  " + Session["EmpCode"] + " </td> <td>  " + Dept + " </td> <td>  " + Name + " </td><td>  " + Relation + " </td>  <td> " + DOB + "</td>  <td> " + Age + "</td>  <td> " + FinYear + "</td> </tr> ");
            }
        }
        dr.Close();
 
        sb.AppendLine("</table>");
        sb.AppendLine("<br/><br/>");
        sb.AppendLine("This is a system generated mail, please donot reply. <br />");
        sb.AppendLine("Thank you<br />");
        sb.AppendLine("</html>");


        body = sb.ToString();
        from = "noreply@jctltd.com"; 
        bcc = "ashish@jctltd.com,kamal@jctltd.com";
 
        subject = "Medical Insurance Details";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(from);
 

        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            for (int i = 0; i < tos.Length; i++)
            {
                mail.To.Add(new MailAddress(tos[i]));
            }
        }
        else
        {
            mail.To.Add(new MailAddress(to));
        }

        if (!string.IsNullOrEmpty(bcc))
        {
            if (bcc.Contains(","))
            {
                string[] bccs = bcc.Split(',');
                for (int i = 0; i < bccs.Length; i++)
                {
                    mail.Bcc.Add(new MailAddress(bccs[i]));
                }
            }
            else
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
        }


        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpClient SmtpMail = new SmtpClient("exchange2k7");
        SmtpMail.Send(mail);
 
    }

 
    protected void ddlRelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            DropDownList relation = (DropDownList)row.FindControl("ddlRelation");
            CheckBox Disable = (CheckBox)row.FindControl("CheckBox1");
            if (relation.SelectedItem.Text == "Son" || relation.SelectedItem.Text == "Daughter")
            {
                Disable.Enabled = true;
            }
            else
            {
                Disable.Checked = false;
                Disable.Enabled = false;
            }

        }
    }

    protected void GetEmployeeData(string empcode)
    {
        sql = "Select * from jct_empmast_base where empcode='" + empcode + "' and EsiNo is Null AND active='Y'"; // AND active='Y'";// 
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                sql = "SELECT  a.Empname ,a.cardno ,b.deptname ,a.desg ,CONVERT(VARCHAR, a.doj, 103) AS doj ,CONVERT(VARCHAR, a.dob, 103) AS dob,ISNULL(c.mobile,'') FROM    jct_empmast_base a INNER JOIN deptmast b ON a.deptcode = b.deptcode LEFT OUTER JOIN dbo.MISTEL AS c ON a.empcode = c.empcode WHERE   a.active = 'Y' and a.Empcode='" + empcode + "'";
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
                        lblEmpCode.Text = empcode;
                        txtMobile.Text = dr[6].ToString();
                    }
                }
                dr.Close();
            }

            sql = "Select * from GMEIS2 where ecode='" + empcode + "' and status='A' and mode in ('Save','Submit')";
            if (obj1.CheckRecordExistInTransaction(sql) == true)
            {
                Bindgrid(empcode);
                //GridView1.Enabled = true;
            }

    }
    protected void cmdFetchDetail_Click(object sender, EventArgs e)
    {
        GetEmployeeData(txtEmpCode.Text);
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmpCode.Text) == true)
        {
            ShowAlertMsg("Invalid Employee Code !!");
        }
        else
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JCt_Emp_Medical_Insurance_Nominee_Manual_Reset";// '" + Session["EmpCode"].ToString() + "','" + txtEmpCode.Text + "'";
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@Ecode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
                cmd.Connection = obj.Connection();
                cmd.ExecuteNonQuery();
                ShowAlertMsg("Record Updated Sucessfully!!");
            }
            catch (Exception ex)
            {
                ShowAlertMsg("Unable to Update Record!! " + ex.Message.ToString());
            }
        }
    }
}