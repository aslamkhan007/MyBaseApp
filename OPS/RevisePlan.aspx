<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="RevisePlan.aspx.cs" Inherits="OPS_RevisePlan" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label21" runat="server" Text="Revise Plan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label16" runat="server" Text="Active PlanID"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPlanID" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label17" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label19" runat="server" Text="Shed"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlShed" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="PARAMETER" 
                    DataValueField="PARAMETER_CODE">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select '' as [PARAMETER_CODE],'' as  [PARAMETER] union SELECT [PARAMETER_CODE], [PARAMETER] FROM [jct_ops_multi_master] WHERE (([Status] = @Status) AND ([PARENT_CATEGORY] = @PARENT_CATEGORY)) ORDER BY [PARAMETER_CODE]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                        <asp:Parameter DefaultValue="ShedDays" Name="PARENT_CATEGORY" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label20" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="NormalText">
                   <div id="divwidth" style="display:none;">   
                        </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label22" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 90px">
                <asp:Label ID="Label23" runat="server" Text="Weaving Sort"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtWeavingSort" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc">Excel</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">

                            <asp:GridView ID="grdPlan" AllowPaging="True" AllowSorting="True" BackColor="White"
                                        Width="100%" Font-Size="X-Small" Font-Names="Verdana"
                                        runat="server" DataKeyNames="OrderNo" ShowFooter="True" 
                                        BorderStyle="Double"
                                        BorderColor="#0083C1" EmptyDataText="No Record Present" 
                                        EnableModelValidation="True" 
                                        onpageindexchanging="grdPlan_PageIndexChanging">
                                        <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        </asp:GridView>

                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

