<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="BeamRewinding.aspx.cs" Inherits="OPS_BeamRewinding" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label16" runat="server" Text="Beam Re-winding"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px; height: 17px">
                <asp:Label ID="Label17" runat="server" Text="Date"></asp:Label>
            </td>
            <td class="NormalText" style="height: 17px">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>

                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDate" ErrorMessage="**Required Field"></asp:RequiredFieldValidator>

            </td>
            <td class="NormalText" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="Label18" runat="server" Text="Issue No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtIssueNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtIssueNo" ErrorMessage="**Required Field"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="Label19" runat="server" Text="Beam No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBeamNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtBeamNo" ErrorMessage="**Required Field"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="Label20" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click1">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">
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
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdBeam" runat="server"  AutoGenerateColumns="false"
                            EmptyDataText=" No Beam No available." ShowFooter="True" Width="100%" 
                            EnableModelValidation="True" onrowdatabound="grdBeam_RowDataBound">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRewind" runat="server" CommandName="Rewind">Rewind</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issue No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIss_No" runat="server" Text='<%# Eval("iss_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Split">
                                    <ItemTemplate>
                                       <asp:Label ID="lblSplit" runat="server" Text='<%# Eval("split") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Flag">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlag" runat="server" Text='<%# Eval("flag") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Date">
                                    <ItemTemplate>
                                       <asp:Label ID="lblDate" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Sort No">
                                    <ItemTemplate>
                                       <asp:Label ID="lblSort_No" runat="server" Text='<%# Eval("sort_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Shed">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMc_Type" runat="server" Text='<%# Eval("mc_type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Beam No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeam_no" runat="server" Text='<%# Eval("beam_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField  HeaderText="Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrder_No" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField  HeaderText="Beam Length">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLength" runat="server" Text='<%# Eval("length") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField  HeaderText="Greigh Production">
                                    <ItemTemplate>
                                      <asp:TextBox ID="txtGreigh_Production" Width="50px" runat="server" Text='<%# Eval("greigh_production") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField  HeaderText="Length Remaining">
                                    <ItemTemplate>
                                      <asp:TextBox ID="txtRemainingLength" Width="50px" runat="server" Text='<%# Eval("remaining_length") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                   
                            <FooterStyle CssClass="FooterStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdRewindBeam" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdRewindBeam" runat="server" AutoGenerateColumns="False" 
                            EnableModelValidation="True" ShowFooter="True" 
                            onrowdatabound="grdRewindBeam_RowDataBound" 
                            onrowcommand="grdRewindBeam_RowCommand">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkReset"  runat="server" CommandName="Save">Save</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issue No">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIssueNo" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BeamNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBeamNo" runat="server" CssClass="textbox" Width="30px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Length">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLength" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="FooterStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdBeam" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="grdRewindBeam" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

