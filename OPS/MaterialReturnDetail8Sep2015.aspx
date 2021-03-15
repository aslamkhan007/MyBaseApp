<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturnDetail.aspx.cs" Inherits="OPS_MaterialReturnDetail" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Material Return Detail"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label17" runat="server" Text="Request Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 125px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label18" runat="server" Text="Request Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label19" runat="server" Text="Sanction ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 125px">
                <asp:TextBox ID="txtSanctionID" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 105px">
                &nbsp;</td>
            <td class="NormalText">
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
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdDetail" runat="server" 
                                EmptyDataText="No data available" EnableModelValidation="True" 
                                onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="

SELECT  RequestID ,
        customer ,
        invoice_no ,
        item_no ,
        invoice_qty ,
        ret_qty AS [Return Qty],Sr_no as SrNo
FROM    dbo.jct_ops_material_request
WHERE   ( Convert(varchar,RequestID) = @RequestID or @RequestID='') 
            	AND AuthStatus='A'
                 AND convert(varchar,RequestID)+ convert(varchar,sr_no) NOT IN (SELECT convert(varchar,RequestID)+ CONVERT(VARCHAR, ISNULL(Req_SrNo,'')) FROM JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION WHERE STATUS='A' AND AuthStatus IN ('A','P') and ( Convert(varchar,RequestID) = @RequestID or @RequestID='')  and status='A')
                   AND (USERID=@EMPCODE OR @EMPCODE='A-00098') ">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSanctionID" DefaultValue=" " 
                                        Name="RequestID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtDateFrom" DefaultValue=" " Name="DateFrom" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtDateTo" DefaultValue=" " Name="DateTo" 
                                        PropertyName="Text" />
                                    <asp:SessionParameter Name="EMPCODE" SessionField="EmpCode" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" 
        UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlEdit" runat="server" CssClass="panelbg" Visible="False">
                            <table style="width:100%;">
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        <asp:Label ID="lblSrNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID" runat="server">RequestID</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="lblC" runat="server">Customer</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID0" runat="server">Invoice No</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID1" runat="server">Item No</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblItemNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID2" runat="server">Invoice Qty</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblInvoiceQty" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID3" runat="server">Return Qty</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblReturnQty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID4" runat="server">No of Bales</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblBales" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID5" runat="server">Freight Paid By</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblFreightBy" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID6" runat="server">Gr No</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtGrNo" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID7" runat="server">GR Date(mm/dd/yyyy)</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:TextBox ID="txtGrDate" runat="server" CssClass="textbox"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtGrDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtGrDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID8" runat="server">Freight Value (Amount)</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        &nbsp;</td>
                                    <td class="NormalText">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label1" runat="server">Enclosures</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBoxList ID="chbEnclosures" runat="server" AutoPostBack="True" 
                                                    onselectedindexchanged="chbEnclosures_SelectedIndexChanged1" RepeatColumns="2" 
                                                    Width="200px">
                                                    <asp:ListItem>Packing List</asp:ListItem>
                                                    <asp:ListItem>Customer Challan</asp:ListItem>
                                                    <asp:ListItem>LC Copy</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtEnclosures" runat="server" CssClass="textbox" 
                                                    Visible="False" Width="200px"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="chbEnclosures" 
                                                    EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        &nbsp;</td>
                                    <td class="NormalText">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="4">
                                        <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" 
                                            onclick="lnkSubmit_Click">Submit</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdDetail" 
                            EventName="SelectedIndexChanged" />
                     <asp:AsyncPostBackTrigger ControlID="lnkSubmit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
           
</asp:Content>

<%--SELECT  RequestID ,
        customer ,
        invoice_no ,
        item_no ,
        invoice_qty ,
        ret_qty AS [Return Qty]
FROM    dbo.jct_ops_material_request
WHERE   ( Convert(varchar,RequestID) = @RequestID or @RequestID='') 
            	AND AuthStatus='A'
                 AND RequestID NOT IN (SELECT RequestID FROM JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION WHERE STATUS='A' AND AuthStatus IN ('A','P'))
                   AND USERID=@EMPCODE">--%>