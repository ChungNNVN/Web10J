using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class importexport_saveexcelfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // データ連結
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(MapPath("../App_Data/data.xml"));
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
        sheet.Protect = false;

        // 列幅の設定
        sheet.Columns[0].Width = 36;
        sheet.Columns[1].Width = 88;
        sheet.Columns[2].Width = 91;
        sheet.Columns[3].Width = 80;
        sheet.Columns[4].Width = 36;
        sheet.Columns[5].Width = 46;
        sheet.Columns[6].Width = 49;
        sheet.Columns[7].Width = 80;
        sheet.Columns[8].Width = 181;

        // 縦方向の揃え位置を中央に設定
        sheet.DefaultStyle.VerticalAlign = VerticalAlign.Middle;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // クライアント側の変更を確定
        FpSpread1.SaveChanges();        

        // MemoryStreamに内容を出力
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        FpSpread1.ActiveSheetView.SaveHtml(ms);

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=spread.html");
        Response.BinaryWrite(ms.ToArray());

        ms.Flush();
        ms.Close();
        Response.End();
    }
}