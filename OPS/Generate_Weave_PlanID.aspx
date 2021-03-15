<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Generate_Weave_PlanID.aspx.cs" Inherits="OPS_Generate_Weave_PlanID" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Generate Plan "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label17" runat="server" Text="Plan Start Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtPlanStartDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtPlanStartDate_CalendarExtender" runat="server" 
                    TargetControlID="txtPlanStartDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPlanStartDate" Display="Dynamic" 
                    ErrorMessage="** Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 136px">
                <asp:Label ID="Label18" runat="server" Text="Plan End Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPlanEndDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtPlanEndDate_CalendarExtender" runat="server" 
                    TargetControlID="txtPlanEndDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPlanEndDate" Display="Dynamic" 
                    ErrorMessage="** Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
           <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label23" runat="server" Text="Expected Delivery"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtExpectedDelivery" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtExpectedDelivery_CalendarExtender" runat="server" 
                    TargetControlID="txtExpectedDelivery">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtExpectedDelivery" Display="Dynamic" 
                    ErrorMessage="** Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 136px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label19" runat="server" Text="Plan Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:DropDownList ID="ddlPlanType" runat="server" CssClass="combobox">
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                    <asp:ListItem>FortNight</asp:ListItem>
                    <asp:ListItem Selected="True">Monthly</asp:ListItem>
                    <asp:ListItem>Quaterly</asp:ListItem>
                    <asp:ListItem>Half Yearly</asp:ListItem>
                    <asp:ListItem>Yearly</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 136px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label20" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 136px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label22" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtDescription" Display="Dynamic" 
                    ErrorMessage="** Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click" ValidationGroup="A">Generate</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdPlanID" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="PLANID" DataSourceID="SqlDataSource1" 
                                EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                     <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypStatus" runat="server" Text='<%# Eval("Status") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TRANSNO" HeaderText="TRANSNO" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="TRANSNO" />
                                    <asp:BoundField DataField="PLANID" HeaderText="PLANID" ReadOnly="True" 
                                        SortExpression="PLANID" />
                                    <asp:BoundField DataField="PLANTYPE" HeaderText="PLANTYPE" 
                                        SortExpression="PLANTYPE" />
                                    <asp:BoundField DataField="PLANSTARTDATE" HeaderText="PLANSTARTDATE" 
                                        SortExpression="PLANSTARTDATE" />
                                    <asp:BoundField DataField="PLANENDDATE" HeaderText="PLANENDDATE" 
                                        SortExpression="PLANENDDATE" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" 
                                        SortExpression="Description" />
                                  <asp:BoundField DataField="Plant" HeaderText="Plant" 
                                        SortExpression="Plant" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                              SelectCommand="SELECT [TRANSNO], [PLANID], [PLANTYPE], Convert(varchar,[PLANSTARTDATE],101) as [PLANSTARTDATE], Convert(varchar,[PLANENDDATE],101) as [PLANENDDATE],  UPPER([Description]) AS Description,UPPER(Plant) AS Plant, CASE WHEN Activated='Y' THEN 'Activated' WHEN Activated='N' THEN 'Completed'WHEN Activated IS NULL THEN 'Not Started' END AS Status FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE ([STATUS] = @STATUS) AND PLANT= @Plant ORDER BY STATUS">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                      <asp:ControlParameter ControlID="ddlPlant" DefaultValue="" Name="Plant" 
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 116px">
                &nbsp;</td>
            <td class="NormalText" style="width: 152px">
                &nbsp;</td>
            <td class="NormalText" style="width: 136px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

