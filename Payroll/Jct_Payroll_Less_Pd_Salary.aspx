<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Less_Pd_Salary.aspx.cs" Inherits="Payroll_Jct_Payroll_Less_Pd_Salary" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
              
                Less Payable Days Salary</td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant</td>
            <td class="NormalText">
          <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    onselectedindexchanged="ddlLocation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlLocation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                      </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px" 
                    MaxLength="6"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" TargetControlID="txttodate" 
                    ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txttodate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
                   <td class="labelcells">
               
            </td>
            <td class="NormalText">
         
            </td>
        </tr>
       
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px">
            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                        onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                    <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                        onclick="lnkreset_Click">Reset</asp:LinkButton>
                    <%--<asp:LinkButton ID="lnkFreeze0" runat="server" CssClass="buttonc" 
                        onclick="lnkFreeze_Click" Enabled="False">Freeze</asp:LinkButton>--%>
                         <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                        onclick="lnkexcel_Click" Enabled="False">Excel</asp:LinkButton>
              <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

          
            </td> 
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>

                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


