using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.Mail;

public partial class Courier_Tracking_System_Generate_request10 : System.Web.UI.Page
{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql;
    SqlTransaction Tran;
    SendMail sm = new SendMail();
    public int num;
    public string dept;
    public string empname;
    public string year;
    public int flag = 0;
    TextBox Name = new TextBox();
    #region Coding Start here..
    protected string GenerateCode(string dept,SqlTransaction tran,SqlConnection con2)
    {
        #region Seial No. Code


            if (rblSelect.SelectedIndex != 6)
            {
                int num;
                string year;
                //sql = "Select StartYear from jct_courier_Year_Master where status='A' and  Sr_No = (Select max(sr_no) from jct_courier_Year_Master where status='A') ";
                //year = obj1.FetchValue(sql).ToString();
                year = DateTime.Now.Year.ToString();
                hd1.Value = year;
                sql = "Select Isnull(MidNumber ,'100001') from jct_courier_serial_master where PostFix='" + hd1.Value + "' and Sr_No =(Select max(Sr_no) from jct_courier_serial_master)";
                if (obj1.CheckRecordExistInTransaction(sql,tran,con2))
                {
                    string c = obj1.FetchValue(sql,con2,tran).ToString();
                    num = Convert.ToInt32(c) + 1;
                    hd2.Value = Convert.ToString(num);
                }
                else
                {
                    num = 1000001;
                    hd2.Value = num.ToString();
                }
                hd3.Value = hdDept.Value + "/" + Convert.ToString(num) + "/" + year;


            }
            if (rblSelect.SelectedIndex == 6)
            {
                int num;
                string year;
                //sql = "Select StartYear from jct_courier_Year_Master where status='A' and Sr_No = (Select max(sr_no) from jct_courier_Year_Master where status='A') ";
                //year = obj1.FetchValue(sql).ToString();
                year = DateTime.Now.Year.ToString();
                hd1.Value = year;
                sql = "Select Isnull(MidNumber,'100001') from jct_courier_serial_master where PostFix='" + hd1.Value + "' and Sr_No =(Select max(Sr_no) from jct_courier_serial_master )";
                if (obj1.CheckRecordExistInTransaction(sql,tran,con2))
                {
                    string c = obj1.FetchValue(sql,con2,tran).ToString();
                    num = Convert.ToInt32(c) + 1;
                    hd2.Value = Convert.ToString(num);
                }
                else
                {
                    num = 1000001;
                    hd2.Value = num.ToString();
                }
                hd3.Value = "PER" + "/" + Convert.ToString(num) + "/" + year;
            }

            return hd3.Value.ToString();

    

        #endregion

    }

