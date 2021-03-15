<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="JCT_Payroll_Tax_Master_Update_Comparision.aspx.cs" Inherits="Payroll_JCT_Payroll_Tax_Master_Update_Comparision" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
       <tr>
            <td class="tableheader" colspan="4">
                Tax Salary Details Comparision
            </td>
        </tr>
        <tr>
            <td class="labelcells">
              Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" 
                    DataValueField="Deduction_code" AutoPostBack="True">                   
                    <asp:ListItem >Tax Salary Details</asp:ListItem>
                    <asp:ListItem Selected="True">Comparision</asp:ListItem>
                          <asp:ListItem>HRA Affidavit</asp:ListItem>
                                       
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>

        <tr>
            <td class="labelcells" style="height: 23px">
                Plant</td>
            <td class="NormalText" style="height: 23px">

            <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                            </asp:DropDownList>

 <%--               <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="plant_name" 
                    DataValueField="Plant_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" SELECT  plant_name,Plant_code FROM jctpayroll_PlantMaster WHERE Status='A'">
                </asp:SqlDataSource>--%>
            </td>
            <td class="labelcells" style="height: 23px">
                </td>
            <td class="NormalText" style="height: 23px">


<%--                <asp:DropDownList ID="ddllocation" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="Location_description" 
                    DataValueField="Location_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" SELECT '' as  Location_code,'' as Location_description union SELECT  Location_code,Location_description FROM JCT_payroll_location_master WHERE Status='A'">
                </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddllocation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
          <tr>
            <td class="labelcells">
                FromPeriod</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                ToPeriod</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodates" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" 
                    Width="32px" onclick="lnkexcel_Click"></asp:LinkButton>
                </td>
            <td class="NormalText">
                
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                        onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkfreeeze" runat="server" CssClass="buttonc" 
                        onclick="lnkfreeeze_Click" ValidationGroup="A">Freeze</asp:LinkButton>--%>
                    <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                        OnClick="lnkReset_Click" ValidationGroup="A">Reset</asp:LinkButton>
                </ContentTemplate>
                </asp:UpdatePanel>

          
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" 
                            Width="950px">
                          <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found " 
                                EnableModelValidation="True" onrowdatabound="grdDetail_RowDataBound" 
                                       >
                        <AlternatingRowStyle CssClass="GridAI" />
                              <Columns>              
                              </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="Griditem" />
                    </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>





