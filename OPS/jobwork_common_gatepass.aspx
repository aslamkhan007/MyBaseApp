<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jobwork_common_gatepass.aspx.cs" Inherits="OPS_jobwork_common_gatepass" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td class="tableheader" >
                JobWork (Gatepass/Challan)</td>
        </tr>
        </table>
        
                <asp:Panel ID="Panel1" runat="server" 
                    Visible="False"  CssClass="panelbg" ScrollBars="Both">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="panelbg">
        <table>
            <tr>
                <td class="NormalText">
                   <asp:Label ID="lbgate" runat="server" Text="GatePass" Visible="False"></asp:Label>
                   </td>
                <td  class="NormalText">
                    <asp:TextBox ID="txtgate" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="NormalText">
                  
                    <asp:Label ID="lbchlnno" runat="server" Text="ChallanNo" Visible="False"></asp:Label>
                    &nbsp;</td>
                <td  class="NormalText">
                    <asp:TextBox ID="txtchallnno" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="NormalText">
                    
                    <asp:Label ID="lbchalandt" runat="server" Text="ChallanDate" Visible="False"></asp:Label>
                   </td>
                <td  class="NormalText">
                    <asp:TextBox ID="txtchalandt" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtchalandt_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtchalandt">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td  class="NormalText">
                   
                    <asp:Label ID="lbqty" runat="server" Text="QtyReceived" Visible="False"></asp:Label>
                    </td>
                <td  class="NormalText">
                    <asp:TextBox ID="txtqty" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtqty_FilteredTextBoxExtender" runat="server" 
                        Enabled="True" TargetControlID="txtqty" ValidChars=".1234567890">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
        </table>
    </asp:Panel>
     
                <asp:Panel ID="Panel3" runat="server"
                    Visible="False" CssClass="panelbg" ScrollBars="Both">
                    <asp:GridView ID="grdDetail2" runat="server" 
                    Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
    <table style="width: 1026px">
        <tr>
            <td class="buttonbackbar"  >
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkFinish" runat="server" CssClass="buttonc" 
                    onclick="lnkFinish_Click" Visible="False">Finish</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        </table>
</asp:Content>

