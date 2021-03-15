using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Payroll_Payroll_Bank_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            plantList();
            LocationList();
            //statelist();
            txteffto_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }

    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateCode();
            string qry = "JCT_payroll_Bank_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Bank_code", SqlDbType.VarChar, 20).Value = ViewState["BnkCode"];
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = txtBankName.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar,30).Value = txtcity.Text;
            cmd.Parameters.Add("@Contact_Person", SqlDbType.VarChar, 50).Value = txtContactPerson.Text;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar,12).Value = txtMobile.Text;          
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@email", SqlDbType.VarChar,40).Value = TxtEmail.Text;
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar,15).Value = TxtIfsc.Text;
            cmd.Parameters.Add("@website", SqlDbType.VarChar,40).Value = TxtWebsite.Text;
            cmd.ExecuteNonQuery();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            partialrefresh();
            lblBankCode.Visible = true;
            lbcodeid.Visible = true;
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "JCT_payroll_Bank_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Bank_code", SqlDbType.VarChar, 20).Value = lbcodeid.Text;
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = txtBankName.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@Contact_Person", SqlDbType.VarChar, 50).Value = txtContactPerson.Text;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 12).Value = txtMobile.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = lbsrid.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = TxtEmail.Text;
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar, 15).Value = TxtIfsc.Text;
            cmd.Parameters.Add("@website", SqlDbType.VarChar, 40).Value = TxtWebsite.Text;
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            partialrefresh();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "JCT_payroll_Bank_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
            cmd.Parameters.Add("@Bank_code", SqlDbType.VarChar, 20).Value = lbcodeid.Text;
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = txtBankName.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 60).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = txtstate.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtcity.Text;
            cmd.Parameters.Add("@Contact_Person", SqlDbType.VarChar, 50).Value = txtContactPerson.Text;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 12).Value = txtMobile.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
            cmd.Parameters.Add("@srno", SqlDbType.Int).Value = lbsrid.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = TxtEmail.Text;
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar, 15).Value = TxtIfsc.Text;
            cmd.Parameters.Add("@website", SqlDbType.VarChar, 40).Value = TxtWebsite.Text;
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

        lbcodeid.Visible = true;
        lblBankCode.Visible = true;
        lblSrNo.Visible = true;
        lbsrid.Visible = true;
        lbsrid.Text = grdDetail.SelectedRow.Cells[1].Text;
        ddlplant.Items.IndexOf(ddlplant.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text));
        ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text));
        lbcodeid.Text = grdDetail.SelectedRow.Cells[4].Text;
        txtBankName.Text = grdDetail.SelectedRow.Cells[5].Text;
        TxtEmail.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[6].Text);
        TxtIfsc.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[7].Text);
        txtaddress.Text = grdDetail.SelectedRow.Cells[8].Text;
        txtcity.Text=grdDetail.SelectedRow.Cells[9].Text;
        txtstate.Text=grdDetail.SelectedRow.Cells[10].Text;
        //ddlstate_SelectedIndexChanged(sender, null);
        ddlcountry.SelectedIndex = ddlcountry.Items.IndexOf(ddlcountry.Items.FindByText(grdDetail.SelectedRow.Cells[11].Text));
        TxtWebsite.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[12].Text);
        txtContactPerson.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[13].Text);
        txtMobile.Text = HttpUtility.HtmlDecode(grdDetail.SelectedRow.Cells[14].Text);
        txtefffrm.Text = grdDetail.SelectedRow.Cells[15].Text;
        txteffto.Text = grdDetail.SelectedRow.Cells[16].Text;
    }

    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;
        //string qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
        ////SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Bank_code),CHARINDEX('-',max(Bank_code))+1,len(max(Bank_code))+3) from JCT_payroll_bank_master ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["BnkCode"] = "100";
                    ViewState["BnkCode"] = "BNK-" + ViewState["BnkCode"];
                }
                else
                {
                    ViewState["BnkCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["BnkCode"] = "BNK-" + ViewState["BnkCode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payroll_Bank_master.aspx");
    }

    private void bindgrid()
    {
        string qry = "Jct_Payroll_Banklist_Fetch";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant_code", SqlDbType.VarChar, 20).Value = ddlplant.SelectedItem.Value;
        cmd.Parameters.Add("@Location_code", SqlDbType.VarChar, 20).Value = ddlLocation.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        
    }

    //protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    citylist();
       
    //}

    //private void citylist()
    //{

    //    string qry = "Jct_Payroll_Citylist_Fetch ";
    //    SqlCommand cmd = new SqlCommand(qry, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@state", SqlDbType.VarChar,30).Value = ddlstate.SelectedItem.Value;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlCity.DataSource = ds;
    //    ddlCity.DataTextField = "City";
    //    ddlCity.DataValueField = "City";
    //    ddlCity.DataBind();
    //}


    public void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearTextBoxes();
        LocationList();
    }


    public void plantList()
    {
        sql = "Jct_Payroll_Plantlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlplant.DataSource = ds;
        ddlplant.DataTextField = "ShortDescription";
        ddlplant.DataValueField = "PlantCode";
        ddlplant.DataBind();
    }
    //private void statelist()
    //{
    //    sql = "Jct_payroll_statelist_fetch";
    //    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    ddlstate.DataSource = ds;
    //    ddlstate.DataTextField = "State";
    //    ddlstate.DataValueField = "State";
    //    ddlstate.DataBind();
    //}

    protected void LocationList()
    {
        sql = "Jct_Payroll_Locationlist_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlLocation.DataSource = ds;
        ddlLocation.DataTextField = "LocationDescription";
        ddlLocation.DataValueField = "LocationCode";
        ddlLocation.DataBind();
        if(ds.Tables.Count > 1)
        {
            bindgrid();
        }
        bindgrid();
        
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    private void ClearTextBoxes()
    {
        //ddlplant.ClearSelection();
        ddlLocation.ClearSelection();
        txtefffrm.Text = "";
        txteffto.Text = "";
        txtBankName.Text = "";
        txtContactPerson.Text = "";
        txtaddress.Text = "";
        txtMobile.Text = "";
        lbcodeid.Visible = false;
        lblBankCode.Visible = false;
        lblSrNo.Visible = false;
        lbsrid.Visible = false;
        txtcity.Text = "";
        txtstate.Text = "";
        ddlcountry.ClearSelection();
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        TxtEmail.Text = "";
        TxtIfsc.Text = "";
        TxtWebsite.Text = "";
    }
    private void partialrefresh()
    {
        txtefffrm.Text = "";
        txteffto.Text = "";
        txtBankName.Text = "";
        txtContactPerson.Text = "";
        txtaddress.Text = "";
        txtMobile.Text = "";
        lblSrNo.Visible = false;
        lbsrid.Visible = false;
        TxtEmail.Text = "";
        TxtIfsc.Text = "";
        TxtWebsite.Text = "";
    }
}