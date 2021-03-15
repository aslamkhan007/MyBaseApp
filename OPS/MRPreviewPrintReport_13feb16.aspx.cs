using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class OPS_MRPreviewPrintReport : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;
    string ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }

        ID = Request.QueryString["ID"];
        if (Request.QueryString["ID"] != null)
        {
            lblCurrentDate.Text = System.DateTime.Now.ToString();
            lblPrintedBy.Text = Session["empcode"].ToString();

            sql = "JCT_OPS_MR_Report";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@RequestID", SqlDbType.VarChar, 20).Value = Request.QueryString["ID"];
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //if (dr["GrDate"].ToString() == "01/01/1900")
                    //{

                    //}
                    lblSerialNo.Text = dr["MrNo"].ToString();
                    lblCustomer.Text = dr["Customer"].ToString();


                    lblDate.Text = dr["Date"].ToString();




                    lblRequestID.Text = dr["SrNo"].ToString();
                    //lblCurrentDate.Text = dr["AuthDate"].ToString();
                    lblRaisedByEmpName.Text = dr["RaisedBy"].ToString();


                    lblStatus.Text = dr["Status"].ToString();
                }
            }
            dr.Close();


            sql = "JCT_OPS_MR_Preview_Report";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            grdReturnDetail.DataSource = ds;
            grdReturnDetail.DataBind();


            sql = "JCT_OPS_MR_Invoices_Report";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = ID;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            grdReturnInvoice.DataSource = ds;
            grdReturnInvoice.DataBind();




            DataTable dt = new DataTable();
            // sql = "SELECT a.USERLEVEL, Upper(b.empname) as AuthorizedBy,Case when STATUS is null Then 'Authorized' Else 'Cancelled' End As Status,CONVERT(VARCHAR,AUTH_DATETIME,103) AS [Authorized Date],Remarks FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.JCT_EmpMast_Base b ON a.EMPCODE=b.empcode WHERE ID='" + ID + "'  order by UserLevel Asc ";
            sql = @"SELECT  a.USERLEVEL ,
                             UPPER(b.empname) AS AuthorizedBy ,
                             CASE WHEN AUTH_DATETIME IS NULL AND CANCEL_DATETIME IS NULL  THEN 'Pending'
                             WHEN AUTH_DATETIME IS NOT NULL THEN 'Authorized'
                             WHEN CANCEL_DATETIME IS NOT NULL  AND AUTH_DATETIME IS NULL THEN 'Cancelled' 
                             END AS Status ,
                             CONVERT(VARCHAR, AUTH_DATETIME, 103) AS [Authorized Date] ,
                             Remarks
                            FROM    dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a
                             JOIN JCT_EmpMast_Base b ON a.EMPCODE = b.empcode
                            WHERE  ID='" + ID + "' ORDER BY UserLevel ASC ";

            obj1.FillGrid(sql, ref grdHistory);
            grdHistory.Visible = true;
            if (grdHistory.Rows.Count == 0)
            {
                grdHistory.Rows[0].Cells.Clear();
                grdHistory.Rows[0].Cells.Add(new TableCell());
                // grdHistory.Rows[0].Cells[0].ColumnSpan = columncount;
                //grdPPCandLogAuth.Rows[0].Cells[0].Text = "Authorization Pending";
                //grdPPCandLogAuth.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            }

            sql = "JCT_OPS_MR_PPC_Status_Report";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = ID;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                grdPPCandLogAuth.DataSource = ds;
                grdPPCandLogAuth.DataBind();
                int columncount = grdPPCandLogAuth.Rows[0].Cells.Count;
                grdPPCandLogAuth.Rows[0].Cells.Clear();
                grdPPCandLogAuth.Rows[0].Cells.Add(new TableCell());
                grdPPCandLogAuth.Rows[0].Cells[0].ColumnSpan = columncount;
                grdPPCandLogAuth.Rows[0].Cells[0].Text = "Pending At PPC End";
                grdPPCandLogAuth.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;

                if (lblSerialNo.Text != "")
                {
                    grdPPCandLogAuth.Rows[0].Cells[0].Text = "OLD Case - Authorized By Logistic Department";
                    grdPPCandLogAuth.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Black;
                }

            }
            else
            {
                grdPPCandLogAuth.DataSource = ds;
                grdPPCandLogAuth.DataBind();
                grdPPCandLogAuth.Visible = true;
                if (grdPPCandLogAuth.Rows[0].Cells[1].Text == "Requested For Order")
                {
                    grdPPCandLogAuth.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
                }
                if (grdPPCandLogAuth.Rows[0].Cells[2].Text == "Pending")
                {
                    grdPPCandLogAuth.Rows[0].Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (grdPPCandLogAuth.Rows[0].Cells[0].Text == "Pending")
                {
                    grdPPCandLogAuth.Rows[0].Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }

            sql = "Jct_Ops_Mr_Folding_Observation_Report";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = ID;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                grdFoldingObservation.DataSource = ds;
                grdFoldingObservation.DataBind();
                int columncount = grdFoldingObservation.Rows[0].Cells.Count;
                grdFoldingObservation.Rows[0].Cells.Clear();
                grdFoldingObservation.Rows[0].Cells.Add(new TableCell());
                grdFoldingObservation.Rows[0].Cells[0].ColumnSpan = columncount;

                grdFoldingObservation.Rows[0].Cells[0].Text = "No Records Found";
                grdFoldingObservation.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;

                if (grdPPCandLogAuth.Rows[0].Cells[0].Text == "OLD Case - Authorized By Logistic Department")
                {
                    grdFoldingObservation.Rows[0].Cells[0].Text = "Pending At Folding End";
                    grdFoldingObservation.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                grdFoldingObservation.DataSource = ds;
                grdFoldingObservation.DataBind();
                grdFoldingObservation.Visible = true;
            }
            sql = "JCT_OPS_MR_SaleOrder";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SanctionNoteID", SqlDbType.VarChar, 20).Value = ID;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                grdOrderDetail.DataSource = ds;
                grdOrderDetail.DataBind();
                int columncount = grdOrderDetail.Rows[0].Cells.Count;
                grdOrderDetail.Rows[0].Cells.Clear();
                grdOrderDetail.Rows[0].Cells.Add(new TableCell());
                grdOrderDetail.Rows[0].Cells[0].ColumnSpan = columncount;

                grdOrderDetail.Rows[0].Cells[0].Text = "No Records Found";
                grdOrderDetail.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                grdOrderDetail.DataSource = ds;
                grdOrderDetail.DataBind();
                grdOrderDetail.Visible = true;
            }
        }
    }
    protected void grdReturnDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            //e.Row.Cells[0].Width = new Unit("200px");


            //e.Row.Cells[1].Width = new Unit("100px");
            //e.Row.Cells[2].Width = new Unit("50px");

            //e.Row.Cells[3].Width = new Unit("100px");
            //e.Row.Cells[4].Width = new Unit("200px");

            //e.Row.Cells[5].Width = new Unit("100px");

        }
    }
}