<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
         CodeFile="savehtml.aspx.cs" Inherits="importexport_saveexcelfile" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Button ID="Button1" runat="server" Text="ダウンロード" 
        onclick="Button1_Click" />
    <FarPoint:FpSpread ID="FpSpread1" runat="server" BorderColor="#A0A0A0" BorderStyle="Solid"
        BorderWidth="1px">
        <CommandBar BackColor="#F6F6F6" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight"
            ButtonShadowColor="ControlDark">
        </CommandBar>
        <Sheets>
            <FarPoint:SheetView SheetName="Sheet1">
            </FarPoint:SheetView>
        </Sheets>
    </FarPoint:FpSpread>
</asp:Content>