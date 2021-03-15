using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OPS_MailContentPages_outsource_wardrobe_mail : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string approvedby = Request.QueryString["EmpCode"].ToString();

                sql = "Select empname from jct_empmast_base where empcode='" + approvedby + "'";
                lblEmpName.Text = obj1.FetchValue(sql).ToString();

                lblRequestID.Text = Request.QueryString["RequestID"].ToString();

                sql = "SELECT authflag FROM dbo.jct_ops_outsourced_wardrobe WHERE reqid='" + Request.QueryString["RequestID"].ToString() + "'";
                string authflag = obj1.FetchValue(sql).ToString();

                if (authflag == "P" || authflag == "P")
                {
                    sql = "SELECT b.Name FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.MISTEL b ON a.EMPCODE = b.empcode WHERE  b.empcode<>'R-01111' and AUTH_DATETIME IS NULL and  id ='" + ViewState["RequestID"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        lbpending.Text = obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        lbpending.Text = "Request Authorized. Now Purchase Order can be generated for this request.";
                    }
                }
                else if (authflag == "A" || authflag == "a")
                {
                    lbpending.Text = "Request Authorized. Now Purchase Order can be generated for this request.";
                }

                sql = "SELECT reqid AS RequestID,supplier AS Supplier,Sort_No AS SortNo,totqty AS TotalQty,rateper_mts AS RatePerMtr,sale_per_mts AS SalePerMtr,shade AS Shade,remarks AS Remarks,plant AS Plant,purchase_by AS PurchaseBy FROM dbo.jct_ops_outsourced_wardrobe WHERE reqid='" + lblRequestID.Text + "'";
                obj1.FillGrid(sql, ref GridView1);
            }
        }
        catch
        { 
        
        }
    }
}