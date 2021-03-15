<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" Theme="OpsSkinFIle" AutoEventWireup="false" CodeFile="Order_Panel_Section.aspx.vb" Inherits="OPS_Order_Panel_Section" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Section Panel</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label5" runat="server" Text="Module"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" 
                            Width="210px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdClear" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label1" runat="server" Text="Page Name"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPageName" runat="server" Width="210px">
                        </asp:DropDownList>
                    </ContentTemplate>
                       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdClear" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label2" runat="server" Text="Section Name"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSectionName" runat="server" MaxLength="50"></asp:TextBox>
                    </ContentTemplate>
                       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdClear" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label3" runat="server" Text="Sequence"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSeq" runat="server" Width="50px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtSeq_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" FilterType="Numbers" TargetControlID="txtSeq">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdClear" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label4" runat="server" Text="Procedure Used"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProcedureUsed" runat="server" MaxLength="100" Width="403px"></asp:TextBox>
                    </ContentTemplate>
                       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdClear" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdSave" runat="server" CssClass="buttonc">Save</asp:LinkButton>
                        <asp:LinkButton ID="CmdClear" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                        <asp:LinkButton ID="CmdUpdate" runat="server" CssClass="buttonc" 
                            Enabled="False">Update</asp:LinkButton>
                        <asp:LinkButton ID="CmdDelete" runat="server" CssClass="buttonc">Delete</asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="CmdDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm Delete ?" TargetControlID="CmdDelete">
                        </cc1:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="labelcells">
                
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" 
                                AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                                 EnableModelValidation="True" 
                                onpageindexchanging="GridView1_PageIndexChanging" 
                                onselectedindexchanged="GridView1_SelectedIndexChanged" >
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="MODULE" HeaderText="MODULE" 
                                        SortExpression="MODULE" />
                                    <asp:BoundField DataField="SECTION_Name" HeaderText="SECTION_Name" 
                                        SortExpression="SECTION_Name" />
                                    <asp:BoundField DataField="Page_Name" HeaderText="Page_Name" 
                                        SortExpression="Page_Name" />
                                    <asp:BoundField DataField="ProcedureUsed" HeaderText="ProcedureUsed" 
                                        SortExpression="ProcedureUsed" />
                                    <asp:BoundField DataField="Default_Seq" HeaderText="Sequence" 
                                        SortExpression="Default_Seq" />
                                </Columns>
                           
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                
                                
                                
                                SelectCommand="SELECT [MODULE], [SECTION_Name], [Page_Name], [ProcedureUsed], [Default_Seq]  FROM [Jct_Ops_OrderPanel_Sections] WHERE ([STATUS] = @STATUS) ORDER BY [MODULE], [SECTION_Name], [Page_Name]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                  
                    <Triggers>
                     
                        <asp:AsyncPostBackTrigger ControlID="CmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUpdate" EventName="Click" />
                     
                    </Triggers>
                  
                </asp:UpdatePanel>
                
                </td>
        </tr>
    </table>

</asp:Content>

