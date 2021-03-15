using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Payroll_payroll_Plant_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    string sql = string.Empty;
    string qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            txteffto_CalendarExtender.SelectedDate = Convert.ToDateTime("12/31/9999");
        }        
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateCode();
            qry = "JCT_payroll_Plant_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Name", SqlDbType.VarChar, 20).Value = txtPlantName.Text;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 20).Value = ViewState["PlnCode"];
            cmd.Parameters.Add("@Plant_description", SqlDbType.VarChar, 100).Value = txtPlantDescription.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = ddlstate.SelectedItem.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlCity.SelectedItem.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            //cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = "s-13823";//Session["EmpCode"];
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Add";
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            lblPlantCode.Visible = true;
            //lbcodeid.Text = ViewState["locCode"];
            lbcodeid.Visible = true;
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    private void bindgrid()
    {
        qry = " SELECT Plant_Name ,Plant_code , Plant_description , Address ,City ,State , Country , CONVERT(VARCHAR(10),FromDate,101) AS EffectiveFrom,CONVERT(VARCHAR(10),ToDate,101) AS EffectiveTo FROM jctpayroll_PlantMaster WHERE  status='A'";
        SqlCommand cmd = new SqlCommand(qry, obj.Connection());
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
        //con.Close();
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("payroll_Plant_master.aspx");
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {

        try
        {
            qry = "JCT_payroll_Plant_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Name", SqlDbType.VarChar, 20).Value = txtPlantName.Text;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Plant_description", SqlDbType.VarChar, 100).Value = txtPlantDescription.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = ddlstate.SelectedItem.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlCity.SelectedItem.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];            
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "upd";
            cmd.ExecuteNonQuery();
            //con.Close();
            bindgrid();
            string script = "alert('Record  Updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            ClearTextBoxes();
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
            //qry = ConfigurationManager.ConnectionStrings["test"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            qry = "JCT_payroll_Plant_master_insert_del_update";
            SqlCommand cmd = new SqlCommand(qry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Plant_Name", SqlDbType.VarChar, 20).Value = txtPlantName.Text;
            cmd.Parameters.Add("@Plant_Code", SqlDbType.VarChar, 10).Value = lbcodeid.Text;
            cmd.Parameters.Add("@Plant_description", SqlDbType.VarChar, 100).Value = txtPlantDescription.Text;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = txtaddress.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlcountry.SelectedItem.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = ddlstate.SelectedItem.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = ddlCity.SelectedItem.Text;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
            cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["EmpCode"];   
            cmd.Parameters.Add("@flag", SqlDbType.Char, 5).Value = "Del";
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
        txtPlantName.Text = grdDetail.SelectedRow.Cells[1].Text;          
        lbcodeid.Text = grdDetail.SelectedRow.Cells[2].Text;
        txtPlantDescription.Text = grdDetail.SelectedRow.Cells[3].Text;   
        txtaddress.Text = grdDetail.SelectedRow.Cells[4].Text;
        ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text));
        ddlstate_SelectedIndexChanged(sender, null);
        ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByText(grdDetail.SelectedRow.Cells[5].Text));     
        ddlcountry.SelectedIndex = ddlcountry.Items.IndexOf(ddlcountry.Items.FindByText(grdDetail.SelectedRow.Cells[7].Text));    
        txtefffrm.Text = grdDetail.SelectedRow.Cells[8].Text;
        txteffto.Text = grdDetail.SelectedRow.Cells[9].Text;            
        lbcodeid.Visible = true;
        lblPlantCode.Visible = true;
    }
    protected void GenerateCode()
    {
        #region Serial No. Code

        string str;

        //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
        //qry = ConfigurationManager.ConnectionStrings["test"].ToString();
        //SqlConnection con = new SqlConnection(qry);
        //con.Open();

        SqlCommand cmd = new SqlCommand("select SUBSTRING(max(Plant_code),CHARINDEX('-',max(Plant_code))+1,len(max(Plant_code))+3) from jctpayroll_PlantMaster ", obj.Connection());
        SqlDataReader dr = cmd.ExecuteReader();
        //dr.Read();
        if (dr.HasRows)
        {

            while (dr.Read())
            {
                str = dr[0].ToString();
                if (string.IsNullOrEmpty(dr[0].ToString()))
                {
                    ViewState["PlnCode"] = "100";
                    ViewState["PlnCode"] = "PLN-" + ViewState["PlnCode"];
                }
                else
                {
                    ViewState["PlnCode"] = int.Parse(dr[0].ToString()) + 1;
                    ViewState["PlnCode"] = "PLN-" + ViewState["PlnCode"];
                }
            }

        }

        dr.Close();
        //con.Close();

        #endregion
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        citylist();
    }
    private void ClearTextBoxes()
    {
        txtefffrm.Text = "";
        txteffto.Text = "";
        lblPlantCode.Visible = false;
        lbcodeid.Visible = false;
        ddlcountry.ClearSelection();
        ddlstate.ClearSelection();
        ddlCity.ClearSelection();
        txtaddress.Text = "";
        txtPlantDescription.Text = "";
        txtPlantName.Text = "";


    }
    private void citylist()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT City FROM JCTGEN..JCT_EPOR_STATE_MASTER   WHERE State LIKE '" + ddlstate.SelectedItem.Value + "'", obj.Connection());

        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlCity.DataSource = ds;
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City";
        ddlCity.DataBind();
    }
}