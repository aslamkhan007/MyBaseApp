<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Delivery_Type.aspx.cs" Inherits="Courier_Tracking_System_Courier_Delivery_Type" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Courier Delivery Type"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label22" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label23" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label19" runat="server" Text="Delivery Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtDeliveryType" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDeliveryType" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label20" runat="server" Text="Short Description"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtShortDescription" runat="server" CssClass="NormalText" Width="300px" 
                    MaxLength="100"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtShortDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label24" runat="server" Text="Long Description"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtLongDescription" runat="server" CssClass="NormalText" Width="300px" 
                    MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="NormalText" Width="400px" 
                    MaxLength="100" Height="40px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" 
                    onclick="lnkAdd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc" 
                    onclick="lnkEdit_Click">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                    onclick="lnkDelete_Click">Delete</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFirst" runat="server" CssClass="buttonc">First</asp:LinkButton>
                <asp:LinkButton ID="lnkNext" runat="server" CssClass="buttonc">Next</asp:LinkButton>
                <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
                <asp:LinkButton ID="lnkLast" runat="server" CssClass="buttonc">Last</asp:LinkButton>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="3">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg" ScrollBars="Both" 
                    Width="800px">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True" AutoGenerateColumns="False" 
                        DataKeyNames="Sr_no" DataSourceID="SqlDataSource1" AllowPaging="True" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="200%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Sr_no" HeaderText="Sr_no" 
                                SortExpression="Sr_no" InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="DeliveryType" HeaderText="DeliveryType" 
                                SortExpression="DeliveryType" />
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                SortExpression="DESCRIPTION" />
                            <asp:BoundField DataField="LongDesc" HeaderText="LongDesc" 
                                SortExpression="LongDesc" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                                SortExpression="Remarks" />
                            <asp:BoundField DataField="EffecFrom" HeaderText="EffecFrom" 
                                SortExpression="EffecFrom" />
                            <asp:BoundField DataField="EffecTo" HeaderText="EffecTo" 
                                SortExpression="EffecTo" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        
                        
                        SelectCommand="SELECT [Sr_no], [DeliveryType], [DESCRIPTION], [LongDesc], [Remarks],Convert(varchar, [EffecFrom],103) as [EffecFrom], Convert(varchar,[EffecTo],103) as [EffecTo]  FROM [jct_courier_Delivery_Type] WHERE ([STATUS] = @STATUS)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

