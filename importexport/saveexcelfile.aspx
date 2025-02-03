<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
         CodeFile="saveexcelfile.aspx.cs" Inherits="importexport_saveexcelfile" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPlaceHolder1" runat="Server">
    <style type="text/css">
        .Exdiv {
            margin-top: 10px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <div class="Exdiv">
        <asp:Label ID="Label1" runat="server" Text="ファイルの種類"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="xls">BIFF8(xls)</asp:ListItem>
            <asp:ListItem Value="xlsx">Open XML(xlsx)</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="CheckBox1" runat="server" Style="margin-left: 10px" Text="フィルター結果をそのまま" />
        <asp:CheckBox ID="CheckBox2" runat="server" Style="margin-left: 10px" Text="ヘッダを含める" />

    </div>
    <asp:Button ID="Button1" runat="server" Style="margin-top: 10px" Width="200px" Height="30px" Text="Excelファイルへエクスポート" OnClick="Button1_Click" />

</asp:Content>
