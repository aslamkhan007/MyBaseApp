<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="mytesing.aspx.cs" Inherits="AssetMngmnt_mytesing" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                Student Detail.</td>
        </tr>
        <tr><td class="NormalText">
        
            <asp:Label ID="lblfrom_date" runat="server" CssClass="labelcells" 
                Text="From date"></asp:Label>
        
        </td><td class="NormalText">
        
                <asp:TextBox ID="Txtdatefrom" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    TargetControlID="Txtdatefrom">
                </cc1:CalendarExtender>
        
        </td></tr>
         <tr><td class="NormalText">
        
             <asp:Label ID="lblto_date" runat="server" CssClass="labelcells" Text="To date:"></asp:Label>
        
        </td><td class="NormalText">
        
                 <asp:TextBox ID="Txtdateto" runat="server"></asp:TextBox>
                 <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                     TargetControlID="Txtdateto">
                 </cc1:CalendarExtender>
        
        </td></tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lblName" runat="server" CssClass="labelcells" Text="Name"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText">
                <asp:Label ID="lblroll_no" runat="server" CssClass="labelcells" Text="Roll No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="Txtroll_no" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lblClass" runat="server" CssClass="labelcells" Text="Class"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtClass" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                    onclick="lnkSave_Click">Save</asp:LinkButton>
            
               
            
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                    
                    <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" onclick="lnkreset_Click" 
                    >Reset</asp:LinkButton>
            
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" ToolTip="Excel"></asp:LinkButton>
            
      </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server"   Width="100%">
                 <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

