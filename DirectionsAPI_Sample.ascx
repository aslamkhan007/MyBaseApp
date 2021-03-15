<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DirectionsAPI_Sample.ascx.cs" Inherits="Samples_User_Controls_DirectionsAPI_Sample" %>
<%@ Register Src="GoogleDrivingDirections.ascx" TagName="GoogleDrivingDirections"
    TagPrefix="uc1" %>

<fieldset title="Start Address" style="width:45%;float:left;padding:10px">
<legend>Start Address</legend>
<label>Street Address [optional]:</label>
<asp:textbox runat="server" id="txtfromStreet" /><br />
<label>City & State, or Zip code:</label>
<asp:textbox runat="server" ID="txtfromCityStateZip"></asp:textbox><asp:RequiredFieldValidator
    ID="rv1" runat="server" ControlToValidate="txtfromCityStateZip" ErrorMessage="<< Required"></asp:RequiredFieldValidator>
</fieldset>

<fieldset title="Destination" style="width:45%;float:right;padding:10px">
<legend>Destination</legend>
<label>Street Address [optional]:</label>
<asp:textbox runat="server" id="txttoStreet" /><br />
<label>City & State, or Zip code:</label>
<asp:textbox runat="server" id="txttoCityStateZip" /><asp:RequiredFieldValidator
    ID="rv2" ControlToValidate="txttoCityStateZip" runat="server" ErrorMessage="<< Required"></asp:RequiredFieldValidator>
</fieldset>

<br />
<asp:Button style="margin-top:15px" runat="server" ID="btnLoad" Text="Load Directions" OnClick="btnLoad_Click" />
<br />
<br />
<div style="width:48%;float:left">
<uc1:GoogleDrivingDirections APIKey="ABQIAAAA9JnCJ-XDwH5zeKCIiCTA0hRSbdt51EmCEFqq1nxm38OjobtZvRQMipBq1da9HpYZnvtPqFElV-j2LA" ID="gdirections" runat="server" MapElementID="dmap" />
</div>

<div id="dmap" style="width:48%;height:400px;border:solid 1px #99d;float:right"></div>
<br style="clear:both" />