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

public partial class Courier_Tracking_System_Generate_Request : System.Web.UI.Page

{
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    String sql ;
    SqlTransaction Tran;
    SendMail sm= new SendMail();
    public int num;
    public string dept;
    public string empname;
    public string year;

    
#region Coding Start here..
      protected string GenerateCode(string dept)
    {
        #region Seial No. Code
      
        int num;
        string year;
        sql = "Select StartYear from jct_courier_Year_Master where status='A' and Sr_No = (Select max(sr_no) from jct_courier_Year_Master where status='A') ";
        year = obj1.FetchValue(sql).ToString();
        hd1.Value = year;
        sql = "Select Isnull(MidNumber,'100001') from jct_courier_serial_master where Sr_No =(Select max(Sr_no) from jct_courier_serial_master )";
        if (obj1.CheckRecordExistInTransaction(sql))
        {
            string c = obj1.FetchValue(sql).ToString();
            num = Convert.ToInt32(c) + 1;
            hd2.Value = Convert.ToString(num);
        }
        else
        {
            num = 1000001;
            hd2.Value = num.ToString();
        }
        hd3.Value = hdDept.Value + "/" + Convert.ToString(num) + "/" + year;

        return hd3.Value.ToString();
        #endregion
      
   }
      protected void EmptyForm()
      {
          #region Empty textbox value
          txtAdd1.Text = "";
          txtAdd2.Text="";
          txtAdd3.Text="";
          txtPartyName.Text="";
          txtSupplierName.Text = "";
          txtCity1.Text="";
          txtState1.Text = "";
          txtZipCode.Text = "";
          txtCountry1.Text = "";
          txt.Text = "";
          txtOtherParty.Text = "";
          #endregion
        
      }
      protected void Page_Load(object sender, EventArgs e)
      {
          //Response.Cache.SetNoStore();
         // ViewState.Clear();

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
          else if(rblSelect.SelectedIndex==1)
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
               hd2.Value= "";
              // txt.Attributes.Add("onkeypress", "return clickButton(event,'" + Button3.ClientID + "')");
               sql = "Select a.deptcode from deptmast a inner join jct_empmast_base b on a.deptcode=b.deptcode where b.empcode='"+ Session["EmpCode"] +"' ";
               string dept = obj1.FetchValue(sql).ToString();
              sql = "Select 'Any','Any' union Select Courier_Service,Courier_Service from jct_Courier_Service_Master where status ='A'";
              obj1.FillList(ddlCourierService, sql);
              sql = "SELECT CourierType,CourierType FROM jct_courier_Type_Master WHERE status='A' and mapped_Department='"+ dept +"' ";
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
        try
        {
            obj.ConOpen();
            GenerateCode( hd1.Value.ToString());
            TextBox Name = new TextBox();
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
            sql = "Insert into jct_courier_Request(Serial_No,Courier_Type,Courier_Service,Delivery_Type,SUBJECT,Party_Name,Address1,Address2,Address3,City,ZipCode,State,Country,STATUS,Request_By,Request_Date,Cost_Center,Attached_File,Remarks,SendType,PartyCode ) values(@Serial_No,@Courier_Type,@Courier_Service,@Delivery_Type,@SUBJECT,@Party_Name,@Address1,@Address2,@Address3,@City,@ZipCode,@State,@Country,@Status,@Request_By,@Request_Date,@Cost_Center,@Attached_File,@Remarks,@SendType,@PartyCode)";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@Serial_No", SqlDbType.VarChar, 16).Value = hd3.Value;
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
            cmd.Parameters.Add("@Cost_Center", SqlDbType.VarChar, 100).Value =  hdDept.Value;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtOtherRequest.Text;
            cmd.Parameters.Add("@SendType", SqlDbType.VarChar, 30).Value = rblSelect.SelectedItem.Text;
            cmd.Parameters.Add("@PartyCode", SqlDbType.Char, 8).Value = txt.Text;
            if ( hd4.Value== "")
            {
                cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = "No File Attached";
            }
            else
            {
                cmd.Parameters.Add("@Attached_File", SqlDbType.VarChar, 2000).Value = hd4.Value;
            }
            //cmd.Prepare();
            cmd.ExecuteNonQuery();

            sql = "INSERT INTO dbo.jct_courier_serial_master( UserCode ,UserName ,Prefix ,PostFix ,MidNumber ,SerialNumber ,STATUS ,EntryDate ) VALUES  ( '" + Session["EmpCode"] + "' ,'" + hd6.Value + "'  ,'" + hdDept.Value + "', '" + hd1.Value + "',Convert(Int,'" + hd2.Value + "') , '" + hd3.Value + "' , 'A',getdate() )";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.ExecuteNonQuery();
            if ( hd2.Value== "")
            {

            }
            else
            {
                for (int i = 0; i <= chkAttachedFiles.Items.Count - 1; i++)
                {
                    if (chkAttachedFiles.Items[i].Selected == true)
                    {
                        string filename = chkAttachedFiles.Items[i].Text;
                        UploadFile.SaveAs(Server.MapPath("Attached_Files/") + chkAttachedFiles.Items[i].Text);
                    }

                }
            }

            //if (UploadFile.HasFile)
            //{
            //    string filename = Path.GetFileName(UploadFile.FileName);
            //    UploadFile.SaveAs(Server.MapPath("Attached_Files/") + filename);
            //}
         
            ShowAlertMsg("Request generated Successfully");

             SendMailCourier();
             hd2.Value= "";

        }
        catch (Exception ex)
        {
            ex.ToString();
            ShowAlertMsg("Some Error Occured.");
        }
        finally
        {
            obj.ConClose();
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
            SubmitRecord();
        }
        if (rblSelect.SelectedItem.Text == "Other")
        {
            sql = "Insert into jct_courier_other_address (PartyName,address1,address2,address3,city,state,zipcode,country,status)values('"+ txtOtherParty.Text +"','"+ txtAdd1.Text +"','"+ txtAdd2.Text +"','"+ txtAdd3.Text +"','"+ txtCity1.Text +"','"+ txtState1.Text +"','"+ txtZipCode.Text +"','"+ txtCountry1.Text +"','A') ";
            obj1.InsertRecord(sql);
            SubmitRecord();  
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
                sql = "UPDATE dbo.jct_courier_Request SET Sendtype='" + rblSelect.SelectedItem.Text + "', Courier_Type='" + ddlCourierType.SelectedItem.Text + "',Courier_Service='" + ddlCourierService.SelectedItem.Text + "',Delivery_Type='" + ddlDelivery.SelectedItem.Text + "',SUBJECT='" + txtSubject.Text + "',Party_Name='" + txtPartyName.Text + "',Address1='" + txtAdd1.Text + "',Address2='" + txtAdd2.Text + "',Address3='" + txtAdd3.Text + "',City='" + txtCity1.Text + "',ZipCode='" + txtZipCode.Text + "',State='" + txtState1.Text + "',Country='" + txtCountry1.Text + "',PartyCode='" + txt.Text + "',Remarks='" + txtOtherRequest.Text + "'  WHERE Status ='P' AND Serial_No='" + hd5.Value + "'";
                SqlCommand cmd1 = new SqlCommand(sql, obj.Connection());
                cmd1.ExecuteNonQuery();
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        #region uploadFiles
        if (UploadFile.HasFile)
        {
            ListItem filename = new ListItem();
            filename.Text = Path.GetFileName(UploadFile.FileName);

             hd4.Value=  hd4.Value+ filename.Text + ",";

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
             hd4.Value= "";
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

   hd4.Value= "";
        for (int i = 0; i <= chkAttachedFiles.Items.Count - 1; i++)
        {
            if (chkAttachedFiles.Items[i].Selected == false)
            {
                chkAttachedFiles.Items.RemoveAt(i);

            }
            else
            {
                 hd4.Value=  hd4.Value+ chkAttachedFiles.Items[i].Text +", ";
            }
        }
        #endregion  
    }
    protected void lnkSubmit0_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Authorize_Courier_Requests.aspx");
    }

    protected void SendMailCourier()
    {
        #region SendMail

        string sender_email;
        // sm.SendMail("jctadmin@jctltd.com", "", "Courier Request- " + txtRefNo.Text + " ", "Courier Request has been generated with reference ID - '"+ txtRefNo.Text +"' on "+System.DateTime.Today+". It will be visible in the Pending List of Couriers in the Courier tracking system.");

        string empcode = Session["EmpCode"].ToString();
        sql = "Select isnull(E_mailID,'noreply@jctltd.com') from mistel where empcode = @empcode and company_code ='JCT00LTD'";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = empcode;
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                sender_email = dr[0].ToString();
                
                sm.SendMail("jatindutta@jctltd.com", sender_email, "Courier Request - " + txtRefNo.Text + " ", "Thank you for your courier request "+ hd6.Value +". Here is the summary of your request : Delivery Type : " + ddlDelivery.SelectedItem.Text + ", Request ID : " + hd3.Value + " and Item : "+ ddlCourierType.SelectedItem.Text +" . It will be visible in the pending list of couriers in the courier tracking system.You will get a confirmation mail whenever your request will be authorized. Thank you for using Courier Management System.");
            }

        }
        else
        { }
        #endregion
    }
    
    //protected void lnkGetAddress_Click(object sender, EventArgs e)
    //{
    //    sql = "Select address_1 , address_2  , address_3 , city ,'' as ZipCode , State ,  country from m_customer_address where cust_name ='"+ txtPartyName.Text +"' ";
    //    txtPartyAddress.Text = (string) obj1.FetchValue(sql);
    //}
   
  
    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        #region Search Party Record

        sql = "Select cust_no,cust_name,address_1 ,address_2 ,address_3 ,city,'' as [ZipCode] , state ,country   from m_customer_address where cust_name    = '" + txtPartNameSearch.Text + "' ";
        obj1.FillGrid(sql, ref GridView2);
        pnlSearch.Visible = true;

        #endregion
      
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Fetch Party Detail while in Search Mode

        txt.Text = GridView2.SelectedRow.Cells[1].Text.ToString();
        //txtPartyAddress.Text = GridView2.SelectedRow.Cells[3].Text.ToString();
        txtAdd1.Text= GridView2.SelectedRow.Cells[3].Text.ToString();
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

        if (rblSelect.SelectedItem.Text == "Customer")
        {
            sql = "Select cust_name , address_1 , address_2  , address_3 , city  , State ,  country,'' as ZipCode  from m_customer_address where cust_no ='" + txt.Text + "' ";
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
            sql = "Select vendor_name , vendor_add1 , vendor_add2  , vendor_add3 , city  , State ,  country,ISnull( zip_code,'') as ZipCode  from jct_courier_vendor_master where vendor_code ='" + txt.Text + "' ";
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
    protected void lnkAddCourierType_Click(object sender, EventArgs e)
    {
        #region AddCourierType
       sql = "Insert into jct_courier_Type_Master(UserCode,UserName,CourierType,DESCRIPTION,STATUS,EntryDate,EffecFrom,EffecTo,Mapped_Department,Dept_EffecFrom,Dept_EffecTo ) values(@UserCode,@UserName,@CourierType,@Description,@Status,@EntryDate,@EffecFrom,@EffecTo,@Mapped,@Dept_EffecFrom,@Dept_EffecTo)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = Session["EmpName"]; 
        cmd.Parameters.Add("@CourierType", SqlDbType.VarChar, 100).Value = txtCourierType.Text;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = txtTypeDescription.Text;
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
        Response.Redirect("Generate_Request.aspx");
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
        sql = "Insert into m_customer_address(cust_no,cust_name,address_1,address_2,address_3,city,state,country ) values(@cust_no,@cust_name,@address1,@address2,@address3,@city,@state,@country)";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.Parameters.Add("@cust_no", SqlDbType.Char, 18).Value = cust_no;
        cmd.Parameters.Add("@cust_name", SqlDbType.VarChar, 40).Value = txtPartyNameNew.Text;
        cmd.Parameters.Add("@address1", SqlDbType.VarChar, 40).Value = txtAddress1.Text;
        cmd.Parameters.Add("@address2", SqlDbType.VarChar, 40).Value = txtAddress2.Text;
        cmd.Parameters.Add("@address3", SqlDbType.VarChar, 40).Value = txtAddress3.Text;
        cmd.Parameters.Add("@city", SqlDbType.VarChar,30).Value = txtCity.Text;
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
        lbl =(Label) GridView1.SelectedRow.Cells[1].FindControl("lblSerial");
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
                //rblSelect.SelectedItem.Text = dr[14].ToString();
                rblSelect.Items.FindByText(dr[14].ToString()).Selected=true;
             
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
                ShowAlertMsg("Can not be Deleted as it is authorized. Please contact concerned person.");
            
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

        if (rblSelect.SelectedItem.Text == "Customer")
        { 
               sql = "Select cust_no , address_1 , address_2  , address_3 , city,'' as ZipCode  , State ,  country  from m_customer_address where  cust_name ='"+ txtPartyName.Text +"'";
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
                   // txtPartyAddress.Text = dr[1].ToString();
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
            sql = "Select vendor_code , vendor_add1 , vendor_add2  , vendor_add3 , city,isnull( Zip_Code ,'') as ZipCode , State , country  from jct_courier_vendor_master where  vendor_name ='" + txtSupplierName.Text + "'";
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
            sql = "Select  ISNULL(PartyCode,''),ISNULL(address1,''),ISNULL(address2,''),ISNULL(address3,''),ISNULL(city,''),ISNULL(STATE,''),ISNULL(zipcode,''),ISNULL(country,'') FROM jct_courier_other_Address where  partyname ='" + txtOtherParty.Text + "'";
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
                    }

                }
                else
                {
                    ShowAlertMsg("No Data Found..!! ");
                }
            }
        }
        #endregion
      
       
    }


    protected void  BindGrid()
    {

        sql = "Exec jct_courier_ListOf_Pending_And_Authorized_Couriers '"+ hd6.Value +"'";
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
            txtOtherParty.Text = "JCT Limited";
            txtAdd1.Text = "JCT Limited";
            txtAdd2.Text = "3/17 , Grover Mansion";
            txtAdd3.Text = "Asif Ali Road";
            txtCity1.Text = "New Delhi";
            txtZipCode.Text = "110002";
            txtState1.Text = "New Delhi";
            txtCountry1.Text = "India";
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
            sql = "Update JCT_Sample_Process_Trans set TrialNo = @TrialNo, Seq = @Seq, " +
                 " Process = @Process, Machine = @Machine WHERE TransNo = @TransNo ";
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
        FMsg.Message= "Selected record " + message + " successfully !";
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
        
        TextBox txtSerialNo =(TextBox) e.Row.Cells[1].FindControl("txtSerial");
        sql = "select Subject,Party_Name,Country from jct_courier_Request where  Serial_No='" + txtSerialNo + "'";
        SqlDataReader dr = obj1.FetchReader(sql);
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtSerialNo.ToolTip = "Subject : " + dr["Subject"] + " \n Party Name=" + dr["Party_Name"] + " \n Country=" + dr["Country"] + "";
            }
        }
     
        }
        ViewState["RowCommand"] = false;
    

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (!e.CommandArgument.Equals("No File Attached"))
        {
            string filepath = Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + e.CommandArgument.ToString());
            if (File.Exists(filepath) == false)
            {
               // ShowAlertMsg("File Not Found.Please contact IT-HelpDesk @4212.");
            }
            else
            {
                Response.ClearContent();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(e.CommandArgument.ToString())));
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString() + "");
                Response.TransmitFile(Server.MapPath("~\\Courier Tracking System\\Attached_Files\\" + e.CommandArgument.ToString()));
                Response.End();
            }

        }

    }
    protected void lnkTrackingID_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "TrackingID")
        {

            ClientScript.RegisterStartupScript(this.Page.GetType(), "", " window.open('" + e.CommandArgument + "','mywin','left=20,top=20,width=500,height=500,toolbar=1,resizable=1');", true);

        }

    }
    #endregion

  
}