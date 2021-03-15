
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Text;
using System.Data.OleDb;


public partial class Main : System.Web.UI.MasterPage
{
    Functions objfun = new Functions();
    Connection objcon = new Connection();
    DataTable Menus = new DataTable();
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"].ToString() == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            string sql = string.Empty;
            objfun.RegAppHit("JCT00LTD", Session["Empcode"].ToString(), "PayRollPortal", Request.UserHostAddress);
            // sql = "select a.empname,b.CardNo from jct_login_emp a,dbo.JCT_EmpMast_Base b where a.active = 'Y' and a.empcode ='" + Session["Empcode"].ToString() + "' AND a.empcode=b.empcode";
            sql = "SELECT  a.EmployeeName AS  empname,CardNo FROM    dbo.JCT_payroll_employees_master a WHERE a.active = 'Y' AND a.STATUS = 'A' AND a.NewEmployeeCode ='" + Session["Empcode"].ToString() + "'";
            dr = objfun.FetchReader(sql);
            // dr.Read();
            if (dr.HasRows)
            {
                dr.Read();
                Session["Empname"] = dr[0].ToString();
                lblName.Text = Session["Empname"].ToString();
                empImg.Src = "Emp_Images//" + dr[1].ToString() + ".jpg";
            }
            dr.Close();
            objcon.ConClose();
           // DataTable dt = this.GetData();
            //PopulateMenu(dt);
            this.BindMenu();
        }


    }

    
    private void BindMenu()
    {
        ui_menu_components.DataSource = null;
        ui_menu_components.DataBind();

        Menus = GetData("Exec Jct_Payroll_Portal_Proc1 '" + Session["EmpCode"].ToString() + "',9999");
        DataView view = new DataView(Menus);
        view.RowFilter = "Parent_Menu=''";
        this.ui_menu_components.DataSource = view;
        this.ui_menu_components.DataBind();



     
    }
    private DataTable GetData(string query)
    {
            using (SqlConnection con = new SqlConnection(objcon.Connection().ConnectionString))
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
                con.Close();
            }
       
            objcon.ConClose();
       
       
        
    }


    private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
    {
        if (parentRows.Length > 0)
        {
            string str_href = string.Empty;
            str_href = "#" + parentTitle;
            //sb.Append("<ul id='" + parentTitle + "' class='sub-menu collapse'>");
            sb.Append("<ul class='menu-collapse collapse' id='" + parentTitle + "' >");
            foreach (var item in parentRows)
            {
                string childId = item["Description"].ToString();
                string childTitle = item["Description"].ToString();
                DataRow[] childRow = Menus.Select("Parent_Menu='" + childId + "'");


                if (childRow.Length > 0)
                {
                    //sb.Append("<li data-toggle='collapse' data-target='#" + childTitle + "' class='collapsed'><a href='" + item["page_name"] + "'>" + item["Menu_Desc"] + "<span class='arrow'></span></a>");
                    sb.Append("<li><a class='padding-right-lg waves-attach' href='" + item["page_name"] + "'>" + item["Description"] + "</a>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li><a href='" + item["page_name"] + "'>" + item["Description"].ToString() + "</a>");
                    sb.Append("</li>");
                }
                CreateChild(sb, childId, childTitle, childRow);
            }
            sb.Append("</ul>");

        }
        return sb;
    }

    protected void rptMenu_OnItemBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (Menus != null)
                {
                    DataRowView drv = e.Item.DataItem as DataRowView;
                    string ID = drv["Description"].ToString();
                    string Title = drv["Description"].ToString();
                    DataRow[] rows = Menus.Select("Parent_Menu='" + ID + "'");
                    if (rows.Length > 0)
                    {

                        StringBuilder sb = new StringBuilder();
                        string str_href = string.Empty;
                        str_href = "#" + Title;

                        //sb.Append("<ul id='" + Title + "' class='sub-menu collapse'>");
                       sb.Append("<a class='collapsed waves-attach' data-toggle='collapse' href='" + str_href + "'" + ">" + Title + "</a>");
                       sb.Append("<ul class='menu-collapse collapse' id='" + Title + "' >");
                        foreach (var item in rows)
                        {
                            string parentId = item["Description"].ToString();
                            string parentTitle = item["Description"].ToString();

                            DataRow[] parentRow = Menus.Select("Parent_Menu='" + parentId + "'");

                            if (parentRow.Length > 0)
                            {
                                //sb.Append("<li data-toggle='collapse' data-target='#" + parentTitle + "' class='menu-collapse collapse'><a href='" + item["page_name"] + "'>" + item["Description"] + "<span class='arrow'></span></a>");
                                //sb.Append("</li>");
                                DataRow[] rows1 = Menus.Select("Parent_Menu='" + parentId + "'"); // to check weather this ParentID is parent of any other item i.e parent of 3rd level menu
                                 if (rows1[0].ItemArray.Length > 0 )
                                 {
                                  str_href = "#" + parentId;

                                sb.Append("<li><a class='collapsed waves-attach' data-toggle='collapse' href='" + str_href + "'" + ">" + parentId + "</a>");
                                 }
                                else
                                sb.Append("<li ><a class='padding-right- lg waves-attach' href ='" + item["page_name"] + "'>" + item["Description"] + "</a>");
                                if(parentRow[0].ItemArray[5].ToString() == "" )
                                sb.Append("</li>");
                            }
                            else
                            {
                                // sb.Append("<li><a href='" + item["page_name"] + "'>" + item["Description"] + "</a>");
                                sb.Append("<li><a class='padding-right-lg waves-attach' href='" + item["page_name"] + "'>" + item["Description"] + "</a>");
                                sb.Append("</li>");
                            }
                            sb = CreateChild(sb, parentId, parentTitle, parentRow);
                        }
                        sb.Append("</ul>");
                        (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                    }
                }
            }
        }
    }
}




