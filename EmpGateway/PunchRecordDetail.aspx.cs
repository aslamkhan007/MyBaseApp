using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmpGateway_PunchRecordDetail : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string empcode = string.Empty;
     
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string leaveid = string.Empty;
            leaveid = Request.QueryString["LeaveID"];

            sql = "Select leaveDate from jct_empg_compensatory_leave WHERE id= " + leaveid;
            DateTime leaveDate = Convert.ToDateTime(obj1.FetchValue(sql).ToString());

            sql = "Select empcode from jct_empg_compensatory_leave WHERE id= " + leaveid;
            empcode = obj1.FetchValue(sql).ToString();

            sql = "savior..JCT_EMPG_SAVIOR_PUCH_DETAIL";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@leaveid", SqlDbType.VarChar, 10).Value = leaveid;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblIPunch.Text = dr["I Punch"].ToString() ;
                    lblIIPunch.Text = dr["II Punch"].ToString()=="" ? "N/A": dr["II Punch"].ToString() ;
                    lblIIIPunch.Text = dr["III Punch"].ToString() == "" ? "N/A" : dr["III Punch"].ToString();
                    lblIVPunch.Text = dr["IV Punch"].ToString();
                    
                }
            }
            dr.Close();

            sql = "savior..JCT_EMPG_Savior_new";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sdate", SqlDbType.DateTime).Value = leaveDate;
            cmd.Parameters.Add("@edate", SqlDbType.DateTime).Value = leaveDate;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = empcode;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblDate.Text = leaveDate.ToString("dd/M/yyyy");//leaveDate.ToShortDateString();
                    lblDescription.Text = dr["Status"].ToString();
                }
            }
            dr.Close();
            obj.ConClose();

        }
    }
}