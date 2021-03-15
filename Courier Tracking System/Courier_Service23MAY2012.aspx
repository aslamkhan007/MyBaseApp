<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Service.aspx.cs" Inherits="Courier_Tracking_System_Courier_Service" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label18" runat="server" Text="Courier Service Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label22" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:Label ID="Label23" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText" style="width: 121px">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label19" runat="server" Text="Courier Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtCourier" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCourier" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label20" runat="server" Text="Short Description"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="NormalText" 
                    Width="300px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label24" runat="server" Text="Long Description"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtLongDescription" runat="server" CssClass="NormalText" 
                    Width="400px"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label25" runat="server" Text="Local Address"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtLocalAddress" runat="server" CssClass="NormalText" 
                    Width="400px"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label26" runat="server" Text="Contact Person Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtName" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label27" runat="server" Text="Phone No."></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label29" runat="server" Text="Email Address"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="NormalText" 
                    MaxLength="50" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label28" runat="server" Text="Office No."></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtOfficeNo" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                Fax</td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtFax" runat="server" CssClass="NormalText" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="lbl" runat="server" Text="WebSite Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtWebSite" runat="server" CssClass="NormalText" 
                    MaxLength="50" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="NormalText" Width="300px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText" style="width: 121px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" 
                    onclick="lnkAdd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc" 
                    onclick="lnkEdit_Click">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                    onclick="lnkDelete_Click">Delete</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                    TargetControlID="lnkDelete" ConfirmText="Are you sure ?">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
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
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg" Width="800px" 
                    ScrollBars="Both">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True" AutoGenerateColumns="False" 
                        DataKeyNames="Sr_No" DataSourceID="SqlDataSource1" Width="200%" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Sr_No" HeaderText="Sr_No" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Sr_No" />
                            <asp:BoundField DataField="UserCode" HeaderText="UserCode" 
                                SortExpression="UserCode" />
                            <asp:BoundField DataField="Courier_Service" HeaderText="Courier_Service" 
                                SortExpression="Courier_Service" />
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                SortExpression="DESCRIPTION" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" 
                                SortExpression="STATUS" />
                            <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" 
                                SortExpression="EntryDate" />
                            <asp:BoundField DataField="Contact_Person_Name" 
                                HeaderText="Contact_Person_Name" SortExpression="Contact_Person_Name" />
                            <asp:BoundField DataField="Local_Address" HeaderText="Local_Address" 
                                SortExpression="Local_Address" />
                            <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" 
                                SortExpression="PhoneNo" />
                            <asp:BoundField DataField="Email_Address" HeaderText="Email_Address" 
                                SortExpression="Email_Address" />
                            <asp:BoundField DataField="OfficeNumber" HeaderText="OfficeNumber" 
                                SortExpression="OfficeNumber" />
                            <asp:BoundField DataField="FaxNumber" HeaderText="FaxNumber" 
                                SortExpression="FaxNumber" />
                            <asp:BoundField DataField="WebSite" HeaderText="WebSite" 
                                SortExpression="WebSite" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        
                        
                        
                        SelectCommand="SELECT [Sr_No], [UserCode], [Courier_Service], [DESCRIPTION], [STATUS],Convert(varchar, [EntryDate],103) as [EntryDate], [Contact_Person_Name], [Local_Address], [PhoneNo],[Email_Address], [OfficeNumber], [FaxNumber], [WebSite] FROM [jct_Courier_Service_Master] WHERE ([STATUS] = @STATUS)">
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

