using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
public partial class opentextfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        // 初期化
        FpSpread1.CommandBar.Visible = false;
        FpSpread1.CssClass = "spreadStyle";
    }

    private void InitSpread(FarPoint.Web.Spread.SheetView sheet)
    {
        // SPREAD設定
        FpSpread1.CommandBar.Visible = false;
        FpSpread1.CssClass = "spreadStyle";
        FpSpread1.UseClipboard = false;

        // フォントサイズの設定
        sheet.DefaultStyle.Font.Size = FontUnit.Point(9);
        sheet.ColumnHeader.DefaultStyle.Font.Size = FontUnit.Point(9);
        sheet.RowHeader.DefaultStyle.Font.Size = FontUnit.Point(9);
        sheet.SheetCorner.DefaultStyle.Font.Size = FontUnit.Point(9);

        // シート設定
        sheet.PageSize = sheet.RowCount;

        // 列幅の設定
        sheet.Columns[0].Width = 35;
        sheet.Columns[1].Width = 80;
        sheet.Columns[2].Width = 90;
        sheet.Columns[3].Width = 68;
        sheet.Columns[4].Width = 40;
        sheet.Columns[5].Width = 38;
        sheet.Columns[6].Width = 50;
        sheet.Columns[7].Width = 70;
        sheet.Columns[8].Width = 173;

        // 縦方向の揃え位置を中央に設定
        sheet.DefaultStyle.VerticalAlign = VerticalAlign.Middle;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        string filepath = Server.MapPath("~/App_Data/spread.csv");

        try
        {
            // CSVファイルからインポート
            FpSpread1.Sheets[0].LoadTextFile(filepath, true, FarPoint.Web.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly, "\r\n", ",", "\"");

            InitSpread(FpSpread1.Sheets[0]);            
        }
        catch (System.Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
    var badstringFromDatabase = "生年月日";
    var recovered1 = System.Text.Encoding.GetEncoding(932).GetBytes(badstringFromDatabase); //Shift JIS
    var recovered4 = System.Text.Encoding.GetEncoding(50220).GetBytes(badstringFromDatabase); //ISO-2022-JP
    var recovered6 = System.Text.Encoding.GetEncoding(50222).GetBytes(badstringFromDatabase); //ISO-2022-JP
    var recovered7 = System.Text.Encoding.GetEncoding(65001).GetBytes(badstringFromDatabase); //UTF-8
    var recovered8 = System.Text.Encoding.GetEncoding(1200).GetBytes(badstringFromDatabase); //UTF-16
    var recovered9 = System.Text.Encoding.GetEncoding(12000).GetBytes(badstringFromDatabase); //UTF-32
    var recovered10 = System.Text.Encoding.GetEncoding(12001).GetBytes(badstringFromDatabase); //UTF-32BE
    var recovered11 = System.Text.Encoding.GetEncoding(65000).GetBytes(badstringFromDatabase); //UTF-7
    Response.Write("Shift JIS: " + System.Text.Encoding.GetEncoding(932).GetString(recovered1)); //Shift JIS
    Response.Write(System.Environment.NewLine);
    Response.Write("ISO-2022-JP: " + System.Text.Encoding.GetEncoding(932).GetString(recovered4)); //ISO-2022-JP
    Response.Write(System.Environment.NewLine);
    Response.Write("ISO-2022-JP: " + System.Text.Encoding.GetEncoding(932).GetString(recovered6)); //ISO-2022-JP
    Response.Write(System.Environment.NewLine);
    Response.Write("UTF-8: " + System.Text.Encoding.GetEncoding(932).GetString(recovered7)); //UTF-8
    Response.Write(System.Environment.NewLine);
    Response.Write("UTF-16: " + System.Text.Encoding.GetEncoding(932).GetString(recovered8)); //UTF-16
    Response.Write(System.Environment.NewLine);
    Response.Write("UTF-32: " + System.Text.Encoding.GetEncoding(932).GetString(recovered9)); //UTF-32
    Response.Write(System.Environment.NewLine);
    return;

    // クライアント側の変更を確定
    FpSpread1.SaveChanges();

        // Spreadコントロールをクリア
        FpSpread1.Reset();

        // 初期化
        FpSpread1.CommandBar.Visible = false;
        FpSpread1.CssClass = "spreadStyle";

        FarPoint.Web.Spread.SheetView wkSheet = new FarPoint.Web.Spread.SheetView();
        FpSpread1.Sheets.Add(wkSheet);
    }

    protected void btnDownLoad_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();

        string filepath = Server.MapPath("~/App_Data/spread.csv");

        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment;filename=spread.csv");
        Response.Flush();
        Response.WriteFile(filepath);
        Response.End();
    }
}