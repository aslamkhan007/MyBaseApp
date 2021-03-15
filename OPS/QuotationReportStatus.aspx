<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="QuotationReportStatus.aspx.vb" Inherits="OPS_QuotationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Status Report</td>
        </tr>

        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt; width: 150px;">
                Quotation No
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtQuotationNo" ErrorMessage="Please Provide Quotation No." 
                    SetFocusOnError="True" ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="textbox" Width="110px" ></asp:TextBox>
                 
                    <asp:ImageButton ID="ibtViewQuotation" runat="server" ImageUrl="~/Image/Icons/Action/Search.png"
                    ToolTip="Check Quotation Status" Width="24px" Visible="True"  />
                 </td>

           
        </tr>
        <tr> <td style="font-size: 10pt" colspan="2">
              Quotation summary</td></tr>
        <tr>
        <td colspan="4">
                <asp:GridView ID="GridViewSummary" runat="server" Width="100%" 
                   EmptyDataText="No Recored Found"  EnableModelValidation="True"            >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
               <%--  EmptyDataText="No Recored Found."DataSourceID="SqlDataSource3" <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_my_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtQuotationNo" Name="Quotation_No" 
                            PropertyName="Value" Type="String" />
                                            </SelectParameters>
                </asp:SqlDataSource>--%>
            </td>
        
        </tr>
       </table>
           <table style="width: 100%;">
        
        <tr>
            <td class="tableheader" colspan="4">
                Quotation PO Status Report</td>
        </tr>
        <tr>
        <td colspan="4">
                <asp:GridView ID="GridViewOrder" runat="server" Width="100%" 
                   EmptyDataText="No Recored Found"  EnableModelValidation="True"            >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
               <%--  EmptyDataText="No Recored Found."DataSourceID="SqlDataSource3" <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_my_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtQuotationNo" Name="Quotation_No" 
                            PropertyName="Value" Type="String" />
                                            </SelectParameters>
                </asp:SqlDataSource>--%>
            </td>
            
            
        </tr>
        </table>

</asp:Content>
