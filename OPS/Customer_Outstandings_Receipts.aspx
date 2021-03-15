<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Outstandings_Receipts.aspx.vb" Inherits="SalesAnalysisSystem_Customer_Outstandings_Receipts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Customer Outstandings and Receipts</td>
        </tr>
        <tr>
            <td class="labelcells">
                Month Year</td>
            <td style="font-size: 10pt">
                <asp:DropDownList ID="ddlDateTo" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                </asp:DropDownList>
                <asp:HiddenField ID="hdfDateFrom" runat="server" />
            </td>
            <td style="font-size: 10pt">
                &nbsp;</td>
            <td style="font-size: 10pt">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 10pt" colspan="4">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value = "jct_sas_customer_outstandings_receipts">Receipts against Outstandings </asp:ListItem>
                    <asp:ListItem Value="jct_sas_customer_receipts" Enabled="False">Receipts Only</asp:ListItem>
                </asp:RadioButtonList>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    Visible="False">View</asp:LinkButton>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">Save to Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="AdjResultsDiv" style="width: 800px; height: 400px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                                EnableModelValidation="True" Width="180%" CaptionAlign="Left" 
                                EmptyDataText="No Data Found" Visible="False">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:GridView ID="GridView2" runat="server" CaptionAlign="Left" 
                                DataSourceID="SqlDataSource1" EmptyDataText="No Data Found" 
                                EnableModelValidation="True" Visible="False">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>" 
                                SelectCommand="" 
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

