<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanWiseOrderSummary.aspx.cs" Inherits="OPS_PlanWiseOrderSummary"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Plan History</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <script type="text/javascript">
          function CloseAndRebind(args) {
              GetRadWindow().Close();
              GetRadWindow().BrowserWindow.refreshGrid(args);
          }

          function GetRadWindow() {
              var oWindow = null;
              if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
              else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

              return oWindow;
          }

          function CancelEdit() {
              GetRadWindow().Close();
          }
        </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>


        <br />
        <telerik:RadGrid ID="radgrdOrderSummary" runat="server" AllowSorting="True" 
            CellSpacing="0" DataSourceID="SqlDataSource1" GridLines="None" 
            onitemdatabound="radgrdOrderSummary_ItemDataBound1" ShowFooter="True" 
            ShowGroupPanel="True">
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
<MasterTableView AllowSorting="False" DataKeyNames="ID,PLANID"  AutoGenerateColumns="false"
                DataSourceID="SqlDataSource1" ShowFooter="True" ShowGroupFooter="true" AllowMultiColumnSorting="true" >
                <Columns>
                <telerik:GridBoundColumn Aggregate="Count" DataField="Month" HeaderText="Month"
                    FooterText="Total Orders: ">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn   DataField="OrderNo" HeaderText="OrderNo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn   DataField="ItemNo" HeaderText="ItemNo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn   DataField="WeavingSort" HeaderText="WeavingSort">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn  Aggregate="Sum"  DataField="OrderQty" HeaderText="OrderQty">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn  Aggregate="Sum"  DataField="PlanQty" HeaderText="PlanQty">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn  Aggregate="Sum"  DataField="PlanQty" HeaderText="PlanQty">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn  Aggregate="Sum"  DataField="GreighReq" HeaderText="GreighReq">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn  Aggregate="Sum" DataField="GreighAdj" HeaderText="GreighAdj">
                </telerik:GridBoundColumn>

                  <telerik:GridBoundColumn  Aggregate="Sum" DataField="GreighRemaining" HeaderText="GreighRemaining">
                </telerik:GridBoundColumn>


                <telerik:GridBoundColumn  Aggregate="Sum" DataField="SizingReq" HeaderText="SizingReq">
                </telerik:GridBoundColumn>


                  <telerik:GridBoundColumn  Aggregate="Sum" DataField="SizingDone" HeaderText="SizingDone">
                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn  Aggregate="Sum" DataField="SizingRemaining" HeaderText="SizingRemaining">
                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn  Aggregate="Sum"  DataField="GreighProd" HeaderText="GreighProd">
                </telerik:GridBoundColumn>

                  <telerik:GridBoundColumn     DataField="PLANID" HeaderText="PLANID">
                </telerik:GridBoundColumn>

                  <telerik:GridBoundColumn     DataField="ID" HeaderText="ID">
                </telerik:GridBoundColumn>

                </Columns>
    <DetailTables>
        <telerik:GridTableView runat="server" AllowSorting="False" 
            DataKeyNames="ID,PLANID" DataSourceID="SqlDataSource2" >
            <ParentTableRelation>
                <telerik:GridRelationFields DetailKeyField="ID" MasterKeyField="ID" />
                <telerik:GridRelationFields DetailKeyField="PLANID" MasterKeyField="PLANID" />
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
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    

    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
        SelectCommand="JCT_OPS_PLANWEISE_ORDER_SUMMARY" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="OrderNo" QueryStringField="OrderNo" 
                Type="String" />
            <asp:QueryStringParameter Name="SortNo" QueryStringField="SortNo" 
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
        SelectCommand="JCT_OPS_PLANWEISE_ORDER_SUMMARY_DETAIL" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
            <asp:SessionParameter Name="PLANID" SessionField="PLANID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
