using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
public partial class TransportRequisition : System.Web.UI.Page
{
    Connection ObjCon = new Connection();
    string sqlstr;
    SqlCommand cmd;
    SqlDataReader dr;
    Connection cn;
    //21 May 2015
    DateTime todaydate;
    //21 May 2015
    string jctdevConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        //21 May 2015

        todaydate = System.DateTime.Now;
        String.Format("{0:MM/dd/yyyy}", todaydate);
        txtTodayDate.Text = String.Format("{0:d/MM/yyyy}", System.DateTime.Now);
        //21 May 2015
        if (!IsPostBack)
        {
            btnfetch.Visible = false;
            btnSave.Visible = false;
            cn = new Connection(jctdevConnectionString);
            sqlstr = "select VEHICLE_No,VEHICLE_Name from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS='' AND Eff_To IS null ORDER BY VEHICLE_Name";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DdlVehicle.Items.Add(dr[1].ToString());
                    DdlVehicleAllocated.Items.Add(dr[1].ToString());
                }
            }
            dr.Close();
            sqlstr = "SELECT DISTINCT State FROM jctgen..JCT_EPOR_STATE_MASTER";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddlPlace.Items.Add(dr[0].ToString());
                    ddlPlace.SelectedItem.Text = "Punjab";
                }
            }
            dr.Close();
            string state = ddlPlace.SelectedItem.Value.ToString();

            sqlstr = "SELECT DISTINCT City FROM jctgen..JCT_EPOR_STATE_MASTER WHERE state='" + state + "'";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddlCity.Items.Add(dr[0].ToString());
                    ddlCity.SelectedItem.Text = "PHAGWARA";
                }
            }
            dr.Close();
            cn = new Connection(jctdevConnectionString);
            sqlstr = "select VEHICLE_No from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS='' AND Eff_To IS null AND VEHICLE_Name = '" + DdlVehicleAllocated.SelectedValue.ToString() + "' ";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtCarAllocated.Text = dr[0].ToString();
                }
            }
            dr.Close();
        }

    }
    protected void ddlPlace_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCity.Items.Clear();
        string state = ddlPlace.SelectedItem.Value.ToString();
        cn = new Connection(jctdevConnectionString);
        sqlstr = "SELECT DISTINCT City FROM jctgen..JCT_EPOR_STATE_MASTER WHERE state='" + state + "'";
        cmd = new SqlCommand(sqlstr, cn.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ddlCity.Items.Add(dr[0].ToString());
            }
        }
        dr.Close();
    }
    protected void btnsub_Click(object sender, EventArgs e)
    {
        try
        {
            cn = new Connection(jctdevConnectionString);



            string place;
            string str2, str3;
            //21 May 2015
            if (txtkms.Text == "")
            {
                txtkms.Text = "0";
            }

            place = txtOther.Text + "#" + ddlExactLocation.SelectedItem.Value.ToString() + "@" + ddlCity.SelectedItem.Value.ToString() + "*" + ddlPlace.SelectedItem.Value.ToString();

            sqlstr = "insert into jct_emp_transport_request(required_by ,Place , OnDate , OnTime ,  Purpose ,  No_of_Persons ,Vehicle_Prefrence , ReturnDate ,ReturnTime ,  ReportPlace , Chargeable ,  Vehicle_Allocated,EntryDate,DriverName,KM ,CarNo)";
            str2 = " values('" + Txtrequiredby.Text + "','" + place + "','" + txt_Date.Text + "','" + txtrequiredtime.SelectedTime.ToShortTimeString() + "','" + ddlpurpose.SelectedItem.Value.ToString() + "'," + txtNo_of_Persons.Text + ",'" + DdlVehicle.SelectedItem.Value.ToString() + "',";
            str3 = "'" + txtexpected.Text + "','" + txtreturntime.SelectedTime.ToShortTimeString() + "','" + txtreport.Text + "','" + rblcharge.Text + "','" + DdlVehicleAllocated.SelectedItem.Value.ToString() + "','" + todaydate.ToShortDateString() + "','" + txtDriver.Text + "'," + txtkms.Text + ",'" + txtCarAllocated.Text + "')";
            //21 May 2015
            sqlstr = sqlstr + str2 + str3;
            cmd = new SqlCommand(sqlstr, cn.Connection());
            cmd.ExecuteNonQuery();
            Message.Text = "Record Added Successfully";
           
            sqlstr = "select max(autoid) from jct_emp_transport_request";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Txtslno.Text = dr[0].ToString();
                }
            }
            dr.Close();

        }
        catch (Exception ex)
        {
            Message.Text = "" + ex;
        }
        btnfetch.Visible = false;
        btnSave.Visible = false;
        btnModify.Enabled = true;

    }




    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EmpGateway/TransportRequisition.aspx");
        //Txtslno.Text = "";
        //Txtrequiredby.Text = "";
        //txt_Date.Text = "";
        //txtNo_of_Persons.Text = "";
        //txtOther.Text = "";
        //ddlExactLocation.SelectedIndex = -1;
        //ddlpurpose.SelectedIndex = -1;
        //txtexpected.Text = "";
        //txtreport.Text = "";
        //Message.Text = "";
        //txtkms.Text = "";
        //txtDriver.Text = "";
        //txtCarAllocated.Text = "";
        //btnfetch.Visible = false;
        //btnSave.Visible = false;
        //btnModify.Enabled = true;
        //btnsub.Enabled = true;

        //cn = new Connection(jctdevConnectionString);
        //sqlstr = "select VEHICLE_No from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS='' AND Eff_To IS null AND VEHICLE_Name = '" + DdlVehicleAllocated.SelectedValue.ToString() + "' ";
        //cmd = new SqlCommand(sqlstr, cn.Connection());
        //dr = cmd.ExecuteReader();
        //if (dr.HasRows)
        //{
        //    while (dr.Read())
        //    {
        //        txtCarAllocated.Text = dr[0].ToString();
        //    }
        //}
        //dr.Close();



    }
    protected void DdlVehicleAllocated_SelectedIndexChanged(object sender, EventArgs e)
    {

        cn = new Connection(jctdevConnectionString);
        sqlstr = "select VEHICLE_No from JCT_EMP_TRANSPORTATION_VEHICLES where STATUS='' AND Eff_To IS null AND VEHICLE_Name = '" + DdlVehicleAllocated.SelectedValue.ToString() + "' ";
        cmd = new SqlCommand(sqlstr, cn.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                txtCarAllocated.Text = dr[0].ToString();
            }
        }
        dr.Close();
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        Txtslno.Text = "";
        Txtrequiredby.Text = "";
        txt_Date.Text = "";
        txtNo_of_Persons.Text = "";
        txtOther.Text = "";
        ddlExactLocation.SelectedIndex = -1;
        ddlpurpose.SelectedIndex = -1;
        txtexpected.Text = "";
        txtreport.Text = "";
        Message.Text = "";
        txtkms.Text = "";
        txtDriver.Text = "";
        txtCarAllocated.Text = "";
        Txtslno.Enabled = true;
        ddlExactLocation.SelectedIndex = -1;
        ddlpurpose.SelectedIndex = -1;
        btnfetch.Visible = true;
        btnModify.Enabled = false;
        btnSave.Visible = true;
        btnsub.Enabled = false;


    }
    protected void btnfetch_Click(object sender, EventArgs e)
    {
        string combinedplace;
        cn = new Connection(jctdevConnectionString);

        sqlstr = "select status from jct_emp_transport_request WHERE AutoID= '" + Txtslno.Text + "' ";
        cmd = new SqlCommand(sqlstr, cn.Connection());
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            
            while (dr.Read())
            {
                if (dr["status"].ToString() == "D")
                {
                    Srnomsg.Text = "SrNo Already Modified";
                    return;
                }
                else
                {
                    sqlstr = "select * from jct_emp_transport_request WHERE AutoID= '" + Txtslno.Text + "' ";
                    cmd = new SqlCommand(sqlstr, cn.Connection());
                    dr.Close();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Srnomsg.Text = "";
                        while (dr.Read())
                        {
                            Txtrequiredby.Text = dr["required_by"].ToString();
                            combinedplace = dr["Place"].ToString();
                            txt_Date.Text = dr["OnDate"].ToString();
                            txtrequiredtime.SelectedValue = Convert.ToDateTime(dr["OnTime"].ToString());
                            ddlpurpose.SelectedItem.Value = dr["Purpose"].ToString();
                            ddlpurpose.SelectedItem.Text = dr["Purpose"].ToString();
                            txtNo_of_Persons.Text = dr["No_of_Persons"].ToString();
                            DdlVehicle.SelectedItem.Text = dr["Vehicle_Prefrence"].ToString();
                            txtkms.Text = dr["KM"].ToString();
                            txtexpected.Text = dr["ReturnDate"].ToString();
                            txtreturntime.SelectedValue = Convert.ToDateTime(dr["ReturnTime"].ToString());
                            txtreport.Text = dr["ReportPlace"].ToString();
                            txtDriver.Text = dr["DriverName"].ToString();
                            DdlVehicleAllocated.SelectedItem.Text = dr["Vehicle_Allocated"].ToString();
                            txtCarAllocated.Text = dr["CarNo"].ToString();
                            rblcharge.SelectedValue = dr["Chargeable"].ToString();
                            int indexother = combinedplace.IndexOf("#");
                            if (indexother > 0)
                            {
                                txtOther.Text = combinedplace.Substring(0, combinedplace.IndexOf("#"));
                            }
                            if (indexother == 0)
                            {
                                txtOther.Text = "";
                            }
                            ddlExactLocation.SelectedItem.Text = combinedplace.Substring(combinedplace.IndexOf("#") + 1, combinedplace.IndexOf("@") - combinedplace.IndexOf("#") - 1);
                            ddlCity.SelectedItem.Text = combinedplace.Substring(combinedplace.IndexOf("@") + 1, combinedplace.IndexOf("*") - combinedplace.IndexOf("@") - 1);
                            int len = combinedplace.Length;
                            int index = combinedplace.IndexOf("*") + 1;
                            ddlPlace.SelectedItem.Text = combinedplace.Substring(combinedplace.IndexOf("*") + 1, len - index);

                        }

                    }
                    else
                    {
                        Srnomsg.Text = "Wrong SrNo";
                        return;
                    }
                    dr.Close();
                    return;
                }
            }
        }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            cn = new Connection(jctdevConnectionString);
            string place;
            string str2, str3;
            
            if (txtkms.Text == "")
            {
                txtkms.Text = "0";
            }

            place = txtOther.Text + "#" + ddlExactLocation.SelectedItem.Value.ToString() + "@" + ddlCity.SelectedItem.Value.ToString() + "*" + ddlPlace.SelectedItem.Value.ToString();
            sqlstr = "UPDATE jct_emp_transport_request SET Status='D' WHERE AutoID= '" + Txtslno.Text + "' ";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            cmd.ExecuteNonQuery();

            sqlstr = "insert into jct_emp_transport_request(required_by ,Place , OnDate , OnTime ,  Purpose ,  No_of_Persons ,Vehicle_Prefrence , ReturnDate ,ReturnTime ,  ReportPlace , Chargeable ,  Vehicle_Allocated,EntryDate,DriverName,KM ,CarNo)";
            str2 = " values('" + Txtrequiredby.Text + "','" + place + "','" + txt_Date.Text + "','" + txtrequiredtime.SelectedTime.ToShortTimeString() + "','" + ddlpurpose.SelectedItem.Value.ToString() + "'," + txtNo_of_Persons.Text + ",'" + DdlVehicle.SelectedItem.Value.ToString() + "',";
            str3 = "'" + txtexpected.Text + "','" + txtreturntime.SelectedTime.ToShortTimeString() + "','" + txtreport.Text + "','" + rblcharge.Text + "','" + DdlVehicleAllocated.SelectedItem.Value.ToString() + "','" + todaydate.ToShortDateString() + "','" + txtDriver.Text + "'," + txtkms.Text + ",'" + txtCarAllocated.Text + "')";
            
            sqlstr = sqlstr + str2 + str3;
            cmd = new SqlCommand(sqlstr, cn.Connection());
            cmd.ExecuteNonQuery();
            Message.Text = "Record Modified Successfully With New Serial Number";
           
            sqlstr = "select max(autoid) from jct_emp_transport_request";
            cmd = new SqlCommand(sqlstr, cn.Connection());
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Txtslno.Text = dr[0].ToString();
                }
            }
            dr.Close();

        }
        catch (Exception ex)
        {
            Message.Text = "" + ex;
        }
        btnfetch.Visible = false;
        btnSave.Visible = false;
        btnModify.Enabled = true;
        btnsub.Enabled = true;

    }
}


//Note: Original File of this code was TransportRequisition.aspx. This file was modified because required person only wants to add the records of person.
//Date: 20 May 2015