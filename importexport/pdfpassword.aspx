<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pdfpassword.aspx.cs" Inherits="importexport_pdfpassword" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPlaceHolder1" runat="Server">
    <style type="text/css">
        input[type=checkbox] {
            margin: 3px 3px 3px 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <FarPoint:FpSpread ID="FpSpread1" runat="server" BorderColor="#A0A0A0" BorderStyle="Solid"
        BorderWidth="1px">
        <CommandBar BackColor="#F6F6F6" ButtonFaceColor="Control" ButtonHighlightColor="ControlLightLight"
            ButtonShadowColor="ControlDark" ShowPDFButton="True">
            <Background BackgroundImageUrl="SPREADCLIENTPATH:/img/cbbg.gif"></Background>
        </CommandBar>
        <Sheets>
            <FarPoint:SheetView SheetName="Sheet1">
            </FarPoint:SheetView>
        </Sheets>

        <TitleInfo BackColor="#E7EFF7" ForeColor="" HorizontalAlign="Center" VerticalAlign="NotSet" Font-Size="X-Large"></TitleInfo>
    </FarPoint:FpSpread>
</asp:Content>

