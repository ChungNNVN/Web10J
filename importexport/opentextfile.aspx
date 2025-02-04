<%@ Page MasterPageFile="~/MasterPage.master" Language="c#" AutoEventWireup="true" 
         Inherits="opentextfile" CodeFile="opentextfile.aspx.cs" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="インポート" onclick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="クリア" onclick="Button2_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDownLoad" runat="server" Text="インポートファイルのダウンロード" 
        onclick="btnDownLoad_Click"/>
    <farpoint:FpSpread ID="FpSpread1" runat="server" BorderColor="#A0A0A0" BorderStyle="Solid"
        BorderWidth="1px">
        <CommandBar BackColor="#F6F6F6" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight"
            ButtonShadowColor="ControlDark" />
        <Sheets>
            <farpoint:SheetView SheetName="Sheet1">
            </farpoint:SheetView>
        </Sheets>
    </farpoint:FpSpread>
</asp:Content>