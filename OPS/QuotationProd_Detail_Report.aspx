<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="QuotationProd_Detail_Report.aspx.vb" Inherits="OPS_QuotationProd_Detail_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 86%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Product Detail Summary Report
            </td>
        </tr>
      
        <tr>
            
            <td class="NormalText" >
                Quotation Date From</td>
            <td class="NormalText" style="width: 132px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:calendarextender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:calendarextender>

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom" ValidationGroup="ab"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 118px" >
                Quotation Date To</td>
            <td >
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:calendarextender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:calendarextender>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo" ValidationGroup="ab"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td class="NormalText" style="width: 120px">
                Quotation No.</td>
            <td class="NormalText" style="width: 132px">
                               <asp:TextBox ID="txtQuotation" runat="server" CssClass="textbox"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="txtQuotation" ValidationGroup="ab"
                    ErrorMessage="Please Specify QuotationNo."></asp:RequiredFieldValidator>--%>
            </td>
        <td style="width: 118px"></td>
        
        <td></td>
        
        </tr>
       
        <tr>
        <td>
           <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
        </td></tr>
             

            <td class="buttonbackbar" colspan="4">
                   <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="ab"
                    onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                    </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
    </table>
      <asp:Panel ID="Panel2" runat="server" Width="86%" Height="500px" ScrollBars="both">
  
  <table style="width: 126%;">

    <tr>
    <td>Authorized Quotations</td>
    </tr>
        <tr>
            <td>
               <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
               <ContentTemplate>
               
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Quotation_No" 
                        EmptyDataText="No Relevant Quotation is found." EnableModelValidation="True" Width="858px">
                        <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                        <Columns>
                       

                                 <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="~/OPS/Quotation_Main.aspx"
                                        Target="_blank" />

                                 <asp:BoundField DataField="Greige Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Greige Date">
                                <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>

                                   <asp:BoundField DataField="Greige Remarks" HeaderText="Greige Remarks" 
                                SortExpression="Greige Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                                <asp:BoundField DataField="Finish Date" HeaderText="Finish Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Finish Date">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                                 <asp:BoundField DataField="Finish Remarks" HeaderText="Finish Remarks" 
                                SortExpression="Finish Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>

                        </Columns>
                         <HeaderStyle CssClass="GridHeader" Wrap="False" />
                        <RowStyle CssClass="GridItem" Wrap="False" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>



               </ContentTemplate>
               </asp:UpdatePanel>
  
             </td>
            </tr>
  </table>
  </asp:Panel>
  
</asp:Content>