//using System;
//using System.Data.SqlClient;
//using System.Data;
//using System.Collections.Generic;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.IO;
//using System.Configuration;
//using System.Text;
//using System.Data.OleDb;


//public partial class Main : System.Web.UI.MasterPage
//{
//    Functions objfun = new Functions();
//    Connection objcon = new Connection();
//    DataTable Menus = new DataTable();
//    SqlDataReader dr;

//    protected void Page_Load(object sender, EventArgs e)
//    {
//        if (Session["Empcode"].ToString() == "")
//        {
//            Response.Redirect("~/login.aspx");
//        }
//        if(!IsPostBack)
//        {
//            string sql = string.Empty;
//            sql = "select a.empname,b.CardNo from jct_login_emp a,dbo.JCT_EmpMast_Base b where a.active = 'Y' and a.empcode ='" + Session["Empcode"].ToString() + "' AND a.empcode=b.empcode";
//            dr = objfun.FetchReader(sql);
//            // dr.Read();
//            if (dr.HasRows)
//            {
//                dr.Read();
//                Session["Empname"] = dr[0].ToString();
//                lblName.Text = Session["Empname"].ToString();
//                empImg.Src = "EmpGateway//Emp_Images//" +  dr[1].ToString() + ".jpg";
//            }

//            DataTable dt = this.GetData();
//            PopulateMenu(dt);
//            this.BindMenu();
//        }


//    }

//    private DataTable GetData()
//    {
//        string query = "Exec Jct_Payroll_Portal_Proc1 '9000000537',9999";
//       //' string constr = ConfigurationManager.ConnectionStrings("constr").ConnectionString;
//        using (SqlConnection con = new SqlConnection(objcon.Connection().ConnectionString))
//        {
//            DataTable dt = new DataTable();
//            using (SqlCommand cmd = new SqlCommand(query))
//            {
//                using (SqlDataAdapter sda = new SqlDataAdapter())
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Connection = con;
//                    sda.SelectCommand = cmd;
//                    sda.Fill(dt);
//                }
//            }
//            return dt;
//        }
//    }

