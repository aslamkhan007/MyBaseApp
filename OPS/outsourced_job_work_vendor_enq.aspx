<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_job_work_vendor_enq.aspx.cs" Inherits="OPS_outsourced_job_work_vendor_enq" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="8">
                Vendor Enquiry </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Panel ID="Panel1" runat="server">
                     <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                         AutoGenerateSelectButton="True" 
                         onselectedindexchanged="grdDetail_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbreqid" runat="server" Text="Requestid" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
            <td>
                Vendor Name</td>
            <td>
                <asp:TextBox ID="txtvendor" runat="server" CssClass="textbox"></asp:TextBox>
               
                <cc1:AutoCompleteExtender ID="txtvendor_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServicePath="~/webservice.asmx" 
                      CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="vendorfab" 
                 
                    TargetControlID="txtvendor">
                </cc1:AutoCompleteExtender>
               
            </td>
            <td>
                Rate</td>
            <td>
                <asp:TextBox ID="txtrate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtrate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtrate" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                UOM</td>
            <td>
                <asp:DropDownList ID="ddluom" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PCS</asp:ListItem>
                    <asp:ListItem>MTR</asp:ListItem>
                    <asp:ListItem>SET</asp:ListItem>
                    <asp:ListItem>PARALLEL</asp:ListItem>
                    <asp:ListItem>KG</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Avg
                Consumption</td>
            <td>
                <asp:TextBox ID="txtconsumption" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Contract Waste</td>
            <td>
                <asp:TextBox ID="txtwaste" runat="server" CssClass="textbox" 
                    ontextchanged="txtwaste_TextChanged" AutoPostBack="True"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtwaste_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtwaste" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                Waste Qtantity</td>
            <td>
                <asp:TextBox ID="txtwasteqty" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                Agent</td>
            <td>
                <asp:TextBox ID="txtagent" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                Validation Date</td>
            <td>
                <asp:TextBox ID="txtvaliddate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtvaliddate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtvaliddate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Delivery Date</td>
            <td>
                <asp:TextBox ID="txtdeliverydate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdeliverydate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdeliverydate">
                </cc1:CalendarExtender>
            </td>
            <td>
                ProductType</td>
            <td>
                <asp:DropDownList ID="ddlproducttype" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Test</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                PackingDetail</td>
            <td>
                <asp:DropDownList ID="ddlpacking" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Lump</asp:ListItem>
                    <asp:ListItem>Roll</asp:ListItem>
                    <asp:ListItem>Taka</asp:ListItem>
                    <asp:ListItem>BoxPacking</asp:ListItem>
                    <asp:ListItem>Bags</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                FreifgtCharges</td>
            <td>
                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Buyer</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Job charges</td>
            <td>
                <asp:TextBox ID="txtjobchrg" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtjobchrg_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtjobchrg" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                PaymentTerms</td>
            <td>
                <asp:TextBox ID="txtpayterms" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                Remarks</td>
            <td>
                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" Height="50px" 
                    TextMode="MultiLine" Width="150px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="8">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    Visible="False">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    Visible="False">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
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

