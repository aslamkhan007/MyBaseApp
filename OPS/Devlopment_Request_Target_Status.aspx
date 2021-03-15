<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Devlopment_Request_Target_Status.aspx.vb" Inherits="OPS_Devlopment_Request_Target_Status" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Devlopment Request Target Status"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="90%" Height="300px" >
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                                CellSpacing="0" DataSourceID="SqlDataSource1" GridLines="None" 
                                Width="100%"> 
                               <%-- Height="300px" >
                                Width="80%">--%>
                               <%-- <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>--%>
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
                                        <telerik:GridBoundColumn DataField="RequestID" DataType="System.Int32" 
                                            FilterControlAltText="Filter RequestID column" HeaderText="RequestID" 
                                            ReadOnly="True" SortExpression="RequestID" UniqueName="RequestID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RequestedBy" 
                                            FilterControlAltText="Filter RequestedBy column" HeaderText="RequestedBy" 
                                            SortExpression="RequestedBy" UniqueName="RequestedBy">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DESCRIPTION" 
                                            FilterControlAltText="Filter DESCRIPTION column" HeaderText="DESCRIPTION" 
                                            SortExpression="DESCRIPTION" UniqueName="DESCRIPTION">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProspectCust" 
                                            FilterControlAltText="Filter ProspectCust column" HeaderText="ProspectCust" 
                                            SortExpression="ProspectCust" UniqueName="ProspectCust">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProspectCustName" 
                                            FilterControlAltText="Filter ProspectCustName column" 
                                            HeaderText="ProspectCustName" SortExpression="ProspectCustName" 
                                            UniqueName="ProspectCustName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SortNo" 
                                            FilterControlAltText="Filter SortNo column" HeaderText="SortNo" 
                                            SortExpression="SortNo" UniqueName="SortNo">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Req_Mtrs" DataType="System.Int16" 
                                            FilterControlAltText="Filter Req_Mtrs column" HeaderText="Req_Mtrs" 
                                            SortExpression="Req_Mtrs" UniqueName="Req_Mtrs">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Finish" 
                                            FilterControlAltText="Filter Finish column" HeaderText="Finish" 
                                            SortExpression="Finish" UniqueName="Finish">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="no_of_shades" DataType="System.Byte" 
                                            FilterControlAltText="Filter no_of_shades column" HeaderText="no_of_shades" 
                                            SortExpression="no_of_shades" UniqueName="no_of_shades">
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
                        </asp:Panel>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>"
                        SelectCommand="Jct_Ops_Get_Devlopment_Request" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Authorize Request" Name="Parameter" 
                                    Type="String" />
                                <asp:SessionParameter Name="Empcode" SessionField="EmpCode" />
                                <asp:Parameter Name="RequestID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Target Hit"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="ddlTarget" Runat="server" Skin="Metro">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Yes" Value="Yes" />
                                <telerik:RadComboBoxItem runat="server" Text="No" Value="No" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" Width="100%" Height="40%" >
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Bulk Sort
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <telerik:RadTextBox ID="txtRemarks" Runat="server" MaxLength="1000" 
                    Skin="Metro" Width="200px">
                </telerik:RadTextBox>
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
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr >
            <td colspan="4" class="buttonbackbar">

                        <telerik:RadButton ID="cmdApply" runat="server" onclick="cmdApply_Click" 
                            Skin="Metro" Text="Apply">
                        </telerik:RadButton>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
    </table>

</asp:Content>

