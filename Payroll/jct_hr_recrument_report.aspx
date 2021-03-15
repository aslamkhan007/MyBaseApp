<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="jct_hr_recrument_report.aspx.vb" Inherits="Payroll_jct_hr_recrument_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" >
        <tr>
            <td colspan="4" class="tableheader" title=" ">
                Recruitment Report</td>
            <td headers=" " title=" ">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" Text="FromDate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_fdate" runat="server" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txt_fdate_CalendarExtender" runat="server" 
                    TargetControlID="txt_fdate">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" CssClass="labelcells" Text="ToDate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_tdate" runat="server" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txt_tdate_CalendarExtender" runat="server" 
                    TargetControlID="txt_tdate">
                </cc1:CalendarExtender>
                <br />
            </td>
            <td>
                <asp:ImageButton ID="imb_close" runat="server" Height="25px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:ImageButton ID="Image1" runat="server" 
    ImageUrl="~/Image/loading.gif" Height="10px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
      
            <asp:LinkButton ID="lnk_fetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonc">XL</asp:LinkButton>
          
                
            </td>
            <td class="buttonbackbar">
                &nbsp;</td>
        </tr>
        <tr>
            
            <td class="buttonbackbar" colspan="4">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td class="buttonbackbar">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

