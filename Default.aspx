<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Header1" ContentPlaceHolderID="HeaderPlaceHolder1" runat="server">
<style type="text/css">
.toppage_description_div
{ 
	margin-left: 20px;
	margin-right: 20px;
}
.toppage_description
{ 
	color: #464646; 
	text-align: center;
	vertical-align: top; 
	position: relative;	
	font-size: 80%;
    font-family: "メイリオ", Meiryo, Helvetica, Verdana, Arial, "ヒラギノ角ゴPro W3", "Hiragino Kaku Gothic Pro", Osaka, 
    "ＭＳ Ｐゴシック", sans-serif;
}
.toppage_image
{ 
	text-align: center;
	position: relative;
}
.toppage_precaution
{ 
	text-align: center;
	vertical-align: top; 
	position: relative;
	font-size: 80%;
    font-family: "メイリオ", Meiryo, Helvetica, Verdana, Arial, "ヒラギノ角ゴPro W3", "Hiragino Kaku Gothic Pro", Osaka, 
    "ＭＳ Ｐゴシック", sans-serif;
}
</style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >	
        <h2>SPREAD for ASP.NETデモアプリケーション</h2>
        <div id="description">
            <div class="toppage_image">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/mainvisual_aspnet_spread.png" AlternateText="SPREAD for ASP.NETデモアプリケーション" ToolTip="SPREAD for ASP.NETデモアプリケーション" />
            </div>
            <div class="toppage_description_div">
                <span class="toppage_description">
                <br />
                SPREAD for ASP.NETはWebアプリケーションでExcel&reg;のような外観や操作性を実現するASP.NETコンポーネントです。非同期処理によるページ切り替え、ソート、フィルタリングを実現しており、大量データに対する操作もユーザーはストレスなく行うことができます。また、豊富な表計算関数に加え、Excelファイル用の強力な入出力エンジンを備えておりExcelとのスムーズなデータ連携を実現します。
        　　　　<br />
                <br />
                このデモでは、SPREAD for ASP.NETの持つ基本的な機能を紹介しています。
                ソースコードも合わせて提供しておりますので、各機能の具体的な実装方法もご確認いただけます。  
            </span>
            <br />
            <br />
            <span class="toppage_precaution">[注意事項]
                <br />
                クライアントの要件については、製品付属のリリースノートの「必要システム」をご覧ください。<br />
                <br />
                サンプルではクライアント側スクリプトを使用しています。サンプルを実行する時にはクライアントのブラウザでJavaScriptを有効にしてください。
            </span>
            </div>
        </div>
</asp:Content>