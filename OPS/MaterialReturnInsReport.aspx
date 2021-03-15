<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturnInsReport.aspx.cs" Inherits="OPS_MaterialReturnInsReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Material Return Inspection Report</td>
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
            <td class="NormalText">
                DateFrom</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdatefrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                DateTo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                RequestID</td>
            <td class="NormalText">
                <asp:TextBox ID="txtID" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    onclick="LinkButton2_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
              <asp:GridView ID="grdMaterialRequest" runat="server" 
                                EnableModelValidation="True" Width="100%" >
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:HyperLinkField HeaderText="Preview"  Text="Preview"  DataNavigateUrlFields="Requestid,transid" 
                                      DataNavigateUrlFormatString="MailContentPages/materialReturnMail.aspx?requestid={0}&transid={1}" 
                                        DataTextField="RequestID" DataTextFormatString="Preview" Target="_blank" />
                                           <asp:TemplateField>
                                  <ItemTemplate>
           
                                      </div>
                                              
                                        </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

