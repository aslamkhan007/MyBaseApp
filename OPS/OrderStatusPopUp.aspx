<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderStatusPopUp.aspx.cs" Inherits="OrderStatusPopUp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Order Already Planned..!!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
        function CloseAndRebind(args)
        {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshGrid(args);
        }
		
        function GetRadWindow()
        {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;//IE (and Moz as well)
				
            return oWindow;
        }

        function CancelEdit()
        {
            GetRadWindow().Close();		
        }
        </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <telerik:RadGrid ID="grdPopUp" runat="server" CellSpacing="0" GridLines="None" >
                            <MasterTableView  >
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True" Created="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
         </telerik:RadGrid>
        
      
        </div>             
    <telerik:RadButton ID="radRePlan" runat="server" onclick="radRePlan_Click" 
        Skin="Hay" Text="RePlan">
    </telerik:RadButton>
    <cc1:ConfirmButtonExtender ID="radRePlan_ConfirmButtonExtender" runat="server" 
        ConfirmText="Are you sure you want to Re-Plan ?" TargetControlID="radRePlan">
    </cc1:ConfirmButtonExtender>
    </form>
</body>
</html>
