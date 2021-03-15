<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="SanctionNoteReport.aspx.cs" Inherits="OPS_SanctionNoteReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Image/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Image/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Check Status of Sanction Note"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label18" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label19" runat="server" Text="Select Area"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="combobox" DataSourceID="SqlDataSource1"
                            DataTextField="AreaName" DataValueField="AreaCode" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="Select '' as AreaName,0 as AreaCode Union SELECT AreaName,AreaCode FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' AND AreaCode NOT IN (1015,1018,1019,1020,1021,1022,1024,1023,1026,1027) ORDER BY AreaName ASC">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label22" runat="server" Text="Status"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="C">Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label20" runat="server" Text="Sanction ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:TextBox ID="txtSanctionID" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label23" runat="server" Text="Authorized By"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlAuthBy" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="M-00063">Michael K Hodges</asp:ListItem>
                    <asp:ListItem Value="C-1111">Charanamrit Singh</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label21" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkSummary" runat="server" CssClass="buttonc" Visible="False"
                            OnClick="lnkSummary_Click">Summary</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlArea" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" OnClick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMaster" runat="server">
                            <asp:GridView ID="grdMaster" runat="server" EnableModelValidation="True" Width="100%"
                                OnRowDataBound="grdMaster_RowDataBound" OnSelectedIndexChanged="grdMaster_SelectedIndexChanged"
                                EmptyDataText="No Record Present">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imageSanctionID-<%# Eval("SanctionID") %>" alt="Click to show/hide Description"
                                                border="0" src="../Image/plus.png" />
                                            <div id="SanctionID-<%# Eval("SanctionID") %>" style="display: none; position: relative;
                                                left: 25px;">
                                                <asp:GridView ID="nestedGridView" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSummary" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlChild" runat="server" Visible="False">
                            <asp:GridView ID="grdChild" runat="server" OnRowDataBound="grdChild_RowDataBound"
                                ShowFooter="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdMaster" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlGrdAuth" runat="server" Visible="false">
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td>
                            <asp:Label ID="lblDetail0" runat="server" Text="Authorization History" Font-Bold="True"
                                Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GrdAuthHistory" runat="server" Width="100%" EnableModelValidation="True"
                                AutoGenerateColumns="true">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    Not Data Found... ! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" CssClass="panelbg">
                                <asp:DataList ID="dtlAttachment" runat="server" 
                                    onitemcommand="dtlAttachment_ItemCommand">
                                    <ItemTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="NormalText" style="width: 114px">
                                                    <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:LinkButton ID="lnkAttachment" runat="server" CommandArgument='<%# Eval("AttachedFile") %>'
                                                        CommandName="Download" Text='<%# Eval("AttachedFile") %>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grdMaster" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
