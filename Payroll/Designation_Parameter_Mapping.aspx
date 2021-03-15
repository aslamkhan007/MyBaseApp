<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Designation_Parameter_Mapping.aspx.cs" Inherits="Payroll_Designation_Parameter_Mapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Designation/Allowance Mapping</td>
        </tr>
        
        <tr>
            <td class="NormalText">
                Designation List</td>
            <td class="NormalText">
                   Allowance List</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="NormalText">
         <asp:Panel ID="Panel2" runat="server" Height="600px" ScrollBars="Vertical" 
                    Visible="False" Width="400px">
             <asp:RadioButtonList ID="rdbdesglist"    runat="server" 
                 DataTextField="Desg_Long_Description" DataValueField="Designation_code" 
                 AutoPostBack="True" onselectedindexchanged="rdbdesglist_SelectedIndexChanged">
             </asp:RadioButtonList>
                </asp:Panel>
              </td>
            <td class="NormalText">
                   <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" 

                    Visible="False" Width="400px">
              <asp:CheckBoxList ID="chklist" runat="server" DataTextField="short_desc" 
                        DataValueField="sr_no" AutoPostBack="True" >
              </asp:CheckBoxList>
                </asp:Panel>
            </td>
            <td class="labelcells">
               </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkadd_Click">Save</asp:LinkButton>
    <%--            <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                     ValidationGroup="A">Update</asp:LinkButton>--%>
             <%--   <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    ValidationGroup="A">Delete</asp:LinkButton>--%>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" onclick="lnkreset_Click" 
                >Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
                
            </td>
      
       
       
        </tr>

    </table>
</asp:Content>

