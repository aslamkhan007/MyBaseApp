using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_MailContentPages_outsource_vendor_comparison : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    bool color = false;
 
    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string approvedby = Request.QueryString["EmpCode"].ToString();

                sql = "Select empname from jct_empmast_base where empcode='" + approvedby + "'";
                lblEmpName.Text = obj1.FetchValue(sql).ToString();

                lblRequestID.Text = Request.QueryString["RequestID"].ToString();
                ViewState["RequestID"] = lblRequestID.Text;
                 
                sql = "jct_ops_check_outsource_areaname";
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 20).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@area", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                string AreaName = cmd.Parameters["@area"].Value.ToString();
                ViewState["AreaName"] = AreaName;

                if (AreaName == "Outsource Yarn")
                {
                    sql = "SELECT vendername FROM dbo.jct_ops_yarn_mat_tb WHERE RequestID='" + Request.QueryString["RequestID"] + "' AND approved='Y'";
                    lblVendorName.Text = obj1.FetchValue(sql).ToString();

                    sql = "SELECT b.Name FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.MISTEL b ON a.EMPCODE = b.empcode WHERE AUTH_DATETIME IS NULL and a.empcode <>'R-01111' and  id ='" + ViewState["RequestID"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        lblPendingAt.Text = obj1.FetchValue(sql).ToString();

                        lblPendingAt.Text = "Request Authorized. Now Purchase order can be generated.";// obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        lblPendingAt.Text = "Request Authorized. Now Purchase Order can be generated for this request.";
                    }

                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = lblRequestID.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    conjctgen.Close();
                }
                else if (AreaName == "Outsource Fabric")
                {
                    sql = "SELECT DISTINCT vendor FROM dbo.jct_ops_out_fab_vendor WHERE RequestID='" + Request.QueryString["RequestID"] + "' AND approved='Y'";
                    lblVendorName.Text = obj1.FetchValue(sql).ToString();

                    sql = "SELECT b.Name FROM dbo.JCT_OPS_SanctionNote_AUTHORIZATION_LISTING a INNER JOIN dbo.MISTEL b ON a.EMPCODE = b.empcode WHERE AUTH_DATETIME IS NULL and a.empcode <>'R-01111' and  id ='" + ViewState["RequestID"] + "'";
                    if (obj1.CheckRecordExistInTransaction(sql))
                    {
                        lblPendingAt.Text = obj1.FetchValue(sql).ToString();
                    }
                    else
                    {
                        lblPendingAt.Text = "Request Authorized. Now Purchase Order can be generated for this request.";
                    }

                    cmd = new SqlCommand("JCT_OPS_VENDOR_SPECS_COMPARISON_FAB", conjctgen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conjctgen.Open();
                    cmd.Parameters.Add("@requestid", SqlDbType.VarChar, 10).Value = lblRequestID.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    conjctgen.Close();
                }





            }
            catch { return; }
            
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string sql = string.Empty;

        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                try
                {
                    if (ViewState["AreaName"] == "Outsource Yarn")
                    {
                        for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                        {
                            sql = "SELECT * FROM dbo.jct_ops_yarn_mat_tb where RequestID='" + ViewState["RequestID"] + "'";
                            if (obj1.CheckRecordExistInTransaction(sql))
                            {
                                sql = "SELECT * FROM dbo.jct_ops_yarn_mat_tb  WHERE vendername='" + e.Row.Cells[i + 2].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                                if (obj1.CheckRecordExistInTransaction(sql))
                                {
                                    color = true;
                                    ViewState["CellNumber"] = i + 2;
                                    ViewState["VendorName"] = e.Row.Cells[i + 2].Text;
                                    //e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                                }
                            }
                            else
                            {
                                sql = "SELECT * FROM dbo.jct_ops_out_fab_vendor WHERE vendor='" + e.Row.Cells[i + 2].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        color = true;
                                        ViewState["CellNumber"] = i + 2;
                                        ViewState["VendorName"] = e.Row.Cells[i + 2].Text;
                                        //e.Row.Cells[i + 2].ForeColor = System.Drawing.Color.Green;
                                    }
                                }
                                else
                                {
                                    color = false;
                                }
                                dr.Close();
                            }
                        }
                    }
                    else if (ViewState["AreaName"] == "Outsource Fabric")
                    {
                        for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                        {
                            sql = "SELECT * FROM dbo.jct_ops_out_fab_vendor where RequestID='" + ViewState["RequestID"] + "'";
                            if (obj1.CheckRecordExistInTransaction(sql))
                            {
                                sql = "SELECT * FROM dbo.jct_ops_out_fab_vendor  WHERE vendername='" + e.Row.Cells[i + 2].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                                if (obj1.CheckRecordExistInTransaction(sql))
                                {
                                    color = true;
                                    ViewState["CellNumber"] = i + 2;
                                    ViewState["VendorName"] = e.Row.Cells[i + 2].Text;
                                    //e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                                }
                            }
                            else
                            {
                                sql = "SELECT * FROM dbo.jct_ops_out_fab_vendor WHERE vendor='" + e.Row.Cells[i + 2].Text + "' AND approved='Y' AND RequestID='" + ViewState["RequestID"] + "' ";
                                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        color = true;
                                        ViewState["CellNumber"] = i + 2;
                                        ViewState["VendorName"] = e.Row.Cells[i + 2].Text;
                                        //e.Row.Cells[i + 2].ForeColor = System.Drawing.Color.Green;
                                    }
                                }
                                else
                                {
                                    color = false;
                                }
                                dr.Close();
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    //string script = "alert('Error : '"+ ex.Message +"' ');";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }


            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (color == true)
                {
                    e.Row.Cells[Convert.ToInt32(ViewState["CellNumber"])].ForeColor = System.Drawing.Color.Green;
                }

            }
        }
        catch
        {
            return;
        }
        

      
    }
}