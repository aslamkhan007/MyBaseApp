using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class OPS_Costing_Serial_no_Master : System.Web.UI.Page
{
    private string Sql;
    private SqlDataReader dr;
    private SqlCommand cmd;
    public HelpDeskClass obj;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    string message = "";
    DBConnect db;
    public CostingSerialNo cs;
    DateTime dtEffFrom, dtNow, dtEffTo;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        
        string currentYear = DateTime.Now.Year.ToString();
        cs = new CostingSerialNo(jctdevConnectionString);
        if (!IsPostBack)
        {

            DisableControls();

        }
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
        DataBind();
        txtSuffix.Text = "/" + currentYear;
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "ADD")
        {
            EnableControls();
            btnAdd.Text = "SAVE";
            return;
        }

        if (btnAdd.Text == "SAVE")
        {
            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);
            if (txtTypeCode.Text == "")
            {
               
                FMsg.Text="Please Enter Type Code ";
                
                txtTypeCode.Focus();
                return;
            }
            if (txtType.Text == "")
            {
                FMsg.Text = "Please Enter Type ";
                txtType.Focus();
                return;
            }
            if (txtPrefix.Text == "")
            {
                FMsg.Text = "Please Enter Prefix ";
                txtPrefix.Focus();
                return;
            }
            //if (txtCountValue.Text == "")
            //{
            //    FMsg.Text = "Please Enter Count Value ";
            //    txtCountValue.Focus();
            //    return;
            //}

            if (txtSuffix.Text == "")
            {
                FMsg.Text = "Please Enter Suffix ";
                txtSuffix.Focus();
                return;
            }
            if (txt_efffrom.Text == "")
            {
                FMsg.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }
            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }

            cs.type_code = txtTypeCode.Text;
            cs.type = txtType.Text;
            cs.Prefix = txtPrefix.Text;
            //cs.count_value = Convert.ToInt32(txtCountValue.Text);
            cs.Suffix = txtSuffix.Text;
            //  cs.Serial_number = txtSerialNo.Text;
            cs.eff_from = Convert.ToDateTime(txt_efffrom.Text);
            cs.eff_to = Convert.ToDateTime(txt_effto.Text);
            cs.Active = "Y";


            message = cs.ExecuteAdd();
            if (message.Trim() == "Sucess")
            {
                DataBind();
                FMsg.Text = "Sucessfully Added";

            }
            else
            {
                FMsg.Text = message;
            }
          //  FMsg.Text = "Record Added Successfully";
            //DataBind();
            btnAdd.Text = "ADD";
            ClearControls();
            DisableControls();
            return;
        }
        if (btnAdd.Text == "MODIFY")
        {
            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);
            if (txtTypeCode.Text == "")
            {
                FMsg.Text = "Please Enter Type Code ";
               
                txtTypeCode.Focus();
                return;
            }
            if (txtType.Text == "")
            {
                FMsg.Text = "Please Enter Type ";
                txtType.Focus();
                return;
            }
            if (txtPrefix.Text == "")
            {
                FMsg.Text = "Please Enter Prefix ";
                txtPrefix.Focus();
                return;
            }
            //if (txtCountValue.Text == "")
            //{
            //    FMsg.Text = "Please Enter Count Value ";
            //    txtCountValue.Focus();
            //    return;
            //}

            if (txtSuffix.Text == "")
            {
                FMsg.Text = "Please Enter Suffix ";
                txtSuffix.Focus();
                return;
            }

            if (txt_efffrom.Text == "")
            {
                FMsg.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }
            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }
            cs.type_code = txtTypeCode.Text;
            cs.type = txtType.Text;
            cs.Prefix = txtPrefix.Text;
            //cs.count_value = Convert.ToInt32(txtCountValue.Text);
            cs.Suffix = txtSuffix.Text;
            // cs.Serial_number = txtSerialNo.Text;
            cs.eff_from = Convert.ToDateTime(txt_efffrom.Text);
            cs.eff_to = Convert.ToDateTime(txt_effto.Text);
            cs.Active = "Y";


            message = cs.ExecuteModify();
            if (message.Trim() == "Sucess")
            {
                DataBind();
                FMsg.Text = "Sucessfully Modified";
            }
            else
            {
                FMsg.Text = message;
            }

            //  FMsg1.Text = "Record Modified Successfully";
            //  DataBind();
            btnAdd.Text = "ADD";
            ClearControls();
            DisableControls();

            return;
        }


    }

    private void DataBind()
    {
        grdView.DataSource = null;
        ds = cs.BindData();
        grdView.DataSource = ds;
        grdView.DataBind();
    }



    private void ClearControls()
    {
        txtType.Text = "";
        txtTypeCode.Text = "";
        txtPrefix.Text = "";
        //txtSuffix.Text = "";                
        //txt_efffrom.Text = "";
        //txt_effto.Text = "";
    }

    private void EnableControls()
    {
        txtType.Enabled = true;
        txtTypeCode.Enabled = true;
        txtPrefix.Enabled = true;       
        //txtSerialNo.Enabled = true;
        txt_efffrom.Enabled = true;
        txt_effto.Enabled = true;
    }
    private void DisableControls()
    {
        txtType.Enabled = false;
        txtTypeCode.Enabled = false;
        txtPrefix.Enabled = false;
        txtSuffix.Enabled = false;     
        //txt_efffrom.Enabled = false;
        //txt_effto.Enabled = false;
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
    }

    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {
        FMsg.Text = "";
        GridViewRow row = grdView.SelectedRow;
       string sKey = grdView.SelectedDataKey.Value.ToString();       
        txtTypeCode.Text = sKey;
        txtType.Text = row.Cells[1].Text;
        txtPrefix.Text = row.Cells[2].Text;        
        txtSuffix.Text = row.Cells[4].Text;       
        txt_efffrom.Text = row.Cells[5].Text;
        txt_effto.Text = row.Cells[6].Text;
        MEV6.InitialValue = row.Cells[5].Text;

        //ViewState["UKey"] = sKey;
        //cs.type_code = sKey;
        //FillControl(sKey);
        EnableControls();
        btnAdd.Text = "MODIFY";
        grdView.SelectedRow.BackColor = Color.LightGreen;
        btnAuthorize.Visible = true;
        btnDelete.Visible = true;
    }


    private void FillControl(string ID)
    {

        ds = cs.FillData();
        txtTypeCode.Text = ds.Tables[0].Rows[0][0].ToString();
        txtType.Text = ds.Tables[0].Rows[0][1].ToString();
        txtPrefix.Text = ds.Tables[0].Rows[0][2].ToString();        
        txtSuffix.Text = ds.Tables[0].Rows[0][4].ToString();        
        txt_efffrom.Text = ds.Tables[0].Rows[0][6].ToString();
        txt_effto.Text = ds.Tables[0].Rows[0][7].ToString();
        
    }

    public string SetDateFormat(string dt)
    {
        DateTime newdt = new DateTime();
        string nwdt = "";
        try
        {
            newdt = Convert.ToDateTime(dt);// dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
            //newdt = dt.Substring(0, dt.IndexOf("/"));
            //dt = dt.Substring(dt.IndexOf("/") + 1, dt.Length - dt.IndexOf("/") - 1);
            //newdt = dt.Substring(0, dt.IndexOf("/")) + "/" + newdt;
            //dt = dt.Substring(dt.IndexOf("/") + 1, dt.Length - dt.IndexOf("/") - 1);
            //newdt = newdt + "/" + dt;
            ////newdt = newdt.Substring(0, newdt.IndexOf(" "));
            nwdt = newdt.Day.ToString() + "/" + newdt.Month.ToString() + "/" + newdt.Year.ToString();
            if (nwdt == "")
                nwdt = "";

            return nwdt;

        }
        catch (Exception ex)
        {
            return "null";
        }
        finally
        {

        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        FMsg.Text = "";
        DisableControls();
        btnAdd.Text = "ADD";
        ClearControls();
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        cs.type_code = txtTypeCode.Text;
        cs.type = txtType.Text;
        cs.Prefix = txtPrefix.Text;
        cs.Suffix = txtSuffix.Text;
        cs.eff_from = Convert.ToDateTime(txt_efffrom.Text);
        cs.eff_to = Convert.ToDateTime(txt_effto.Text);
        cs.Active = "A";

        message = cs.ExecuteAuthorize();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg.Text = "Sucessfully Authorized";
        }
        else
        {
            FMsg.Text = message;
        }        
        DataBind();
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();
        return;

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cs.type_code = txtTypeCode.Text;
        cs.type = txtType.Text;
        cs.Prefix = txtPrefix.Text;        
        cs.Suffix = txtSuffix.Text;        
        cs.eff_from = Convert.ToDateTime(txt_efffrom.Text);
        cs.eff_to = Convert.ToDateTime(txt_effto.Text);
        cs.Active = "C";

        message = cs.ExecuteDelete();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg.Text = "Sucessfully Deleted";
        }
        else
        {
            FMsg.Text = message;
        }        
        DataBind();
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();
        return;
    }
    
}