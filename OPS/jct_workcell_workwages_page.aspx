<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jct_workcell_workwages_page.aspx.cs" Inherits="OPS_jct_workcell_workwages_page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Jct Workwages Detail.</td>
        </tr>
       
        <tr>
            <td class="labelcells" style="height: 16px">
                Employee Code</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployeecode" runat="server" CssClass="textbox" 
                    Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEmployeecode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="height: 16px">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_from" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_from_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_from">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txteff_from" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;Effective To&nbsp;</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_to">
                </cc1:CalendarExtender>
            </td>
        </tr>
             <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkPrint" runat="server" CssClass="buttonc" 
                    onclick="lnkPrint_Click" ValidationGroup="A">Print</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
                <%--                                   </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                 
                    <asp:GridView ID="grdDetail" runat="server" 
                    Width="100%" >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                     
                    </asp:GridView>
            
                </asp:Panel>
                      <%--                                   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
       
       
       
        </tr>
    </table>
</asp:Content>
