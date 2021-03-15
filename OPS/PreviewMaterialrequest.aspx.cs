using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_PreviewMaterialrequest : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    String Enclosures;
    Decimal TotalInvoiceqty=0, TotalReturnQty=0, TotalBales=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            sql = "JCT_OPS_MATERIAL_REQUEST_PREVIEW_DATA";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["ID"];
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblSerialNo.Text = dr["MrNo"].ToString();
                    lblCustomer.Text = dr["Customer"].ToString();
                    lblGrNo.Text = ( dr["GrNo"].ToString()== "" ? "N/A" : dr["GrNo"].ToString()) ;
                    lblFreightBy.Text = dr["FreightBy"].ToString();
                    lblDate.Text = dr["Date"].ToString();
                    lblGrDate.Text = (dr["GrDate"].ToString()=="" ? "N/A" : dr["GrDate"].ToString());
                    lblTransport.Text = dr["Transport"].ToString();
                    Enclosures = dr["Enclouser"].ToString();
                    lblInstructions.Text = dr["Instructions"].ToString();
                    lblApproval.Text = dr["AuthBy"].ToString();//"U-04002";//
                    lblFreightValue.Text = dr["FreightValue"].ToString();
                    lblLocation.Text = dr["Location"].ToString();
                    lblRequestID.Text = dr["SrNo"].ToString();
                    lblCurrentDate.Text = dr["AuthDate"].ToString();
                    lblRaisedByEmpName.Text = dr["RaisedBy"].ToString();
                    lblEnclosures.Text = dr["Enclouser"].ToString();
                    lblPrintedOn.Text = DateTime.Now.ToString();
                    lblStatus.Text = dr["Status"].ToString();
                }
            }
            dr.Close();

            sql = "SELECT a.USERLEVEL, Upper(b.empname) as AuthorizedBy,Case when STATUS is null Then 'Authorized' Else 'Cancelled' End As Status,CONVERT(VARCHAR,AUTH_DATETIME,103) AS [Authorized Date],Remarks FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID='" + Request.QueryString["ID"] + "' and Auth_DateTime is not null order by UserLevel Asc ";
            obj1.FillGrid(sql, ref GridView2);
            //GridView2.DataSourceID = "SqlDataSource2";
            //GridView2.DataBind();
            sql = "Select UPPER(empname) from jct_empmast_base where empcode='"+ lblApproval.Text +"'";
            //sql = "Select UPPER(empname) from jct_empmast_base where empcode='U-04002'";
            lblApproval.Text = obj1.FetchValue(sql).ToString();
            //if (Enclosures.ToString() != "")
            //{
            //    List<String> EnlcosuresList = new List<String>(Enclosures.Split(','));
            //    chbEnclosures.DataSource = EnlcosuresList;
            //    chbEnclosures.DataBind();
            //}
          
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TotalInvoiceqty =TotalInvoiceqty + Convert.ToDecimal(e.Row.Cells[3].Text);
            TotalReturnQty = TotalReturnQty + Convert.ToDecimal(e.Row.Cells[4].Text);
            TotalBales = TotalBales + Convert.ToDecimal(e.Row.Cells[5].Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Total";
            e.Row.Cells[3].Text = TotalInvoiceqty.ToString();
            e.Row.Cells[4].Text = TotalReturnQty.ToString();
            e.Row.Cells[5].Text = TotalBales.ToString();
        }
    }
}