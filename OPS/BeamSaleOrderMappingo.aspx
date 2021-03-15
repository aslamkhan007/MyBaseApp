<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="BeamSaleOrderMapping.aspx.cs" Inherits="OPS_BeamSaleOrderMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <script type="text/javascript">
     function setRowBackColor(checkBox, className) {
         if (checkBox.checked)
             checkBox.parentNode.parentNode.parentNode.className = 'HighlightedRow';
         else
             checkBox.parentNode.parentNode.parentNode.className = 'GridItem';
     }

    </script>

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Beam-Sale Order Mapping"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label17" runat="server" Text="Beam Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 161px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom"
                    ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 80px">
                <asp:Label ID="Label18" runat="server" Text="Beam Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                    ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label20" runat="server" Text="Sort"></asp:Label>
            </td>
            <td class="NormalText" style="width: 161px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSort" runat="server" AutoPostBack="True" Columns="8" CssClass="textbox"
                            MaxLength="8"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 80px">
                <asp:Label ID="Label21" runat="server" Text="Shed"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlShed" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="PARAMETER" DataValueField="PARAMETER_CODE">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="SELECT [PARAMETER_CODE], [PARAMETER] FROM [jct_ops_multi_master] WHERE (([Status] = @Status) AND ([PARENT_CATEGORY] = @PARENT_CATEGORY)) ORDER BY [PARAMETER]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                                <asp:Parameter DefaultValue="WeavingShed" Name="PARENT_CATEGORY" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label19" runat="server" Text="Issue No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 161px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtIssueNo" runat="server" Columns="12" CssClass="textbox" MaxLength="12"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 80px">
                <asp:Label ID="Label22" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            CssClass="combobox" DataSourceID="SqlDataSource2" DataTextField="Type" DataValueField="Type">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:productionConnectionString1 %>"
                            SelectCommand="SELECT Distinct case when [Type]='S' Then 'Sized' when [Type]='C' Then 'Cut-Beam' when [Type]='U' Then 'Un-Sized' Else [Type] End as Type FROM [jct_tracking_beam_status_warping] order by Type">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         <tr>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label31" runat="server" Text="Select Year"></asp:Label>
            </td>
            <td class="NormalText" style="width: 161px">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 80px">
                <asp:Label ID="Label32" runat="server" Text="Select Month"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click"
                            CausesValidation="False">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            OnClick="lnkSave_Click">Save</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%" AutoGenerateColumns="False"
                                EnableModelValidation="True" AllowPaging="True" OnPageIndexChanging="grdDetail_PageIndexChanging"
                                OnRowCommand="grdDetail_RowCommand" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ControlStyle Width="20px" />
                                        <FooterStyle Width="20px" />
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issue No">
                                        <ItemTemplate>
                                            <asp:Label ID="lbliss_no" runat="server" Text='<%# Eval("iss_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Split">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsplit" runat="server" Text='<%# Eval("split") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsort_no" runat="server" Text='<%# Eval("sort_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shed">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmc_type" runat="server" Text='<%# Eval("mc_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Beam No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbeam_no" runat="server" Text='<%# Eval("beam_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                              
                                    <asp:TemplateField HeaderText="Length Rem">
                                        <ItemTemplate>
                                           <asp:Label ID="lblLeftLength" runat="server" Text='<%# Eval("LeftLength") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Length">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLength" runat="server" Text='<%# Eval("length") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
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
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlSaleOrder" runat="server">
                            <asp:GridView ID="grdSaleOrder" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                Width="100%" 
                                EmptyDataText="No Sale Order Present for the Selected Sort No" 
                                onrowdatabound="grdSaleOrder_RowDataBound">
                                <AlternatingRowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chbHeader" runat="server" AutoPostBack="True" 
                                                OnCheckedChanged="chbHeader_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbRow" runat="server"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sale Order">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              
                                    <asp:TemplateField HeaderText="Weaving Sort">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWeavingSort" runat="server" Text='<%# Eval("WeavingSort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreq_qty" runat="server" Text='<%# Eval("req_qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Greigh Req. Dt">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgreighreqdt" runat="server" Text='<%# Eval("GREIGH_REQDT") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Required">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgreighreq" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greigh Adj">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighAdj" runat="server" Text='<%# Eval("GreighAdj") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Remaining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighRem" runat="server" Text='<%# Eval("GreighRem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sizing Required">
                                        <ItemTemplate>
                                            <asp:Label ID="Label30" runat="server" Text='<%# Eval("Sizing") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Sizing Done">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSizingSaved" runat="server" Text='<%# Eval("SizingSaved") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sizing Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSizingLeft" runat="server" Text='<%# Eval("SizingLeft") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sizing Produced">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSizingDone" runat="server" Columns="10" CssClass="textbox" Text='<%# Eval("SizingDone") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdDetail" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="grdDetail" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 128px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 161px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 103px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
