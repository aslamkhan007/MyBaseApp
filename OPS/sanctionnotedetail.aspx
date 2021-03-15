<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="sanctionnotedetail.aspx.cs" Inherits="OPS_sanctionnotedetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 800px">
        <tr>
            <td colspan="5" class="tableheader">
                Sanctionote Detail
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Date From
            </td>
            <td>
                <asp:TextBox ID="txtdatefrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrom_CalendarExtender" runat="server" TargetControlID="txtdatefrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Date To
            </td>
            <td>
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="usercode" runat="server" Text="Raised By"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtusercode" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="sanvtionnoteid" runat="server" Text="SanctionnoteId" CssClass="NormalText"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsanction" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Status
            </td>
            <td>
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;Area
            </td>
            <td>
                <asp:DropDownList ID="ddlselectares" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="AreaName" DataValueField="AreaCode">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Select 0 as [AreaCode],'--Select--' as [AreaName] Union SELECT AreaCode,AreaName FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and parentarea=1015 and areacode not in (1015,1018,1019,1020,1021,1014,1022,1024,1023) ORDER BY AreaName">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;<asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" 
                    BorderStyle="None">                      </asp:LinkButton>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Authorized By</td>
            <td>
                <asp:DropDownList ID="ddlauthorized" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Michael hodge</asp:ListItem>
                    <asp:ListItem>Charanamrit singh</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NewsTab">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NewsTab">
                &nbsp;</td>
            <td class="NewsTab">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="5" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="reset" runat="server" CssClass="buttonc" OnClick="reset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="reset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="image" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="both" Height="500px" 
                            Width="800px">
                            <asp:GridView ID="grdDetail" runat="server" Width="89%" 
                                OnSelectedIndexChanged="grdDetail_SelectedIndexChanged" 
                                onrowdatabound="grdDetail_RowDataBound">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="Pagerstyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
