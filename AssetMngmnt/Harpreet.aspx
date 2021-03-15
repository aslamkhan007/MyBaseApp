<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="Harpreet.aspx.cs" Inherits="AssetMngmnt_Harpreet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr class="tableheader">
            <td >
                STUDENT DETAIL</td>
            <td>
                &nbsp;</td>
         
        </tr>
        <tr>
            <td class="NormalText" >
                <asp:Label ID="lblname" runat="server" CssClass="labelcells" Text="Name"></asp:Label></td>
             <td class="NormalText">   <asp:TextBox ID="Txtbox" runat="server" 
                     CssClass="textbox" ></asp:TextBox></td></tr>
           <tr>  <td  class="NormalText">   <asp:Label ID="lblroll" runat="server" CssClass="labelcells" Text="Rollno"></asp:Label></td>
             <td  class="NormalText">   <asp:TextBox ID="txtroll" runat="server" 
                     CssClass="textbox"></asp:TextBox>
            </td></tr>
            
        <tr>
            <td class="NormalText" >
                <asp:Label ID="lblclass" runat="server" CssClass="labelcells" Text="Class"></asp:Label></td>
            <td>    <asp:TextBox ID="txtclass" runat="server" CssClass="textbox"></asp:TextBox></td></tr>
                <tr><td class="buttonbackbar" colspan="2"><asp:LinkButton ID="button" runat="server" CssClass="buttonc" 
                    onclick="button_Click">SAVE</asp:LinkButton>
                    <asp:LinkButton ID="LinkFetch" runat="server" CssClass="buttonc" 
                        onclick="LinkFetch_Click">Fetch</asp:LinkButton>
                    </td>
                    </tr>
       
                <tr> <td colspan="2">
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

