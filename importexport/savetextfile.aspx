<%@ Page MasterPageFile="~/MasterPage.master" Language="c#" AutoEventWireup="true"
    Inherits="savetextfile" CodeFile="savetextfile.aspx.cs" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderPlaceHolder1" runat="Server">
    <style type="text/css">
        .Exdiv {
            margin-bottom: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Exdiv">
        <asp:Button ID="Button1" runat="server" Style="margin-top: 10px" Width="200px" Height="30px" Text="ダウンロード" OnClick="Button1_Click" />
        <asp:CheckBox ID="CheckBox1" runat="server" Style="margin-left: 10px" Text="ヘッダを含める" />
    </div>
    <FarPoint:FpSpread ID="FpSpread1" runat="server" BorderColor="#A0A0A0" BorderStyle="Solid"
        BorderWidth="1px">
        <CommandBar BackColor="#F6F6F6" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight"
            ButtonShadowColor="ControlDark" />
        <Sheets>
            <FarPoint:SheetView SheetName="Sheet1">
            </FarPoint:SheetView>
        </Sheets>
    </FarPoint:FpSpread>
</asp:Content>
