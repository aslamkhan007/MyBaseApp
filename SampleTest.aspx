
<%@ Page Title="" Language="VB"  AutoEventWireup="false" CodeFile="SampleTest.aspx.vb" Inherits="CostingSystemTest_SampleTest" %>
<%@ Register src="GoogleDrivingDirections.ascx" tagname="GoogleDrivingDirections" tagprefix="uc1" %>
<%@ Register src="DirectionsAPI_Sample.ascx" tagname="DirectionsAPI_Sample" tagprefix="uc2" %>
<form id="form1" runat="server">

<asp:textbox runat="server" text="Phagwara" ID="t1"></asp:textbox>

<asp:textbox runat="server" text="jalandhar" ID="t2"></asp:textbox>
<asp:button runat="server" text="Get" onclick="Unnamed1_Click" />

<uc1:GoogleDrivingDirections ID="GoogleDrivingDirections1" runat="server" 
    APIKey="59546960665C68616A5B6C6B635C5325413F40423A40463D493F4544464644504E4F512" AutoLoad="True" FromAddress="phagwara" ToAddress="jalandhar"  />
     
<uc2:DirectionsAPI_Sample ID="DirectionsAPI_Sample1" runat="server"     APIKey="59546960665C68616A5B6C6B635C5325413F40423A40463D493F4544464644504E4F512" />
     
</form>
