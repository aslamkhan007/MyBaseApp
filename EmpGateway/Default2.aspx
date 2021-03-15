<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" Title="Leave Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" style="width:100%">
                <asp:Label ID="Label1" runat="server" Text="Leave Detail (Updated on Last Month)"
                    Width="309px"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text="Year"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem> 
                    <asp:ListItem >2012</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
 <asp:ListItem>2014</asp:ListItem>
 <asp:ListItem>2015</asp:ListItem>

 
                  

<asp:ListItem Selected="True">2016</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  
                       CssClass="GridViewStyle" GridLines="None"    Width="100%"  >
                   <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" align="left">
                <asp:Label ID="Label2" runat="server" Text="Leave Status Record For Current Year"
                    Width="227px" Height="16px"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="A-Authorized ,         P-Pending ,         C-Canceled"
                    Width="220px" Height="16px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" 
                    PostBackUrl="Leave_Application.aspx" 
                    ToolTip="Click Here To Apply For Leave">Apply For Leave</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton12" runat="server" 
                    ToolTip="Click Here To See Punch Records">See Punch Records</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td >
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                        Width="100%" PageSize="5" GridLines="Both"    CssClass="GridViewStyle" OnRowDataBound="GridView2_RowDataBound">
              
               <RowStyle BorderColor="Black" BorderStyle="Groove" Height="20px" 
                        VerticalAlign="Middle" />  
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />
  <AlternatingRowStyle BackColor="Silver" />
                    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" style="text-align: left" >
                Compensatory Leave Detail</td>
        </tr>
        <tr>
            <td style="text-align: left" >
                <asp:GridView ID="grdCompensatory" runat="server" AllowPaging="True"  
                       CssClass="GridViewStyle" GridLines="None"    Width="100%" 
                    EmptyDataText="No Compensatory Leaves are available."  >
                   <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
