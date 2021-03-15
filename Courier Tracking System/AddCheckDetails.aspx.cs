using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;

public partial class OPS_AddCheckDetails : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql="";

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["AWBNo"] == null)
        {
           // DetailsView1.DefaultMode = DetailsViewMode.Insert;
        }
        else
        {
            //DetailsView1.DefaultMode = DetailsViewMode.Edit;
        }
        this.Page.Title = "Add More Checks";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "SELECT distinct ID AS ID,AWBNo,Carrier,InvoiceNo FROM dbo.JCT_COURIER_COD_CASH_COLLECTION WHERE AWBNo=@AWBNo and Status='A'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@AWBNo", SqlDbType.VarChar, 50).Value = Request.QueryString["AWBNo"];
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            RadGrid1.DataSource = ds.Tables[0];
            RadGrid1.DataBind();

            sql = "Select distinct isnull(Carrier,'') as Carrier from JCT_COURIER_COD_CASH_COLLECTION where Status='A' and AWBNo='"+ Request.QueryString["AWBNo"] +"'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                ViewState["Carrier"] = obj1.FetchValue(sql).ToString();
            }
            

        }

    }

   

   
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
      

    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandArgument == "Save")
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    RadButton save = (RadButton)e.Item.FindControl("radbtnSave");
                    Label id = (Label)e.Item.FindControl("lblID");
                    Label invoiceno = (Label)e.Item.FindControl("lblInvoiceNo");
                    Label awbno = (Label)e.Item.FindControl("lblAwbNo");
                    Label carrier = (Label)e.Item.FindControl("lblCarrier");
                    RadTextBox chequeno = (RadTextBox)e.Item.FindControl("radtxtChequeNo");
                    RadTextBox chequeamt = (RadTextBox)e.Item.FindControl("radtxtChequeAmt");
                    RadDatePicker chequedate = (RadDatePicker)e.Item.FindControl("radDtPckrChequeDate");

                    sql = "JCT_COURIER_COD_CASH_COLLECTION_MULTIPLE_CHECKS_INSERT";

                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt16(id.Text);
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = invoiceno.Text;
                    cmd.Parameters.Add("@AWBNO", SqlDbType.VarChar, 50).Value = awbno.Text;
                    cmd.Parameters.Add("@CHECKNO", SqlDbType.VarChar, 50).Value = chequeno.Text;
                    cmd.Parameters.Add("@CHECKAMT", SqlDbType.Decimal).Value = Convert.ToDecimal(chequeamt.Text);
                    cmd.Parameters.Add("@CHECKDATE", SqlDbType.VarChar, 20).Value = Convert.ToString(Convert.ToDateTime(chequedate.SelectedDate).ToShortDateString());
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];

                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
                    string script = "alert('Record Submitted Successfully..!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                }
            }

            catch (Exception ex)
            {
                string script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            }
        
        }
    }

    //protected void radbtnAddRow_Click(object sender, EventArgs e)
    //{
    //    SetInitialRow();
    //    AddNewRowToGrid();
    //}

    //private void SetInitialRow()
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        DataRow dr = null;
    //        dt.Columns.Add(new DataColumn("ID", typeof(string)));
    //        dt.Columns.Add(new DataColumn("AWBNO", typeof(string)));
    //        dt.Columns.Add(new DataColumn("Carrier", typeof(string)));
    //        dt.Columns.Add(new DataColumn("CheckNo", typeof(string)));
    //        dt.Columns.Add(new DataColumn("CheckAmt", typeof(string)));
    //        dt.Columns.Add(new DataColumn("CheckDate", typeof(string)));

    //        dr = dt.NewRow();
    //        dr["ID"] = string.Empty;
    //        dr["AWBNO"] = Request.QueryString["AWBNo"];
    //        dr["Carrier"] = ViewState["Carrier"];
    //        dr["CheckNo"] = string.Empty;
    //        dr["CheckAmt"] = string.Empty;
    //        dr["CheckDate"] = string.Empty;
            

    //        dt.Rows.Add(dr);

    //        ViewState["CurrentTable"] = dt;

    //    }
    //    catch (Exception ex)
    //    {
    //        string script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }

    //}


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

    //                for (int i = 0; i <= dtCurrentTable.Rows.Count - 1; i++)
    //                {
    //                    Label ID = (Label)RadGrid1.Items[rowIndex].FindControl("lblID");
    //                    Label AWBNo = (Label)RadGrid1.Items[rowIndex].FindControl("lblAWBNo");
    //                    Label carrier = (Label)RadGrid1.Items[rowIndex].FindControl("lblCarrier");
    //                    RadTextBox checkno = (RadTextBox)RadGrid1.Items[rowIndex].FindControl("radtxtCheckNo");
    //                    RadTextBox checkamt = (RadTextBox)RadGrid1.Items[rowIndex].FindControl("radtxtCheckAmt");
    //                    RadDatePicker checkdate = (RadDatePicker)RadGrid1.Items[rowIndex].FindControl("radDtPckrCheckDate");

    //                    drCurrentRow = dtCurrentTable.NewRow();

    //                    dtCurrentTable.Rows[i]["ID"] = ID.Text;
    //                    dtCurrentTable.Rows[i]["AWBNO"] = AWBNo.Text;
    //                    dtCurrentTable.Rows[i]["Carrier"] = carrier.Text;
    //                    dtCurrentTable.Rows[i]["CheckNo"] = checkno.Text;
    //                    dtCurrentTable.Rows[i]["CheckAmt"] = checkamt.Text;
    //                    dtCurrentTable.Rows[i]["CheckDate"] = Convert.ToString(Convert.ToDateTime(checkdate.SelectedDate).ToShortDateString());
                        

    //                    rowIndex += 1;
    //                }

    //                dtCurrentTable.Rows.Add(drCurrentRow);
    //                ViewState["CurrentTable"] = dtCurrentTable;

    //                sql = "Select '" + dtCurrentTable.Columns["ID"].ToString() + "' as ID,'" + dtCurrentTable.Columns["AWBNO"].ToString() + "' as AWBNO,'" + dtCurrentTable.Columns["Carrier"].ToString() + "' as Carrier,'" + dtCurrentTable.Columns["CheckNo"].ToString() + "' as CheckNo,'" + dtCurrentTable.Columns["CheckAmt"].ToString() + "' as CheckAmt,'" + dtCurrentTable.Columns["CheckDate"].ToString() + "' as CheckDate";
    //                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //                SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                DataSet ds = new DataSet();
    //                da.Fill(ds);
    //                RadGrid1.DataSource = ds.Tables[0];
    //                RadGrid1.DataBind();
    //            }
    //        }
    //        else
    //        {
    //            Response.Write("ViewState is null");
    //        }

    //        //Set Previous Data on Postbacks

    //        SetPreviousData();
    //    }
    //    catch (Exception ex)
    //    {
    //        string script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }
    //}


    //private void SetPreviousData()
    //{
    //    try
    //    {
    //        int rowIndex = 0;

    //        if (ViewState["CurrentTable"] != null)
    //        {
    //            DataTable dt = (DataTable)ViewState["CurrentTable"];
    //            if (dt.Rows.Count > 0)
    //            {

    //                for (int i = 0; i <= dt.Rows.Count - 1; i++)
    //                {
    //                    Label ID = (Label)RadGrid1.Items[rowIndex].FindControl("lblID");
    //                    Label AWBNo = (Label)RadGrid1.Items[rowIndex].FindControl("lblAWBNo");
    //                    Label carrier = (Label)RadGrid1.Items[rowIndex].FindControl("lblCarrier");
    //                    RadTextBox checkno = (RadTextBox)RadGrid1.Items[rowIndex].FindControl("radtxtCheckNo");
    //                    RadTextBox checkamt = (RadTextBox)RadGrid1.Items[rowIndex].FindControl("radtxtCheckAmt");
    //                    RadDatePicker checkdate = (RadDatePicker)RadGrid1.Items[rowIndex].FindControl("radDtPckrCheckDate");

    //                    ID.Text = dt.Rows[i]["ID"].ToString();
    //                    AWBNo.Text = dt.Rows[i]["AWBNO"].ToString();
    //                    carrier.Text = dt.Rows[i]["Carrier"].ToString();
    //                    checkno.Text = dt.Rows[i]["CheckNo"].ToString();
    //                    checkamt.Text = dt.Rows[i]["CheckAmt"].ToString();
    //                    checkdate.SelectedDate =  Convert.ToDateTime(dt.Rows[i]["CheckDate"].ToString());
                       
    //                    rowIndex += 1;
    //                }
    //            }

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        string script = "alert('" + ex.Message + "');";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
    //    }


    //}

}