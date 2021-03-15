<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImportNewContacts.aspx.vb" Inherits="SMSGateway_ImportNewContacts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../stylesheets/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/EmpGatewayStyleSheet.css" />
    <style type="text/css">
        .style2
        {
            width: 175px;
        }
    </style>
   </head>
<body style="margin:0;">
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td class="tableheader">
                </td>
            </tr>
        </table>
        <table class="tableback" style="width:100%;">
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label1" runat="server" Text="Contact Type"></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="ddlContactType" runat="server" AutoPostBack="True" 
            CssClass="combobox">
            <asp:ListItem Value="SqlCustomer">Customer</asp:ListItem>
            <asp:ListItem Value="SqlSupplier">Supplier</asp:ListItem>
            <asp:ListItem Value="SqlEmployee">Employee</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td class="labelcells" style="width: 200px">
                    <asp:Label ID="Label2" runat="server" Text="No of Contacts to be displayed"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCount" runat="server" AutoPostBack="True" Columns="5" 
                        CssClass="textbox">100</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" colspan="4">
                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblAlpha" runat="server" Text='<%# Eval("Data") %>' 
                                CommandArgument='<%# Eval("Data") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 500px; overflow: scroll">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grdContacts" runat="server" Width="98%" 
                AutoGenerateColumns="False">
                <RowStyle CssClass="GridItem" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" 
                                />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                    <asp:BoundField DataField="Address1" HeaderText="Address1" />
                    <asp:BoundField DataField="Address2" HeaderText="Address2" />
                    <asp:BoundField DataField="Address3" HeaderText="Address3" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="Country" HeaderText="Country" />
                    <asp:TemplateField HeaderText="Mobile No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPhoneNo" runat="server" Columns="20" CssClass="textbox" 
                                Text='<%# Eval("Phone_No") %>'></asp:TextBox>
                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("Phone_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EMail">
                        <ItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Columns="20" CssClass="textbox" 
                                Text='<%# Eval("Email") %>'></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DOB" HeaderText="DOB" />
                    <asp:BoundField DataField="DOA" HeaderText="DOA" />
                </Columns>
                <PagerStyle CssClass="GridHeader" />
                <HeaderStyle CssClass="GridHeader" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlCustomer" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SOMConnectionString %>">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlSupplier" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SOMConnectionString %>">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlEmployee" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                ProviderName="<%$ ConnectionStrings:misjctdev.ProviderName %>" 
                
                SelectCommand="Select CardNo, FullName, DOB, Date_Of_Aniv from jct_epor_master_employee where status &lt;&gt; 'D' and getdate() between eff_from and eff_to"></asp:SqlDataSource>
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlContactType" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmdImport" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="tableback">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:LinkButton ID="cmdImport" runat="server" CssClass="buttonc">Import</asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
