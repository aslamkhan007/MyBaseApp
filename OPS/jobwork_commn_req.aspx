<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jobwork_commn_req.aspx.cs" Inherits="OPS_jobwork_commn_req" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">
                &nbsp;Request for Jobwork</td>
        </tr>
        <tr>
            <td style="width: 129px">
                <asp:Label ID="lbreqid" runat="server" Text="RequestID" Visible="False"></asp:Label>
            </td>
            <td style="width: 161px">
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td style="width: 149px">
                &nbsp;</td>
            <td style="width: 168px">
                &nbsp;</td>
            <td style="width: 146px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 129px">
                Plant</td>
            <td style="width: 161px">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 149px">
                Marketing Executive</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtmkt" runat="server" CssClass="textbox"></asp:TextBox>
              
                  <div id="divwidth2" style="display:none;">
                        <cc1:AutoCompleteExtender ID="txtmkt_AutoCompleteExtender" runat="server"
                            CompletionInterval="10" CompletionListCssClass="autocomplete_completionListElement" CompletionListElementID="divwidth2"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                            CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="mktnames" ServicePath="~/WebService.asmx"
                            TargetControlID="txtmkt">
                        </cc1:AutoCompleteExtender>
                    </div>

              
              
            </td>
            <td style="width: 146px">
                SortNo</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox" AutoPostBack="True" 
                    ontextchanged="txtsort_TextChanged" ValidationGroup="A"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtsort" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Contruction</td>
            <td style="width: 161px">
                <asp:TextBox ID="txtconstruction" runat="server" CssClass="textbox" 
                    AutoPostBack="True" Enabled="False"></asp:TextBox>
            </td>
            <td style="width: 149px">
                Shade No</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtshade" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 146px">
                Quantity</td>
            <td>
                <asp:TextBox ID="txtqty" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtqty_FilteredTextBoxExtender" runat="server" 
                    Enabled="True" TargetControlID="txtqty" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtqty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                FabricRate</td>
            <td style="width: 161px">
                <asp:TextBox ID="txtfabrate" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtfabrate_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtfabrate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtfabrate" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtfabrate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 149px">
                Value</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtvalue" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
            </td>
            <td style="width: 146px">
                Jobwork Type</td>
            <td>
                <asp:TextBox ID="txtjbtype" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Job Rate</td>
            <td style="width: 161px">
                <asp:TextBox ID="txtjbrate" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 149px">
                Nature of Job</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtnature" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 146px">
                Job ContractDate</td>
            <td>
                <asp:TextBox ID="txtjbcntrctdt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtjbcntrctdt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtjbcntrctdt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Job contractNo</td>
            <td style="width: 161px">
                <asp:TextBox ID="txtjbctrctno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 149px">
                &nbsp;</td>
            <td style="width: 168px">
                &nbsp;</td>
            <td style="width: 146px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 129px">
                Vendor</td>
          <td class="NormalText">
                <asp:TextBox ID="txtvendor" runat="server" CssClass="textbox"></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="txtvendor_AutoCompleteExtender" runat="server" 
                      CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="vendorfab" 
                    ServicePath="~/webservice.asmx"
                    TargetControlID="txtvendor">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtvendor" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                Delivery Date</td>
            <td style="width: 149px">
                <asp:TextBox ID="txtdelivdate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdelivdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdelivdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtdelivdate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 146px">
                Freight charges</td>
            <td style="width: 104px">
                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                    <asp:ListItem>Supplier</asp:ListItem>
                    <asp:ListItem>Buyer</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Elongation Bearer</td>
            <td style="width: 161px">
                <asp:DropDownList ID="ddlelong" runat="server" CssClass="combobox">
                    <asp:ListItem>Buyer</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 149px">
                Elongation %</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtelong" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 146px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 129px">
                Shrinkage Bearer</td>
            <td style="width: 161px">
                <asp:DropDownList ID="ddlshrink" runat="server" CssClass="combobox">
                    <asp:ListItem>Buyer</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 149px">
                Shrinkage %</td>
            <td style="width: 168px">
                <asp:TextBox ID="txtshrink" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td style="width: 146px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
       <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                    Visible="False" Width="900px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
       
       
       
        </tr>
        </table>
</asp:Content>

