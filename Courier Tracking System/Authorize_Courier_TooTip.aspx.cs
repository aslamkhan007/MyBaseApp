using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

public partial class Courier_Tracking_System_Authorize_Courier_TooTip : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //string ReferenceID = Request.QueryString["ReferenceID"];
        //SqlCommand cmd1 = new SqlCommand("select * from jct_courier_Request where  Serial_No='" + ReferenceID + "'", obj.Connection());
        //obj.ConOpen();
        //SqlDataReader dr = cmd1.ExecuteReader();
        //Response.Write(" <fieldset style=' width:400px;height:auto;border-color=white;'>");
        //Response.Write("<table border= '0' width='auto';height='auto'; >");

        //Response.Write("<tbody>");
        //while (dr.Read())
        //{
        //    // Response.Write("<tr><td VALIGN='top'>  <img  width='100px' src='./PlayerImages/" + dr["PictureUrl"].ToString() + " '></td>");
        //    //Response.Write("<td  VALIGN='top'><table><tr><td >  ID         :  " + dr["pid"].ToString() + "</td></tr> ");
        //    Response.Write("<tr><td > Subject : " + dr["Subject"].ToString() + "</td></tr> ");

        //    //Response.Write("<td>  <img  width='100px' src='./ProductImages/" + dr["PictureURL"].ToString() + " '</td>");
        //    Response.Write("<tr><td>PartyName:  " + dr["Party_Name"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>Address:  " + dr["Address1"].ToString() + ", " + dr["Address2"].ToString() + ", " + dr["Address3"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>City:  " + dr["City"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>State:  " + dr["State"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>ZipCode:  " + dr["ZipCode"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>Country:  " + dr["Country"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>AttachedFile:  " + dr["Attached_File"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>Request Date:  " + dr["Request_Date"].ToString() + "</td> </tr>");
        //    Response.Write("<tr><td>Request By:  " + dr["Request_By"].ToString() + "</td> </tr>");
        //    Response.Write("</table>");
        //    Response.Write("</td>");
        //    Response.Write("</tr>");

        //}
        //obj.ConClose();
        //Response.Write("</tbody>");
        //Response.Write("</table>");
        //Response.Write("</fieldset>");


      string ReferenceID = Request.QueryString["ReferenceID"];
     //   string ReferenceID = Request.Form["ID"];
      SqlCommand cmd1 = new SqlCommand("select *,Address1 + ', ' + Address2 + ', ' + Address3 + ',' + city +', '+ State +', ' + Country +', '  + zipcode AS [Address]  from jct_courier_Request where  Serial_No='" + ReferenceID + "'", obj.Connection());
        obj.ConOpen();
        //SqlDataReader dr = cmd1.ExecuteReader();
        SqlDataAdapter sqlAd= new SqlDataAdapter(cmd1);
        DataTable dt= new DataTable();
        sqlAd.Fill(dt);

        if(dt.Rows.Count >0)
        {
            DetailsView1.DataSource= dt;
            DetailsView1.DataBind();
        }
   //  Response.End();
      
    }
   
   
}