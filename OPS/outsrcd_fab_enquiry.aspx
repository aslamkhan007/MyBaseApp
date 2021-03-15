<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsrcd_fab_enquiry.aspx.cs" Inherits="OPS_outsrcd_fab_enquiry" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader">
                Outsourced Fabric Enquiry</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                    Width="900px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                        onselectedindexchanged="grdDetail_SelectedIndexChanged">
                   
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
                <asp:Panel ID="Panel2" runat="server" CssClass="panelbg" Width="900px">
                    <asp:RadioButtonList ID="RDlst" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="RDlst_SelectedIndexChanged" RepeatColumns="2">
                    </asp:RadioButtonList>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <table style="width: 100%;" class="tableback">
     <tr>
            <td class="NormalText" colspan="6">
                &nbsp;</td>
        </tr>
     <tr>
            <td class="NormalText">
                Vendor Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtvendor" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtvender_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="vendorfab" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtvendor">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Rate/mtr</td>
            <td class="NormalText">
                <asp:TextBox ID="txtrate" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtrate" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                RateType</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlratetype" runat="server" CssClass="combobox">
                    <asp:ListItem>EX-Mills</asp:ListItem>
                    <asp:ListItem>FOR</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
     <tr>
            <td class="NormalText">
                Agent</td>
            <td class="NormalText">
                <asp:TextBox ID="txtagent" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                ValidationDate</td>
            <td class="NormalText">
                <asp:TextBox ID="txtvaliddate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtvaliddate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtvaliddate">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
     <tr>
            <td class="NormalText">
                Quantity required</td>
            <td class="NormalText">
                <asp:TextBox ID="txtqtyreq" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtqtyreq_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtqtyreq" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Fabric Type</td>
           <td class="NormalText">
                <asp:TextBox ID="txtfbtype" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtfbtype_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" 
                    ServiceMethod="ops_fetch_itemtype" ServicePath="~/webservice.asmx" 
                    TargetControlID="txtfbtype">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Payment/delivery terms</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpayment" runat="server" CssClass="textbox" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="NormalText">
                Delivery upto</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdeli" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Delivery date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdelivdt" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtdelivdt_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtdelivdt" 
                    WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
                <cc1:CalendarExtender ID="txtdelivdt_CalendarExtender" runat="server" 
                    TargetControlID="txtdelivdt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Parallel sort(if any)</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Sale order (if any)</td>
            <td>
                <asp:TextBox ID="txtso" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                New number(if any)</td>
            <td>
                <asp:TextBox ID="txtnum" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Finish fabric`s customer name</td>
            <td>
                <asp:TextBox ID="txtcust" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtcust_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtcust">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Reference marketing executive</td>
            <td>
                <asp:TextBox ID="txtmkt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtmkt_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="mktnames" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtmkt">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Freight charges</td>
            <td>
                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Buyer</asp:ListItem>
                    <asp:ListItem>supplier</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Packing Details</td>
            <td>
                <asp:DropDownList ID="ddlpack" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Roll</asp:ListItem>
                    <asp:ListItem>Lump</asp:ListItem>
                    <asp:ListItem>Taka</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Special specification (if any)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtspecial" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lbprchse" runat="server" Text="Purchase(mtr)" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpurchase" runat="server" CssClass="textbox" Width="50px" 
                    Visible="False"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtpurchase_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtpurchase" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                <asp:Label ID="lbfinshprice" runat="server" Text="Finish Sale price" 
                    Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfinishsale" runat="server" CssClass="textbox" Width="50px" 
                    Visible="False"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                Remarks
                <br />
                <asp:TextBox ID="txtremark" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Height="51px" Width="611px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
            <tr>
            <td class="NormalText" colspan="6">
                &nbsp;</td>
        </tr>


            <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>
              <tr>
            <td class="NormalText">
                Ends/inch</td>
            <td>
                <asp:TextBox ID="txtends" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtends_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtends" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                Picks/inch</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpicks" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtpicks_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtpicks" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                Warp Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtwarp" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Weft Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtweft" runat="server" CssClass="textbox" MaxLength="20" 
                    Width="80px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Grey Width</td>
            <td>
                <asp:TextBox ID="txtgreywidth" runat="server" CssClass="textbox" MaxLength="20" 
                    Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Finish Width</td>
            <td>
                <asp:TextBox ID="txtfinishwidth" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Blend percent</td>
            <td>
                <asp:TextBox ID="txtblend" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Selvage</td>
            <td>
                <asp:TextBox ID="txtselvage" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Peice Length</td>
            <td>
                <asp:TextBox ID="txtpiece" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtpiece_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtpiece" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Weave</td>
            <td>
                <asp:TextBox ID="txtweave" runat="server" CssClass="textbox"  Width="50px" ></asp:TextBox>
            </td>
            <td class="NormalText">
                Weaved on</td>
            <td>
                <asp:TextBox ID="txtweaveon" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Weight(gsm)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtwgt" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtwgt_FilteredTextBoxExtender" runat="server" 
                    TargetControlID="txtwgt" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                BS(weft)</td>
            <td>
                <asp:TextBox ID="txtBSweft" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                TS(weft)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtTSweft" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Grab(weft)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtgrabweft" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                BS(warp)</td>
            <td>
                <asp:TextBox ID="txtBSwarp" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                TS(warp)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtTSwarp" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Grab(warp)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtgrabwarp" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Shrinkage%(warp)</td>
            <td>
                <asp:TextBox ID="txtshrnkwarp" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                MPS</td>
            <td class="NormalText">
                <asp:TextBox ID="txtMPS" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Abrasion</td>
            <td class="NormalText">
                <asp:TextBox ID="txtAbrasion" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Shrinkage%(weft)</td>
            <td>
                <asp:TextBox ID="txtshrnkweft" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                CIE</td>
            <td class="NormalText">
                <asp:TextBox ID="txtCIE" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Absorbency</td>
            <td class="NormalText">
                <asp:TextBox ID="txtabsorbency" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                pH of Fabric</td>
            <td>
                <asp:TextBox ID="txtpH" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Tegewa</td>
            <td class="NormalText">
                <asp:TextBox ID="txttegewa" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Points/100Linear</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpoint" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
        </tr>

     
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkclr" runat="server" CssClass="buttonc" 
                    onclick="lnkclr_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click">Freezevendor</asp:LinkButton>
            </td>
        </tr>
        </table>

    </asp:Content>