//    private void PopulateMenu(DataTable dt)
//    {
//        string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
//        DataView view = new DataView(dt);
//        view.RowFilter = "parent_menu=''";
//        foreach (DataRowView row in view)
//        {
//            MenuItem menuItem = new MenuItem()
//            {
//                Value = row["Title"].ToString(),
//                Text = row["Description"].ToString(),
//                NavigateUrl = row["page_name"].ToString(),
//                Selected = row["page_name"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
//            };
//          // NavigationMenu.Items.Add(menuItem);

//            AddChildItems(dt, menuItem);
//        }
//    }

//    private void AddChildItems(DataTable table, MenuItem menuItem)
//    {
//        DataView viewItem = new DataView(table);
//        viewItem.RowFilter = "parent_menu='" + menuItem.Text + "'";
//        foreach (DataRowView childView in viewItem)
//        {
//            MenuItem childmenuItem = new MenuItem()
//            {
//                Value = childView["Title"].ToString(),
//                Text = childView["Description"].ToString(),
//                NavigateUrl = childView["page_name"].ToString()
//            };
//            menuItem.ChildItems.Add(childmenuItem);
//            AddChildItems(table, childmenuItem);
//        }
//    }


//    private void BindMenu()
//    {
//        Menus = GetData("Exec Jct_Payroll_Portal_Proc1 '9000000537',9999");
//        DataView view = new DataView(Menus);
//        view.RowFilter = "Parent_Menu=''";
//        this.ui_menu_components.DataSource = view;
//        this.ui_menu_components.DataBind();



//        //string query = "Exec Jct_Payroll_Portal_Proc1 '9000000537',9999";

//        //using (SqlConnection con = new SqlConnection(objcon.Connection().ConnectionString))
//        //{
//        //    DataTable dt = new DataTable();
//        //    using (SqlCommand cmd = new SqlCommand(query))
//        //    {
//        //        using (SqlDataAdapter sda = new SqlDataAdapter())
//        //        {
//        //            cmd.CommandType = CommandType.Text;
//        //            cmd.Connection = con;
//        //            sda.SelectCommand = cmd;
//        //            sda.Fill(dt);
//        //        }
//        //    }
//        //    return dt;
//        //}
//    }
//    private DataTable GetData(string query)
//    {
//        //DataTable dt = new DataTable();
//        //OleDbConnection VMScon = new OleDbConnection(objcon.Connection().ConnectionString);
//        //using (OleDbConnection con = new OleDbConnection(objcon.Connection().ConnectionString))
//        //{
//        //    using (OleDbCommand cmd = new OleDbCommand(query))
//        //    {
//        //        using (OleDbDataAdapter sda = new OleDbDataAdapter())
//        //        {
//        //            cmd.CommandType = CommandType.Text;
//        //            cmd.Connection = con;
//        //            sda.SelectCommand = cmd;
//        //            sda.Fill(dt);
//        //        }
//        //    }
//        //    return dt;
//        //}
//        //string query = "Exec Jct_Payroll_Portal_Proc1 '9000000537',9999";
//        //' string constr = ConfigurationManager.ConnectionStrings("constr").ConnectionString;
//        using (SqlConnection con = new SqlConnection(objcon.Connection().ConnectionString))
//        {
//            DataTable dt = new DataTable();
//            using (SqlCommand cmd = new SqlCommand(query))
//            {
//                using (SqlDataAdapter sda = new SqlDataAdapter())
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Connection = con;
//                    sda.SelectCommand = cmd;
//                    sda.Fill(dt);
//                }
//            }
//            return dt;
//        }
//    }


//    private StringBuilder CreateChild(StringBuilder sb, string parentId, string parentTitle, DataRow[] parentRows)
//    {
//        if (parentRows.Length > 0)
//        {
//            string str_href = string.Empty;
//            str_href = "#" + parentTitle;
//             //sb.Append("<a class='collapsed waves-attach' data-toggle='collapse' href='" + str_href + "'" + ">" + parentTitle + "</a>");
//             sb.Append("<ul class='menu-collapse collapse' id='" + parentTitle + "' >");
//            foreach (var item in parentRows)
//            {
//                string childId = item["Description"].ToString();
//                string childTitle = item["Description"].ToString();
//                DataRow[] childRow = Menus.Select("Parent_Menu='" + childId + "'");


