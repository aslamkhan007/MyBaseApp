<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false" CodeFile="ReMapping.aspx.vb" Inherits="EmpGateway_ReMapping" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label16" runat="server" Text="Change Mapping"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 143px; height: 16px">
                <asp:Label ID="Label17" runat="server" Text="Employee Code"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 143px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkGet" runat="server" CssClass="buttonc">GET</asp:LinkButton>
                <asp:LinkButton ID="lnkDeactivate" runat="server" CssClass="buttonc">UnMap</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 143px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" EnableModelValidation="True" 
                    CssClass="GridView">
                    <Columns>
                        <asp:BoundField DataField="empname" HeaderText="empname" 
                            SortExpression="empname" />
                        <asp:BoundField DataField="Resp_Emp" HeaderText="Resp_Emp" 
                            SortExpression="Resp_Emp" />
                        <asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />
                        <asp:BoundField DataField="Days" HeaderText="Days" SortExpression="Days" />
                        <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" 
                            SortExpression="Status" />
                        <asp:BoundField DataField="Auth_Req" HeaderText="Auth_Req" 
                            SortExpression="Auth_Req" />
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <RowStyle CssClass="RowStyle" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_emp_hod_remapping_Select" 
                    SelectCommandType="StoredProcedure" 
                    UpdateCommand="jct_emp_hod_remapping_Update" 
                    UpdateCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtEmpCode" DefaultValue="" Name="empcode" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                    
                        <asp:Parameter Name="empcode" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 143px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        
</asp:Content>

