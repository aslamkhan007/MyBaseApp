using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Courier_Service : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        sql = "Select empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and Active='Y'";
        string empname = sql;

        sql = "Insert into jct_Courier_Service_Master(UserCode,UserName,Courier_Service,DESCRIPTION,Remarks,STATUS,EntryDate,Contact_Person_Name,Local_Address,Address2,Address3,City,ZipCode,State,Country,PhoneNo,Email_Address,OfficeNumber,FaxNumber,WebSite,EffecFrom,EffecTo,Contact_person2,mobile2,Email2,STDCode ) values(@UserCode,@UserName,@Courier_Service,@Description,@Remarks,@Status,@EntryDate,@Contact_Person_Name,@Local_Address,@Address2,@Address3,@City,@ZipCode,@State,@Country,@PhoneNo,@Email_Address,@OfficeNumber,@FaxNumber,@WebSite,@EffecFrom,@EffecTo,@Contact_Person2,@mobile2,@Email2,@STDCode)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpName"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = empname;
        cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 100).Value = txtCourier.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = txtDescription.Text;
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = txtRemarks.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
        cmd.Parameters.Add("@Contact_Person_Name", SqlDbType.VarChar, 50).Value = txtName.Text;
        cmd.Parameters.Add("@Local_Address", SqlDbType.VarChar, 200).Value = txtLocalAddress.Text;
        cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 200).Value = txtAddress2.Text;
        cmd.Parameters.Add("@Address3", SqlDbType.VarChar, 200).Value = txtAddress3.Text;
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 100).Value = txtCity.Text;
        cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar, 12).Value = txtZipCode.Text;
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtState.Text;
        cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = txtCountry.Text;
        cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 12).Value = txtPhone.Text;
        cmd.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = txtEmail.Text;
        cmd.Parameters.Add("@OfficeNumber", SqlDbType.VarChar, 12).Value = txtOfficeNo.Text;
        cmd.Parameters.Add("@FaxNumber", SqlDbType.VarChar, 20).Value = txtFax.Text;
        cmd.Parameters.Add("@WebSite", SqlDbType.VarChar, 50).Value = txtWebSite.Text;
        cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.Parameters.Add("@Contact_Person2", SqlDbType.VarChar, 100).Value = txtName2.Text;
        cmd.Parameters.Add("@mobile2", SqlDbType.VarChar, 12).Value = txtPhone2.Text;
        cmd.Parameters.Add("@Email2", SqlDbType.VarChar, 100).Value = txtEmail2.Text;
        cmd.Parameters.Add("@STDCode", SqlDbType.VarChar, 6).Value = txtSTDCode.Text;
        cmd.ExecuteNonQuery();
        ShowAlertMsg("Record Inserted Successfuly.");
    }
    public void ShowAlertMsg(string error1)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            // error1 = error1.Replace("'", "'")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error1 + "');", true);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Update Record

        lnkEdit.Text = "Update";
        sql="Select Convert(varchar,EffecFrom,101) as [EffecFrom],Convert(varchar,EffecTo,101) as [EffecTo],* from jct_Courier_Service_Master where Sr_no ='" +GridView1.SelectedRow.Cells[1].Text.ToString() +"'" ;
        SqlDataReader dr = obj.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtCourier.Text = dr["Courier_Service"].ToString();
                txtDescription.Text = dr["Description"].ToString();
                txtRemarks.Text = dr["Remarks"].ToString();
                txtName.Text = dr["Contact_Person_Name"].ToString();
                txtLocalAddress.Text = dr["Local_Address"].ToString();
                txtPhone.Text = dr["PhoneNo"].ToString();
                txtEmail.Text = dr["Email_Address"].ToString();
                txtOfficeNo.Text = dr["OfficeNumber"].ToString();
                txtFax.Text = dr["FaxNumber"].ToString();
                txtWebSite.Text = dr["Website"].ToString();
                txtEffecFrom.Text = dr["EffecFrom"].ToString();
                txtEffecTo.Text = dr["EffecTo"].ToString();
                txtName2.Text = dr["Contact_Person2"].ToString();
                txtPhone2.Text = dr["Mobile2"].ToString();
                txtEmail2.Text = dr["Email2"].ToString();
                txtSTDCode.Text = dr["STDCode"].ToString();
                txtAddress2.Text = dr["Address2"].ToString();
                txtAddress3.Text = dr["Address3"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtZipCode.Text = dr["ZipCode"].ToString();
                txtState.Text = dr["State"].ToString();
                txtCountry.Text = dr["Country"].ToString();

            }
        
        }
        #endregion
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        if (lnkEdit.Text == "Update")
        {
            try
            {
                sql = "Update jct_Courier_Service_Master set Address2='"+ txtAddress2.Text +"',Address3='"+ txtAddress3.Text +"',City='"+ txtCity.Text +"',ZipCode='"+ txtZipCode.Text +"',State='"+ txtState.Text +"',Country='"+ txtCountry.Text +"', Contact_Person2='"+ txtName2.Text +"', mobile2='"+ txtPhone2.Text +"',Email2='"+ txtEmail2.Text +"',STDCode='"+ txtSTDCode.Text +"', Contact_Person_Name='" + txtName.Text + "',Local_Address='" + txtLocalAddress.Text + "',PhoneNo='" + txtPhone.Text + "',Email_Address='" + txtEmail.Text + "',OfficeNumber='" + txtOfficeNo.Text + "',FaxNumber='" + txtFax.Text + "',Website='" + txtWebSite.Text + "',EffecFrom=Convert(datetime,'" + txtEffecFrom.Text + "'),EffecTo=Convert(datetime,'" + txtEffecTo.Text + "') where Sr_No = '" + GridView1.SelectedRow.Cells[1].Text.ToString() + "'";
                if (obj1.UpdateRecord(sql))
                {
                    ShowAlertMsg("Record Updated Successfully");
                    lnkEdit.Text = "Edit";
                }
                else
                {
                    ShowAlertMsg("Some Error Occured. Please contact IT @4226");
                    lnkEdit.Text = "Edit";
                }
             
            }
            catch (Exception ex)
            {
                ShowAlertMsg("Some Error Occured while updating record."+ ex.ToString());
            }
            finally
            { 
            
            }
            }
           
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "Update jct_Courier_Service_Master set Status='D' where  Sr_no ='" + GridView1.SelectedRow.Cells[1].Text.ToString() + "'";
            obj1.UpdateRecord(sql);
            Response.Redirect("Courier_Service.aspx");
            ShowAlertMsg("Record Deleted Successfully.");
        }
        catch (Exception ex)
        {
            ShowAlertMsg("Error Occured while deleting record. " + ex.ToString());
        }
    }
}