//                if (childRow.Length > 0)
//                {
//                    //sb.Append("<li  data-target='#" + childTitle + "' ><a href='" + item["page_name"] + "'>" + item["Menu_Desc"] + "</a>");
//                    sb.Append("<li><a class='padding-right-lg waves-attach' href='" + item["page_name"] + "'>" + item["Description"] + "</a>");
//                    DataRow[] rows1 = Menus.Select("Parent_Menu='" + parentId + "'"); // to check weather this ParentID is parent of any other item i.e parent of 3rd level menu
//                    if (rows1[0].ItemArray.Length > 0)
//                    {
//                        str_href = string.Empty;
//                    }
//                    else
//                        sb.Append("</li>");
//                }
//                else
//                {
//                    sb.Append("<li><a class='padding-right-lg waves-attach' href='" + item["page_name"] + "'>" + item["Description"].ToString()  + "</a>");
//                    sb.Append("</li>");
//                }
//                CreateChild(sb, childId, childTitle, childRow);
//            }
//            sb.Append("</ul>");

//        }
//        return sb;
//    }

//    protected void rptMenu_OnItemBound(object sender, RepeaterItemEventArgs e)
//    {
//        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
//        {
//            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
//            {
//                if (Menus != null)
//                {
//                    DataRowView drv = e.Item.DataItem as DataRowView;
//                    string ID = drv["Description"].ToString();
//                    string Title = drv["Description"].ToString();
//                    //DataRow[] rows = Menus.Select("Parent_Menu=" + ID);
//                    DataRow[] rows = Menus.Select("Parent_Menu='" + ID + "'");
//                    if (rows.Length > 0)
//                    {

//                        StringBuilder sb = new StringBuilder();
//                        string str_href = string.Empty;

//                        str_href = "#" + Title;

//                        sb.Append("<a class='collapsed waves-attach' data-toggle='collapse' href='" + str_href + "'" + ">" + Title + "</a>");
//                        sb.Append("<ul id='" + Title + "' class='menu-collapse collapse'>");
//                        foreach (var item in rows)
//                        {
//                            string parentId = item["Description"].ToString();
//                            string parentTitle = item["Description"].ToString();

//                            DataRow[] parentRow = Menus.Select("Parent_Menu='" + parentId + "'");

//                            if (parentRow.Length > 0)
//                            {
//                                DataRow[] rows1 = Menus.Select("Parent_Menu='" + parentId + "'"); // to check weather this ParentID is parent of any other item i.e parent of 3rd level menu
//                                if (rows1[0].ItemArray.Length > 0 )
//                                {
//                                    str_href = "#" + parentId;

//                                    sb.Append("<li><a class='collapsed waves-attach' data-toggle='collapse' href='" + str_href + "'" + ">" + parentId + "</a>");
//                                }
//                                else
//                                sb.Append("<li ><a class='padding-right- lg waves-attach' href ='" + item["page_name"] + "'>" + item["Description"] + "</a>");
//                                if(parentRow[0].ItemArray[5].ToString() == "" )
//                                sb.Append("</li>");
//                            }
//                            else
//                            {
//                                string liclass = string.Empty;
//                                liclass = "padding-right-lg waves-attach";
//                                sb.Append("<li><a class='padding-right-lg waves-attach' href='" + item["page_name"] + "'>" + item["Description"] + "</a>");
//                                sb.Append("</li>");
//                            }
//                            sb = CreateChild(sb, parentId, parentTitle, parentRow);
//                            sb.Append("</li>");
//                        }
//                        sb.Append("</ul>");
//                        (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
//                    }
//                }
//            }
//        }
//    }
//}
