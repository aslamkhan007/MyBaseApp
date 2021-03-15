<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_job_work_req.aspx.cs" Inherits="OPS_outsourced_job_work_req" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="8">
                Job Work Request</td>
        </tr>
        <tr>
            <td colspan="8">
                RequestID&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbid" runat="server" Text="lbid" Visible="False"></asp:Label>
            &nbsp;</td>
        </tr>
        <tr>
            <td>
                Production</td>
            <td>
                <asp:DropDownList ID="ddlprod" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Regular</asp:ListItem>
                    <asp:ListItem>Sampling</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                SortNo</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox" 
                    ontextchanged="txtsort_TextChanged"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtsort" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                Quantity Required</td>
            <td>
                <asp:TextBox ID="txtqtyreq" runat="server" CssClass="textbox" 
                    ValidationGroup="A"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtqtyreq_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtqtyreq" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtqtyreq" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                Consumption</td>
            <td>
                <asp:TextBox ID="txtconsumption" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtconsumption_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtconsumption" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                Marketing Executive</td>
            <td>
                <asp:TextBox ID="txtmkt" runat="server" CssClass="textbox"></asp:TextBox>

                            <cc1:AutoCompleteExtender ID="txtmkt_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="mktnames" TargetControlID="txtmkt" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList">
                        </cc1:AutoCompleteExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtmkt" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                Product Type</td>
            <td>
                <asp:DropDownList ID="ddlproducttype" runat="server" CssClass="combobox">
                    <asp:ListItem>test</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                FabricType</td>
            <td>
                <asp:TextBox ID="txtfabtype" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Freight Charges</td>
            <td>
                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                    <asp:ListItem>Buyer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                PackingDetail</td>
            <td>
                <asp:DropDownList ID="ddlpacking" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Roll</asp:ListItem>
                    <asp:ListItem>Lump</asp:ListItem>
                    <asp:ListItem>Taka</asp:ListItem>
                    <asp:ListItem>BoxPacking</asp:ListItem>
                    <asp:ListItem>Bags</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Size</td>
            <td>
                <asp:TextBox ID="txtsize" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                Stlye</td>
            <td>
                <asp:DropDownList ID="ddlstyle" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Bales</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Payment Delivery Term</td>
            <td>
                <asp:TextBox ID="txtpayterms" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                DeliveryUpto</td>
            <td>
                <asp:TextBox ID="txtdeliupto" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                DeliveryDate</td>
            <td>
                <asp:TextBox ID="txtdeliverydt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdeliverydt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdeliverydt">
                </cc1:CalendarExtender>
            </td>
            <td>
                Finish Sale Price</td>
            <td>
                <asp:TextBox ID="txtfinishsaleprice" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtfinishsaleprice_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtfinishsaleprice" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtfinishsaleprice" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Memo Date</td>
            <td>

                  <div id="divwidth" style="display:none;">   
                            </div>  

           <%--     <cc1:AutoCompleteExtender ID="txtmkt_AutoCompleteExtender" runat="server" 
                     CompletionInterval="100" 
                       CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="mktnames" 
                 DelimiterCharacters="" Enabled="True" ServicePath="~/webservice.asmx" TargetControlID="txtmkt">
                </cc1:AutoCompleteExtender>--%>

                
                <asp:TextBox ID="txtmemo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtmemo_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtmemo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtmemo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

                
            </td>
            <td>
                DNV Cost</td>
            <td>
                <asp:TextBox ID="txtdnv" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdnv_FilteredTextBoxExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdnv" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtdnv" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                UOM</td>
            <td>
                <asp:DropDownList ID="ddluom" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddluom_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PCS</asp:ListItem>
                    <asp:ListItem>MTR</asp:ListItem>
                    <asp:ListItem>SET</asp:ListItem>
                    <asp:ListItem>PARALLEL</asp:ListItem>
                    <asp:ListItem>Kg</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Remarks</td>
            <td>
                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" Height="50px" 
                    TextMode="MultiLine" Width="180px"></asp:TextBox>
            </td>
            <td colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                    AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="8">
                <asp:LinkButton ID="lnk" runat="server" CssClass="buttonc" onclick="lnk_Click" 
                    ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" Visible="False">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>


</asp:Content>

