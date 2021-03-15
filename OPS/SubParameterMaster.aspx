<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" Theme="OpsSkinFIle" AutoEventWireup="false" CodeFile="SubParameterMaster.aspx.vb" Inherits="OPS_SubParameterMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Sub Parameter Definition</td>
        </tr>
        <tr>
            <td>
                Parameter</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlParameter" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Height="20px" Width="197px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Sub Parameter"></asp:Label>
                </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlSubParam" runat="server" Width="197px">
                        </asp:DropDownList>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Type"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" Width="121px">
                            <asp:ListItem>Qualitative</asp:ListItem>
                            <asp:ListItem>Quantitative</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Value"></asp:Label>
                1</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtValue1" runat="server" MaxLength="8" Width="79px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtValue1_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="TxtValue1" 
                            ValidChars="1234567890.">
                        </cc1:FilteredTextBoxExtender>
                        <asp:CheckBox ID="ChkCopyValues" runat="server" AutoPostBack="True" 
                            ForeColor="#FF8080" 
                            Text="Click . If starting Value and Ending Values are same..." />
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Value2"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtValue2" runat="server" MaxLength="8" Width="79px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtValue2_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="TxtValue2" 
                            ValidChars="1234567890.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtRemarks" runat="server" MaxLength="150" Width="250px"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td>
                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtEffFrom" runat="server" AccessKey="d" CssClass="textbox" 
                                MaxLength="8" TabIndex="3" Width="70px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalFrom" runat="server" Animated="False" 
                                Format="MM/dd/yyyy" TargetControlID="TxtEffFrom">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="TxtEffFrom">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                ControlExtender="MaskedEditExtender1" ControlToValidate="TxtEffFrom" 
                                Display="Dynamic" EmptyValueMessage="*" 
                                InvalidValueMessage="The Date is invalid" IsValidEmpty="False" 
                                TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                        </ContentTemplate>
                         <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Effective Upto"></asp:Label>
            </td>
            <td>
                 <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                     <ContentTemplate>
                         <asp:TextBox ID="TxtEffTo" runat="server" CssClass="textbox" MaxLength="8" 
                             TabIndex="4" Width="70px"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalTo" runat="server" Animated="False" 
                             Format="MM/dd/yyyy" TargetControlID="TxtEffTo">
                         </cc1:CalendarExtender>
                         <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                             Mask="99/99/9999" MaskType="Date" TargetControlID="TxtEffTo">
                         </cc1:MaskedEditExtender>
                         <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
                             ControlExtender="MaskedEditExtender2" ControlToValidate="TxtEffTo" 
                             Display="Dynamic" EmptyValueMessage="*" 
                             InvalidValueMessage="The Date is invalid " IsValidEmpty="False" 
                             TooltipMessage="MM/DD/YYYY"></cc1:MaskedEditValidator>
                     </ContentTemplate>
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                 
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdSave" runat="server" CssClass="buttonc">Save</asp:LinkButton>
                        <asp:LinkButton ID="CmdUPdate" runat="server" CssClass="buttonc" 
                            Enabled="False">Update</asp:LinkButton>
                        
                        <asp:LinkButton ID="CmdClear" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                        <asp:LinkButton ID="cmdDelete" runat="server" CssClass="buttonc">Delete</asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="cmdDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm Delete ?" TargetControlID="cmdDelete">
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
                                    <asp:BoundField DataField="Paramcode" HeaderText="Paramcode" 
                                        SortExpression="Paramcode" />
                                    <asp:BoundField DataField="SubParamcode" HeaderText="SubParamcode" 
                                        SortExpression="SubParamcode" />
                                    <asp:BoundField DataField="Qualitative" HeaderText="Qualitative" 
                                        SortExpression="Qualitative" />
                                    <asp:BoundField DataField="value1" HeaderText="value1" 
                                        SortExpression="value1" />
                                    <asp:BoundField DataField="value2" HeaderText="value2" 
                                        SortExpression="value2" />
                                 <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                                        SortExpression="Remarks" />
                                          <asp:BoundField DataField="Eff_From" HeaderText="Eff_From" 
                                        SortExpression="Eff_From" />
                                          <asp:BoundField DataField="Eff_To" HeaderText="Eff_To" 
                                        SortExpression="Eff_To" />
                                </Columns>
                           
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                
                                SelectCommand="SELECT [Paramcode], [SubParamcode], [Qualitative], [value1], [value2], Remarks,Eff_From,Eff_To FROM [JCt_OPS_Sub_Parameters] WHERE ([STATUS] = @STATUS) ORDER BY [Paramcode], [SubParamcode]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                  
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CmdUPdate" EventName="Click" />
                    </Triggers>
                  
                </asp:UpdatePanel>
               
               </td>
        </tr>
    </table>
</asp:Content>

