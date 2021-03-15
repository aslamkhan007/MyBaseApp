<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Leave Update Master.aspx.vb" Inherits="LeaveMaster" title="Leave Master" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

    <table style="width:100%">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Text="Leave Application (OD/SL/PL/CL/Travel Leave/Comp Leave)" Width="373px"></asp:Label></td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="width: 80px" class="labelcells">
                Leave From</td>
            <td style="width: 93px" class="textcells">
                <ew:CalendarPopup ID="LeaveFrom" runat="server" cssclass="textbox" Culture="English (United Kingdom)"
                    Text="..." Width="65px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td style="width: 78px" class="labelcells">
                Leave To</td>
            <td cssclass="textcells">
                <ew:CalendarPopup ID="LeaveTo" runat="server" CssClass="textbox" Culture="English (United Kingdom)"
                    Text="..." Width="65px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:Button ID="BtnGet" runat="server" Text="Get" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="Button1" runat="server" Text="Authorize" 
                    CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="Check" runat="server" Text="Check" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="UnCheck" runat="server" Text="UnCheck" CssClass="ButtonBack" BackColor="Black"/></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  
                     PageSize="25"   width="100%" GridLines="None"  CssClass="GridViewStyle" 
                    AllowSorting="True" OnSorting="GridView1_Sorting">
                    <PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="20" />
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Tahoma" Font-Size="8pt" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                  
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

