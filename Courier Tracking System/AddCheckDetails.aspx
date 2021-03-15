<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCheckDetails.aspx.cs" Inherits="OPS_AddCheckDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript">
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CancelEdit() {
                GetRadWindow().close();
            }
        </script>
        <asp:ScriptManager ID="ScriptManager2" runat="server" />
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0"  GridLines="None" 
            onitemdatabound="RadGrid1_ItemDataBound" 
            onitemcommand="RadGrid1_ItemCommand">
<MasterTableView  >
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            HeaderText="Save" UniqueName="TemplateColumn">
            <ItemTemplate>
                <telerik:RadButton ID="radbtnSave" runat="server" Text="Save" 
                    CommandArgument="Save" CommandName="Save">
                </telerik:RadButton>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="ID" 
            FilterControlAltText="Filter ID column" HeaderText="ID" UniqueName="ID">
            <ItemTemplate>
                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
          <telerik:GridTemplateColumn DataField="InvoiceNo" 
            FilterControlAltText="Filter InvoiceNo column" HeaderText="InvoiceNo" 
            UniqueName="InvoiceNo">
            <ItemTemplate>
                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>

        <telerik:GridTemplateColumn DataField="AWBNo" 
            FilterControlAltText="Filter AWBNo column" HeaderText="AWBNo" 
            UniqueName="AWBNo">
            <ItemTemplate>
                <asp:Label ID="lblAwbNo" runat="server" Text='<%# Eval("AWBNo") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="Carrier" 
            FilterControlAltText="Filter Carrier column" HeaderText="Carrier" 
            UniqueName="Carrier">
            <ItemTemplate>
                <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="ChequeNo" 
            FilterControlAltText="Filter ChequeNo column" HeaderText="ChequeNo" 
            UniqueName="ChequeNo">
            <ItemTemplate>
                <telerik:RadTextBox ID="radtxtChequeNo" Runat="server" Width="100px">
                </telerik:RadTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="ChequeAmt" 
            FilterControlAltText="Filter ChequeAmt column" HeaderText="ChequeAmt" 
            UniqueName="ChequeAmt">
            <ItemTemplate>
                <telerik:RadTextBox ID="radtxtChequeAmt" Runat="server" Width="100px">
                </telerik:RadTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="ChequeDate" 
            FilterControlAltText="Filter ChequeDate column" HeaderText="ChequeDate" 
            UniqueName="ChequeDate">
            <ItemTemplate>
                <telerik:RadDatePicker ID="radDtPckrChequeDate" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40px" 
                        Width="100px">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />
                </telerik:RadDatePicker>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <br />
       


        
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
            SelectCommand="SELECT ID AS ID,AWBNo,Carrier,CheckNo,CheckAmt,CONVERT(VARCHAR,CheckDate,101) AS CheckDate FROM dbo.JCT_COURIER_COD_CASH_COLLECTION WHERE AWBNo=@AWBNo">
            <SelectParameters>
                <asp:SessionParameter Name="AWBNo" SessionField="AWBNo" />
            </SelectParameters>
        </asp:SqlDataSource>
       


        <br />
      
    
        <br />
       
    
    </div>
    </form>
</body>
</html>
