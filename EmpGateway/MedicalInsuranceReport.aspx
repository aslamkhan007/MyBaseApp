<%@ Page Title="" Language="C#" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="true" CodeFile="MedicalInsuranceReport.aspx.cs" Inherits="EmpGateway_MedicalInsuranceReport" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label16" runat="server" Text="Medical Insurance Report"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 169px">
                <asp:Label ID="Label17" runat="server" Text="Select Financial Year"></asp:Label>
            </td>
            <td class="NormalText">

            <telerik:RadComboBox ID="ddlFinYear" runat="server"  DataSourceID="SqlDataSource1" DataTextField="FinancialYear" 
                    DataValueField="FinancialYear" Skin="Metro"></telerik:RadComboBox>
               
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT DISTINCT [FinancialYear] FROM [GMEIS2] order by FinancialYear desc">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 169px">
                <telerik:RadButton ID="radAutoUpdate" runat="server" 
                    onclick="radAutoUpdate_Click" Skin="Metro" Text="AutoUpdate" 
                    ToolTip="Click here to fetch the data of employees who haven't submitted data but has previous years data. So, clicking here will take same entries from previous years to this year..">
                </telerik:RadButton>
                <cc1:ConfirmButtonExtender ID="radAutoUpdate_ConfirmButtonExtender" 
                    runat="server" 
                    ConfirmText="Do you want to updata previous data for remaining employees ?" 
                    TargetControlID="radAutoUpdate">
                </cc1:ConfirmButtonExtender>
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
                <telerik:RadButton ID="radFetch" runat="server" 
                    onclick="radFetch_Click" Skin="Metro" Text="Fetch Record">
                </telerik:RadButton>
               
                <telerik:RadButton ID="radExcel" runat="server" 
                    onclick="radExcel_Click" Skin="Metro" Text="Excel">
                </telerik:RadButton>
                
            </td>
        </tr>
        </table>
        <table>
        <tr>
            
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                    AllowPaging="True" AllowSorting="True" CellSpacing="0" 
                     GridLines="None" Skin="Metro">
  <MasterTableView autogeneratecolumns="False" datasourceid="SqlDataSource2" 
                        DataKeyNames="ecode,ecode">
    <DetailTables>
        <telerik:GridTableView runat="server" AllowFilteringByColumn="False" 
            AllowNaturalSort="False" DataKeyNames="ecode" 
            DataSourceID="SqlDataSource3">
            <ParentTableRelation>
                <telerik:GridRelationFields DetailKeyField="ecode" MasterKeyField="ecode" />
            </ParentTableRelation>
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                Visible="True">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
            <PagerStyle PageSizeControlType="RadComboBox" />
        </telerik:GridTableView>
    </DetailTables>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ecode" 
            FilterControlAltText="Filter ecode column" HeaderText="ecode" 
            SortExpression="ecode" UniqueName="ecode">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="Name" 
            SortExpression="Name" UniqueName="Name">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dept" 
            FilterControlAltText="Filter dept column" HeaderText="dept" 
            SortExpression="dept" UniqueName="dept">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Designation" 
            FilterControlAltText="Filter Designation column" HeaderText="Designation" 
            SortExpression="Designation" UniqueName="Designation">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DOB" DataType="System.DateTime" 
            FilterControlAltText="Filter DOB column" HeaderText="DOB" SortExpression="DOB" 
            UniqueName="DOB">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Age" DataType="System.Double" 
            FilterControlAltText="Filter Age column" HeaderText="Age" SortExpression="Age" 
            UniqueName="Age">
        </telerik:GridBoundColumn>
          <telerik:GridBoundColumn DataField="Entry_Date" DataType="System.DateTime" 
            FilterControlAltText="Filter Entry_Date column" HeaderText="Entry Date" SortExpression="Entry_Date" 
            UniqueName="Entry_Date">
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="EntitlementAmount" DataType="System.Int32" 
            FilterControlAltText="Filter EntitlementAmount column" HeaderText="Sum Insured" SortExpression="EntitlementAmount" 
            UniqueName="EntitlementAmount">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="SELECT DISTINCT a.ecode AS [ecode] ,a.Name AS [Name] ,a.dept AS [dept] ,a.Designation AS [Designation] ,a.DOB AS [DOB] ,a.Age AS [Age] ,a.Entry_Date [Entry_Date] ,  b.EntitlementAmount AS [EntitlementAmount] FROM    [GMEIS2] AS a LEFT OUTER JOIN [Medical_Entitlement] AS b ON a.Designation = b.Desg AND b.STATUS = 'A' WHERE   ( a.Relation = @Relation ) AND ( a.STATUS = @STATUS ) AND ( a.FinancialYear = @FinancialYear ) AND ( a.Mode = @Mode )">                    
                    <%--SelectCommand="SELECT DISTINCT [ecode], [Name], [dept], [Designation], [DOB]   , [Age],[Entry_Date] FROM [GMEIS2] WHERE ([Relation] = @Relation) AND ([STATUS] = @STATUS) AND ([FinancialYear] = @FinancialYear) AND ([Mode] = @Mode)">--%>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="SELF" Name="Relation" Type="String" />
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        <asp:ControlParameter ControlID="ddlFinYear" Name="FinancialYear" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="SUBMIT" Name="Mode" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="SELECT DISTINCT [ecode], [Name], [Relation], [Age], Convert(varchar,[DOB],103) as [DOB (dd/mm/yyyy)] FROM [GMEIS2] WHERE (([STATUS] = @STATUS) AND ([FinancialYear] = @FinancialYear) AND ([Mode] = @Mode) AND ([Relation] &lt;&gt; @Relation) and ecode=@ecode  )">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        <asp:ControlParameter ControlID="ddlFinYear" Name="FinancialYear" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="SUBMIT" Name="Mode" Type="String" />
                        <asp:Parameter DefaultValue="SELF" Name="Relation" Type="String" />
                        
                        <asp:SessionParameter DefaultValue="" Name="ecode" SessionField="ecode" />
                        
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
            </asp:UpdatePanel>
              
            </td>
        </tr>
        </table>
</asp:Content>