    protected void EmptyForm()
    {
        #region Empty textbox value
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtAdd3.Text = "";
        txtPartyName.Text = "";
        txtSupplierName.Text = "";
        txtCity1.Text = "";
        txtState1.Text = "";
        txtZipCode.Text = "";
        txtCountry1.Text = "";
        txt.Text = "";
        txtOtherParty.Text = "";
        txtPhoneNo.Text = "";
        txtDestination.Text = "";
        #endregion

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["EmpCode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (rblSelect.SelectedIndex == 0)
        {
            txtSupplierName.Visible = false;
            txtPartyName.Visible = true;
            txtOtherParty.Visible = false;

        }
        else if (rblSelect.SelectedIndex == 1)
        {
            txtSupplierName.Visible = true;
            txtPartyName.Visible = false;
            txtOtherParty.Visible = false;

        }
        else if (rblSelect.SelectedIndex == 2 || rblSelect.SelectedIndex == 3 || rblSelect.SelectedIndex == 4 || rblSelect.SelectedIndex == 5)
        {
            txtSupplierName.Visible = false;
            txtOtherParty.Visible = true;
            txtPartyName.Visible = false;
        }

        ViewState["RowCommand"] = false;
        #region IF Page is Not Postback
        if (!IsPostBack)
        {

            Panel1.Visible = false;
            hd2.Value = "";
            // txt.Attributes.Add("onkeypress", "return clickButton(event,'" + Button3.ClientID + "')");
            sql = "Select a.deptcode from deptmast a inner join jct_empmast_base b on a.deptcode=b.deptcode where b.empcode='" + Session["EmpCode"] + "' ";
            string dept = obj1.FetchValue(sql).ToString();
            sql = "Select 'Any','Any' union Select Courier_Service,Courier_Service from jct_Courier_Service_Master where status ='A'";
            obj1.FillList(ddlCourierService, sql);
            sql = "SELECT CourierType,CourierType FROM jct_courier_Type_Master WHERE status='A' and mapped_Department='" + dept + "' ";
            obj1.FillList(ddlCourierType, sql);
            sql = "Select 'Any','Any' union Select DeliveryType ,DeliveryType from jct_courier_Delivery_Type where status='A'";
            obj1.FillList(ddlDelivery, sql);
            sql = "Select deptcode,empname from jct_empmast_base where empcode='" + Session["EmpCode"] + "' and Active ='Y'  ";
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept = dr[0].ToString();
                    // hd1.Value = dept;
                    hdDept.Value = dept;
                    empname = dr[1].ToString();
                    hd6.Value = empname;
                }
            }
            dr.Close();
        #endregion
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void SubmitRecord()
    {
          SqlTransaction Tran;
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = obj.Connection().ConnectionString.ToString();
        con2.Open();
        Tran = con2.BeginTransaction();

        string RecordGen="";
        try
        {

            #region SaveData
            //obj.ConOpen();
            GenerateCode(hd1.Value.ToString(),Tran,con2);
            
            if (txtPartyName.Visible == true)
            {

                Name.Text = txtPartyName.Text;
            }
            else if (rblSelect.SelectedIndex == 1)
            {

                Name.Text = txtSupplierName.Text;
            }
            else
            {
                Name.Text = txtOtherParty.Text;
            }

                sql = "EXEC JCT_COURIER_CHECK_COSTCENTER '"+ txtCostCenter.Text +"' ";

            if (obj1.CheckRecordExistInTransaction(sql,Tran,con2))
            {


            sql = "Insert into jct_courier_Request(Serial_No,Courier_Type,Courier_Service,Delivery_Type,SUBJECT,Party_Name,Address1,Address2,Address3,City,ZipCode,State,Country,STATUS,Request_By,Request_Date,Dept_Code,Attached_File,Remarks,SendType,PartyCode,CostCenter,AccountNo,BookingNo,Destination,EmpCode,MailTo,MailCC ) values(@Serial_No,@Courier_Type,@Courier_Service,@Delivery_Type,@SUBJECT,@Party_Name,@Address1,@Address2,@Address3,@City,@ZipCode,@State,@Country,@Status,@Request_By,@Request_Date,@Dept_Code,@Attached_File,@Remarks,@SendType,@PartyCode,@COSTCENTER,@AccountNo,@BookingNo,@Destination,@EmpCode,@MailTo,@MailCC)";
            SqlCommand cmd = new SqlCommand(sql, con2, Tran);
            cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 20).Value = hd3.Value;
            cmd.Parameters.Add("@Courier_Type", SqlDbType.VarChar, 100).Value = ddlCourierType.SelectedItem.Text;
            cmd.Parameters.Add("@Courier_Service", SqlDbType.VarChar, 50).Value = ddlCourierService.SelectedItem.Text;
            cmd.Parameters.Add("@Delivery_Type", SqlDbType.VarChar, 100).Value = ddlDelivery.SelectedItem.Text;
            cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 100).Value = txtSubject.Text;
            cmd.Parameters.Add("@Party_Name", SqlDbType.VarChar, 100).Value = Name.Text;
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 100).Value = txtAdd1.Text;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 100).Value = txtAdd2.Text;
            cmd.Parameters.Add("@Address3", SqlDbType.VarChar, 100).Value = txtAdd3.Text;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = txtCity.Text;
            cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar, 10).Value = txtZipCode.Text;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 30).Value = txtState1.Text;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = txtCountry1.Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'P';
            cmd.Parameters.Add("@Request_By", SqlDbType.VarChar, 50).Value = hd6.Value;
            cmd.Parameters.Add("@Request_Date", SqlDbType.DateTime).Value = DateTime.Today;
            cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar, 100).Value = hdDept.Value;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 8000).Value = txtOtherRequest.Text;
            cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 30).Value = rblSelect.SelectedItem.Text;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Char, 8).Value = txt.Text;
            if (txtCostCenter.Text == "")
            {
                cmd.Parameters.Add("@COSTCENTER", SqlDbType.VarChar, 30).Value = hdDept.Value;
            }
            else
            {
                cmd.Parameters.Add("@COSTCENTER", SqlDbType.VarChar, 30).Value = txtCostCenter.Text;
            }
            cmd.Parameters.Add("@AccountNo", SqlDbType.VarChar, 30).Value = txtAccountNo.Text;
            cmd.Parameters.Add("@BookingNo", SqlDbType.VarChar, 30).Value = txtBookingNo.Text;
            cmd.Parameters.Add("@Destination", SqlDbType.VarChar, 50).Value = txtDestination.Text;
            if (Request.Files.Count > 0)
            {
                List<String> Files = new List<String>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile PostedFile = Request.Files[i];
                    if (PostedFile.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        PostedFile.SaveAs(Server.MapPath("Attached_Files\\") + FileName);
                        Files.Add(FileName);
                    }

                }
                cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());
            }
            else
            {
                cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = "No File Attached";
            }

            //if (chkAttachedFiles.Items.Count > 0)
            //{
            //    List<String> Files = new List<String>();
            //    for (int i = 0; i <= chkAttachedFiles.Items.Count - 1; i++)
            //    {
            //        if (chkAttachedFiles.Items[i].Selected == true)
            //        {
            //            UploadFile.PostedFile.SaveAs(Server.MapPath("Attached_Files/" + chkAttachedFiles.Items[i].Text));
            //            Files.Add(chkAttachedFiles.Items[i].Text);
            //        }
            //    }

            //    cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());
            //}
            //else
            //{
            //    if (UploadFile.PostedFile != null)
            //    {
            //        string filename = System.IO.Path.GetFileName(UploadFile.FileName);
            //        hd4.Value = filename;
            //        if (hd4.Value != "")
            //        {
            //            UploadFile.PostedFile.SaveAs(Server.MapPath("Attached_Files/" + filename));
            //        }

            //    }
            //    if (hd4.Value == "")
            //    {
            //        cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = "No File Attached";
            //    }
            //    else
            //    {
            //        cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = hd4.Value;
            //    }
            //}


            //cmd.Prepare();
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            //cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = txtTo.Text;

            //if (chkEmailIDTo.Items.Count > 0)
            //{
            //    List<String> Files = new List<String>();
            //    for (int i = 0; i <= chkEmailIDTo.Items.Count - 1; i++)
            //    {

            //        if (chkEmailIDTo.Items[i].Selected == true)
            //        {
            //            Files.Add(chkEmailIDTo.Items[i].Text);
            //        }
            //    }
            //    cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());

            //}
            //else
            //{
            //    cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = "";
            //}


            //if (chkEmailID.Items.Count > 0)
            //{
            //    List<String> Files1 = new List<String>();
            //    for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
            //    {

            //        if (chkEmailID.Items[i].Selected == true)
            //        {
            //            Files1.Add(chkEmailID.Items[i].Text);
            //        }
            //    }
            //    cmd.Parameters.Add("@MailCC", SqlDbType.VarChar, 500).Value = String.Join(",", Files1.Select(x => x.ToString()).ToArray());

            //}
            //else
            //{
            //    cmd.Parameters.Add("@MailCC", SqlDbType.VarChar, 500).Value = "";
            //}


            if (string.IsNullOrEmpty(txtTo.Text))
            {
                if (chkEmailIDTo.Items.Count > 0)
                {
                    List<String> Files = new List<String>();
                    for (int i = 0; i <= chkEmailIDTo.Items.Count - 1; i++)
                    {

                        if (chkEmailIDTo.Items[i].Selected == true)
                        {
                            Files.Add(chkEmailIDTo.Items[i].Text);
                        }
                    }
                    cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());

                }
                else
                {
                    cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = "";
                }
            }
            else
            {
                List<String> Files = new List<String>();
                if (chkEmailIDTo.Items.Count > 0)
                {

                    for (int i = 0; i <= chkEmailIDTo.Items.Count - 1; i++)
                    {

                        if (chkEmailIDTo.Items[i].Selected == true)
                        {
                            Files.Add(chkEmailIDTo.Items[i].Text);
                        }
                    }


                }
                Files.Add(txtTo.Text);
                cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 500).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());
            }

            if (string.IsNullOrEmpty(txtTo.Text))
            {

                if (chkEmailID.Items.Count > 0)
                {
                    List<String> Files1 = new List<String>();
                    for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
                    {

                        if (chkEmailID.Items[i].Selected == true)
                        {
                            Files1.Add(chkEmailID.Items[i].Text);
                        }
                    }
                    cmd.Parameters.Add("@MailCC", SqlDbType.VarChar, 500).Value = String.Join(",", Files1.Select(x => x.ToString()).ToArray());

                }
                else
                {
                    cmd.Parameters.Add("@MailCC", SqlDbType.VarChar, 500).Value = "";
                }
            }
            else
            {
                List<String> Files = new List<String>();
                if (chkEmailID.Items.Count > 0)
                {

                    for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
                    {

                        if (chkEmailID.Items[i].Selected == true)
                        {
                            Files.Add(chkEmailID.Items[i].Text);
                        }
                    }


                }
                Files.Add(txtCC.Text);
                cmd.Parameters.Add("@MailCC", SqlDbType.VarChar, 500).Value = String.Join(",", Files.Select(x => x.ToString()).ToArray());
            }
           

            cmd.ExecuteNonQuery();

            sql = "INSERT INTO dbo.jct_courier_serial_master( UserCode ,UserName ,Prefix ,PostFix ,MidNumber ,SerialNumber ,STATUS ,EntryDate ) VALUES  ( '" + Session["EmpCode"] + "' ,'" + hd6.Value + "'  ,'" + hdDept.Value + "', '" + hd1.Value + "',Convert(Int,'" + hd2.Value + "') , '" + hd3.Value + "' , 'A',getdate() )";
            cmd = new SqlCommand(sql, con2, Tran);
            cmd.ExecuteNonQuery();

            ShowAlertMsg("Request generated Successfully.Your Request number is : " + hd3.Value + "");
            Tran.Commit();
            RecordGen = "Y";
            hd2.Value = "";
            
            //BindGrid();
            #endregion
            }
            else
            {
                ShowAlertMsg("The CostCenter you mentioned does not exit.Please enter correct CostCenter..!!");
            }

        }
        catch (Exception ex)
        {
            Tran.Rollback();
            ex.ToString();
            ShowAlertMsg("Some Error Occured." + ex.Message.ToString());
        }

        finally
        {
            con2.Close();


        }
        if (RecordGen == "Y")
        {
            SendMailCourier();
            //Response.Redirect("Generate_Request10.aspx");
            lnkSubmit.Enabled = false;
        }
 

    }


    protected void lnkSubmit_Click(object sender, EventArgs e)
    {

        #region SubmitCode
        if (rblSelect.SelectedItem.Text == "Customer")
        {
            #region Submit&UpdateRecordOfCustomer

            if (lnkSubmit.Text == "Submit")
            {
                SubmitRecord();
            }
            else
            {
                UpdateRecord();
            }

            #endregion
        }
        if (rblSelect.SelectedItem.Text == "Supplier")
        {
            if (lnkSubmit.Text == "Submit")
            {
                SubmitRecord();
            }
            else
            {
                UpdateRecord();
            }
        }
        if (rblSelect.SelectedItem.Text == "Other")
        {
            if (lnkSubmit.Text == "Submit")
            {
                for (int i = 0; i <= rblSaleOffices.Items.Count - 1; i++)
                {
                    if (rblSaleOffices.Items[i].Selected == true)
                    {
                        sql = "Insert into jct_courier_other_address (PartyName,address1,address2,address3,city,state,zipcode,country,status,Description,ContactNo,Destination)values('" + txtOtherParty.Text + "','" + txtAdd1.Text + "','" + txtAdd2.Text + "','" + txtAdd3.Text + "','" + txtCity1.Text + "','" + txtState1.Text + "','" + txtZipCode.Text + "','" + txtCountry1.Text + "','A','" + rblSaleOffices.Items[i].Text + "','" + txtPhoneNo.Text + "','" + txtDestination.Text + "') ";
                        flag = 1;
                    }
                    if (flag != 1)
                    {
                        sql = "Insert into jct_courier_other_address (PartyName,address1,address2,address3,city,state,zipcode,country,status,Description,ContactNo,Destination)values('" + txtOtherParty.Text + "','" + txtAdd1.Text + "','" + txtAdd2.Text + "','" + txtAdd3.Text + "','" + txtCity1.Text + "','" + txtState1.Text + "','" + txtZipCode.Text + "','" + txtCountry1.Text + "','A','" + rblSelect.SelectedItem.Text + "','" + txtPhoneNo.Text + "','" + txtDestination.Text + "') ";
                        flag = 0;
                    }
                }

                obj1.InsertRecord(sql);
                SubmitRecord();
            }
        }
        if (rblSelect.SelectedItem.Text == "HO" || rblSelect.SelectedItem.Text == "Sales Office" || rblSelect.SelectedItem.Text == "Hoshiarpur JCT")
        {

            if (lnkSubmit.Text == "Submit")
            {
                SubmitRecord();
            }
            else
            {
                UpdateRecord();
            }
        }
        if (rblSelect.SelectedItem.Text == "Personal")
        {
            if (lnkSubmit.Text == "Submit")
            {
                SubmitRecord();
            }
            else
            {
                UpdateRecord();
            }
        }
        #endregion


    }
    protected void UpdateRecord()
    {
        try
        {
            obj.ConOpen();

            sql = "Select * from jct_courier_Request where status='P' and  Serial_No='" + hd5.Value + "'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                if (Request.Files.Count > 0)
                {
                    List<String> Files = new List<String>();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i];
                        if (PostedFile.ContentLength > 0)
                        {
                            string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            PostedFile.SaveAs(Server.MapPath("Attached_Files\\") + FileName);
                            Files.Add(FileName);
                        }

                    }

                    sql = "UPDATE dbo.jct_courier_Request SET Attached_File='" + String.Join(",", Files.Select(x => x.ToString()).ToArray()) + "' , Sendtype='" + rblSelect.SelectedItem.Text + "', Courier_Type='" + ddlCourierType.SelectedItem.Text + "',Courier_Service='" + ddlCourierService.SelectedItem.Text + "',Delivery_Type='" + ddlDelivery.SelectedItem.Text + "',SUBJECT='" + txtSubject.Text + "',Party_Name='" + txtPartyName.Text + "',Address1='" + txtAdd1.Text + "',Address2='" + txtAdd2.Text + "',Address3='" + txtAdd3.Text + "',City='" + txtCity1.Text + "',ZipCode='" + txtZipCode.Text + "',State='" + txtState1.Text + "',Country='" + txtCountry1.Text + "',PartyCode='" + txt.Text + "',Remarks='" + txtOtherRequest.Text + "'  WHERE Status ='P' AND Serial_No='" + hd5.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.ExecuteNonQuery();

                }
                else
                {
                    sql = "UPDATE dbo.jct_courier_Request SET Sendtype='" + rblSelect.SelectedItem.Text + "', Courier_Type='" + ddlCourierType.SelectedItem.Text + "',Courier_Service='" + ddlCourierService.SelectedItem.Text + "',Delivery_Type='" + ddlDelivery.SelectedItem.Text + "',SUBJECT='" + txtSubject.Text + "',Party_Name='" + txtPartyName.Text + "',Address1='" + txtAdd1.Text + "',Address2='" + txtAdd2.Text + "',Address3='" + txtAdd3.Text + "',City='" + txtCity1.Text + "',ZipCode='" + txtZipCode.Text + "',State='" + txtState1.Text + "',Country='" + txtCountry1.Text + "',PartyCode='" + txt.Text + "',Remarks='" + txtOtherRequest.Text + "'  WHERE Status ='P' AND Serial_No='" + hd5.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                    cmd1.ExecuteNonQuery();
                }
                
                lnkSubmit.Text = "Submit";
                ShowAlertMsg("Record Updated Successfully.");
            }
            else
            {
                ShowAlertMsg("Authorized Courier Cannot be changed.Please Contact It-helpDesk @ 4212");
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Error Occured..!!";
            FMsg.Display();
        }
        finally
        {
            obj.ConClose();
        }

    }
    protected void lnkAttach_Click(object sender, EventArgs e)
    {
        #region uploadFiles
        if (UploadFile.HasFile)
        {
            ListItem filename = new ListItem();
            filename.Text = Path.GetFileName(UploadFile.FileName);

            hd4.Value = hd4.Value + filename.Text + ",";

            //   filename.Text = UploadFile.PostedFile.FileName;
            filename.Value = UploadFile.PostedFile.FileName;
            chkAttachedFiles.Items.Add(filename);


            for (int i = 0; i <= chkAttachedFiles.Items.Count - 1; i++)
            {
                chkAttachedFiles.Items[i].Selected = true;
            }

        }
        else
        {
            hd4.Value = "";
        }
        #endregion
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
    protected void chkAttachedFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region RemoveSelectedFiles.

        hd4.Value = "";
        for (int i = 0; i <= chkAttachedFiles.Items.Count - 1; i++)
        {
            if (chkAttachedFiles.Items[i].Selected == false)
            {
                chkAttachedFiles.Items.RemoveAt(i);

            }
            else
            {
                hd4.Value = hd4.Value + chkAttachedFiles.Items[i].Text + ", ";
            }
        }
        #endregion
    }
    protected void lnkSubmit0_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generate_Request10.aspx");
    }

    protected void SendMailCourier()
    {
        #region SendMail

        string sender_email;
        // sm.SendMail("jctadmin@jctltd.com", "", "Courier Request- " + txtRefNo.Text + " ", "Courier Request has been generated with reference ID - '"+ txtRefNo.Text +"' on "+System.DateTime.Today+". It will be visible in the Pending List of Couriers in the Courier tracking system.");

        string empcode = Session["EmpCode"].ToString();
        string subject = txtSubject.Text;
        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sender_email = dr[0].ToString();
               // String msg = "<html><body><Table><tr><td>Hello " + hd6.Value + ",</td></tr><tr><td>We Received a courier request from you.</td></tr><tr><td>Details of the your courier are :</td></tr><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><tr><td>Party Name : "+ Name.Text +"</tr></td><tr><td></td></tr><tr><td>Your courier is pending, as soon as it approves, you will receive a confirmation email with Tracking ID.</td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
               // String msg = "<html><body><Table><tr><td>Hello " + hd6.Value + ",</td></tr><tr><td>We Received a courier request from you.</td></tr><tr><td>Details of the your courier are :</td></tr><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><tr><td>Party Name : " + Name.Text + "</tr></td><tr><td>Address : " + txtAdd1.Text + " , " + txtAdd2.Text + "," + txtAdd3.Text + " ," + txtCity1.Text + " - "+ txtZipCode.Text +" ," + txtState1.Text + " ," + txtCountry1.Text + " </tr></td><tr><td>Request Date : " + DateTime.Now + "</tr></td><tr><td></td></tr><tr><td>Your courier is pending, as soon as it approves, you will receive a confirmation email with Tracking ID.</td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";

                //String msg = "<html><body><Table><tr><td>Hello " + hd6.Value + ",</td></tr><BR /><tr><td>We Received a courier request from you.</td></tr><BR /><tr><td>Subject : " + txtSubject.Text + "</td></tr><BR /><tr><td>Details of the your courier are :</td></tr><BR /><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><BR /><tr><td>Party Name : " + Name.Text + "</td></tr><BR /><tr><td>Address : " + txtAdd1.Text + " , " + txtAdd2.Text + "," + txtAdd3.Text + " ," + txtCity1.Text + " - " + txtZipCode.Text + " ," + txtState1.Text + " ," + txtCountry1.Text + " </td></tr><BR /><tr><td>Request Date : " + DateTime.Now + "</td></tr><BR /><tr><td> Material To be Sent : " + ddlCourierType.SelectedItem.Text + " </td></te><BR /><tr><td> Courier Service : " + ddlCourierService.SelectedItem.Text + " </tr></td><BR /><tr><td>Delivery Type : " + ddlDelivery.SelectedItem.Text + " </tr></td><BR /><tr><td>Remarks : " + txtRemarks.Text + "</td></tr><BR /><tr><td>Your courier is pending, as soon as it approves, you will receive a confirmation email with Tracking ID.</td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";

                //String msg = "<html><body><Table><tr><td>Hello " + hd6.Value + ",</td></tr><BR /><tr><td>We Received a courier request from you.</td></tr><BR /><tr><td>Subject : " + txtSubject.Text + "</td></tr><BR /><tr><td>Details of the your courier are :</td></tr><BR /><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><BR /><tr><td><Table><tr><td>" + Name.Text + "</td><BR /></tr><tr><td>" + txtAdd1.Text + " , " + txtAdd2.Text + "</td></tr><tr><td>" + txtAdd3.Text + " ," + txtCity1.Text + " - " + txtZipCode.Text + "</td></tr><tr><td> " + txtState1.Text + " ," + txtCountry1.Text + " </td></tr></Table><BR /> </td></tr><BR /><tr><td>Request Date : " + DateTime.Now + "</td></tr><BR /><tr><td> Material To be Sent : " + ddlCourierType.SelectedItem.Text + " </td></te><BR /><tr><td> Courier Service : " + ddlCourierService.SelectedItem.Text + " </tr></td><BR /><tr><td>Delivery Type : " + ddlDelivery.SelectedItem.Text + " </tr></td><BR /><tr><td>Remarks : " + txtRemarks.Text + "</td></tr><BR /><tr><td>Your courier is pending, as soon as it approves, you will receive a confirmation email with Tracking ID.</td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";

                String msg = "<html><body><Table><tr><td>Hello " + hd6.Value + ",</td></tr><BR /><tr><td>We Received a courier request from you.</td></tr><BR /><tr><td>Subject : " + txtSubject.Text + "</td></tr><BR /><tr><td>Details of the your courier are :</td></tr><BR /><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><BR /><tr><td><Table><tr><td>" + Name.Text + "</td><BR /></tr><tr><td>" + txtAdd1.Text + " , " + txtAdd2.Text + "</td></tr><tr><td>" + txtAdd3.Text + " ," + txtCity1.Text + " - " + txtZipCode.Text + "</td></tr><tr><td> " + txtState1.Text + ", " + txtDestination.Text + " ," + txtCountry1.Text + " </td></tr><tr><td>Phone No: " + txtPhoneNo.Text + " </td></tr></Table><BR /> </td></tr><BR /><tr><td>Request Date : " + DateTime.Now + "</td></tr><BR /><tr><td> Material To be Sent : " + ddlCourierType.SelectedItem.Text + " </td></te><BR /><tr><td> Courier Service : " + ddlCourierService.SelectedItem.Text + " </tr></td><BR /><tr><td>Delivery Type : " + ddlDelivery.SelectedItem.Text + " </tr></td><BR /><tr><td>Remarks : " + txtRemarks.Text + "</td></tr><BR /><tr><td>Your courier is pending, as soon as it approves, you will receive a confirmation email with Tracking ID.</td></tr> <tr><td>Thanks..!!</td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
                sm.SendMail(sender_email, "noreply@jctltd.com", " " + subject + " ( ID - " + hd2.Value + ")  ", msg);
                //sm.SendMail("jatindutta@jctltd.com", "noreply@jctltd.com", " " + subject + " ( ID - " + hd2.Value + ")  ", msg);

                // For HOD msg when Cost center is entered.

                if (txtCostCenter.Text != "")
                {
                     sql = "Select CostCenter from jct_empmast_base where empcode ='"+ Session["EmpCode"] +"' and active='Y' and Company_Code='JCT00LTD' and CostCenter is not null  ";
                     if (obj1.FetchValue(sql) != txtCostCenter.Text)
                     {
                         sql = "Exec jct_courier_CostCenter_HOD_Email '" + txtCostCenter.Text + "'";

                         if (rblSelect.SelectedIndex == 0)
                         {
                             String HodMsg = "<html><body><table><tr><td> Hello " + obj1.FetchValue("Select name from mistel where e_mailid='" + obj1.FetchValue(sql).ToString() + "' ") + ",</td><tr><td> We Received a courier request from " + hd6.Value + " and your cost center has been selected in this request.</td></tr><tr><td>Courier ID  : " + hd3.Value + "</td></tr><tr><td> Send to : " + txtPartyName.Text + "  </br></td></tr><tr><td> This mail is just to inform you about the courier to be sent. This is a system generated mail, please donot reply.</td></tr></br> <tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table> </body></html>  ";
                             if (obj1.FetchValue(sql).ToString() != "uppal@jctltd.com") // removed uppal to get mail as per conversation on feb 17,2014
                             {
                                 sm.SendMail(obj1.FetchValue(sql).ToString(), "noreply@jctltd.com", " " + subject + " ( ID - " + hd2.Value + ")  ", HodMsg);
                             }
                         }
                         else if (rblSelect.SelectedIndex == 1)
                         {
                             String HodMsg = "<html><body><table><tr><td> Hello " + obj1.FetchValue("Select name from mistel where e_mailid='" + obj1.FetchValue(sql).ToString() + "' ") + ",</td><tr><td> We Received a courier request from " + hd6.Value + " and your cost center has been selected in this request.</td></tr><tr><td>Courier ID  : " + hd3.Value + "</td></tr><tr><td> Send to : " + txtSupplierName.Text + " </br></td></tr><tr><td> This mail is just to inform you about the courier to be sent. This is a system generated mail, please donot reply.</td></tr></br>  <tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>  ";
                             if (obj1.FetchValue(sql).ToString() != "uppal@jctltd.com")
                             {
                                 sm.SendMail(obj1.FetchValue(sql).ToString(), "noreply@jctltd.com", " " + subject + " ( ID - " + hd2.Value + ")  ", HodMsg);
                             }
                         }
                         else
                         {
                             String HodMsg = "<html><body><table><tr><td> Hello " + obj1.FetchValue("Select name from mistel where e_mailid='" + obj1.FetchValue(sql).ToString() + "' ") + ",</td><tr><td> We Received a courier request from " + hd6.Value + " and your cost center has been selected in this request.</td></tr><tr><td>Courier ID  : " + hd3.Value + "</td></tr><tr><td> Send to : " + txtOtherParty.Text + "  </br></td></tr><tr><td> This mail is just to inform you about the courier to be sent. This is a system generated mail, please donot reply.</td></tr></br>  <tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>  ";
                             if (obj1.FetchValue(sql).ToString() != "uppal@jctltd.com")
                             {
                                 sm.SendMail(obj1.FetchValue(sql).ToString(), "noreply@jctltd.com", " " + subject + " ( ID - " + hd2.Value + ")  ", HodMsg);
                             }
                         }
                     }
                }

                // End of HOD MSg
            }

        }
        else
        { }
        if (txtTo.Text != "" || txtCC.Text != "")
        {
            String msg = "<html><body><Table><tr><td>Hello ,</td></tr><tr><td>Courier has been sent and there is a need to send you the copy of that courier.</td></tr><tr><td>Details of the your courier are :</td></tr><tr><td><b> Courier ID : " + hd3.Value + " </b></td></tr><tr><td>Party Name : "+ Name.Text +"</td></tr><tr><td>Remarks : " + txtRemarks.Text + "</tr></td><tr><td></td></tr><tr><td>Here with mail please find the attachments that have been forwarded to you.</td></tr> <tr><td>Thanks..!!<br/><br/></td></tr><tr><td>NOTE: This is an automated mail. Please, do not reply.</td></tr><tr><td> </td></tr><tr><td>Regards,</td></tr><tr><td>JCT Phagwara</td></tr><tr><td></td></tr></table></body></html>";
            SendMailWithAttachments(msg);
        }


        dr.Close();
        #endregion
    }

    //protected void lnkGetAddress_Click(object sender, EventArgs e)
    //{
    //    sql = "Select address_1 , address_2  , address_3 , city ,'' as ZipCode , State ,  country from m_customer_address where cust_name ='" + txtPartyName.Text + "' ";
    //    txtPartyName.Text = (string)obj1.FetchValue(sql);
    //}

 

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        #region Search Party Record

        sql = "Select cust_no,cust_name,address_1 ,address_2 ,address_3 ,city,'' as [ZipCode] , state ,country   from m_customer_address1 where cust_name    = '" + txtPartNameSearch.Text + "' ";
        obj1.FillGrid(sql, ref GridView2);
        pnlSearch.Visible = true;

        #endregion

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Fetch Party Detail while in Search Mode

        txt.Text = GridView2.SelectedRow.Cells[1].Text.ToString();
        //txtPartyAddress.Text = GridView2.SelectedRow.Cells[3].Text.ToString();
        txtAdd1.Text = GridView2.SelectedRow.Cells[3].Text.ToString();
        txtAdd2.Text = GridView2.SelectedRow.Cells[4].Text.ToString();
        txtAdd3.Text = GridView2.SelectedRow.Cells[5].Text.ToString();
        txtCity1.Text = GridView2.SelectedRow.Cells[6].Text.ToString();
        txtZipCode.Text = GridView2.SelectedRow.Cells[7].Text.ToString();
        txtState1.Text = GridView2.SelectedRow.Cells[8].Text.ToString();
        txtCountry1.Text = GridView2.SelectedRow.Cells[9].Text.ToString();
        txtPartyName.Text = GridView2.SelectedRow.Cells[2].Text.ToString();
        Panel1.Visible = false;
        lnkSearchParty_ModalPopupExtender.Hide();

        #endregion



    }

    //protected void lnkCancel_Click(object sender, EventArgs e)
    //{
    //    Button1_PopupControlExtender1.Enabled = false;
    //    Panel1.Visible = false;
    //}

    // protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    // {
    //     #region Deleted Record
    //if (e.CommandName == "Delete")
    //     {
    //         sql = "Update jct_courier_Request set status='D' , Deleted_date=getdate(),Deleted_UserCode='"+ Session["EmpCode"] +"' where Sr_no = ";

    //     }
    //     #endregion

    // }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        lnkSearchParty_ModalPopupExtender.Hide();
    }

    protected void txt_TextChanged(object sender, EventArgs e)
    {

        #region Fill Party Detail On the Basis of PartyCode
        try
        {
            if (rblSelect.SelectedItem.Text == "Customer")
            {
                // sql = "Select cust_name , address_1 , address_2  , address_3 , city  , State ,  country,isnull(zip_no,'') as ZipCode,isnull(Phone_no,'') as [Phone]  from m_customer_address1 where cust_no ='" + txt.Text + "' ";
                sql = " SELECT b.cust_name , a.address_1 , a.address_2  , a.address_3 , a.city  , a.State ,  a.country,isnull(a.zip_no,'') as ZipCode,isnull(a.Phone_no,'') as [Phone]  FROM miserp.som.dbo.m_cust_address a JOIN miserp.som.dbo.m_customer b ON a.cust_no=b.cust_no where a.cust_no ='" + txt.Text + "' ";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtPartyName.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtState1.Text = dr[5].ToString();
                            txtCountry1.Text = dr[6].ToString();
                            txtZipCode.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
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
                sql = "Select vendor_name , ISnull(addr1,'') as addr1 , Isnull(addr2,'') as addr2  , Isnull(addr3,'') as addr3 , Isnull(city,'') as city  , State ,  country,ISnull( zipcode,'') as ZipCode,isnull(phone_no,'') as [Phone_No]  from miserp.apdb.dbo.ap_vendor_master where vendor_code ='" + txt.Text + "' ";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtSupplierName.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtState1.Text = dr[5].ToString();
                            txtCountry1.Text = dr[6].ToString();
                            txtZipCode.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
                        }

                    }
                    else
                    {
                        ShowAlertMsg("No Party Found..!! ");
                    }
                }
            }
        }
        catch (Exception ex)
        { 
        
        }
      
        #endregion

    }
    protected void lnkAddCourierType_Click(object sender, EventArgs e)
    {
        #region AddCourierType
        sql = "Insert into jct_courier_Type_Master(UserCode,UserName,CourierType,DESCRIPTION,STATUS,EntryDate,EffecFrom,EffecTo,Mapped_Department,Dept_EffecFrom,Dept_EffecTo ) values(@UserCode,@UserName,@CourierType,@Description,@Status,@EntryDate,@EffecFrom,@EffecTo,@Mapped,@Dept_EffecFrom,@Dept_EffecTo)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = Session["EmpName"];
        cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 500).Value = txtCourierType.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 5000).Value = txtTypeDescription.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.Today;
        cmd.Parameters.Add("@EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.Parameters.Add("@Mapped", SqlDbType.VarChar, 50).Value = hdDept.Value;
        cmd.Parameters.Add("@Dept_EffecFrom", SqlDbType.DateTime).Value = txtEffecFrom.Text;
        cmd.Parameters.Add("@Dept_EffecTo", SqlDbType.DateTime).Value = txtEffecTo.Text;
        cmd.ExecuteNonQuery();
        FMsg1.CssClass = "errormsg";
        FMsg1.Message = "Record Added Successfully..!!";
        FMsg1.Display();
        Response.Redirect("Generate_Request10.aspx");
        #endregion

    }
    protected void lnkAddParty_Click(object sender, EventArgs e)
    {
        #region AddParty
        sql = "Insert into jct_courier_Type_Master(UserCode,UserName,CourierType,DESCRIPTION,STATUS,EntryDate ) values(@UserCode,@UserName,@CourierType,@Description,@Status,@EntryDate)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = Session["EmpName"];
        cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 100).Value = txtCourierType.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = txtTypeDescription.Text;
        cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 'A';
        cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
        cmd.ExecuteNonQuery();
        FMsg1.CssClass = "errormsg";
        FMsg1.Message = "Record Added Successfully..!!";
        FMsg1.Display();
        Response.Redirect("Generate_Request.aspx");
        #endregion

    }
    protected void lnkAddNewParty_Click(object sender, EventArgs e)
    {

        #region AddNewParty
        sql = "Select left('" + txtPartyNameNew.Text + "',5)";
        string cust_no = obj1.FetchValue(sql).ToString();
        sql = "Insert into m_customer_address1(cust_no,cust_name,address_1,address_2,address_3,city,state,country ) values(@cust_no,@cust_name,@address1,@address2,@address3,@city,@state,@country)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@cust_no", SqlDbType.Char, 18).Value = cust_no;
        cmd.Parameters.Add("@cust_name", SqlDbType.VarChar, 40).Value = txtPartyNameNew.Text;
        cmd.Parameters.Add("@address1", SqlDbType.VarChar, 40).Value = txtAddress1.Text;
        cmd.Parameters.Add("@address2", SqlDbType.VarChar, 40).Value = txtAddress2.Text;
        cmd.Parameters.Add("@address3", SqlDbType.VarChar, 40).Value = txtAddress3.Text;
        cmd.Parameters.Add("@city", SqlDbType.VarChar, 30).Value = txtCity.Text;
        cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = txtState.Text;
        cmd.Parameters.Add("@country", SqlDbType.VarChar, 30).Value = txtCountry.Text;
        cmd.ExecuteNonQuery();
        FMsg1.CssClass = "errormsg";
        FMsg1.Message = "Record Added Successfully..!!";
        FMsg1.Display();
        Response.Redirect("Generate_Request.aspx");
        #endregion

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region FillRecordInFormAndEdit

        lnkSubmit.Text = "Update";
        TextBox t = new TextBox();
        Label lbl = new Label();
        lbl = (Label)GridView1.SelectedRow.Cells[1].FindControl("lblSerial");
        hd5.Value = lbl.Text;
        sql = "SELECT Courier_Type,Courier_Service,Delivery_Type,SUBJECT,isnull(PartyCode,''),Party_Name,isnull(Address1,''),isnull(Address2,''),isnull(Address3,''),isnull(City,''),isnull(zipcode,''),isnull(State,''),isnull(Country,''),Remarks,SendType FROM dbo.jct_courier_Request where Serial_No ='" + hd5.Value + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlCourierType.SelectedItem.Text = dr[0].ToString();
                ddlCourierService.SelectedItem.Text = dr[1].ToString();
                ddlDelivery.SelectedItem.Text = dr[2].ToString();
                txtSubject.Text = dr[3].ToString();
                txt.Text = dr[4].ToString();
                txtPartyName.Text = dr[5].ToString();
                txtAdd1.Text = dr[6].ToString();
                txtAdd2.Text = dr[7].ToString();
                txtAdd3.Text = dr[8].ToString();
                txtCity1.Text = dr[9].ToString();
                txtZipCode.Text = dr[10].ToString();
                txtState1.Text = dr[11].ToString();
                txtCountry1.Text = dr[12].ToString();
                txtOtherRequest.Text = dr[13].ToString();
                rblSelect.Items.FindByText(dr[14].ToString()).Selected = true;


            }

        }
        #endregion


    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {

        #region Delete
        try
        {
            obj.ConOpen();
            sql = "Select * from  jct_courier_Request where Serial_No='" + hd5.Value + "' and status='P'";
            if (obj1.CheckRecordExistInTransaction(sql))
            {
                sql = "UPDATE dbo.jct_courier_Request SET STATUS='D',Deleted_date=getdate(),Deleted_userCode='" + Session["EmpCode"] + "' WHERE Status ='P' AND Serial_No='" + hd5.Value + "'";
                SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                cmd1.ExecuteNonQuery();
                ShowAlertMsg("Record Deleted Succeesfully");

            }
            else
            {
                ShowAlertMsg("Cannot be Deleted as it is authorized. Please contact concerned person.");

            }

        }
        catch (Exception ex)
        {
            ex.ToString();
            FMsg.CssClass = "errormsg";
            FMsg.Message = "Error Occured..!!";
            FMsg.Display();
        }
        finally
        {
            obj.ConClose();
        }
        #endregion


    }
    protected void lnkShowAll_Click(object sender, EventArgs e)
    {
        #region ShowRecordInGrid
        if (lnkShowAll.Text == "Show All")
        {
            Panel1.Visible = true;
            lnkShowAll.Text = "Hide";
            BindGrid();

        }
        else
        {
            Panel1.Visible = false;
            lnkShowAll.Text = "Show All";
        }
        #endregion


    }
    protected void txtPartyName_TextChanged(object sender, EventArgs e)
    {
        #region FetchPartyDetail

        try
        {
            if (rblSelect.SelectedItem.Text == "Customer")
            {
                // sql = "Select cust_no , address_1 , address_2  , address_3 , city,isnull(zip_no,'') as ZipCode  , State ,  country,isnull(phone_no,'') as [Phone_No]  from m_customer_address1 where  cust_name ='" + txtPartyName.Text + "'";
                sql = "SELECT a.cust_no , a.address_1 , a.address_2  , a.address_3 , a.city ,isnull(a.zip_no,'') as ZipCode , a.State ,  a.country,isnull(a.Phone_no,'') as [Phone]  FROM miserp.som.dbo.m_cust_address a JOIN miserp.som.dbo.m_customer b ON a.cust_no=b.cust_no where b.cust_name ='" + txtPartyName.Text + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtZipCode.Text = dr[5].ToString();
                            txtState1.Text = dr[6].ToString();
                            txtCountry1.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
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
                AutoCompleteExtender1.TargetControlID = "txtPartyName";
                AutoCompleteExtender1.ServiceMethod = "SupplierAddress_CourierSystem";
                //   sql = "Select vendor_code , vendor_add1 , vendor_add2  , vendor_add3 , city,isnull( Zip_Code ,'') as ZipCode , State , country  from jct_courier_vendor_master where  vendor_name ='" + txtSupplierName.Text + "'";
                sql = "Select vendor_code , ISnull(addr1,'') as addr1 , Isnull(addr2,'') as addr2  , Isnull(addr3,'') as addr3 , Isnull(city,'') as city ,ISnull( zipcode,'') as ZipCode , State ,  country,isnull(phone_no,'') as [Phone_No]  from miserp.apdb.dbo.ap_vendor_master where vendor_name ='" + txtSupplierName.Text + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtZipCode.Text = dr[5].ToString();
                            txtState1.Text = dr[6].ToString();
                            txtCountry1.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
                        }

                    }
                    else
                    {
                        ShowAlertMsg("No Supplier Found..!! ");
                    }
                }
            }
            if (rblSelect.SelectedItem.Text == "Other")
            {
                AutoCompleteExtender1.TargetControlID = "txtPartyName";
                AutoCompleteExtender1.ServiceMethod = "OtherPartyAddress_CourierSystem";
                sql = "Select  ISNULL(PartyCode,''),ISNULL(address1,''),ISNULL(address2,''),ISNULL(address3,''),ISNULL(city,''),ISNULL(STATE,''),ISNULL(zipcode,''),ISNULL(country,''),isnull(ContactNo,'') FROM jct_courier_other_Address where  partyname ='" + txtOtherParty.Text + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtState1.Text = dr[5].ToString();
                            txtZipCode.Text = dr[6].ToString();
                            txtCountry1.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
                        }

                    }
                    else
                    {
                        ShowAlertMsg("No Data Found..!! ");
                    }
                }
            }
        }
        catch (Exception ex)
        { 
            
        }
    
        #endregion

    }


    protected void BindGrid()
    {
        sql = "Exec jct_courier_ListOf_Pending_And_Authorized_Couriers '" + hd6.Value + "'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        DataTable dt = new DataTable();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }

    protected void rblSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        EmptyForm();
        if (rblSelect.SelectedItem.Text == "HO")
        {
            txtCostCenter.Enabled = true;
            rblSaleOffices.Items.Clear();
            sql = "select Isnull(PartyName,'') as PartyName,Isnull(Address1,'') as Address1,Isnull(Address2,'') as Address2,Isnull(Address3,'') as Address3, Isnull(City,'') as City,Isnull(ZipCode,'') as ZipCode,Isnull(State,'') as State,Isnull(Country,'') as Country from jct_courier_other_address where status='A' and PartyCode='" + rblSelect.SelectedItem.Text + "'";
            SqlDataReader dr = obj1.FetchReader(sql);
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    txtOtherParty.Text = dr["PartyName"].ToString();
                    txtAdd1.Text = dr["Address1"].ToString();
                    txtAdd2.Text = dr["Address2"].ToString();
                    txtAdd3.Text = dr["Address3"].ToString();
                    txtCity1.Text = dr["City"].ToString();
                    txtZipCode.Text = dr["ZipCode"].ToString();
                    txtState1.Text = dr["State"].ToString();
                    txtCountry1.Text = dr["Country"].ToString();
                }
            }

        }
        else if (rblSelect.SelectedItem.Text == "Sales Office")
        {
            txtCostCenter.Enabled = true;
            rblSaleOffices.Items.Clear();
            sql = "select PartyCode,Description  from jct_courier_other_address where SaleOffice='Y' and status='A' ";
            obj1.FillList(rblSaleOffices, sql);
            //  pnlSaleOffice.Visible = true;

        }
        else if (rblSelect.SelectedItem.Text == "Hoshiarpur JCT")
        {
            txtCostCenter.Enabled = true;
            rblSaleOffices.Items.Clear();
            sql = "select Isnull(PartyName,'') as PartyName,Isnull(Address1,'') as Address1,Isnull(Address2,'') as Address2,Isnull(Address3,'') as Address3, Isnull(City,'') as City,Isnull(ZipCode,'') as ZipCode,Isnull(State,'') as State,Isnull(Country,'') as Country  from jct_courier_other_address where Description='" + rblSelect.SelectedItem.Value + "' and SaleOffice='N' and status='A' ";
            SqlDataReader dr = obj1.FetchReader(sql);
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    txtOtherParty.Text = dr["PartyName"].ToString();
                    txtAdd1.Text = dr["Address1"].ToString();
                    txtAdd2.Text = dr["Address2"].ToString();
                    txtAdd3.Text = dr["Address3"].ToString();
                    txtCity1.Text = dr["City"].ToString();
                    txtZipCode.Text = dr["ZipCode"].ToString();
                    txtState1.Text = dr["State"].ToString();
                    txtCountry1.Text = dr["Country"].ToString();
                }
            }
        }
        else if (rblSelect.SelectedItem.Text == "Other")
        {
            rblSaleOffices.Items.Clear();
            ListItem li = new ListItem("Prospective Customer", "Prospective Customer");
            rblSaleOffices.Items.Add(li);
            li = new ListItem("Prospective Supplier", "Prospective Supplier");
            rblSaleOffices.Items.Add(li);
            li = new ListItem("Agent", "Agent");
            rblSaleOffices.Items.Add(li);
            //li = new ListItem("Personal", "Personal");
            //rblSaleOffices.Items.Add(li);
        }
    }

    /// Updates the data.
    /// </summary>
    private void UpdateInsertData(string editId)
    {
        string sql = string.Empty;
        string message = "Added";
        if (editId.EndsWith("0"))
        {
            sql = "insert into jct_courier_vendor_master (CompanyCode,vender_code, vendor_name, vender_add1, vender_add2,vendor_add3,city,state,country,zip_code,vendor_type,vendor_category,vendor_class,lang_id,customer_flag,vendor_status) values " +
          " ('JCT00LTD',@vendorcode, @vendor_name, @vendor_add1, @vendor_add2,@vendor_add3,@city,@state,@country,@zipcode,'V','P','T','1','N','A')";
        }
        else
        {
            message = "Update";
            //sql = "Update JCT_Sample_Process_Trans set TrialNo = @TrialNo, Seq = @Seq, " +
            //     " Process = @Process, Machine = @Machine WHERE TransNo = @TransNo ";
        }

        // get the data now
        using (SqlConnection conn = new SqlConnection("ConStr"))
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;

                SqlParameter p = new SqlParameter("@vendorcode", SqlDbType.VarChar, 10);
                p.Value = Request.Form["PartyCode"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@vendor_name", SqlDbType.VarChar, 10);
                p.Value = Request.Form["PartyName"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@vendor_add1", SqlDbType.VarChar, 50);
                p.Value = Request.Form["Address1"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@vendor_add2", SqlDbType.VarChar, 50);
                p.Value = Request.Form["Address2"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@vendor_add3", SqlDbType.VarChar, 50);
                p.Value = Request.Form["Address3"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@city", SqlDbType.VarChar, 50);
                p.Value = Request.Form["City"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@state", SqlDbType.VarChar, 50);
                p.Value = Request.Form["State"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@country", SqlDbType.VarChar, 50);
                p.Value = Request.Form["Country"];
                cmd.Parameters.Add(p);
                p = new SqlParameter("@zipCode", SqlDbType.VarChar, 50);
                p.Value = Request.Form["ZipCode"];
                cmd.Parameters.Add(p);

                //p = new SqlParameter("@TransNo", SqlDbType.Int);
                //p.Value = int.Parse(editId);
                //cmd.Parameters.Add(p);
                string sql1 = sql;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        FMsg.CssClass = "errormsg";
        FMsg.Message = "Selected record " + message + " successfully !";
        FMsg.Display();
        // rebind the data again
        // BindMyGrid();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataList dtl = (DataList)e.Row.FindControl("DataList1");
            TextBox txtSerialNo = (TextBox)e.Row.Cells[1].FindControl("txtSerial");
            Label lblSerialNo = (Label)e.Row.Cells[1].FindControl("lblSerialNo");
            sql = "select Subject,Party_Name,Country,Attached_File from jct_courier_Request where  Serial_No = '" + lblSerialNo.Text + "'";
            SqlDataReader dr = obj1.FetchReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   // txtSerialNo.ToolTip = "Subject : " + dr["Subject"] + " \n Party Name=" + dr["Party_Name"] + " \n Country=" + dr["Country"] + "";
                    
                    String[] Attachments = dr["Attached_File"].ToString().Split(',');
                    DataTable table = new DataTable();
                    table.Columns.Add("File");
                    
                    
                    foreach (String ae in Attachments )
                    {
                        DataRow drow = table.NewRow();
                        drow[0] = ae;
                        table.Rows.Add(drow);
                    }
                    
                    //for(int i=0;i<= Attachments.Count() -1 ;i++)
                    //{
                        
                    //    table.Rows.Add(Attachments[i]);
                    //}
                    dtl.DataSource = table;
                    dtl.DataBind();
                    table.Dispose();
                }
            }

        }
        ViewState["RowCommand"] = false;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName != "TrackingID")
        //{
        //    if (!e.CommandArgument.Equals("No File Attached"))
        //    {

        //        String Files = e.CommandArgument.ToString();
        //        String[] Attachments = Files.Split(',');
        //        for (int i = 0; i <= Attachments.Count() - 1; i++)
        //       { 
        //        string filepath = Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + Attachments[i]);
        //        if (File.Exists(filepath) == false)
        //        {
        //            // ShowAlertMsg("File Not Found.Please contact IT-HelpDesk @4212.");
        //        }
        //        else
        //        {
        //            Response.ClearContent();
        //            Response.ContentType = "application/octet-stream";
        //            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(Attachments[i])));
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Attachments[i] + "");
        //            Response.TransmitFile(Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + Attachments[i]));
        //            Response.End();
        //        }
        //     }
        //    }
        //}


    }

    protected void lnkTrackingID_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "TrackingID")
        {

            ClientScript.RegisterStartupScript(this.Page.GetType(), "", " window.open('" + e.CommandArgument + "','mywin','left=20,top=20,width=500,height=500,toolbar=1,resizable=1');", true);
        }

    }
    #endregion



    protected void rblSaleOffices_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select Isnull(PartyCode,'') as PartyCode, Isnull(PartyName,'') as PartyName,Isnull(Address1,'') as Address1,Isnull(Address2,'') as Address2,Isnull(Address3,'') as Address3, Isnull(City,'') as City,Isnull(ZipCode,'') as ZipCode,Isnull(State,'') as State,Isnull(Country,'') as Country from jct_courier_other_address where status='A' and PartyCode='" + rblSaleOffices.SelectedItem.Value + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        while (dr.Read())
        {
            if (dr.HasRows)
            {
                txt.Text = dr["PartyCode"].ToString();
                txtOtherParty.Text = dr["PartyName"].ToString();
                txtSupplierName.Text = dr["PartyName"].ToString();
                txtPartyName.Text = dr["PartyName"].ToString();
                txtAdd1.Text = dr["Address1"].ToString();
                txtAdd2.Text = dr["Address2"].ToString();
                txtAdd3.Text = dr["Address3"].ToString();
                txtCity1.Text = dr["City"].ToString();
                txtZipCode.Text = dr["ZipCode"].ToString();
                txtState1.Text = dr["State"].ToString();
                txtCountry1.Text = dr["Country"].ToString();
            }
        }
    }
    protected void txtCostCenter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSelect.SelectedItem.Text == "Other")
            {
                //txtCostCenter.Text = "";
                //   ShowAlertMsg("Please donot add any cost center for personnel couriers.");
            }
            else
            {
                if (txtCostCenter.Text.Contains("~"))
                {
                    txtCostCenter.Text = txtCostCenter.Text.Split('~')[1].ToString();

                }
                sql = "EXEC JCT_COURIER_CHECK_COSTCENTER '" + txtCostCenter.Text + "' ";

                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    imgCheck.Visible = true;
                    imgCheck.ImageUrl = "~/Image/Availabilitytrue.png";
                }
                else
                {
                    imgCheck.Visible = true;
                    imgCheck.ImageUrl = "~/Image/AvailabilityFalse.png";
                    ShowAlertMsg("The CostCenter you mentioned does not exit.Please enter correct CostCenter..!!");

                }

            }

        }
        catch (Exception ex)
        {

        }

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName != "TrackingID")
        {
            if (!e.CommandArgument.Equals("No File Attached"))
            {

                String Files = e.CommandArgument.ToString();
                String[] Attachments = Files.Split(',');
                for (int i = 0; i <= Attachments.Count() - 1; i++)
                {
                    string filepath = Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + Attachments[i]);
                    if (File.Exists(filepath) == false)
                    {
                        // ShowAlertMsg("File Not Found.Please contact IT-HelpDesk @4212.");
                    }
                    else
                    {
                        Response.ClearContent();
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(Attachments[i])));
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Attachments[i] + "");
                        Response.TransmitFile(Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + Attachments[i]));
                        Response.End();
                    }
                }
            }
        }
    }

    protected void txtOtherParty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSelect.SelectedItem.Text == "Other")
            {
                AutoCompleteExtender1.TargetControlID = "txtPartyName";
                AutoCompleteExtender1.ServiceMethod = "OtherPartyAddress_CourierSystem";
                sql = "Select  ISNULL(PartyCode,''),ISNULL(address1,''),ISNULL(address2,''),ISNULL(address3,''),ISNULL(city,''),ISNULL(STATE,''),ISNULL(zipcode,''),ISNULL(country,''),isnull(ContactNo,'') FROM jct_courier_other_Address where  partyname ='" + txtOtherParty.Text + "'";
                if (obj1.CheckRecordExistInTransaction(sql))
                {
                    SqlDataReader dr = obj1.FetchReader(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt.Text = dr[0].ToString();
                            txtAdd1.Text = dr[1].ToString();
                            txtAdd2.Text = dr[2].ToString();
                            txtAdd3.Text = dr[3].ToString();
                            txtCity1.Text = dr[4].ToString();
                            txtState1.Text = dr[5].ToString();
                            txtZipCode.Text = dr[6].ToString();
                            txtCountry1.Text = dr[7].ToString();
                            txtPhoneNo.Text = dr[8].ToString();
                        }

                    }
                    else
                    {
                        // ShowAlertMsg("No Data Found..!! ");
                    }
                }
            }
        }
        catch (Exception ex)
        { 
            
        }
     
    }

    protected void SendMailWithAttachments(String Body)
    {
        /* Create a new blank MailMessage */
        MailMessage mailMessage = new MailMessage();
        String MailCC = "";
        List<String> Files = new List<String>();
        mailMessage.From = "noreply@jctltd.com";
        mailMessage.To = txtTo.Text.Trim();
        mailMessage.BodyFormat = MailFormat.Html;
        if (txtCC.Text == "")
        {
            for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
            {
                // MailCC= String.Join(",", chkEmailID.Items[i].Select(x => x.ToString()).ToArray());
                Files.Add(chkEmailID.Items[i].Text);
            }
        }
        else
        {

            Files.Add(txtCC.Text);
        }
        //mail.Bcc
        mailMessage.Bcc = "ashish@jctltd.com";
        mailMessage.Cc = String.Join(",", Files.Select(x => x.ToString()).ToArray());
        //mailMessage.Bcc = "jatindutta@jctltd.com";
        mailMessage.Subject = txtSubject.Text + " (Courier Copy)";
        mailMessage.Body = Body;

        if (Request.Files.Count > 0)
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile PostedFile = Request.Files[i];
                if (PostedFile.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    PostedFile.SaveAs(Server.MapPath("Attached_Files\\") + FileName);
                    MailAttachment attach = new MailAttachment(Server.MapPath("Attached_Files\\") + FileName);
                    mailMessage.Attachments.Add(attach);
                }

            }
        
        }
        SmtpMail.SmtpServer = "exchange2k7";
        SmtpMail.Send(mailMessage);
      
    }

    //protected void txtTo_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        txtTo.Text = txtTo.Text.Split('~')[2].ToString();
    //        sql = "Select e_mailid from mistel where empcode='" + txtTo.Text + "'";
    //        txtTo.Text = obj1.FetchValue(sql).ToString().Trim();
    //    }
    //    catch (Exception ex)
    //    { }

    //}

    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtTo.Text = txtTo.Text.Split('~')[2].ToString();
            sql = "Select e_mailid from mistel where empcode='" + txtTo.Text + "'";
            txtTo.Text = obj1.FetchValue(sql).ToString().Trim();
            if (!string.IsNullOrEmpty(txtTo.Text))
            {
                chkEmailIDTo.Items.Add(txtTo.Text);
            }
            else
            {
                string script = "alert('No Email address present.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
            for (int i = 0; i <= chkEmailIDTo.Items.Count - 1; i++)
            {
                chkEmailIDTo.Items[i].Selected = true;
            }
            txtTo.Text = "";
            txtTo.Focus();
        }
        catch (Exception ex)
        { }

    }


    protected void txtCC_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtCC.Text = txtCC.Text.Split('~')[2].ToString();
            sql = "Select e_mailid from mistel where empcode='" + txtCC.Text + "'";
            txtCC.Text = obj1.FetchValue(sql).ToString().Trim();
            if (!string.IsNullOrEmpty(txtCC.Text))
            {
                chkEmailID.Items.Add(txtCC.Text);
            }
            else
            {
                string script = "alert('No Email address present.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }
           
            for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
            {
                chkEmailID.Items[i].Selected = true;
            }
            txtCC.Text = "";
            txtCC.Focus();
        }
        catch (Exception ex)
        { }
    }


    protected void chkEmailID_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chkEmailID.Items.Count - 1; i++)
        {
            if (chkEmailID.Items[i].Selected == false)
            {
                chkEmailID.Items.RemoveAt(i);
            }
        }
    }

    protected void chkEmailIDTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chkEmailIDTo.Items.Count - 1; i++)
        {
            if (chkEmailIDTo.Items[i].Selected == false)
            {
                chkEmailIDTo.Items.RemoveAt(i);
            }
        }
    }
}