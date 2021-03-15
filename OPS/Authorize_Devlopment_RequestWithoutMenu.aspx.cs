using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class OPS_Authorize_Devlopment_RequestWithoutMenu : System.Web.UI.Page
{

    private const string ViewsFolder = "~/OPS/UsrCtrl/";
    private string DefaultContentControl = "RequestDetail.ascx";
    //private const string DefaultContentControl = "RequestDetail.ascx";
    //private string DefaultContentControl = "";

    private string LoadedControlName
    {
        get
        {
            return (string)ViewState["LoadedControlName"] ?? DefaultContentControl;
        }

        set
        {
            ViewState["LoadedControlName"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    var control = LoadControl(ViewsFolder + LoadedControlName);
        //    control.ID = "contentControl";

        //    Content.Controls.Clear();
        //    Content.Controls.Add(control);
        //}
        
    }
    protected void radAuthorizeRequest_Click(object sender, EventArgs e)
    {
        //RadPanelItem item = RadPanelBar0.Items[0];
        //CheckBox CheckItem = item.Header.FindControl("checkBox1") as CheckBox;
        //CheckItem.Checked = false;

        HiddenField1.Value = radAuthorizeRequest.Text;
        RadListView1.Rebind();
    }
    protected void radAcceptFeedback_Click(object sender, EventArgs e)
    {
        //RadPanelItem item = RadPanelBar0.Items[0];
        //CheckBox CheckItem = item.Header.FindControl("checkBox1") as CheckBox;
        //CheckItem.Checked = false;
        HiddenField1.Value = radAcceptFeedback.Text;
        RadListView1.Rebind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //RequestDetail1.RequestID = 7001;
        //RequestDetail1.RequestType = "Authorize Request";
        //RequestDetail1.EmpCode = Session["EmpCode"].ToString();
        //RequestDetail1.GetDetail();


        
       
    }

    protected void ViewChooser_TabClick(object sender, RadTabStripEventArgs e)
    {
        if (e.Tab.Text == "Employee Info")
        {
            
            
            var control = LoadControl(ViewsFolder + LoadedControlName);
            control.ID = "contentControl";
            DefaultContentControl = "EmployeeInfo.ascx";
            Content.Controls.Clear();
            Content.Controls.Add(control);


            EmployeeInfo1.RequestType = "Authorize Request";
            EmployeeInfo1.EmpCode = "A-00222"; //Session["EmpCode"].ToString();
            EmployeeInfo1.GetDetail();
            
        }
        else
        {
            DefaultContentControl = "RequestDetail.ascx";
            var control = LoadControl(ViewsFolder + LoadedControlName);
            control.ID = "contentControl";

            Content.Controls.Clear();
            Content.Controls.Add(control);

            RequestDetail1.RequestID = 7001;
            RequestDetail1.RequestType = "Authorize Request";
            RequestDetail1.EmpCode = Session["EmpCode"].ToString();
            RequestDetail1.GetDetail();
            
        }
        string selectedControl = tabs.SelectedTab.Value;
        if (selectedControl != LoadedControlName)
        {
            LoadedControlName = selectedControl;

            var control = LoadControl(ViewsFolder + LoadedControlName);
            control.ID = "contentControl";
           
            Content.Controls.Clear();
            Content.Controls.Add(control);
        }
    }

}