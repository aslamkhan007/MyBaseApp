<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="ReasonMaster.aspx.cs" Inherits="OPS_ReasonMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Reason Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 129px">
                <asp:Label ID="Label17" runat="server" Text="Select Area"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" 
                            CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="AreaName" 
                            DataValueField="AreaCode">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="SELECT AreaName,AreaCode FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and ParentArea is null Order by AreaName asc">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdReason" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 129px">
                <asp:Label ID="Label18" runat="server" Text="Select SubArea"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSubArea" runat="server" CssClass="combobox" 
                            DataSourceID="SqlDataSource2" DataTextField="AreaName" 
                            DataValueField="AreaCode">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="Select 'None' as AreaName ,999 as AreaCode Union SELECT AreaName,AreaCode FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' and ParentArea=@ParentArea ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlArea" Name="ParentArea" 
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlArea" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="grdReason" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 129px">
                <asp:Label ID="Label19" runat="server" Text="Reason Short Desc"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReasonShortDesc" runat="server" Columns="50" 
                            CssClass="textbox" MaxLength="50" Rows="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtReasonShortDesc" ErrorMessage="** Required" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdReason" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 129px">
                <asp:Label ID="Label20" runat="server" Text="Reason Long Desc"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ( 500 charcters..)</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReasonLongDesc" runat="server" Columns="50" 
                            CssClass="textbox" Height="50px" MaxLength="500" Rows="50" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtReasonLongDesc" ErrorMessage="** Required" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdReason" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click" ValidationGroup="A">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:Label ID="lblReasonCode" runat="server" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdReason" runat="server" AllowPaging="True" 
                                EnableModelValidation="True" 
                                onpageindexchanging="grdReason_PageIndexChanging" 
                                onselectedindexchanged="grdReason_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="
SELECT  ReasonCode ,
        ISNULL(ReasonShortDesc, '') AS ShortDesc ,
        ReasonDesc ,
        Area ,
        CONVERT(VARCHAR, CreatedDate, 103) AS CreatedDate
FROM    dbo.Jct_Ops_Reason_Master
WHERE   STATUS = 'A'
ORDER BY ReasonCode ASC"></asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

