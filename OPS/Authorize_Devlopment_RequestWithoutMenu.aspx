<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPageWithoutMenu.master" AutoEventWireup="true" CodeFile="Authorize_Devlopment_RequestWithoutMenu.aspx.cs" Inherits="OPS_Authorize_Devlopment_RequestWithoutMenu" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="UsrCtrl/RequestDetail.ascx" tagname="RequestDetail" tagprefix="uc2" %>

<%@ Register src="UsrCtrl/EmployeeInfo.ascx" tagname="EmployeeInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .line1
        {
            background: url(/image/line_ver1.gif) 325px 0 repeat-y;
        }
        .line2
        {
            background: url(/image/line_ver1.gif) 635px 0 repeat-y;
        }
        #content2 .line2, #content2 .line1
        {
            background-image: url(/image/line_ver2.png);
        }
    </style>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Devlopment Request Status Marking
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td valign="top" width="200" height="500" style="width: 205px">
                <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Skin="Metro" Width="200px">
                    <Items>
                        <telerik:RadPanelItem runat="server" Text="Categories" ForeColor="Black">
                            <%--  <Items>
                                            <telerik:RadPanelItem runat="server" Text="A">
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem runat="server" Text="B">
                                            </telerik:RadPanelItem>
                                        </Items>--%>
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" ImageUrl="~/Image/Final/Customers.png"
                                                Width="47px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ImageButton ID="ImageButton2" runat="server" Height="43px" ImageUrl="~/Image/Final/Employees.png"
                                                Width="47px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ImageButton ID="ImageButton3" runat="server" Height="43px" ImageUrl="~/Image/Final/Prospects3.png"
                                                Width="47px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ImageButton ID="ImageButton4" runat="server" Height="43px" ImageUrl="~/Image/Final/Vendor.png"
                                                Width="47px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem runat="server" Text="Search Option">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <telerik:RadButton ID="radAuthorizeRequest" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                Text="Authorize Request" Skin="Metro" GroupName="SearchOption" OnClick="radAuthorizeRequest_Click"
                                                Checked="true">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="baseline">
                                            <telerik:RadButton ID="radAcceptFeedback" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                Text="Accept Request" Skin="Metro" GroupName="SearchOption" OnClick="radAcceptFeedback_Click">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <%-- <Items>
                                <telerik:RadPanelItem runat="server" Text="C">
                                </telerik:RadPanelItem>
                            </Items>--%>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem runat="server" Text="Ordering">
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelBar>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td style="background-image: url('Image/line_ver2.png'); background-repeat: repeat-y;
                vertical-align: middle; text-align: left; white-space: normal; letter-spacing: normal;
                width: 2px;">
            </td>
            <td valign="top">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" style="background-color: #25A0DA">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkReset0" runat="server" CssClass="buttonPrint2" BorderStyle="None"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <telerik:RadSearchBox ID="RadSearchBox1" runat="server">
                                        </telerik:RadSearchBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <telerik:RadListView ID="RadListView1" runat="server" ItemPlaceholderID="RequestDEtail"
                                DataSourceID="SqlDataSource1" AllowCustomPaging="True" AllowPaging="True" 
                                Skin="Metro">
                                <LayoutTemplate>
                                    <fieldset style="width: 95%">
                                        <legend>Request Detail</legend>
                                        <asp:PlaceHolder ID="RequestDEtail" runat="server"></asp:PlaceHolder>
                                    </fieldset>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <fieldset style="float: left; width: 95%;">
                                        <legend>Empname:
                                            <%#Eval("RequestID")%>
                                            -- Requested By
                                            <%#Eval("RequestedBy")%>
                                        </legend>
                                    </fieldset>
                                </ItemTemplate>
                            </telerik:RadListView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>"
                                SelectCommand="Jct_Ops_Get_Devlopment_Request" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="HiddenField1" Name="Parameter" PropertyName="Value"
                                        Type="String" />
                                    <asp:SessionParameter Name="Empcode" SessionField="EmpCode" Type="String" />
                                    <asp:Parameter Name="RequestID" Type="Int32" DefaultValue="0" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <uc1:EmployeeInfo ID="EmployeeInfo1" runat="server" />
                <uc2:RequestDetail ID="RequestDetail1" runat="server"   />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            	<telerik:RadTabStrip runat="server" ID="tabs" AutoPostBack="True" 
                    OnTabClick="ViewChooser_TabClick" SelectedIndex="1" 
                    ClickSelectedTab="True" >
					<Tabs>
							<telerik:RadTab Text="Test" Value="RequestDetail.ascx" Selected="True"/>
					        <telerik:RadTab runat="server" Text="Employee Info" Value="EmployeeInfo.ascx" >
                            </telerik:RadTab>
					</Tabs>
				</telerik:RadTabStrip>
                
            </td>
        </tr>
    </table>

     <div class="content">
		    <asp:Panel runat="server" ID="Content"></asp:Panel>
            <telerik:RadAjaxLoadingPanel runat="server" ID="ContentLoadingPanel"   Skin="Black" IsSticky="true" 
                   CssClass="ajaxLoader" />
	    </div>
    
</asp:Content>
