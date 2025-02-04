<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
         CodeFile="openexcelfile.aspx.cs" Inherits="importexport_openexcelfile" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="ファイルの種類"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="xls">BIFF8(xls)</asp:ListItem>
        <asp:ListItem Value="xlsx">Open XML(xlsx)</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Excelファイルのインポート" 
        onclick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="SPREADのクリア" 
        onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="インポートファイルのダウンロード" 
        onclick="Button3_Click" />
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