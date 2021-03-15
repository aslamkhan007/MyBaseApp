using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;


public partial class OPS_Costing_Count_Master : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DBConnect db;
    public CostingCount cc;

    string message = "";
    SqlDataReader dr = null;
    DateTime dtEffFrom, dtNow, dtEffTo;
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;

    DateTime date;
    DateTime startdate;
    DateTime enddate;

    protected void Page_Load(object sender, EventArgs e)
    {
        cc = new CostingCount(jctdevConnectionString);
        txtCountCode.Focus();
        if (!IsPostBack)
        {
            txttranno.Enabled = false;

          
            //DisableControls();
            btnAuthorize.Visible = false;
            btnDelete.Visible = false;
            DataBind();
        }
      
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //if (btnAdd.Text == "ADD")
        //{
        //   // EnableControls();
        //    btnAdd.Text = "SAVE";
        //    return;
        //}

        if (btnAdd.Text == "ADD")
        {
                       
            if (txtCountCode.Text == "")
            {
                FMsg1.Text = "Please Enter Count Code ";
                txtCountCode.Focus();
                return;
            }
            if (txtCountDesc.Text == "")
            {
                FMsg1.Text = "Please Enter Count Desc. ";
                txtCountDesc.Focus();
                return;
            }
            if (ddlCountType.SelectedItem.Value == "")
            {
                FMsg1.Text = "Select Count Type ";
              
                return;
            }
            if (txtSequenceNo.Text == "")
            {
                FMsg1.Text = "Please Enter Sequence No ";
                txtSequenceNo.Focus();
                return;
            }
            if (ddlCountUsage.SelectedItem.Value == "")
            {
                FMsg1.Text = "Select Count Usage ";
                
                return;
            }

            if (txt_efffrom.Text == "")
            {
                FMsg1.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg1.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }
            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);
            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }



            cc.tran_no = txttranno.Text;
            cc.count_code = txtCountCode.Text;
            cc.count_desc = txtCountDesc.Text;
            cc.sequence_no = Convert.ToInt32(txtSequenceNo.Text);
            cc.actual_type = Convert.ToDouble(txtActualCount.Text);
            cc.eff_from = txt_efffrom.Text;

            cc.eff_to = Convert.ToDateTime(txt_effto.Text);

            cc.status = "O";
            cc.count_type = Convert.ToInt32(ddlCountType.SelectedItem.Value);

         

            cc.count_usage = ddlCountUsage.SelectedItem.Value;
            message = cc.ExecuteAdd();
            if (message.Trim() == "Sucess")
            {
                DataBind();
                FMsg1.Text = "Sucessfully Added";

            }
            else
            {
                FMsg1.Text = message;
            }
        
            DataBind();
            btnAdd.Text = "ADD";
            ClearControls();
            //  DisableControls();
            return;

        }

        if (btnAdd.Text == "MODIFY")
        {
          
            if (txtCountCode.Text == "")
            {
                FMsg1.Text = "Please Enter Count Code ";
                txtCountCode.Focus();
                return;
            }
            if (txtCountDesc.Text == "")
            {
                FMsg1.Text = "Please Enter Count Desc. ";
                txtCountDesc.Focus();
                return;
            }

            if (ddlCountType.SelectedItem.Value == "")
            {
                FMsg1.Text = "Select Count Type ";

                return;
            }

            if (txtActualCount.Text == "")
            {
                FMsg1.Text = "Please Enter Count Desc. ";
                txtActualCount.Focus();
                return;
            }


            if (ddlCountUsage.SelectedItem.Value == "")
            {
                FMsg1.Text = "Please Select Count Usage ";
             
                return;
            }


            if (txtSequenceNo.Text == "")
            {
                FMsg1.Text = "Please Enter Sequence No ";
                txtSequenceNo.Focus();
                return;
            }
            if (txt_efffrom.Text == "")
            {
                FMsg1.Text = "Please Enter Eff From Date. ";
                txt_efffrom.Focus();
                return;
            }
            if (txt_effto.Text == "")
            {
                FMsg1.Text = "Please Enter Eff To Date. ";
                txt_effto.Focus();
                return;
            }
            dtEffFrom = DateTime.Parse(txt_efffrom.Text);
            dtEffTo = DateTime.Parse(txt_effto.Text);

            if (dtEffFrom.Date > dtEffTo)
            {
                FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
                return;
            }

           
            cc.tran_no = txttranno.Text;
            cc.count_code = txtCountCode.Text;
            cc.count_desc = txtCountDesc.Text;
            cc.sequence_no = Convert.ToInt32(txtSequenceNo.Text);
            cc.actual_type = Convert.ToDouble(txtActualCount.Text);
            cc.count_usage = ddlCountType.SelectedItem.Value;
       
            cc._eff_from = txt_efffrom.Text;
            cc.eff_to = Convert.ToDateTime(txt_effto.Text);
            cc.status = "O";
            cc.userid = null;

            message = cc.ExecuteModify();
            if (message.Trim() == "Sucess")
            {
                DataBind();

                FMsg1.Text = "Successfully Modified";
            }
            else
            {
                FMsg1.Text = message;
            }

          
            btnAdd.Text = "ADD";
            ClearControls();
            DisableControls();

            return;
        }

    }

    private void DataBind()
    {
        grdView.DataSource = null;
        ds = cc.BindData();
        grdView.DataSource = ds;
        grdView.DataBind();
    }

    private void EnableControls()
    {
        txtCountCode.Enabled = true;
        txtCountDesc.Enabled = true;
        txtSequenceNo.Enabled = true;
        txt_efffrom.Enabled = true;
        txt_effto.Enabled = true;
    }

    private void ClearControls()
    {
        txttranno.Text = "";
        txtCountCode.Text = "";
        txtCountDesc.Text = "";
        ddlCountType.SelectedItem.Value = "";
        ddlCountUsage.SelectedItem.Value = "";
        txtActualCount.Text = "";
        txtSequenceNo.Text = "";
        txt_efffrom.Text = "";
        txt_effto.Text = "";
        txtActualCount.Text = "";

    }
    private void DisableControls()
    {
        txttranno.Enabled = false;
        txtCountCode.Enabled = false;
        txtCountDesc.Enabled = false;
        txtSequenceNo.Enabled = false;
      
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
    }
    protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = grdView.SelectedRow;
        //grdView.UseAccessibleHeader = true;
        //grdView.HeaderRow.TableSection = TableRowSection.TableHeader;  
        FMsg1.Text = "";
        string sKey = grdView.SelectedDataKey.Value.ToString();

        txttranno.Text = sKey;
        txtCountCode.Text = row.Cells[1].Text;
        txtCountDesc.Text = row.Cells[2].Text;
        ddlCountType.SelectedValue = row.Cells[3].Text;
        ddlCountUsage.SelectedValue = row.Cells[5].Text;
        txtActualCount.Text = row.Cells[4].Text;
        txtSequenceNo.Text = row.Cells[6].Text;
        date = Convert.ToDateTime(row.Cells[7].Text);
        txt_efffrom.Text = date.ToShortDateString();
     
        date = Convert.ToDateTime(row.Cells[8].Text);
        txt_effto.Text = date.ToShortDateString();
      
        EnableControls();
        btnAdd.Text = "MODIFY";




        grdView.SelectedRow.BackColor = Color.LightGreen;
        btnAuthorize.Visible = true;
        btnDelete.Visible = true;
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        DisableControls();
        btnAdd.Text = "ADD";
        ClearControls();
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
      

        if (txtCountCode.Text == "")
        {
            FMsg1.Text = "Please Enter Count Code ";
            txtCountCode.Focus();
            return;
        }
        if (txtCountDesc.Text == "")
        {
            FMsg1.Text = "Please Enter Count Desc. ";
            txtCountDesc.Focus();
            return;
        }

        if (ddlCountType.SelectedItem.Value=="")
        {
            FMsg1.Text = "Please Select Count Type. ";
          
            return;
        }

        if (txtActualCount.Text == "")
        {
            FMsg1.Text = "Please Enter Count Desc. ";
            txtActualCount.Focus();
            return;
        }


        if (ddlCountUsage.SelectedItem.Value == "")
        {
            FMsg1.Text = "Please Select Count Usage ";
           
            return;
        }


        if (txtSequenceNo.Text == "")
        {
            FMsg1.Text = "Please Enter Sequence No ";
            txtSequenceNo.Focus();
            return;
        }
        if (txt_efffrom.Text == "")
        {
            FMsg1.Text = "Please Enter Eff From Date. ";
            txt_efffrom.Focus();
            return;
        }
        if (txt_effto.Text == "")
        {
            FMsg1.Text = "Please Enter Eff To Date. ";
            txt_effto.Focus();
            return;
        }
        dtEffFrom = DateTime.Parse(txt_efffrom.Text);
        dtEffTo = DateTime.Parse(txt_effto.Text);
        if (dtEffFrom.Date > dtEffTo)
        {
            FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
            return;
        }
    
        cc.tran_no = txttranno.Text;
        cc.count_code = txtCountCode.Text;
        cc.count_desc = txtCountDesc.Text;
        cc.sequence_no = Convert.ToInt32(txtSequenceNo.Text);
        cc.actual_type = Convert.ToDouble(txtActualCount.Text);
        cc.count_type = Convert.ToInt32(ddlCountType.SelectedItem.Value);
        cc.count_usage = ddlCountUsage.SelectedItem.Value;
     
        cc._eff_from = txt_efffrom.Text;
        cc.eff_to = Convert.ToDateTime(txt_effto.Text);
        cc.status = "A";
        cc.userid = null;

        message = cc.ExecuteAuthorize();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg1.Text = "Sucessfully Authorized";

        }
        else
        {
            FMsg1.Text = message;
        }

       
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();

        return;
    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
      

        if (txtCountCode.Text == "")
        {
            FMsg1.Text = "Please Enter Count Code ";
            txtCountCode.Focus();
            return;
        }
        if (txtCountDesc.Text == "")
        {
            FMsg1.Text = "Please Enter Count Desc. ";
            txtCountDesc.Focus();
            return;
        }

        if (ddlCountType.SelectedItem.Value == "")
        {
            FMsg1.Text = "Please Select Count Type. ";
           
            return;
        }

        if (txtActualCount.Text == "")
        {
            FMsg1.Text = "Please Enter Count Desc. ";
            txtActualCount.Focus();
            return;
        }


        if (ddlCountUsage.SelectedItem.Value == "")
        {
            FMsg1.Text = "Please Select Count Usage ";
         
            return;
        }


        if (txtSequenceNo.Text == "")
        {
            FMsg1.Text = "Please Enter Sequence No ";
            txtSequenceNo.Focus();
            return;
        }
        if (txt_efffrom.Text == "")
        {
            FMsg1.Text = "Please Enter Eff From Date. ";
            txt_efffrom.Focus();
            return;
        }
        if (txt_effto.Text == "")
        {
            FMsg1.Text = "Please Enter Eff To Date. ";
            txt_effto.Focus();
            return;
        }
        dtEffFrom = DateTime.Parse(txt_efffrom.Text);
        dtEffTo = DateTime.Parse(txt_effto.Text);
        if (dtEffFrom.Date > dtEffTo)
        {
            FMsg1.Text = "Effective From Date Can't Less Than Effective To Date ";
            return;
        }
      
        cc.tran_no = txttranno.Text;
        cc.count_code = txtCountCode.Text;
        cc.count_desc = txtCountDesc.Text;
        cc.sequence_no = Convert.ToInt32(txtSequenceNo.Text);
        cc.actual_type = Convert.ToDouble(txtActualCount.Text);
        cc.count_type = Convert.ToInt32(ddlCountType.SelectedItem.Value);
        cc.count_usage = ddlCountUsage.SelectedItem.Value;
        //cc.eff_from = Convert.ToDateTime(txt_efffrom.Text);
        cc._eff_from = txt_efffrom.Text;
        cc.eff_to = Convert.ToDateTime(txt_effto.Text);
        cc.status = "C";
        cc.userid = null;

        message = cc.ExecuteDelete();
        if (message.Trim() == "Sucess")
        {
            DataBind();
            FMsg1.Text = "Sucessfully Deleted";

        }
        else
        {
            FMsg1.Text = message;
        }

       
        btnAdd.Text = "ADD";
        ClearControls();
        DisableControls();

        return;

    }
}