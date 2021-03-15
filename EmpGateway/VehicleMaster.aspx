<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false" CodeFile="VehicleMaster.aspx.vb" Inherits="EmpGateway_VehicleMaster" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%">
  <asp:ScriptManager ID="ScriptManager1" runat="server" 
                                AsyncPostBackTimeout="1800">
                            </asp:ScriptManager>
        <tr>
            <td  colspan="2" align="center" class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Font-Bold="True"
                    Font-Names="Trebuchet MS" Font-Size="10pt" Text="Vehicle Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells">
                &nbsp;</td>
            <td style="height: 17px;">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblVehicleName" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Vehicle Name" Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox ID="txtVehicleName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RF2" runat="server" ValidationGroup="b"  ControlToValidate="txtVehicleName" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblVehicleType" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Vehicle Type" Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox CssClass="textbox" ID="txtVehicleType" runat="server" Width="200px" ></asp:TextBox><asp:RequiredFieldValidator
                    ID="RF1" runat="server" ValidationGroup="b"   ControlToValidate="txtVehicleType" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>

          <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblVehicleNo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Vehicle No." Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox  CssClass="textbox" ID="txtVehicleNo" runat="server" Width="200px" ></asp:TextBox><asp:RequiredFieldValidator
                    ID="RF3" runat="server" ValidationGroup="b"  ControlToValidate="txtVehicleNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>



          <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblVehicleModelNo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Vehicle Model No." Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox  CssClass="textbox" ID="txtVehicleModelNo" runat="server" Width="200px" ></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ValidationGroup="b"  ControlToValidate="txtVehicleModelNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>


        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Vehicle Version(Petrol/Diesel)." Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox CssClass="textbox" ID="txtVehicleMake" runat="server" Width="200px" ></asp:TextBox>
                    </td>
        </tr>
           <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblPurchaseDate" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Purchase Date." Width="112px"></asp:Label></td>
            <td style="height: 17px;">
               <asp:TextBox  CssClass="textbox" ID="txtPurchaseDate" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ValidationGroup="b"  ControlToValidate="txtPurchaseDate" ErrorMessage="*">*</asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtPurchaseDate">
                </cc1:CalendarExtender>
                    </td>
        </tr>
          <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblPlate" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Plate Type" Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox CssClass="textbox" ID="txtplate" runat="server" Width="200px" ></asp:TextBox>
                    </td>
        </tr>


        <tr>
           <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="lblFrom" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Effective From" Width="112px"></asp:Label></td>
            <td style="height: 17px;">
               <asp:TextBox  CssClass="textbox" ID="txtfrom" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ValidationGroup="b"  ControlToValidate="txtfrom" ErrorMessage="*">*</asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtfrom">
                </cc1:CalendarExtender>
                    </td>
            <td colspan="1" >
               <asp:Label ID="Lbleffectiveto" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Effective To" Width="112px"></asp:Label></td>
            <td colspan="1">
                    <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                      <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ValidationGroup="b"  ControlToValidate="txtDateTo" ErrorMessage="*">*</asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender></td>
        </tr>

        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Effective To Remarks" Width="112px"></asp:Label></td>
            <td style="height: 17px;">
                <asp:TextBox ID="txtRemarks" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                    </td>
        </tr>


        <tr>
            <td align="center" colspan="4" 
                style="height: 16px; background-color: whitesmoke;" class="buttoncbar">
                <asp:LinkButton ID="btnIns" runat="server" CssClass="buttonc" Text="Insert"  ValidationGroup="b"/>
                
                </td>
                </tr>


                
        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                &nbsp;</td>
            <td style="height: 17px;">
                &nbsp;</td>
        </tr>
        <tr >
        <td colspan="4">
        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdvehicle" runat="server" EnableModelValidation="True" Width="100%"
                                EmptyDataText="No Cost Sheet Available">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                 
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>

        </td>
        
        </tr>
        </table>
</asp:Content>

