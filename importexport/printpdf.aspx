<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="printpdf.aspx.cs" Inherits="importexport_printpdf" %>

<%@ Register Assembly="FarPoint.Web.SpreadJ" Namespace="FarPoint.Web.Spread" TagPrefix="FarPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="PDF出力" onclick="Button1_Click" />
        </td>
        <td>先頭行idx</td>
        <td>
            <asp:DropDownList ID="DDLstartrowidx" runat="server" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td>先頭列idx</td>
        <td>
            <asp:DropDownList ID="DDLstartcolidx" runat="server" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td">行数</td>
        <td>
            <asp:DropDownList ID="DDLrowcnt" runat="server" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td>列数</td>
        <td>
            <asp:DropDownList ID="DDLcolcnt" runat="server" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        </tr>
    </table>    
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

