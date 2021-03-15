<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="exchangerate.aspx.cs" Inherits="OPS_exchangerate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">

        <link href="js/CSS.css" rel="stylesheet" type="text/css" />
        <script src="js/Extension.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function checkDate(sender, args) 
        {

            var obj = document.getElementById("<%=txteff_from.ClientID%>");

            alert(obj);

            var dt = new Date();
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth()+1

            var yyyy = today.getFullYear();
            dt = mm + '/' + dd + '/' + yyyy;

            alert(dt);
            alert(obj);

            if (obj < dt) {

                alert(dt);
                alert(sender._selectedDate);
                    alert("you cannot select a day earlier than today!");
              
                

                sender._textbox
            .set_Value(dt.format(sender._format));
            }
           

        }         
        
                </script>



        <tr>
            <td colspan="4" class="tableheader">
                Exchange Rate</td>
        </tr>





        <tr>
            <td class="NormalText">
                <asp:Label ID="currencyrate" runat="server" Text="Currency Code" 
                    CssClass="NormalText"></asp:Label>
            </td>
            <td class="NormalText"> 
                <asp:DropDownList ID="ddlcurrencycode" runat="server" CssClass="combobox"  AutoPostBack="true"
                    onselectedindexchanged="ddlcurrencycode_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="IndianRupees">INR</asp:ListItem>
                    <asp:ListItem Value="Us Dollar">USD</asp:ListItem>
                    <asp:ListItem Value="Euro">EUR</asp:ListItem>
                     <asp:ListItem Value="Great Britain Pound">GBP</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                <asp:Label ID="currency_desc" runat="server" Text="Currency Desc" 
                    CssClass="NormalText"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtcurrencydesc" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="exchangerate" runat="server" Text="Exchange Rate" 
                    CssClass="Normal"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtexchangerate" runat="server" CssClass="textbox"></asp:TextBox>
               
                <cc1:FilteredTextBoxExtender ID="txtexchangerate_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtexchangerate" ValidChars="1234567890.">
                </cc1:FilteredTextBoxExtender>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtexchangerate" ErrorMessage="cannot be blank" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
               
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="effectedfrom" runat="server" Text="Effected From" 
                    CssClass="Normal"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_from" runat="server"  AutoPostBack="true" CssClass="textbox" 
                    ontextchanged="txteff_from_TextChanged"></asp:TextBox>
       <asp:ImageButton runat="server" ID="imgPopup" ImageUrl="~/Image/calendar.png" 
                    style="width: 16px"  />
                <cc1:CalendarExtender ID="txteff_from_CalendarExtender" runat="server" 
                    Enabled="True" PopupButtonID="imgPopup"
                    TargetControlID="txteff_from">
                </cc1:CalendarExtender>

                

            </td>
            <td class="NormalText">
                <asp:Label ID="effecteto" runat="server" Text="Effected To" CssClass="Normal"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True"  TargetControlID="txteff_to" PopupButtonID="ImageButton1">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 26px" class="buttonbackbar">
                <asp:LinkButton ID="update" runat="server" CssClass="buttonc" 
                    onclick="add_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkClear" runat="server" CssClass="buttonc" 
                    onclick="lnkClear_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:GridView ID="grdDetail" runat="server" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

