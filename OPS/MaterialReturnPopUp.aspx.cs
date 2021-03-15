using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MaterialReturnPopUp : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RequestID"] != "")
        {
            string requestID = Request.QueryString["RequestID"];
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine(" table.gridtable {font-family: verdana,arial,sans-serif;font-size:11px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;}");
            sb.AppendLine(" table.gridtable th {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #dedede;}");
            sb.AppendLine("table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;background-color: #ffffff;}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("Details of Material Return - "+ requestID +"<br/><br/>");
 
            sb.AppendLine("Details are Shown below : <br/><br/>");
            sb.AppendLine("<table class=gridtable>");
            sb.AppendLine("<tr><th> Invoice No</th> <th> Sort</th> <th> Customer</th> <th> Sale Person</th> <th> Invoice Qty</th> <th> Return Qty</th>  <th> Status </th> </tr>");

            sql = "SELECT invoice_no AS InvoiceNo,item_no AS SortNo,customer AS Customer,b.empname AS SalePerson,CONVERT(NUMERIC(12,2),invoice_qty) AS InvoiceQty,ret_qty AS ReturnQty,CASE WHEN AuthStatus ='A' THEN 'Authorized' WHEN AuthStatus='P' THEN 'Pending' WHEN AuthStatus='C' THEN 'Cancelled' END AS Status FROM dbo.jct_ops_material_request  a INNER JOIN dbo.JCT_EmpMast_Base b ON a.sales_person=REPLACE(b.empcode,'-','') WHERE RequestID=@RequestID ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
            SqlDataReader Dr = cmd.ExecuteReader();
            if ((Dr.HasRows))
            {

                while ((Dr.Read()))
                {
                    ViewState["Customer"] = Dr[2].ToString();

                    sb.AppendLine("<tr> <td> " + Dr[0].ToString() + " </td> <td> " + Dr[1].ToString() + "  </td>  <td> " + Dr[2].ToString() + "</td>  <td>" + Dr[3].ToString() + " </td>  <td>" + Dr[4].ToString() + " </td>  <td>" + Dr[5].ToString() + "</td>  <td>Authorized</td> </tr> ");
                }

            }
            Dr.Close();
            obj.ConClose();
            sb.AppendLine("</table>");


            sb.AppendLine("<br /><br/>");
            sql = "SELECT distinct DESCRIPTION,reason FROM dbo.jct_ops_material_request  WHERE RequestID=" + requestID;
            cmd = new SqlCommand( sql, obj.Connection());
            Dr = cmd.ExecuteReader();

            if ((Dr.HasRows))
            {

                while ((Dr.Read()))
                {
                    sb.AppendLine("Detailed Description (Entered by Marketing Executive) : " + Dr[0].ToString().ToUpper());
                    sb.AppendLine("<br /><br />");
                    sb.AppendLine("Reason : " + Dr[1].ToString().ToUpper());
                    sb.AppendLine("<br /><br />");

                }

            }
            Dr.Close();
            obj.ConClose();

            sb.AppendLine("Authorisation History : ");
            sb.AppendLine("<table class=gridtable>");
            sb.AppendLine("<tr><th> UserLevel</th> <th> Authorised By</th> <th> Remarks</th> <th>Authorisation Date </th> </tr>");

            sql = "  SELECT USERLEVEL,b.empname AS AuthorisedBy,Remarks,AUTH_DATETIME AS  AuthorisationDate FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING  a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID IN ('" + requestID + "') order by userlevel asc";
            cmd = new SqlCommand(sql, obj.Connection());
            Dr = cmd.ExecuteReader();

            if ((Dr.HasRows))
            {

                while ((Dr.Read()))
                {
                    sb.AppendLine("<tr><td> " + Dr[0].ToString() + "</td> <td>" + Dr[1].ToString() + "</td> <td>" + Dr[2].ToString() + "</td> <td> " + Dr[3].ToString() + "</td> </tr>");

                }

            }
            Dr.Close();
            obj.ConClose();

            sb.AppendLine("</table><br />");
 
            sb.AppendLine("</html>");

            lblContent.Text = sb.ToString();
        }
    }
    protected void radImport_Click(object sender, EventArgs e)
    {
        sql = "SELECT AuthStatus FROM dbo.jct_ops_material_request WHERE RequestID=" + Request.QueryString["RequestID"];
        string status = obj1.FetchValue(sql).ToString();
        if (status == "C" || status=="P")
        {
            Response.Redirect("materialrequest.aspx?RequestID=" + Request.QueryString["RequestID"]);
        }
        else if (status == "A")
        { 
               string script = "alert('The Sanction Note has been authorized..!! This action is applicable only for Cancelled/Pending Sanction Notes..!! Thanks.');";
               ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);            
        }


        
       // sql = "JCT_OPS_MATERIAL_REQUEST_GENERATE_REQUESTID";
       //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
       //cmd.CommandType = CommandType.StoredProcedure;
       //SqlDataReader dr = cmd.ExecuteReader();

       // if ((dr.HasRows))
       // {

       //     while ((dr.Read()))
       //     {
       //        ViewState["RequestID"] = Convert.ToInt16(dr[0].ToString());
                
       //     }

       // }
       // dr.Close();

       // sql = "SELECT Freight_by,reason,ret_qty,bales,invoice_qty,item_no,invoice_no AS InvoiceNo,invoice_date,customer,sales_person,Instructions,Enclouser,FlagAuth,sales_person,Plant,DESCRIPTION FROM dbo.jct_ops_material_request WHERE RequestID=@RequestID ";
       // cmd = new SqlCommand(sql, obj.Connection());
       // dr = cmd.ExecuteReader();

       // if ((dr.HasRows))
       // {

       //     while ((dr.Read()))
       //     {

       //         sql = "JCT_OPS_MATERIAL_RETURN_REQUEST_GENERATE";
       //         cmd = new SqlCommand(sql, obj.Connection());
       //         cmd.CommandType = CommandType.StoredProcedure;

       //         cmd.Parameters.Add("@Freight", SqlDbType.VarChar, 20).Value = dr["Freight_by"].ToString();
       //         cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = dr["reason"].ToString();
       //         cmd.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = dr["ret_qty"].ToString();
       //         cmd.Parameters.Add("@Bales", SqlDbType.Decimal).Value = Convert.ToDecimal(bales.Text);
       //         cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(qty);
       //         cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 200).Value = item_no;
       //         cmd.Parameters.Add("@Invoice_no", SqlDbType.VarChar, 30).Value = invoice_no;
       //         cmd.Parameters.Add("@Inv_date", SqlDbType.VarChar, 20).Value = inv_date;
       //         cmd.Parameters.Add("@Cust_name", SqlDbType.VarChar, 100).Value = cust_name;
       //         cmd.Parameters.Add("@SalePerson", SqlDbType.VarChar, 100).Value = ddlSalesPerson.SelectedItem.Value;
       //         cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = Session("EmpCode");
       //         cmd.Parameters.Add("@Instruction", SqlDbType.VarChar, 200).Value = txtinstructions.Text;
       //         cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestId;
       //         cmd.Parameters.Add("@Enclosures", SqlDbType.VarChar, 100).Value = List;
       //         cmd.Parameters.Add("@FlagAuth", SqlDbType.VarChar, 20).Value = FlagAuth;
       //         cmd.Parameters.Add("@AuthStatus", SqlDbType.VarChar, 2).Value = "P";
       //         cmd.Parameters.Add("@salespersonCode", SqlDbType.VarChar, 200).Value = (string.IsNullOrEmpty(saleperson) ? ddlSalesPerson.SelectedItem.Text : saleperson);
       //         cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = (string.IsNullOrEmpty(ddlPlant.SelectedItem.Text) ? "No Plant Selected" : ddlPlant.SelectedItem.Text);
       //         cmd.Parameters.Add("@Description", SqlDbType.VarChar, 4000).Value = txtDescription.Text;
       //         cmd.ExecuteNonQuery();
       //     }

       // }
       // dr.Close();
       // obj.ConClose();
        
    }
}