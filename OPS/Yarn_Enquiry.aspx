﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Yarn_Enquiry.aspx.cs" Inherits="OPS_Yarn_Enquiry" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Material Yarn&nbsp; 
                Enquiry</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="1000px" 
                    Height="300px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True"  EmptyDataText="No Specifications Available Defined To Search Vendors For Yarn Request..!!"
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel2" runat="server" CssClass="panelbg" Width="800px">
                    <asp:RadioButtonList ID="RDlst" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="RDlst_SelectedIndexChanged">
                    </asp:RadioButtonList>
                      <asp:LinkButton ID="lnkcomparision" runat="server" 
                    onclick="lnkcomparision_Click" Visible="False">Comparison</asp:LinkButton>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Vender Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtvender" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtvender_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="vendornames" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtvender">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Offered Quality</td>
            <td class="NormalText">
                <asp:TextBox ID="txtoffrquqlity" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Offered Quantity</td>
            <td class="NormalText">
                <asp:TextBox ID="txtqty" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                UOM</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddluom" runat="server" CssClass="combobox">
                    <asp:ListItem>M.T</asp:ListItem>
                    <asp:ListItem>Kgs</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Delivery Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdlidt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdlidt_CalendarExtender" runat="server" 
                    TargetControlID="txtdlidt">
                </cc1:CalendarExtender>
                <cc1:TextBoxWatermarkExtender ID="txtdlidt_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="txtdlidt" WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="NormalText">
                Payment Terms</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpaytrm" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Rate Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlrate" runat="server" CssClass="combobox">
                    <asp:ListItem>ExMill</asp:ListItem>
                    <asp:ListItem>FOR</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Basic Rate/Kg</td>
            <td class="NormalText">
                <asp:TextBox ID="txtbasic" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                landed rate/kg</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlandrate" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
             <td colspan="4" style="font-weight: bold; font-size: 10pt;">
                Specification</td>
        </tr>
         <tr>
            <td class="NormalText">
                Actual count/Denier</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcount" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Count Cv%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcountcv" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Countname</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcountname" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Tenacity</td>
            <td class="NormalText">
                <asp:TextBox ID="Txttenacity" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Elongation</td>
            <td class="NormalText">
                <asp:TextBox ID="txtelongation" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Lusture</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlust" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                OPU</td>
            <td class="NormalText">
                <asp:TextBox ID="txtOPU" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Nips/mtr</td>
            <td class="NormalText">
                <asp:TextBox ID="txtnip" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                BWS</td>
            <td class="NormalText">
                <asp:TextBox ID="txtBWS" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                CSP(not 
                less than)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtCSP" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                U%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtu" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                IPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtIPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Hairiness</td>
            <td class="NormalText">
                <asp:TextBox ID="txtHair" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                TPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtTPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Blend%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtBlend" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                All faults</td>
            <td class="NormalText">
                <asp:TextBox ID="txtallfaults" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Classimate Faults<br />
                (as per classimate quantum result)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtclassimate" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Major Short Thick<br />
                (A4+B4+C3+C4+D3+D4)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtmajorthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Short Thick<br />
                (A3+B3+C2+D2)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtshortthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Long Thick(E+F+G)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlngthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Thin Faults(H1)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtthinfaults" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Major Thin(H2+l1+l2)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtmajorthin" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Lycra/spandex %</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlycrapercnt" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Lycra/spandex(Denier)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlycradenier" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                    onclick="lnkSave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="Lnkclear" runat="server" CssClass="buttonc" 
                    onclick="Lnkclear_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="lnkfrezvend" runat="server" CssClass="buttonc" 
                    onclick="lnkfrezvend_Click">FreezeVendors</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

