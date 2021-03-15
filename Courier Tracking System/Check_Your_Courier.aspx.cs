using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Check_Your_Courier : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    float Sum = 0;
    float Total;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtRequestBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRequestBy.Text = txtRequestBy.Text.Split('~')[2].ToString();
        }
        catch (Exception ex)
        {

        }
    }

    protected void BindGridWithOutDates()
    {
        sql = "JCT_COURIER_GET_STATUS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = "09/10/2012";
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Now;
        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtCustomer.Text;
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = 100000;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void BindGridWithDates()
    {
        sql = "JCT_COURIER_GET_STATUS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtCustomer.Text;
        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = 100000;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void BindGrid()
    {

        for (int i = 0; i <= rblSaleOffices.Items.Count - 1; i++)
        {
            if (rblSaleOffices.Items[i].Selected == true)
            {
                sql = "JCT_COURIER_GET_STATUS";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFrom.Text;
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtTo.Text;
                cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
                cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtCustomer.Text;
                cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
                cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 20).Value = rblSelect.SelectedItem.Text;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = rblSaleOffices.Items[i].Text;

                cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
                cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
                cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

    
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (rblSelect.SelectedIndex == 0 || rblSelect.SelectedIndex == 1 || rblSelect.SelectedIndex == 2 || rblSelect.SelectedIndex == 3 || rblSelect.SelectedIndex == 6)
        {
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                BindGridWithOutDates(); 
            }
            else
            {
                BindGridWithDates();
            }
        }

        if (rblSelect.SelectedIndex == 4)
        {
            sql = "JCT_COURIER_GET_STATUS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
            cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
            cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtOtherParty.Text;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
            cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
            cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
            cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].Text = "Total Couriers";
        //    Sum = Sum + float.Parse(e.Row.Cells[4].Text);

        //}
        //else if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[4].Text = Sum.ToString();
        //    sql = "Select Count(*) as Total from  FROM    dbo.jct_courier_request_authorized a   INNER JOIN dbo.jct_courier_Request b ON a.Serial_No = b.Serial_No   WHERE   ( a.Slip_No = @COURIERID   OR @COURIERID = ''   )     AND ( b.PartyCode = @PARTyCode   OR @PARTYCODE = ''    )   AND ( b.Party_Name = @PARTYNAME   OR @PARTYNAME = ''    )   AND ( b.EmpCode = @RequestBy    OR @RequestBy = ''   )   AND a.STATUS <> 'D'  ";
        //}
    }

    protected void rblSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSelect.SelectedIndex == 0)
        {
            txtCustomer.Visible = true;
            txtSupplierName.Visible = false;
            txtOtherParty.Visible = false;
        }
        if (rblSelect.SelectedIndex == 1)
        {
            txtCustomer.Visible = false;
            txtSupplierName.Visible = true;
            txtOtherParty.Visible = false;
        }
        if (rblSelect.SelectedItem.Text == "HO")
        {
            txtOtherParty.Visible = true;
            txtSupplierName.Visible = false;
            txtCustomer.Visible = false;
            rblSaleOffices.Items.Clear();
        }
        else if (rblSelect.SelectedItem.Text == "Sales Office")
        {
            txtOtherParty.Visible = true;
            txtSupplierName.Visible = false;
            txtCustomer.Visible = false;
            rblSaleOffices.Items.Clear();
            sql = "select PartyCode,Description  from jct_courier_other_address where SaleOffice='Y' and status='A' ";
            obj1.FillList(rblSaleOffices, sql);

        }
        else if (rblSelect.SelectedItem.Text == "Hoshiarpur JCT")
        {
            txtOtherParty.Visible = true;
            txtSupplierName.Visible = false;
            txtCustomer.Visible = false;
            rblSaleOffices.Items.Clear();
        }
        else if (rblSelect.SelectedItem.Text == "Other")
        {
            txtOtherParty.Visible = true;
            txtSupplierName.Visible = false;
            txtCustomer.Visible = false;
            txtOtherParty.Visible = true;
            rblSaleOffices.Items.Clear();
            ListItem li = new ListItem("Prospective Customer", "Prospective Customer");
            rblSaleOffices.Items.Add(li);
            li = new ListItem("Prospective Supplier", "Prospective Supplier");
            rblSaleOffices.Items.Add(li);
            li = new ListItem("Agent", "Agent");
            rblSaleOffices.Items.Add(li);
            li = new ListItem("Personal", "Personal");
            rblSaleOffices.Items.Add(li);
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


    protected void txtPartyCode_TextChanged(object sender, EventArgs e)
    {
        #region Fill Party Detail On the Basis of PartyCode

        if (rblSelect.SelectedItem.Text == "Customer")
        {
            // sql = "Select cust_name , address_1 , address_2  , address_3 , city  , State ,  country,isnull(zip_no,'') as ZipCode,isnull(Phone_no,'') as [Phone]  from m_customer_address1 where cust_no ='" + txt.Text + "' ";
            sql = " SELECT b.cust_name   FROM miserp.som.dbo.m_cust_address a JOIN miserp.som.dbo.m_customer b ON a.cust_no=b.cust_no where a.cust_no ='" + txtPartyCode.Text + "' ";

            if (obj1.CheckRecordExistInTransaction(sql))
            {
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtCustomer.Text = dr[0].ToString();

                    }

                }
                else
                {
                    ShowAlertMsg("No Party Found..!! ");
                }
            }

        }
        if (rblSelect.SelectedItem.Text == "Supplier")
        {
            //  sql = "Select vendor_name , vendor_add1 , vendor_add2  , vendor_add3 , city  , State ,  country,ISnull( zip_code,'') as ZipCode  from jct_courier_vendor_master where vendor_code ='" + txt.Text + "' ";
            sql = "Select vendor_name  from miserp.apdb.dbo.ap_vendor_master where vendor_code ='" + txtPartyCode.Text + "' ";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtSupplierName.Text = dr[0].ToString();

                    }

                }
                else
                {
                    ShowAlertMsg("No Party Found..!! ");
                }
            }
        }
        #endregion
    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
   

        if (rblSelect.SelectedItem.Text == "Customer")
        {

            sql = "SELECT a.cust_no  FROM miserp.som.dbo.m_cust_address a JOIN miserp.som.dbo.m_customer b ON a.cust_no=b.cust_no where b.cust_name ='" + txtCustomer.Text + "'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtPartyCode.Text = dr[0].ToString();
                    }

                }
               
            }
            else
            {
                ShowAlertMsg("No Party Found..!! ");
            }
        }
    }

    protected void txtSupplierName_TextChanged(object sender, EventArgs e)
    {
          if (rblSelect.SelectedItem.Text == "Supplier")
        {

       
            sql = "Select vendor_code   from miserp.apdb.dbo.ap_vendor_master where vendor_name ='" + txtSupplierName.Text + "'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtPartyCode.Text = dr[0].ToString();
                 
                    }

                }
                else
                {
                    ShowAlertMsg("No Supplier Found..!! ");
                }
            }
        }
       
 
    }
    protected void txtOtherParty_TextChanged(object sender, EventArgs e)
    {
        if (rblSelect.SelectedItem.Text == "Other")
        {
            sql = "Select  ISNULL(PartyCode,'') FROM jct_courier_other_Address where  partyname ='" + txtOtherParty.Text + "'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                SqlDataReader dr = obj1.FetchReader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        { 
                         txtPartyCode.Text = dr[0].ToString();
                        }
                       
                        catch(Exception ex)
                        {
                        }
                    }

                }
                else
                {
                    ShowAlertMsg("No Data Found..!! ");
                }
            }
        }
    }
    protected void rblSaleOffices_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOtherParty.Visible = true;
        txtCustomer.Visible = false;
        if (rblSelect.SelectedIndex == 4)
        { 
              sql = "select Isnull(PartyCode,'') as PartyCode,PartyName from jct_courier_other_address where status='A' and PartyCode ='" + rblSaleOffices.SelectedItem.Value + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        while (dr.Read())
        {
            if (dr.HasRows)
            {
                txtOtherParty.Text = dr["PartyName"].ToString();
             
            }
        }
        }
        else if (rblSelect.SelectedIndex == 5)
        {
            txtPartyCode.Text = "";
            txtOtherParty.Text = "";
   
        }
      
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (txtTo.Text == "" || txtFrom.Text == "")
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridWithOutDates();
        }
        else
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridWithDates();
        }
        if (rblSelect.SelectedIndex == 4)
        {
            GridView1.PageIndex = e.NewPageIndex;
            sql = "JCT_COURIER_GET_STATUS";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
            cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
            cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtOtherParty.Text;
            cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
            cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
            cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
            cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        

    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);
        //DataSet ds = new DataSet();

        //if (rblSelect.SelectedIndex == 0 || rblSelect.SelectedIndex == 1 || rblSelect.SelectedIndex == 2 || rblSelect.SelectedIndex == 3 || rblSelect.SelectedIndex == 6)
        //{
        //    if (txtFrom.Text == "" || txtTo.Text == "")
        //    {
        //        sql = "JCT_COURIER_GET_STATUS";
        //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        //        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = "09/10/2012";
        //        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Now;
        //        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
        //        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtCustomer.Text;
        //        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        //        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        //        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        //        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        //        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);

        //        da.Fill(ds);
        //    }
        //    else
        //    {
        //        sql = "JCT_COURIER_GET_STATUS";
        //        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        //        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        //        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        //        cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
        //        cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtCustomer.Text;
        //        cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        //        cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        //        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        //        cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        //        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.SelectCommand.CommandTimeout = 100000;
        //        da.Fill(ds);
        //    }
        //}

        //if (rblSelect.SelectedIndex == 4)
        //{
        //    sql = "JCT_COURIER_GET_STATUS";
        //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@CourierID", SqlDbType.VarChar, 20).Value = txtCourierID.Text;
        //    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        //    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        //    cmd.Parameters.Add("@PartyCode", SqlDbType.VarChar, 20).Value = txtPartyCode.Text;
        //    cmd.Parameters.Add("@Partyname", SqlDbType.VarChar, 200).Value = txtOtherParty.Text;
        //    cmd.Parameters.Add("@RequestBy", SqlDbType.VarChar, 50).Value = txtRequestBy.Text;
        //    cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 50).Value = rblSelect.SelectedItem.Text;
        //    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 20).Value = "";

        //    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = ddlCourierStatus.SelectedItem.Value;
        //    cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDeliveryType.SelectedItem.Value;
        //    cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = DdlCouriertype.SelectedItem.Value;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);

        //    da.Fill(ds);
        //}

        //DataTable dt = ds.Tables[0];


        //string attachment = "attachment; filename=CourierReport.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/vnd.ms-excel";
        //string tab = "";
        //foreach (DataColumn dc in dt.Columns)
        //{
        //    Response.Write(tab + dc.ColumnName);
        //    tab = "\t";
        //}
        //Response.Write("\n");
        //int i;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    tab = "";
        //    for (i = 0; i < dt.Columns.Count; i++)
        //    {
        //        Response.Write(tab + dr[i].ToString());
        //        tab = "\t";
        //    }
        //    Response.Write("\n");
        //}
        //Response.End();

        //obj.ConClose();
    }

}