<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Asset_accept_reject_report.aspx.cs" Inherits="AssetMngmnt_Asset_accept_reject_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<script runat="server">

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td  style="width:100px" class="NormalText">
                Employee Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtempname" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtempname_AutoCompleteExtender" runat="server" 
                          CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
               CompletionListCssClass="autocomplete_ListItem" ContextKey="JCT00LTD" 
                            ServiceMethod="GetEmployeeName_shweta" ServicePath="~/WebService.asmx" 
                    TargetControlID="txtempname">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Status</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="combobox">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem Value="A">Accepted</asp:ListItem>
                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText" rowspan="2">
                <asp:LinkButton ID="LinkButton2" runat="server" BorderStyle="None" 
                    CssClass="buttonXL" onclick="LinkButton2_Click1" 
                    ToolTip="Click to Export data to Excel"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
       

 <td  colspan="4" class="NormalText">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="Nos" Width="100%">
                <HeaderTemplate>
                    Summary Report:
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td class="NormalText" width="350">
                                <asp:Label ID="LabeUserName" runat="server" Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="Large" Text='<%# Eval("List") %>'></asp:Label>                                                                                

                            </td>
                            <td  class="labelcells_s" width="250" align="right">
                                     &nbsp;<asp:Label ID="Labelhead" runat="server" Font-Bold="True" 
                                    Font-Names="Calibri" Font-Size="Large" ForeColor="Black" 
                                    Text='<%# Eval("Nos") %>'></asp:Label>
                            </td>
                        </tr>                        
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </td>
       
        </tr> 
        <tr>
            <td class="panelbg" colspan="4">
                Detail Info..</td>
        </tr>
        <tr>
           
            <td  colspan="4" class="NormalText">
      
 
                <asp:Panel ID="Panel1" runat="server" class="panelbg" Height="300px" 
                    ScrollBars="Vertical" >
                    <asp:GridView ID="grdDetail" runat="server"  Width="100%"   BorderColor="Black" 
                    EmptyDataText="No record Found" onrowdatabound="grdDetail_RowDataBound"  >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
     
        </tr>
   
    </table>
</asp:Content>

