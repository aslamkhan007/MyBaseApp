<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_fab_specs.aspx.cs" Inherits="OPS_outsourced_fab_specs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr class="tableheader">
            <td colspan="6">
                &nbsp;
                &nbsp;Outsourced Fabric Specification&nbsp;
            </td>
        </tr>

        <tr>
            <td class="NormalText">
                RequestID</td>
            <td class="NormalText">
                <asp:TextBox ID="txtreq" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/OPS/Image/searchBlueSmall.PNG" onclick="ImageButton1_Click" 
                    style="height: 16px" />
            </td>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>


        <tr>
            <td class="NormalText" colspan="6">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="900px" Height="300px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True"   OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
            <td class="NormalText" colspan="6">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px">
                    <asp:GridView ID="grdDetail2" runat="server" onselectedindexchanged="grdDetail2_SelectedIndexChanged" 
                  
                      >
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
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" 
                    onclick="lnkapply_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkclr" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                <asp:LinkButton ID="lnkupdt" runat="server" CssClass="buttonc" Visible="False">Update</asp:LinkButton>
            </td>
        </tr>
    </table>

 </asp:Content>

