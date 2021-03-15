<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Jctians_Empwise.aspx.vb" Inherits="Default4" Title="JCTians (Employee Wise)"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script language="JavaScript" type="text/javascript"> 
 
function clickButton(e, buttonid){ 
      var evt = e ? e : window.event;
      var bt = document.getElementById(buttonid);
      if (bt)
      { 
          if (evt.keyCode == 13)
          { 
             bt.click(); 
              
                return false; 
          } 
      }

  }
  
    </script>
    <table style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" class="frameheader">
                <asp:Label ID="Label1" runat="server" Text="JCTians (Employee Wise)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Employee Name" Width="97px"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="TxtName" runat="server" Width="273px" Font-Bold="True" 
                    Height="15px" CssClass="textbox" onclick="javascript:btnClick.click();"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Fetch" CssClass="ButtonBack" Font-Bold="True" BackColor="Black" />
            </td>
            <td>
             <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="ButtonBack"
                                    Height="0px" OnClick="Button1_Click" Text="Button" Width="0px"  />
            </td>
        </tr>
        <tr>
            <td colspan="2"
                valign="top">
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                    GridLines="None" CssClass="GridViewStyle" Width="100%">
                     <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <PagerStyle CssClass="PagerStyle" />  
    <HeaderStyle CssClass="HeaderStyle" />
    <EditRowStyle CssClass="EditRowStyle" />
    <AlternatingRowStyle CssClass="AltRowStyle" />
               
                </asp:DetailsView>
            </td>
            <td
                valign="top" class="textcells_s">
                <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="230px" ImageAlign="Middle"
                    ImageUrl="~/Image/2.JPG" Width="172px" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
