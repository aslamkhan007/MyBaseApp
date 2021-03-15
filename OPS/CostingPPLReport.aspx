<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="CostingPPLReport.aspx.cs" Inherits="OPS_CostingPPLReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label16" runat="server" Text="Costing PPL Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label20" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 156px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 96px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label17" runat="server" Text="Select Plan"></asp:Label>
            </td>
            <td class="NormalText" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chbPlan" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource1" DataTextField="DESCRIPTION" 
                            DataValueField="PLANID" RepeatColumns="2" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="SELECT UPPER([DESCRIPTION]) as Description, [PLANID] FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE (([STATUS] = @STATUS) AND ([Plant] = @Plant))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                <asp:ControlParameter ControlID="ddlPlant" Name="Plant" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label18" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText" style="width: 156px">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 96px">
                <asp:Label ID="Label19" runat="server" Text="SortNo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                    <asp:PostBackTrigger ControlID="lnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">



            <asp:GridView ID="grd" runat="server" AllowPaging="True" 
                EmptyDataText="No Data Found..!!" Width="100%" 
                onpageindexchanging="grd_PageIndexChanging">
                <AlternatingRowStyle CssClass="GridAI" />
                <HeaderStyle CssClass="GridHeader" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>



        </asp:Panel>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

