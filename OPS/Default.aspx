<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage_Default.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="OPS_Default" %>
<%@ Register assembly="obout_Show_Net" namespace="OboutInc.Show" tagprefix="obshow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<obshow:Show ID="Show1" runat="server" Height="100%"
                    ImagesShowPath="../image/quotes" TransitionType="Fading" Width="100%"
                    FadingStep="2" FixedScrolling="True" StopScrolling="True"
                    TimeBetweenPanels="5000" CSSPath="ob_show_panel" FadeFirstPanel="True" 
                    StartTimeDelay="5000">
<Changer Type="Arrow" ArrowType="Side1" Position="Bottom" VerticalAlign="Middle" HorizontalAlign="Center"></Changer>
                </obshow:Show>
    </asp:Content>

