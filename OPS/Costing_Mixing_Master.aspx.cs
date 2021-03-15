using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class OPS_Costing_Mixing_Master : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DBConnect db;
    public CostingMixing cm;

    string message = "";

    DateTime dtEffFrom, dtNow, dtEffTo;
    string CurrentDate = DateTime.Now.Month.ToString() + '/' + DateTime.Now.Day.ToString() + '/' + DateTime.Now.Year.ToString();
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        cm = new CostingMixing(jctdevConnectionString);
        if (!IsPostBack)
        {
            DisableControls();
        }
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
        DataBind();
    }

    private void DataBind()
    {
        grdView.DataSource = null;
        ds = cm.BindData();
        grdView.DataSource = ds;
        grdView.DataBind();
    }
    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {

        FMsg1.Text = "";
        GridViewRow row = grdView.SelectedRow;
        string sKey = grdView.SelectedDataKey.Value.ToString();
        EnableControls();
        txttranno.Text = sKey;
        txtMixingCode.Text = row.Cells[1].Text;
        txtMixingDesc.Text = row.Cells[2].Text;
        txtSequence.Text = row.Cells[3].Text;
        txt_efffrom.Text = row.Cells[4].Text;
        txt_effto.Text = row.Cells[5].Text;
        btnAdd.Text = "MODIFY";
        grdView.SelectedRow.BackColor = Color.LightGreen;
        btnAuthorize.Visible = true;
        btnDelete.Visible = true;

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "ADD")
        {
            EnableControls();
            btnAdd.Text = "SAVE";
            txtMixingCode.Focus();
            return;
        }

        if (btnAdd.Text == "SAVE")
        {

            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);

            if (txtMixingCode.Text == "")
            {
                FMsg1.Text = "Please Enter Mixing Code ";
                txtMixingCode.Focus();
                return;
            }
            if (txtMixingDesc.Text == "")
            {
                FMsg1.Text = "Please Enter Mixing Desc. ";
                txtMixingDesc.Focus();
                return;
            }
            if (txtSequence.Text == "")
            {
                FMsg1.Text = "Please Enter Sequence No ";
                txtSequence.Focus();
                return;
            }
            if (txt_efffrom.Text == "")
            {
                FMsg1.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }

            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg1.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }


            cm.tran_no = txttranno.Text;
            cm.mixing_code = txtMixingCode.Text;
            cm.mixing_desc = txtMixingDesc.Text;
            cm.sequence_no = Convert.ToInt32(txtSequence.Text);
            cm.eff_from = Convert.ToDateTime(txt_efffrom.Text);
            cm.eff_to = Convert.ToDateTime(txt_effto.Text);
            cm.status = "O";

            message = cm.ExecuteAdd();
            if (message.Trim() == "Sucess")
            {
                DataBind();
                FMsg1.Text = "Sucessfully Added";

            }
            else
            {
                FMsg1.Text = message;
            }
            // txttranno.Text = dt.Rows[0].ToString();
            //  FMsg1.Text = "Record Added Successfully";
            DataBind();
            btnAdd.Text = "ADD";
            ClearControls();
            DisableControls();
            return;

        }
        if (btnAdd.Text == "MODIFY")
        {

            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);

            if (txtMixingCode.Text == "")
            {
                FMsg1.Text = "Please Enter Mixing Code ";

                txtMixingCode.Focus();
                return;
            }
            if (txtMixingDesc.Text == "")
            {
                FMsg1.Text = "Please Enter Mixing Desc. ";
                txtMixingDesc.Focus();
                return;
            }
            if (txtSequence.Text == "")
            {
                FMsg1.Text = "Please Enter Sequence No ";
                txtSequence.Focus();
                return;
            }
            if (txt_efffrom.Text == "")
            {
                FMsg1.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }
            //if (dtEffFrom.Date < Convert.ToDateTime(CurrentDate))
            //{
            //    FMsg1.Text = "Effective From Date Can't Less Than Today Date ";
            //    return;
            //}
            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg1.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }

            cm.tran_no = txttranno.Text;
            cm.mixing_code = txtMixingCode.Text;
            cm.mixing_desc = txtMixingDesc.Text;
            cm.sequence_no = Convert.ToInt32(txtSequence.Text);
            cm.eff_from = Convert.ToDateTime(txt_efffrom.Text);
            cm.eff_to = Convert.ToDateTime(txt_effto.Text);
            cm.status = "O";
            cm.userid = null;


            string CityId = (string)(Session["fkCityId"]);



            message = cm.ExecuteModify();
            if (message.Trim() == "Sucess")
            {
                DataBind();
                FMsg1.Text = "Sucessfully Modified";
            }
            else
            {
                FMsg1.Text = message;
            }

            //  FMsg1.Text = "Record Modified Successfully";
            //  DataBind();
            btnAdd.Text = "ADD";
            ClearControls();
            DisableControls();
            return;
        }

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        FMsg1.Text = "";
        DisableControls();
        btnAdd.Text = "ADD";
        ClearControls();
    }

    private void EnableControls()
    {
        txtMixingCode.Enabled = true;
        txtMixingDesc.Enabled = true;
        txtSequence.Enabled = true;
        txt_efffrom.Enabled = true;
        txt_effto.Enabled = true;
    }

    private void ClearControls()
    {
        txttranno.Text = "";
        txtMixingCode.Text = "";
        txtMixingDesc.Text = "";
        txtSequence.Text = "";
        txt_efffrom.Text = "";
        txt_effto.Text = "";
    }
    private void DisableControls()
    {
        txttranno.Enabled = false;
        txtMixingCode.Enabled = false;
        txtMixingDesc.Enabled = false;
        txtSequence.Enabled = false;
        //txt_efffrom.Enabled = false;
        //txt_effto.Enabled = false;
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        cm.tran_no = txttranno.Text;
        cm.mixing_code = txtMixingCode.Text;
        cm.mixing_desc = txtMixingDesc.Text;
        cm.sequence_no = Convert.ToInt32(txtSequence.Text);
        cm.eff_from = Convert.ToDateTime(txt_efffrom.Text);
        cm.eff_to = Convert.ToDateTime(txt_effto.Text);
        cm.status = "O";


        message = cm.ExecuteAuthorize();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg1.Text = "Sucessfully Authorized";
        }
        else
        {
            FMsg1.Text = message;
        }
        //  FMsg1.Text = "Record Authorize Successfully";
        DataBind();
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();
        return;

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        cm.tran_no = txttranno.Text;
        cm.mixing_code = txtMixingCode.Text;
        cm.mixing_desc = txtMixingDesc.Text;
        cm.sequence_no = Convert.ToInt32(txtSequence.Text);
        cm.eff_from = Convert.ToDateTime(txt_efffrom.Text);
        cm.eff_to = Convert.ToDateTime(txt_effto.Text);
        cm.status = "O";

        message = cm.ExecuteDelete();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg1.Text = "Sucessfully Deleted";
        }
        else
        {
            FMsg1.Text = message;
        }
        //FMsg1.Text = "Record Delete Successfully";
        DataBind();
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();
        return;
    }

    //protected void txtSequence_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtSequence.Text.Any(char.IsLetter))
    //    {
    //        FMsg1.Text = "Record Delete Successfully";
    //    }
    //}


    protected void grdView_Sorting(object sender, GridViewSortEventArgs e)
    {
        
    }
}