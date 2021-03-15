<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="IncomeTax.aspx.vb" Inherits="IncomeTax" Title="Income Tax" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Income Tax Computation for Financial Year (2010 - 2011)"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="labelcells">
                Sr.No.
            </td>
            <td class="labelcells" colspan="2">
                Particulars
            </td>
            <td class="labelcells">
                Rupees
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                1
            </td>
            <td class="labelcells" colspan="2">
                Salary, Leave Encahment, Bonus, House Rent Allowance etc.
            </td>
            <td>
                <asp:TextBox ID="TxtGtdSsal" runat="server" CssClass="TextBack" Font-Names="Tahoma"
                    Font-Size="8pt" Height="12px" ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                2
            </td>
            <td colspan="2" class="labelcells">
                Deduct amount of House rent allowance exempt under section 10(13A)
            </td>
            <td class="textcells">
                <strong><span >
                    <asp:TextBox ID="TxtGhra" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox></span></strong>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                3
            </td>
            <td colspan="2" class="labelcells">
                Value of prequisties :-&nbsp;
                <br />
                Accomdation, Furniture, Electricty, Water, LTA, Conveyance, Intrest free loan, Medical
                <span>Reimbursement (Above Rs.
                    15,000) , Movable assets, Others, etc.</span></span></strong>
            </td>
            <td class="textcells">
                <strong><span >
                    <asp:TextBox ID="TxtGsub" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox></span></strong>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                4
            </td>
            <td colspan="2" class="labelcells">
                <span><strong>Gross Income from salary</strong></span>
            </td>
            <td class="textcells">
                <strong><span >
                    <asp:TextBox ID="TxtGincome" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox></span></strong>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                5
            </td>
            <td bgcolor=" " colspan="2" class="labelcells">
                <span>
                    <strong>Any other income : Bank/NSC, Housing Loan&nbsp; Interest</strong></span>
            </td>
            <td class="textcells">
                <ew:NumericBox ID="TxtOthIncome" runat="server" AutoPostBack="True" Width="90px" CssClass="textbox"
                    BackColor="#FFC0C0"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                6
            </td>
            <td colspan="2" class="labelcells">
                <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                    mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Gross total income
            </td>
            <td class="textcells">
                <asp:TextBox ID="TxtGGross" runat="server" CssClass="TextBack" Font-Names="Tahoma"
                    Font-Size="8pt" Height="12px" ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                7
            </td>
            <td colspan="2" class="labelcells">
                Deduction under section 80C                
                <br />
                <strong><span>a) </span></strong><strong>
                    <span ><span><span>PF/VPF &amp; PF
                        arrear<br />
                    </span>b) LIC, MF &nbsp;Unit, PPF, NSC Interest, Bank FDR, Housing Loa (Principal),
                        ELSS, Tuition fees, Pension fund &nbsp;&nbsp;&nbsp;</span></span></strong>
            </td>
            <td class="textcells">
                <asp:TextBox ID="TxtGpf" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox>
                <br />
                <ew:NumericBox ID="Txt7a" runat="server" AutoPostBack="True" BackColor="#FFC0C0"
                    Height="12px" Width="90px"></ew:NumericBox>
            </td>
        </tr>
        <tr class="labelcells">
            <td class="labelcells">
                8
            </td>
            <td colspan="2" class="labelcells">
                <strong><span >1) </span></strong><strong>
                    <span ><span><span>Medical Insurance&nbsp;
                        u/s 80D &nbsp; &nbsp;(Restricted to Rs. 15,000)
                        <br />
                        <br />
                    </span>2)</span></span></strong><strong><span><span><span>
                        Handi dependent u/s 80DD &nbsp; &nbsp; (Restricted to Rs. 75,000)
                        <br />
                        <br />
                    </span>3) </span></span></strong><span><strong><span><span
                        >Handicap &nbsp;u/s 80U &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; (Restricted to Rs. 75,000)
                        <br />
                        <br />
                        4) PM Fund/Higher Education <span ><span>&nbsp;u/s 80E/80G</span></span></span></span></strong></span>
            </td>
            <td class="textcells">
                <ew:NumericBox ID="Txt8a" runat="server" AutoPostBack="True" BackColor="#FFE0C0"
                    Height="12px" Width="90px"></ew:NumericBox><br />
                <ew:NumericBox ID="Txt8b" runat="server" AutoPostBack="True" BackColor="#FFE0C0"
                    Height="12px" Width="90px"></ew:NumericBox><br />
                <ew:NumericBox ID="Txt8c" runat="server" AutoPostBack="True" BackColor="#FFE0C0"
                    Height="12px" Width="90px"></ew:NumericBox><br />
                <ew:NumericBox ID="Txt8d" runat="server" AutoPostBack="True" BackColor="#FFE0C0"
                    Height="12px" Width="90px"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 16px">
                9
            </td>
            <td colspan="2" class="labelcells" style="height: 16px">
                Net Taxable Income
            </td>
            <td  class="textcells" >
                <asp:TextBox ID="TxtTax_Income" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                10
            </td>
            <td colspan="2" class="labelcells">
                Calculated Tax
            </td>
            <td  class="textcells">
                <asp:TextBox ID="TxtGtax" runat="server" CssClass="textbox" ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                11
            </td>
            <td class="labelcells" colspan="2">
                Ecess
            </td>
            <td  >
                <asp:TextBox ID="TXTGecess" runat="server" CssClass="textbox" 
                    ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                12
            </td>
            <td colspan="2" class="labelcells">
                SHEcess
            </td>
            <td  >
                <asp:TextBox ID="txtGSHECESS" runat="server" CssClass="textbox"
                    ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                13
            </td>
            <td colspan="2" class="labelcells">
                Total Tax
            </td>
            <td  >
                <asp:TextBox ID="TxtTotal_Tax" runat="server" CssClass="textbox"
                    ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                14
            </td>
            <td colspan="2" class="labelcells">
                Per/Month Tax (Total Tax/12)
            </td>
            <td  >
                <asp:TextBox ID="TxtPerMonth" runat="server" CssClass="textbox"
                    ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                15
            </td>
            <td colspan="2" class="labelcells">
                Actual tax deducted in previous month's
            </td>
            <td class="textcells">
                <asp:TextBox ID="TxtGtax_ded" runat="server" CssClass="textbox"
                    ReadOnly="True" Width="90px"></asp:TextBox>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript" src="datetimepicker.js">

        //Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
        //Script featured on JavaScript Kit (http://www.javascriptkit.com)
        //For this script, visit http://www.javascriptkit.com 



    </script>

</asp:Content>
