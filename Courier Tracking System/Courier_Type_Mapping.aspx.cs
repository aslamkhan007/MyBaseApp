using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Courier_Tracking_System_Courier_Type_Mapping : System.Web.UI.Page
{
    string sql;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {
        //sql = "Insert into jct_courier_Type_Master(Dept_EffecFrom,Dept_EffecTo,Mapped_Department)values('"+ txtEffecFrom.Text +"','"+ txtEffecTo.Text +"','"+ ddlDepartment.SelectedItem.value  +"') ";
        for (int i = 0; i <= cblCourierType.Items.Count - 1; i++)
        {
            if (cblCourierType.Items[i].Selected)
            {
                sql = "Update jct_courier_type_master set Dept_EffecFrom='" + txtEffecFrom.Text + "',Dept_EffecTo='" + txtEffecTo.Text + "',Mapped_Department='" + ddlDepartment.SelectedItem.Text + "' where Status='A' and CourierType='" + cblCourierType.Items[i].Text + "'";
                if (obj1.UpdateRecord(sql))
                {
                    cblCourierType.Items[i].Enabled = false;
                    ShowAlertMsg("Items Mapped Successfully.");
                }
                else
                {
                    ShowAlertMsg("Items not mapped please contact at 4226.");
                }
            }
          

        }
          
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
}