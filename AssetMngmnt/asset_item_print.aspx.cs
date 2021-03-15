using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_item_print : System.Web.UI.Page
{
    /*
    
Preparing Data for Encoding
When I called the Json method from within the GetPeopleDataJson action method, I left the MVC Framework to
figure out how to encode People objects in the JSON format. The MVC Framework doesn’t have any special insights
into the model types in an application, and so it makes a best-effort guess about what it needs to do. Here is how the
MVC Framework expresses a single Person object in JSON:
...
{"PersonId":0,"FirstName":"Adam","LastName":"Freeman",
"BirthDate":"\/Date(62135596800000)\/","HomeAddress":null,"IsApproved":false,"Role":0}
...
It looks like a bit of a mess, but the result is actually pretty clever—it just isn’t quite what I need. First, all the
properties defined by the Person class are represented in the JSON, even though I did not assign values to some
of them in the People controller. In some cases, the default value for the type has been used (false is used for
IsApproved, for example), and in others null has been used (such as for HomeAddress). Some values are converted
into a form that can be readily interpreted by JavaScript, such as the BirthDate property, but others are not handled
as well, such as using 0 for the Role property rather than Admin.
VIEWING JSON DATA
It can be useful to see what JSON data your action methods return and the easiest way to do this is to enter a
URL that targets the action in the browser, like this:
http://localhost:13949/People/GetPeopleDataJson?selectedRole=Guest
You can do this in pretty much any browser, but most will force you to save and open a text file before you can
see the JSON content. I like to use the Google Chrome browser for this because it helpfully displays the JSON
data in the main browser window, which makes the process quicker and means you don’t end up with dozens
of open text file windows. I also recommend Fiddler (www.fiddler2.com), which is an excellent Web debugging
proxy that allows you to dig right into the details of the data sent between the browser and the server.
The MVC Framework has made a good attempt, but I end up sending properties to the browser that I don’t
subsequently use and the Role value isn’t expressed in a useful way. This is a typical situation when relying on
the default JSON encoding, and some preparation of the data you want to send the client is usually required.
In Listing 23-19, you can see how I have revised the GetPeopleDataJson action method in the People controller
to prepare the data I pass to the Json method.
Listing 23-19. Preparing Data Objects for JSON Encoding in the PeopleController.cs File
...
public JsonResult GetPeopleDataJson(string selectedRole = "All") {
var data = GetData(selectedRole).Select(p => new {
FirstName = p.FirstName,
LastName = p.LastName,
Role = Enum.GetName(typeof(Role), p.Role)
});
return Json(data, JsonRequestBehavior.AllowGet);
}
...
 
 
     */
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string requestID;
    string jctsr_no;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            requestID = Request.QueryString["requestid"].ToString();
            string sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" + requestID + "' AND status='A'");
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.Text;
               SqlDataReader dr = cmd.ExecuteReader();
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       jctsr_no = dr[0].ToString();
                       lblsrno.Text = dr[0].ToString();
                   }
               }
               dr.Close();
          
            BindDataList();
            // SELECT  DISTINCT c.item_name  FROM jct_asset_item_details  a  JOIN  jct_asset_type_item_detail b ON a.item_id=b.request_id  JOIN jct_asset_master c ON b.asset_id=c.asset_id  WHERE a.jctSR_NO='385'AND a.status='a'
            
            //string transid = Request.QueryString["transid"].ToString();
            //string requestid = Request.QueryString["requestid"].ToString();
          
                sql = "jct_asset_item_detail_print";
                cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = requestID;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        lblcomptype.Text = dr["computer_type"].ToString();
                        lblCurrentDate.Text = dr["Dated"].ToString();
                        lblissuedto.Text = dr["IssueTo"].ToString();
                        lbldept.Text = dr["Department"].ToString();
                        lblmodelno.Text = dr["ModelNo"].ToString();
                        //lblsrno.Text = dr["jctSR_NO"].ToString();

                    }

                }
                else
                {
                    string script = "alert(Noooooooooooooooo data available!!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                                 
                }

                dr.Close();
             
          
            sql = "jct_asset_item_detail_print2";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = requestID;

          
             dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    lblitemname.Text = dr["item_name"].ToString();
                    //lblDop.Text = dr["DOP"].ToString();
                    //lblipaddress.Text = dr["IP_address"].ToString();

                }
            
            }
            dr.Close();


        }
    }
    public void BindDataList()
    {
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT c.item_name,c.asset_id   FROM jct_asset_item_details  a  JOIN  jct_asset_type_item_detail b ON a.item_id=b.request_id  JOIN jct_asset_master c ON b.asset_id=c.asset_id  WHERE a.jctSR_NO= '" + jctsr_no + "' AND a.status='a' ", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
       
       
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gv = (GridView)e.Item.FindControl("GridView1");
            Label lbh = (Label)e.Item.FindControl("Labelhead");
         
            int asset_id =(int) DataList1.DataKeys[e.Item.ItemIndex];
            if (gv != null)
            {

                string qry = "  SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '" + jctsr_no + "' AND c.asset_id='" + asset_id + "'";
                SqlCommand cmd = new SqlCommand(qry, obj.Connection());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds.Tables[0];
                gv.DataBind();
                
            }
       
         
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            e.Row.Cells[0].Width = new Unit("200px");
            e.Row.Cells[1].Width = new Unit("400px");
         
               
           
        }
    }
}