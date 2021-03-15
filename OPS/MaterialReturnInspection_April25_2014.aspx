<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturnInspection.aspx.cs" Inherits="OPS_MaterialReturnInspection" %>

<script runat="server">

 
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Material Return Inspection"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                                <asp:GridView ID="grdInspection" runat="server" Width="1005px" EnableModelValidation="True" OnSelectedIndexChanged="grdInspection_SelectedIndexChanged">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridRow" />
                                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                <table style="width:100%;">
                    <tr>
                        <td style="height: 17px; text-align: center;">
                            <asp:Label ID="Label17" runat="server" Text="MATERIAL RETURN GOODS DETAIL"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="Label18" runat="server" Text="Request ID - "></asp:Label>
                            <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td style="width: 284px; text-align: center; height: 17px;">
                            <asp:Label ID="lbl" runat="server">Request Data ( By Marketing)</asp:Label>
                        </td>
                        <td style="text-align: right; height: 17px;">
                            
                            &nbsp;</td>
                        <td style="text-align: center; height: 17px;"><asp:Label ID="lbl0" runat="server">Inspection Data</asp:Label></td>
                    </tr>
                </table>
                <table  style="width:100%" class="tableback">
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl1" runat="server">Party / Customer Name</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPartyName" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPartyName_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            MR No</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lbmrno" runat="server" Text="[lbMRno_ins]"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl2" runat="server">Invoice No</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceNo_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 284px">
                            <asp:Label ID="lbl3" runat="server">Sort No</asp:Label>
                        </td>
                        <td style="height: 17px">
                            <asp:Label ID="lblSortNo" runat="server"></asp:Label>
                        </td>
                        <td style="height: 17px">
                            <asp:Label ID="lblSortNo_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td style="width: 284px">
                            <asp:Label ID="lbl4" runat="server">Shade</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShade" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShade_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl5" runat="server">Invoice Qty</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceQty" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceQty_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl6" runat="server">Return Qty</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReturnQty" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReturnQty_ins" runat="server" Columns="8" CssClass="textbox" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtReturnQty_ins" Display="Dynamic" 
                                ErrorMessage="** Please mention return qty." ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl7" runat="server">No. of Rolls</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRolls" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRolls_ins" runat="server" Columns="5" CssClass="textbox" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtRolls_ins" Display="Dynamic" 
                                ErrorMessage="** Please mention number of rolls." ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl8" runat="server">Reason</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReason" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReason_ins" runat="server" CssClass="combobox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl9" runat="server">Inspection Remarks</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInspectionRemarks" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInspectionRemarks" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtInspectionRemarks" Display="Dynamic" 
                                ErrorMessage="**Please give remarks." ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl10" runat="server">Invoice Date</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl11" runat="server">Authorized Date</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAuthorizedDate" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAuthorizedDate_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl12" runat="server">Sales Person</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSalesPerson_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl13" runat="server">Plant</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlant" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlant_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl14" runat="server">Freight Paid By</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFreightPaidBy" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFreightPaidBy_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 284px">
                            <asp:Label ID="lbl15" runat="server">Freight Value</asp:Label>
                        </td>
                        <td style="height: 17px">
                            <asp:Label ID="lblFreightValue" runat="server"></asp:Label>
                        </td>
                        <td style="height: 17px">
                            <asp:Label ID="lblFreightValue_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">
                            <asp:Label ID="lbl16" runat="server">Inspection Done By</asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblInspectionDoneBy_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 284px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 284px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td style="width: 389px">
                            <asp:Label ID="lbl17" runat="server">Authorization History</asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:GridView ID="grdAuthorizationHistory" runat="server" Width="1005px">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridRow" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    </table>
                <table style="width:100%;">
                    <tr>
                        <td class="buttonbackbar" colspan="3">
                            <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" OnClick="lnkSubmit_Click">Submit</asp:LinkButton>
                            <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 389px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 389px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 389px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>

