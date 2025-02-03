using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class savetextfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        // データ連結
        DataSet ds = new DataSet();
        ds.ReadXml(MapPath("../App_Data/datanum2.xml"));
        FpSpread1.DataSource = ds;

        // SPREAD初期化
        InitSpread(FpSpread1.Sheets[0]);
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
        sheet.Columns[0].Width = 45;
        sheet.Columns[1].Width = 85;
        sheet.Columns[2].Width = 221;
        sheet.Columns[3].Width = 65;
        sheet.Columns[4].Width = 65;
        sheet.Columns[5].Width = 65;
        sheet.Columns[6].Width = 65;

        // 縦方向の揃え位置を中央に設定
        sheet.DefaultStyle.VerticalAlign = VerticalAlign.Middle;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();
        FarPoint.Web.Spread.Model.IncludeHeaders saveFlg;

        // MemoryStreamに内容を出力
        System.IO.MemoryStream ms = new System.IO.MemoryStream();

        if (CheckBox1.Checked)
        {
            saveFlg = FarPoint.Web.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly;
        }
        else
        {
            saveFlg = FarPoint.Web.Spread.Model.IncludeHeaders.None;
        }

        FpSpread1.ActiveSheetView.SaveTextFile(ms, true, saveFlg, "\r\n", ",", "\"");

        // クライアント側に応答
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment;filename=spread.csv");
        Response.BinaryWrite(ms.ToArray());

        ms.Flush();
        ms.Close();
        Response.End();
    }
}