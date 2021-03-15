<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Authorize_Devlopment_Request.aspx.cs" Inherits="OPS_Authorize_Devlopment_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label1" runat="server" 
                    Text="Authorize / Accept  Devlopment Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="150px" >
            <asp:Label ID="Label3" runat="server" Text="Request Type"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlAuthorizationType" runat="server" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlAuthorizationType_SelectedIndexChanged" 
                        Skin="Metro">

                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Authorize Request" 
                                Value="Authorize Request" />
                            <telerik:RadComboBoxItem runat="server" Text="Accept Feedback" 
                                Value="Accept Feedback" />
                        </Items>

                    </telerik:RadComboBox>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <%--   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="90%" Height="300px" >--%>
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                                CellSpacing="0" DataSourceID="SqlDataSource1" 
                            Height="300px" Width="800px" Skin="Metro"> 
                               <%-- Height="300px" >
                                Width="80%">--%>
                               <%-- <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>--%>
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="RequestID" 
                                    DataSourceID="SqlDataSource1">
                                   <%--  <MasterTableView AutoGenerateColumns="False" DataKeyNames="RequestedBy" 
                                    DataSourceID="SqlDataSource1">--%>

                                   <%--  <MasterTableView AutoGenerateColumns="False" DataKeyNames="DESCRIPTION" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProspectCust" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProspectCustName" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="SortNo" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="Finish" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="No Of Shades" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="EndUse" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="Segment" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="Devlopment" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="EnquiryNo" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="DevlopmentNo" 
                                    DataSourceID="SqlDataSource1">

                                     <MasterTableView AutoGenerateColumns="False" DataKeyNames="RequiredOn" 
                                    DataSourceID="SqlDataSource1">--%>


                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                     <telerik:GridButtonColumn CommandName="Select" Text="Select" 
                                            UniqueName="Select">
                                        </telerik:GridButtonColumn>
                                       <%-- <telerik:GridBoundColumn DataField="RequestID" DataType="System.Int32" 
                                            FilterControlAltText="Filter RequestID column" HeaderText="RequestID" 
                                            ReadOnly="True" SortExpression="RequestID" UniqueName="RequestID">
                                        </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn DataField="RequestID" DataType="System.Int32" 
                                            FilterControlAltText="Filter RequestID column" HeaderText="RequestID" 
                                            ReadOnly="True" SortExpression="RequestID" UniqueName="RequestID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Plant" 
                                            FilterControlAltText="Filter Plant column" HeaderText="Plant" 
                                            SortExpression="Plant" UniqueName="Plant">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RequestedBy" 
                                            FilterControlAltText="Filter RequestedBy column" HeaderText="RequestedBy" ItemStyle-Width="200px"
                                            SortExpression="RequestedBy" UniqueName="RequestedBy">
                                        </telerik:GridBoundColumn>
                                        <%--ItemStyle-Wrap="false"--%>
                                        <telerik:GridBoundColumn DataField="DESCRIPTION" 
                                            FilterControlAltText="Filter DESCRIPTION column" HeaderText="DESCRIPTION" ItemStyle-Wrap="false" 
                                            SortExpression="DESCRIPTION" UniqueName="DESCRIPTION">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProspectCust" 
                                            FilterControlAltText="Filter ProspectCust column" 
                                            HeaderText="ProspectCust" SortExpression="ProspectCust" 
                                            UniqueName="ProspectCust">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProspectCustName" 
                                            FilterControlAltText="Filter ProspectCustName column" HeaderText="ProspectCustName" 
                                            SortExpression="ProspectCustName" UniqueName="ProspectCustName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CustomerName" 
                                            FilterControlAltText="Filter CustomerName column" HeaderText="CustomerName" 
                                            SortExpression="CustomerName" UniqueName="CustomerName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SortNo" 
                                            FilterControlAltText="Filter SortNo column" HeaderText="SortNo" 
                                            SortExpression="SortNo" UniqueName="SortNo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NoOfShades" DataType="System.Byte" 
                                            FilterControlAltText="Filter NoOfShades column" HeaderText="NoOfShades" 
                                            SortExpression="NoOfShades" UniqueName="NoOfShades">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ReqMtrs" 
                                            FilterControlAltText="Filter ReqMtrs column" HeaderText="ReqMtrs" 
                                            SortExpression="ReqMtrs" UniqueName="ReqMtrs" DataType="System.Int16">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Finish" 
                                            FilterControlAltText="Filter Finish column" HeaderText="Finish" 
                                            SortExpression="Finish" UniqueName="Finish">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EndUse" 
                                            FilterControlAltText="Filter EndUse column" HeaderText="EndUse" 
                                            SortExpression="EndUse" UniqueName="EndUse">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Segment" 
                                            FilterControlAltText="Filter Segment column" HeaderText="Segment" 
                                            SortExpression="Segment" UniqueName="Segment">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Devlopment" 
                                            FilterControlAltText="Filter Devlopment column" HeaderText="Devlopment" 
                                            SortExpression="Devlopment" UniqueName="Devlopment">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EnquiryNo" DataType="System.Int32" 
                                            FilterControlAltText="Filter EnquiryNo column" HeaderText="EnquiryNo" 
                                            SortExpression="EnquiryNo" UniqueName="EnquiryNo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DevlopmentNo" DataType="System.Int32" 
                                            FilterControlAltText="Filter DevlopmentNo column" HeaderText="DevlopmentNo" 
                                            SortExpression="DevlopmentNo" UniqueName="DevlopmentNo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RequiredOn" DataType="System.DateTime" 
                                            FilterControlAltText="Filter RequiredOn column" HeaderText="RequiredOn" 
                                            SortExpression="RequiredOn" UniqueName="RequiredOn">
                                        </telerik:GridBoundColumn>
                                    </Columns>
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
<%--                        </asp:Panel>--%>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>"
                        SelectCommand="Jct_Ops_Get_Devlopment_Request" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlAuthorizationType" Name="Parameter" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:SessionParameter Name="Empcode" SessionField="EmpCode" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Action"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="ddlAction" Runat="server" Skin="Metro">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Authorize" Value="Authorize" />
                                <telerik:RadComboBoxItem runat="server" Text="Cancel" Value="Cancel" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Remarks</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtRemarks" Runat="server" MaxLength="1000" 
                            ShouldResetWidthInPixels="False" Skin="Metro" Width="200px">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtRemarks" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="center">
            <asp:UpdateProgress ID="Updateprogress" runat="server" >
                <ProgressTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" width="400px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <telerik:RadButton ID="cmdApply" runat="server" onclick="cmdApply_Click" 
                            Skin="Metro" Text="Apply">
                        </telerik:RadButton>
                        &nbsp;<telerik:RadButton ID="cmdApply0" runat="server" onclick="cmdApply0_Click" 
                            Skin="Metro" Text="SendMail" Visible="False">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
